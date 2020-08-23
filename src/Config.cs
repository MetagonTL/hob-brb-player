using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Hob_BRB_Player
{
    static class Config
    {
        // Fills the config with standard values and saves it to file. However, does not touch Initial Setup values (BRBDirectory, StartPlayerOnDifferentScreen, Chapter), this should be done beforehand
        public static bool GenerateAndSaveStandardConfig()
        {
            PermittedOvertimeMinutes = 2;
            PermittedUndertimePercent = 90;
            AvoidForChaptersAfterPlay = 3;
            PreferredPlayAfterChapters = 100;
            ChaptersHistoryConsidered = 200;
            ReservedChanceForPriorityBRBs = 10;
            SortingMode = BRBPlaylistSortingMode.Interwoven;
            InterBRBCountdown = 10;
            TimeUntilHobbVLC = 30;
            HobbVLCCountdown = 10;
            HobbVLCMaxDuration = 3;
            HobbVLCIgnoreMaxDurationAfterTries = 2;

            return SaveConfig();
        }

        // Loads config from file and resets Test Mode to Disabled
        public static bool LoadConfig()
        {
            try
            {
                FileStream fs = File.Open("config.json", FileMode.Open, FileAccess.Read);
                JsonReader jsonConfig = new JsonTextReader(new StreamReader(fs));

                jsonConfig.Read(); // Comment
                jsonConfig.Read(); // StartObject

                jsonConfig.Read(); // PropertyName
                BRBDirectory = jsonConfig.ReadAsString();
                jsonConfig.Read(); // PropertyName. Etc...
                StartPlayerOnDifferentScreen = (bool)jsonConfig.ReadAsBoolean();
                TestMode = false;
                jsonConfig.Read();
                Chapter = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                StandardPlayerVolume = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                PermittedOvertimeMinutes = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                PermittedUndertimePercent = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                AvoidForChaptersAfterPlay = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                PreferredPlayAfterChapters = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                ChaptersHistoryConsidered = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                ReservedChanceForPriorityBRBs = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                SortingMode = (BRBPlaylistSortingMode)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                InterBRBCountdown = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                TimeUntilHobbVLC = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                HobbVLCCountdown = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                HobbVLCMaxDuration = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                HobbVLCIgnoreMaxDurationAfterTries = (int)jsonConfig.ReadAsInt32();
                // That is all, no need to continue reading

                jsonConfig.Close();
                fs.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }

        // Saves config to file
        public static bool SaveConfig()
        {
            try
            {
                FileStream fs = File.Open("config.json", FileMode.Create, FileAccess.Write);
                JsonWriter jsonConfig = new JsonTextWriter(new StreamWriter(fs));
                jsonConfig.Formatting = Formatting.Indented;

                jsonConfig.WriteComment("DO NOT TOUCH THIS FILE. Only change settings via the application itself. "
                                        + "Otherwise, you might accidentally destroy your configuration, render the video player useless, or cause corruption of BRB statistics.");
                jsonConfig.WriteStartObject();

                jsonConfig.WritePropertyName("BRBDirectory");
                jsonConfig.WriteValue(BRBDirectory);
                jsonConfig.WritePropertyName("StartPlayerOnDifferentScreen");
                jsonConfig.WriteValue(StartPlayerOnDifferentScreen);
                jsonConfig.WritePropertyName("Chapter");
                jsonConfig.WriteValue(Chapter);
                jsonConfig.WritePropertyName("StandardPlayerVolume");
                jsonConfig.WriteValue(StandardPlayerVolume);
                jsonConfig.WritePropertyName("PermittedOvertimeMinutes");
                jsonConfig.WriteValue(PermittedOvertimeMinutes);
                jsonConfig.WritePropertyName("PermittedUndertimePercent");
                jsonConfig.WriteValue(PermittedUndertimePercent);
                jsonConfig.WritePropertyName("AvoidForChaptersAfterPlay");
                jsonConfig.WriteValue(AvoidForChaptersAfterPlay);
                jsonConfig.WritePropertyName("PreferredPlayAfterChapters");
                jsonConfig.WriteValue(PreferredPlayAfterChapters);
                jsonConfig.WritePropertyName("ChaptersHistoryConsidered");
                jsonConfig.WriteValue(ChaptersHistoryConsidered);
                jsonConfig.WritePropertyName("ReservedChanceForPriorityBRBs");
                jsonConfig.WriteValue(ReservedChanceForPriorityBRBs);
                jsonConfig.WritePropertyName("SortingMode");
                jsonConfig.WriteValue((int)SortingMode);
                jsonConfig.WritePropertyName("InterBRBCountdown");
                jsonConfig.WriteValue(InterBRBCountdown);
                jsonConfig.WritePropertyName("TimeUntilHobbVLC");
                jsonConfig.WriteValue(TimeUntilHobbVLC);
                jsonConfig.WritePropertyName("HobbVLCCountdown");
                jsonConfig.WriteValue(HobbVLCCountdown);
                jsonConfig.WritePropertyName("HobbVLCMaxDuration");
                jsonConfig.WriteValue(HobbVLCMaxDuration);
                jsonConfig.WritePropertyName("HobbVLCIgnoreMaxDurationAfterTries");
                jsonConfig.WriteValue(HobbVLCIgnoreMaxDurationAfterTries);

                jsonConfig.WriteEndObject();

                jsonConfig.Close();
                fs.Close();
            }
            catch
            {
                return false;
            }

            return true;
        }

        // Config variables

        // General / Initial Setup
        public static string BRBDirectory { get; set; } // Path of the BRB episodes (video files). Includes backslash at the end of the string
        public static bool StartPlayerOnDifferentScreen { get; set; } // Whether the player form should always try to display on a different screen than the main form
        public static int Chapter { get; set; } // The chapter number of the currently or soon running stream
        public static int StandardPlayerVolume { get; set; } // The volume the player is initially set to when starting the application
        public static bool TestMode { get; set; } // Whether the manager is in "test mode". BRB breaks in this mode will not count towards any statistics. Setting is reset on application startup

        // Generator
        public static int PermittedOvertimeMinutes { get; set; } // How much overtime in minutes the generator is allowed to incur when suggesting a playlist
        public static int PermittedUndertimePercent { get; set; } // How close in percent the generator absolutely needs to get to the target duration
        public static int AvoidForChaptersAfterPlay { get; set; } // For how many chapters a BRB should be avoided after being played (playback chapter included)
        public static int PreferredPlayAfterChapters { get; set; } // When a BRB isn't chosen for that many chapters, it will be played very soon
        public static int ChaptersHistoryConsidered { get; set; } // How many previous chapters should be considered for the statistics
        public static int ReservedChanceForPriorityBRBs { get; set; } // When a BRB is chosen, there should be this chance that it is one of the priority ones, if there are any
        public static BRBPlaylistSortingMode SortingMode { get; set; } // How the generator should sort the playlist at the end. "Interwoven" means long-short-long-short-etc.

        // Playback
        public static int InterBRBCountdown { get; set; } // How long the countdown in InterBRBs should be in seconds
        public static int TimeUntilHobbVLC { get; set; } // How long the end screen should wait in seconds for Hob before engaging hobbVLC mode
        public static int HobbVLCCountdown { get; set; } // How long the countdown in the hobbVLC screen should be in seconds
        public static int HobbVLCMaxDuration { get; set; } // Maximum playtime for a hobbVLC BRB
        public static int HobbVLCIgnoreMaxDurationAfterTries { get; set; } // After this many short hobbVLC videos have been played, allow hobbVLCs of unlimited duration
    }
}
