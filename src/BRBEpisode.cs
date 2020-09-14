using LibVLCSharp.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using WMPLib;

namespace Hob_BRB_Player
{
    [JsonObject(MemberSerialization.OptOut)]
    public class BRBEpisode : IComparable
    {
        //[JsonIgnore] public static WindowsMediaPlayer WMPlayer { get; } = new WindowsMediaPlayer();

        public string Filename { get; private set; }
        public TimeSpan Duration { get; private set; }
        public bool Favourite { get; set; } // Is marked with a star in the BRB list and receives a boost to urgency score
        public string Title { get; set; }
        public string Description { get; set; }
        public string Credits { get; set; }
        public bool IsNew { get; set; } // A BRB is set to New when it is first found in the BRB directory. It is un-set from New once the first non-priority play occurs.
        public List<int> PlaybackChapters { get; } // The chapters should be ordered ascending
        public int GuaranteedPlays { get; set; } // Will be played on the first opportunity this many times
        public int PriorityPlays { get; set; } // Will be played with a certain minimum chance this many times
        [JsonIgnore] public char PriorityChar
        {
            get
            {
                return GuaranteedPlays > 0 ? 'G' : (PriorityPlays > 0 ? 'P' : 'N');
            }
        }
        [JsonIgnore] public int LatestPlaybackChapter
        {
            get
            {
                if (PlaybackChapters.Count == 0)
                {
                    return 0;
                }
                return PlaybackChapters.Last() >= Config.Chapter - Config.ChapterHistoryConsidered ? PlaybackChapters.Last() : 0;
            }
        }
        [JsonIgnore] public int RecentPlaybacks
        {
            get { return PlaybackChapters.Count(c => (c >= Config.Chapter - Config.ChapterHistoryConsidered)); }
        }

        // Constructor for new BRB episodes where the user does not immediately enter information
        public BRBEpisode(string filename)
        {
            Filename = filename;
            Media media = new Media(Program.VLC, new Uri(Path.GetFullPath(Path.Combine(Config.BRBDirectory, filename))));
            Task<MediaParsedStatus> parseTask = media.Parse();
            parseTask.Wait();
            Duration = new TimeSpan(media.Duration > -1 ? media.Duration * TimeSpan.TicksPerMillisecond : 0);
            Favourite = false;
            Title = "";
            Description = "";
            Credits = "";
            IsNew = true;
            PlaybackChapters = new List<int>();
            GuaranteedPlays = Config.AutoGuaranteedPlaysForNewBRBs;
            PriorityPlays = Config.AutoPriorityPlaysForNewBRBs;
        }

        // Constructor for new BRB episodes where the user immediately enters information
        public BRBEpisode(string filename, string title, string description, string credits)
        {
            Filename = filename;
            Media media = new Media(Program.VLC, new Uri(Path.GetFullPath(Path.Combine(Config.BRBDirectory, filename))));
            Task<MediaParsedStatus> parseTask = media.Parse();
            parseTask.Wait();
            Duration = new TimeSpan(media.Duration > -1 ? media.Duration * TimeSpan.TicksPerMillisecond : 0);
            Favourite = false;
            Title = title;
            Description = description;
            Credits = credits;
            IsNew = true;
            PlaybackChapters = new List<int>();
            GuaranteedPlays = Config.AutoGuaranteedPlaysForNewBRBs;
            PriorityPlays = Config.AutoPriorityPlaysForNewBRBs;
        }

        // Constructor for already extant BRB episodes (on application load or information update)
        [JsonConstructor] public BRBEpisode(string filename, TimeSpan duration, bool favourite, string title, string description,
                                            string credits, bool isnew,  List<int> playbackChapters, int guaranteedPlays, int priorityPlays)
        {
            Filename = filename;
            Duration = duration;
            Favourite = favourite;
            Title = title;
            Description = description;
            Credits = credits;
            IsNew = isnew;
            PlaybackChapters = playbackChapters;
            GuaranteedPlays = guaranteedPlays;
            PriorityPlays = priorityPlays;
        }

        public void RefreshDuration()
        {
            Media media = new Media(Program.VLC, new Uri(Path.GetFullPath(Path.Combine(Config.BRBDirectory, Filename))));
            Task<MediaParsedStatus> parseTask = media.Parse();
            parseTask.Wait();
            Duration = new TimeSpan(media.Duration > -1 ? media.Duration * TimeSpan.TicksPerMillisecond : 0);
        }

        public bool Rename(string newFilename, bool renameOnDisk)
        {
            // Failsafe so BRB episodes do not get into the system twice, but this should never trigger
            if (File.Exists(Path.Combine(Config.BRBDirectory, newFilename)))
            {
                return false;
            }
            foreach (BRBEpisode ep in BRBManager.BRBEpisodes)
            {
                if (ep.Filename == newFilename)
                {
                    return false;
                }
            }

            try
            {
                if (renameOnDisk)
                {
                    File.Move(Path.Combine(Config.BRBDirectory, Filename), Path.Combine(Config.BRBDirectory, newFilename));
                }
                Filename = newFilename;
                BRBManager.BRBEpisodes.Sort();
                BRBManager.RefreshAvailableList();

                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }

        // This is the same urgency score as in the BRB Excel Masterlist, calculated exactly the same way (except for the ability to mark favorites)
        public int GetUrgencyScore()
        {
            double vanillaScore;
            if (LatestPlaybackChapter == 0)
            {
                vanillaScore = 1000.0;
            }
            else
            {
                double rec = RecentPlaybacks;
                double lat = LatestPlaybackChapter;
                double par = Config.ChapterHistoryConsidered / 20.0;
                if (lat == Config.Chapter)
                {
                    if (rec <= 10)
                    {
                        vanillaScore = Math.Round(400.0 / (1 + Math.Pow(rec / par, 3)));
                    }
                    else
                    {
                        vanillaScore = Math.Round(400.0 / (1 + Math.Pow(rec / par, 6)));
                    }
                }
                else
                {
                    if (rec <= 10)
                    {
                        vanillaScore = Math.Round(400.0 / (1 + Math.Pow(rec / par, 3)) + 600.0 / (1 + Math.Pow(20.0 / (Config.Chapter - lat), 3)));
                    }
                    else
                    {
                        vanillaScore = Math.Round(400.0 / (1 + Math.Pow(rec / par, 6)) + 600.0 / (1 + Math.Pow(20.0 / (Config.Chapter - lat), 3)));
                    }
                }
            }

            return (int)Math.Round(Math.Min(vanillaScore * (Favourite ? Config.FavouriteMultiplier : 1.0), 1000.0));
        }
        
        // The urgency score is divided by 100 and rounded up to yield its weight used in choosing a BRB at random
        public int GetWeight()
        {
            return Math.Max((int)Math.Ceiling(GetUrgencyScore() / 100.0), 1);
        }
        
        public bool ContainsTextAtField(string search, int field)
        {
            switch (field)
            {
                case 0:
                default:
                    return ContainsText(search);
                case 1:
                    return Filename.ToLower().Contains(search.ToLower());
                case 2:
                    return Title.ToLower().Contains(search.ToLower());
                case 3:
                    return Credits.ToLower().Contains(search.ToLower());
                case 4:
                    return Description.ToLower().Contains(search.ToLower());
            }
        }

        public bool ContainsText(string search)
        {
            return Filename.ToLower().Contains(search.ToLower())
                || Title.ToLower().Contains(search.ToLower())
                || Credits.ToLower().Contains(search.ToLower())
                || Description.ToLower().Contains(search.ToLower());
        }

        public override bool Equals(object obj)
        {
            if (obj is BRBEpisode episode)
            {
                return Filename == episode.Filename;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return 1488168680 + EqualityComparer<string>.Default.GetHashCode(Filename);
        }

        public int CompareTo(object obj)
        {
            return Filename.CompareTo(((BRBEpisode)obj).Filename);
        }
    }
}
