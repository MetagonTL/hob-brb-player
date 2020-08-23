using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hob_BRB_Player
{
    static class BRBManager
    {
        public static List<BRBEpisode> BRBEpisodes { get; private set; } = new List<BRBEpisode>();

        public static bool LoadEpisodes()
        {
            try
            {
                if (File.Exists("brbepisodes.json"))
                {
                    string serializedBRBList = File.ReadAllText("brbepisodes.json");
                    BRBEpisodes = JsonConvert.DeserializeObject<List<BRBEpisode>>(serializedBRBList);
                }
            }
            catch
            {
                return false;
            }

            foreach (BRBEpisode ep in BRBEpisodes)
            {
                // Sacrifice some time to sort BRB playbacks ascending, just in case
                ep.PlaybackChapters.Sort();
            }

            return true;
        }

        public static bool SaveEpisodes()
        {
            try
            {
                string serializedBRBList = JsonConvert.SerializeObject(BRBEpisodes, Formatting.Indented);
                File.WriteAllText("brbepisodes.json", serializedBRBList);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static BRBEpisode GetEpisode(string filename)
        {
            return BRBEpisodes.FirstOrDefault(ep => ep.Filename == filename);
        }

        // Generates a playlist. For the overall duration, InterBRB times are taken into account
        public static List<BRBEpisode> GeneratePlaylist(TimeSpan minDuration, TimeSpan targetDuration, TimeSpan maxDuration, ref List<string> refAddReason)
        {
            List<BRBEpisode> playlist = GeneratePlaylist(minDuration, targetDuration, maxDuration, true, ref refAddReason);
            if (playlist == null)
            {
                playlist = GeneratePlaylist(minDuration, targetDuration, maxDuration, false, ref refAddReason); // If this is also is null, then it is likely the time conditions are too strict
            }
            return playlist;
        }
            
        private static List<BRBEpisode> GeneratePlaylist(TimeSpan minDuration, TimeSpan targetDuration, TimeSpan maxDuration, bool replayAvoidance, ref List<string> refAddReason)
        {
            List<BRBEpisode> playlist = new List<BRBEpisode>();
            TimeSpan duration = new TimeSpan(0);
            TimeSpan constInterBRBTimeSpan = new TimeSpan((long)((Config.InterBRBCountdown + 0.1) * TimeSpan.TicksPerSecond));

            List<BRBEpisode> remDataset = new List<BRBEpisode>(BRBEpisodes);

            // First, consider BRBs marked "Guaranteed" (that is, "play ASAP"). Fill as much of the playlist with them as possible, ignoring Replay Avoidance
            List<BRBEpisode> guaranteedEpisodes = remDataset.FindAll(e => e.GuaranteedPlays > 0 && e.Duration + constInterBRBTimeSpan <= maxDuration - duration);
            while (guaranteedEpisodes.Count > 0 && duration < targetDuration)
            {
                BRBEpisode episode = GetWeightedRandomBRBFrom(guaranteedEpisodes);
                playlist.Add(episode);
                refAddReason.Add("Guaranteed");
                duration += episode.Duration + constInterBRBTimeSpan;
                remDataset.Remove(episode);
                guaranteedEpisodes.Remove(episode);
                guaranteedEpisodes = guaranteedEpisodes.FindAll(e => e.GuaranteedPlays > 0 && e.Duration + constInterBRBTimeSpan <= maxDuration - duration);
            }
            remDataset = remDataset.FindAll(e => e.Duration + constInterBRBTimeSpan <= maxDuration - duration);

            // From now on, ignore all BRBs affected by Replay Avoidance
            if (replayAvoidance)
            {
                remDataset = remDataset.FindAll(e => Config.Chapter - e.LatestPlaybackChapter >= Config.AvoidForChaptersAfterPlay);
            }

            // Choose one BRB marked "Priority", if there are any
            List<BRBEpisode> priorityEpisodes = remDataset.FindAll(e => e.PriorityPlays > 0);
            if (priorityEpisodes.Count > 0 && duration < targetDuration)
            {
                BRBEpisode episode = GetWeightedRandomBRBFrom(priorityEpisodes);
                playlist.Add(episode);
                refAddReason.Add("Priority");
                duration += episode.Duration + constInterBRBTimeSpan;
                remDataset.Remove(episode);
                remDataset = remDataset.FindAll(e => e.Duration + constInterBRBTimeSpan <= maxDuration - duration);
            }

            // Choose one BRB that hasn't been played in forever, if there are any
            List<BRBEpisode> preferredEpisodes = remDataset.FindAll(e => e.LatestPlaybackChapter <= Config.Chapter - Config.PreferredPlayAfterChapters);
            if (preferredEpisodes.Count > 0 && duration < targetDuration)
            {
                BRBEpisode episode = GetWeightedRandomBRBFrom(preferredEpisodes);
                playlist.Add(episode);
                refAddReason.Add("Distance");
                duration += episode.Duration + constInterBRBTimeSpan;
                remDataset.Remove(episode);
                remDataset = remDataset.FindAll(e => e.Duration + constInterBRBTimeSpan <= maxDuration - duration);
            }

            // Now, fill up the rest of the playlist
            while (remDataset.Count > 0 && duration < targetDuration)
            {
                BRBEpisode episode = GetWeightedRandomBRBFrom(remDataset);
                playlist.Add(episode);
                refAddReason.Add("Random");
                duration += episode.Duration + constInterBRBTimeSpan;
                remDataset.Remove(episode);
                remDataset = remDataset.FindAll(e => e.Duration + constInterBRBTimeSpan <= maxDuration - duration);
            }

            // Check whether minimum duration is satisfied. If yes, finding a playlist was successful. If not, the algorithm failed
            if (duration < minDuration)
            {
                return null;
            }

            playlist = SortPlaylist(playlist, ref refAddReason);

            return playlist;
        }

        private class BRBEpisodeDurationComparer : IComparer<BRBEpisode>
        {
            public int Compare(BRBEpisode x, BRBEpisode y)
            {
                if (x.Duration.Equals(y.Duration))
                {
                    return 0;
                }
                return x.Duration < y.Duration ? -1 : 1;
            }
        }

        private static List<BRBEpisode> SortPlaylist(List<BRBEpisode> playlist, ref List<string> refAddReason)
        {
            List<BRBEpisode> playlistCopy = new List<BRBEpisode>(playlist);
            List<BRBEpisode> sorted = new List<BRBEpisode>();

            List<string> addReasonSorted = new List<string>();

            if (Config.SortingMode == BRBPlaylistSortingMode.Random)
            {
                Random rand = new Random();
                int index;
                while (playlistCopy.Count > 0)
                {
                    index = rand.Next(0, playlistCopy.Count - 1);
                    sorted.Add(playlistCopy[index]);
                    playlistCopy.Remove(playlistCopy[index]);
                }
            }

            playlistCopy.Sort(new BRBEpisodeDurationComparer());

            switch (Config.SortingMode)
            {
                case BRBPlaylistSortingMode.ShortToLong:
                    sorted = playlistCopy;
                    break;

                case BRBPlaylistSortingMode.LongToShort:
                    playlistCopy.Reverse();
                    sorted = playlistCopy;
                    break;

                case BRBPlaylistSortingMode.Interwoven:
                    if (playlistCopy.Count % 2 == 0)
                    {
                        for (int i = 0; i < playlistCopy.Count / 2 - 1; i++)
                        {
                            sorted.Add(playlistCopy[playlistCopy.Count - 1 - i]);
                            sorted.Add(playlistCopy[playlistCopy.Count / 2 - 1 - i]);
                        }
                        sorted.Add(playlistCopy[0]);
                        sorted.Add(playlistCopy[playlistCopy.Count / 2]);
                    }
                    else
                    {
                        for (int i = 0; i < (playlistCopy.Count - 1) / 2; i++)
                        {
                            sorted.Add(playlistCopy[playlistCopy.Count - 1 - i]);
                            sorted.Add(playlistCopy[(playlistCopy.Count - 1) / 2 - 1 - i]);
                        }
                        sorted.Add(playlistCopy[(playlistCopy.Count + 1) / 2 - 1]);
                    }
                    break;
            }

            for (int i = 0; i < sorted.Count; i++)
            {
                addReasonSorted.Add(refAddReason[playlist.IndexOf(sorted[i])]);
            }
            refAddReason = addReasonSorted;
            return sorted;
        }

        // Returns a (weighted) random BRB. If the return value is null, it means there is no BRB fitting the criteria given. Use maxDuration = null for unlimited duration
        public static BRBEpisode GetRandomBRBEpisode(TimeSpan? maxDuration, bool replayAvoidance)
        {
            return GetRandomBRBEpisode(maxDuration, replayAvoidance, new List<BRBEpisode>());
        }

        public static BRBEpisode GetRandomBRBEpisode(TimeSpan? maxDuration, bool replayAvoidance, List<BRBEpisode> episodesToAvoidAdditionally)
        {
            List<BRBEpisode> dataset = new List<BRBEpisode>();

            foreach (BRBEpisode ep in BRBEpisodes)
            {
                if (maxDuration != null && ep.Duration >= maxDuration)
                {
                    continue;
                }
                if (replayAvoidance && Config.Chapter - ep.LatestPlaybackChapter < Config.AvoidForChaptersAfterPlay)
                {
                    continue;
                }
                if (episodesToAvoidAdditionally.Contains(ep))
                {
                    continue;
                }
                dataset.Add(ep);
            }

            if (dataset.Count == 0)
            {
                return null;
            }
            return GetWeightedRandomBRBFrom(dataset);
        }

        // For internal use only; does not filter in any way
        private static BRBEpisode GetWeightedRandomBRBFrom(List<BRBEpisode> dataset)
        {
            List<string> weightedFilenameList = new List<string>();
            weightedFilenameList.Capacity = dataset.Count * 10;

            foreach (BRBEpisode ep in dataset)
            {
                for (int i = 0; i < ep.GetWeight(); i++)
                {
                    weightedFilenameList.Add(ep.Filename);
                }
            }

            Random rand = new Random();
            int randomIndex = rand.Next(0, weightedFilenameList.Count - 1);

            return GetEpisode(weightedFilenameList[randomIndex]);
        }

        // Adds the playback to the episode data. Only episode instances from BRBEpisodes should be used here
        public static void OnPlayedBack(BRBEpisode episode)
        {
            if (BRBEpisodes.Contains(episode))
            {
                episode.PlaybackChapters.Add(Config.Chapter);
                if (episode.GuaranteedPlays > 0)
                {
                    episode.GuaranteedPlays--;
                }
                else if (episode.PriorityPlays > 0)
                {
                    episode.PriorityPlays--;
                }
            }
            Program.MainForm.UpdateBRBData();
        }

        public static string TimeSpanToMMSS(TimeSpan span)
        {
            return ((int)Math.Floor(span.TotalMinutes)).ToString("D2") + ":" + span.Seconds.ToString("D2");
        }
    }
}
