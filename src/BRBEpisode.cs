using LibVLCSharp.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hob_BRB_Player
{
    [JsonObject(MemberSerialization.OptOut)]
    public class BRBEpisode : IComparable
    {
        public struct AutoMuteSpan : IComparable
        {
            public TimeSpan Begin;
            public TimeSpan End;
            public string Info;
            public bool Enabled;

            public AutoMuteSpan(TimeSpan begin, TimeSpan end, string info, bool enabled)
            {
                Begin = begin;
                End = end;
                Info = info;
                Enabled = enabled;
            }

            // It is the job of FormAutoMuteData to ensure no two identical spans end up in the system
            public int CompareTo(object obj)
            {
                AutoMuteSpan other = (AutoMuteSpan)obj;

                if (!Begin.Equals(other.Begin))
                {
                    return Begin.CompareTo(other.Begin);
                }
                else if (!End.Equals(other.End))
                {
                    return End.CompareTo(other.End);
                }
                else
                {
                    return Info.CompareTo(other.Info);
                }
            }
        }

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
        public List<AutoMuteSpan> AutoMutes { get; private set; } // The player can automatically mute the BRB at these times (for instance, to avoid DMCA takedowns)
        public bool AutoMuteEnabled { get; set; } // Whether the player should do AutoMute for this BRB

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

        // Constructor for new BRB episodes
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
            AutoMutes = new List<AutoMuteSpan>();
            AutoMuteEnabled = false;
        }

        // Constructor for already extant BRB episodes (on application load or information update)
        [JsonConstructor] public BRBEpisode(string filename, TimeSpan duration, bool favourite, string title, string description,
                                            string credits, bool isnew, List<int> playbackChapters, int guaranteedPlays, int priorityPlays,
                                            List<AutoMuteSpan> autoMutes, bool autoMuteEnabled)
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
            AutoMutes = (autoMutes == null ? new List<AutoMuteSpan>() : autoMutes);
            // TEMP
            //if (Filename == "A Fume Knight Fight.mkv")
            //{
            //    AutoMutes.Add(new AutoMuteSpan(new TimeSpan(1704 * TimeSpan.TicksPerMillisecond), new TimeSpan(2503 * TimeSpan.TicksPerMillisecond), "Test by Band\r\nMuted etc.", true));
            //    AutoMutes.Add(new AutoMuteSpan(new TimeSpan(61003 * TimeSpan.TicksPerMillisecond), new TimeSpan(69003 * TimeSpan.TicksPerMillisecond), "Test2 by Band\r\nMuted etc.", false));
            //}
            AutoMuteEnabled = autoMuteEnabled;
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

        public bool ShouldMuteAt(TimeSpan time)
        {
            if (!AutoMuteEnabled)
            {
                return false;
            }

            foreach (AutoMuteSpan span in AutoMutes)
            {
                if (span.Begin <= time && time <= span.End && span.Enabled)
                {
                    return true;
                }
            }

            return false;
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
