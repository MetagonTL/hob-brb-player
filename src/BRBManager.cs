using LibVLCSharp.Shared;
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
        public static List<BRBEpisode> AvailableBRBEpisodes { get; private set; }

        public static bool LoadEpisodes()
        {
            try
            {
                if (File.Exists("brbepisodes.json"))
                {
                    string serializedBRBList = File.ReadAllText("brbepisodes.json");
                    BRBEpisodes = JsonConvert.DeserializeObject<List<BRBEpisode>>(serializedBRBList);
                }

                foreach (BRBEpisode ep in BRBEpisodes)
                {
                    // Sacrifice some time to sort BRB playbacks ascending, just in case
                    ep.PlaybackChapters.Sort();
                }

                BRBEpisodes.Sort();

                RefreshAvailableList();

                return true;
            }
            catch (IOException)
            {
                return false;
            }
            catch (JsonException)
            {
                return false;
            }
        }

        public static bool SaveEpisodes()
        {
            try
            {
                string serializedBRBList = JsonConvert.SerializeObject(BRBEpisodes, Formatting.Indented);
                File.WriteAllText("brbepisodes.json", serializedBRBList);

                return true;
            }
            catch (IOException)
            {
                return false;
            }
            catch (JsonException)
            {
                return false;
            }
        }

        public static void RefreshAvailableList()
        {
            AvailableBRBEpisodes = new List<BRBEpisode>();

            foreach (BRBEpisode ep in BRBEpisodes)
            {
                if (File.Exists(Path.Combine(Config.BRBDirectory, ep.Filename)))
                {
                    AvailableBRBEpisodes.Add(ep);
                }
            }
        }

        public static List<string> GetBRBFilenameList()
        {
            List<string> list = new List<string>();
            foreach (BRBEpisode ep in BRBEpisodes)
            {
                list.Add(ep.Filename);
            }
            return list;
        }

        public static BRBEpisode GetEpisode(string filename)
        {
            return BRBEpisodes.FirstOrDefault(ep => ep.Filename == filename);
        }

        public static bool RegisterNewBRB(string filename)
        {
            // Failsafe so BRB episodes do not get into the system twice, but this should never trigger
            foreach (BRBEpisode ep in BRBEpisodes)
            {
                if (ep.Filename == filename)
                {
                    return false;
                }
            }

            try
            {
                BRBEpisode newEpisode = new BRBEpisode(filename);
                if (newEpisode.Duration.Ticks > 0)
                {
                    BRBEpisodes.Add(new BRBEpisode(filename));
                    BRBEpisodes.Sort();
                    RefreshAvailableList();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return false;
            }
            catch (VLCException)
            {
                return false;
            }
        }

        // Update the filename of a BRB episode, without considering anything else (for instance, when user updates a BRB to its new filename)
        public static bool TransferToNewFilename(BRBEpisode episode, string newFilename, bool removeOldEpisode)
        {
            BRBEpisode newEpisodeVersion = new BRBEpisode(newFilename, episode.Duration, episode.Favourite, episode.Title,
                                                          episode.Description, episode.Credits, episode.IsNew, episode.PlaybackChapters,
                                                          episode.GuaranteedPlays, episode.PriorityPlays);
            newEpisodeVersion.RefreshDuration();

            // Make sure the episode's video file is understood by the application
            if (newEpisodeVersion.Duration.Ticks == 0)
            {
                return false;
            }

            if (removeOldEpisode)
            {
                BRBEpisodes.Remove(episode);
            }
            BRBEpisodes.Add(newEpisodeVersion);
            BRBEpisodes.Sort();
            return true;
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
            Random rand = new Random();

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

            // Now, fill up the rest of the playlist. Use the minimum chance from the config for Priority BRBs
            List<BRBEpisode> remPriorityEpisodes;

            while (remDataset.Count > 0 && duration < targetDuration)
            {
                remPriorityEpisodes = remDataset.FindAll(e => e.PriorityPlays > 0);
                BRBEpisode episode;
                // Since the Priority chance is an integer percentage, one can use a random integer here
                if (remPriorityEpisodes.Count > 0 && rand.Next(1, 100) <= Config.ReservedChanceForPriorityBRBs)
                {
                    episode = GetWeightedRandomBRBFrom(remPriorityEpisodes);
                    refAddReason.Add("Priority");
                }
                else
                {
                    episode = GetWeightedRandomBRBFrom(remDataset);
                    refAddReason.Add("Random");
                }
                playlist.Add(episode);
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
                int weight = ep.GetWeight();
                for (int i = 0; i < weight; i++)
                {
                    weightedFilenameList.Add(ep.Filename);
                }
            }

            Random rand = new Random();
            int randomIndex = rand.Next(0, weightedFilenameList.Count);

            return GetEpisode(weightedFilenameList[randomIndex]);
        }

        // Adds the playback to the episode data
        public static void OnPlayedBack(BRBEpisode episode)
        {
            if (Config.TestMode)
            {
                // In Test Mode, save no playback data
                return;
            }

            episode.PlaybackChapters.Add(Config.Chapter);

            if (episode.GuaranteedPlays > 0)
            {
                episode.GuaranteedPlays--;
            }
            else if (episode.PriorityPlays > 0)
            {
                episode.PriorityPlays--;
            }
            else
            {
                episode.IsNew = false; // Non-priority playback, the episode is no longer "new"
            }

            SaveEpisodes(); // Suppress warnings here. A last save is performed on exiting the player window; if saving still doesn't work there, then inform the user
            Program.MainForm.UpdateBRBData();
        }

        public static string TimeSpanToMMSS(TimeSpan span)
        {
            return ((int)Math.Floor(span.TotalMinutes)).ToString("D2") + ":" + span.Seconds.ToString("D2");
        }
    }
}
