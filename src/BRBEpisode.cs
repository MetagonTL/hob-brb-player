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
    public class BRBEpisode
    {
        //[JsonIgnore] public static WindowsMediaPlayer WMPlayer { get; } = new WindowsMediaPlayer();

        public string Filename { get; private set; }
        public TimeSpan Duration { get; private set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Credits { get; set; }
        public List<int> PlaybackChapters { get; } // The chapters should be ordered ascending
        public int GuaranteedPlays { get; set; } // Will be played on the first opportunity this many times
        public int PriorityPlays { get; set; } // Will be played with a certain minimum chance this many times
        public char PriorityChar
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
                return PlaybackChapters.Last() >= Config.Chapter - Config.ChaptersHistoryConsidered ? PlaybackChapters.Last() : 0;
            }
        }
        [JsonIgnore] public int RecentPlaybacks
        {
            get { return PlaybackChapters.Count(c => (c >= Config.Chapter - Config.ChaptersHistoryConsidered)); }
        }

        // Constructor for new BRB episodes where the user does not immediately enter information
        public BRBEpisode(string filename)
        {
            Filename = filename;
            Media media = new Media(Program.VLC, new Uri(Path.Combine(Config.BRBDirectory, filename)));
            Duration = new TimeSpan(media.Duration > -1 ? media.Duration * TimeSpan.TicksPerMillisecond : 0);
            Name = "";
            Description = "";
            Credits = "";
            PlaybackChapters = new List<int>();
            GuaranteedPlays = 0;
            PriorityPlays = 0;
        }

        // Constructor for new BRB episodes where the user immediately enters information
        public BRBEpisode(string filename, string name, string description, string credits)
        {
            Filename = filename;
            Media media = new Media(Program.VLC, new Uri(Path.Combine(Config.BRBDirectory, filename)));
            Duration = new TimeSpan(media.Duration > -1 ? media.Duration * TimeSpan.TicksPerMillisecond : 0);
            Name = name;
            Description = description;
            Credits = credits;
            PlaybackChapters = new List<int>();
            GuaranteedPlays = 0;
            PriorityPlays = 0;
        }

        // Constructor for already extant BRB episodes (on application load or information update)
        [JsonConstructor] public BRBEpisode(string filename, TimeSpan duration, string name, string description, string credits, List<int> playbackChapters, int guaranteedPlays, int priorityPlays)
        {
            Filename = filename;
            Duration = duration;
            Name = name;
            Description = description;
            Credits = credits;
            PlaybackChapters = playbackChapters;
            GuaranteedPlays = guaranteedPlays;
            PriorityPlays = priorityPlays;
        }

        public void RefreshDuration()
        {
            Media media = new Media(Program.VLC, new Uri(Path.Combine(Config.BRBDirectory, Filename)));
            Duration = new TimeSpan(media.Duration > -1 ? media.Duration * TimeSpan.TicksPerMillisecond : 0);
        }

        public bool Rename(string newFilename)
        {
            if (File.Exists(Path.Combine(Config.BRBDirectory, newFilename)))
            {
                return false;
            }
            try
            {
                File.Move(Path.Combine(Config.BRBDirectory, Filename), Path.Combine(Config.BRBDirectory, newFilename));
                Filename = newFilename;
            }
            catch
            {
                return false;
            }
            return true;
        }

        // This is the same urgency score as in the BRB Excel Masterlist, calculated exactly the same way
        public int GetUrgencyScore()
        {
            if (LatestPlaybackChapter == 0)
            {
                return 1000;
            }
            double rec = RecentPlaybacks;
            double lat = LatestPlaybackChapter;
            double par = Config.ChaptersHistoryConsidered / 20.0;
            if (lat == Config.Chapter)
            {
                if (rec <= 10)
                {
                    return (int)Math.Round(400.0 / (1 + Math.Pow(rec / par, 3)));
                }
                else
                {
                    return (int)Math.Round(400.0 / (1 + Math.Pow(rec / par, 6)));
                }
            }
            else
            {
                if (rec <= 10)
                {
                    return (int)Math.Round(400.0 / (1 + Math.Pow(rec / par, 3)) + 600.0 / (1 + Math.Pow(20.0 / (Config.Chapter - lat), 3)));
                }
                else
                {
                    return (int)Math.Round(400.0 / (1 + Math.Pow(rec / par, 6)) + 600.0 / (1 + Math.Pow(20.0 / (Config.Chapter - lat), 3)));
                }
            }
        }
        
        // The urgency score is divided by 100 and rounded up to yield its weight used in choosing a BRB at random
        public int GetWeight()
        {
            return Math.Max((int)Math.Ceiling(GetUrgencyScore() / 100.0), 1);
        }

        public override bool Equals(object obj)
        {
            if (obj is BRBEpisode)
            {
                return Filename == ((BRBEpisode)obj).Filename;
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
    }
}
