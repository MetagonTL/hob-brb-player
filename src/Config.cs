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
        public const string Version = "0.3"; // The current app version

        public const int CurrentReleaseChapter = 1714; // When the current app version was released; this is used as the minimum chapter the user can set in the app

        // Fills the config with standard values and saves it to file.
        // However, does not touch Initial Setup values (BRBDirectory, StartPlayerOnDifferentScreen, MakePlayerTopMost, Chapter), this should be done beforehand
        public static bool GenerateAndSaveStandardConfig()
        {
            ConfigVersion = Version;
            PermittedOvertimeMinutes = 2;
            PermittedUndertimePercent = 10;
            AvoidForChaptersAfterPlay = 3;
            PreferredPlayAfterChapters = 100;
            ChapterHistoryConsidered = 200;
            ReservedChanceForPriorityBRBs = 20;
            AutoGuaranteedPlaysForNewBRBs = 1;
            AutoPriorityPlaysForNewBRBs = 3;
            FavouriteMultiplier = 1.5;
            SortingMode = BRBPlaylistSortingMode.Interwoven;
            StandardPlayerVolume = 80;
            InterBRBCountdown = 10;
            TimeUntilHobbVLC = 30;
            HobbVLCCountdown = 10;
            HobbVLCMaxDuration = 2;
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
                ConfigVersion = jsonConfig.ReadAsString();
                jsonConfig.Read(); // PropertyName. Etc...
                BRBDirectory = jsonConfig.ReadAsString();
                jsonConfig.Read();
                StartPlayerOnDifferentScreen = (bool)jsonConfig.ReadAsBoolean();
                jsonConfig.Read();
                MakePlayerTopMost = (bool)jsonConfig.ReadAsBoolean();
                TestMode = false;
                jsonConfig.Read();
                Chapter = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                PermittedOvertimeMinutes = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                PermittedUndertimePercent = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                AvoidForChaptersAfterPlay = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                PreferredPlayAfterChapters = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                ChapterHistoryConsidered = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                ReservedChanceForPriorityBRBs = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                AutoGuaranteedPlaysForNewBRBs = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                AutoPriorityPlaysForNewBRBs = (int)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                FavouriteMultiplier = (double)jsonConfig.ReadAsDouble();
                jsonConfig.Read();
                SortingMode = (BRBPlaylistSortingMode)jsonConfig.ReadAsInt32();
                jsonConfig.Read();
                StandardPlayerVolume = (int)jsonConfig.ReadAsInt32();
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

                jsonConfig.WritePropertyName("ConfigVersion");
                jsonConfig.WriteValue(ConfigVersion);
                jsonConfig.WritePropertyName("BRBDirectory");
                jsonConfig.WriteValue(BRBDirectory);
                jsonConfig.WritePropertyName("StartPlayerOnDifferentScreen");
                jsonConfig.WriteValue(StartPlayerOnDifferentScreen);
                jsonConfig.WritePropertyName("MakePlayerTopMost");
                jsonConfig.WriteValue(MakePlayerTopMost);
                jsonConfig.WritePropertyName("Chapter");
                jsonConfig.WriteValue(Chapter);
                jsonConfig.WritePropertyName("PermittedOvertimeMinutes");
                jsonConfig.WriteValue(PermittedOvertimeMinutes);
                jsonConfig.WritePropertyName("PermittedUndertimePercent");
                jsonConfig.WriteValue(PermittedUndertimePercent);
                jsonConfig.WritePropertyName("AvoidForChaptersAfterPlay");
                jsonConfig.WriteValue(AvoidForChaptersAfterPlay);
                jsonConfig.WritePropertyName("PreferredPlayAfterChapters");
                jsonConfig.WriteValue(PreferredPlayAfterChapters);
                jsonConfig.WritePropertyName("ChapterHistoryConsidered");
                jsonConfig.WriteValue(ChapterHistoryConsidered);
                jsonConfig.WritePropertyName("ReservedChanceForPriorityBRBs");
                jsonConfig.WriteValue(ReservedChanceForPriorityBRBs);
                jsonConfig.WritePropertyName("AutoGuaranteedPlaysForNewBRBs");
                jsonConfig.WriteValue(AutoGuaranteedPlaysForNewBRBs);
                jsonConfig.WritePropertyName("AutoPriorityPlaysForNewBRBs");
                jsonConfig.WriteValue(AutoPriorityPlaysForNewBRBs);
                jsonConfig.WritePropertyName("FavouriteMultiplier");
                jsonConfig.WriteValue(FavouriteMultiplier);
                jsonConfig.WritePropertyName("SortingMode");
                jsonConfig.WriteValue((int)SortingMode);
                jsonConfig.WritePropertyName("StandardPlayerVolume");
                jsonConfig.WriteValue(StandardPlayerVolume);
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

        // Config variables

        // General / Initial Setup
        public static string ConfigVersion { get; private set; } // The version of the app that was used to save the config and BRB info
        public static string BRBDirectory { get; set; } // Path of the BRB episodes (video files)
        public static bool StartPlayerOnDifferentScreen { get; set; } // Whether the player form should always try to display on a different screen than the main form
        public static bool MakePlayerTopMost { get; set; } // Whether the player form should be topmost (for the purpose of display recording)
        public static int Chapter { get; set; } // The chapter number of the currently or soon running stream
        public static bool TestMode { get; set; } // Whether the manager is in "test mode". BRB breaks in this mode will not count towards any statistics. Setting is reset on application startup

        // Generator
        public static int PermittedOvertimeMinutes { get; set; } // How much overtime in minutes the generator is allowed to incur when suggesting a playlist
        public static int PermittedUndertimePercent { get; set; } // How close in percent the generator absolutely needs to get to the target duration
        public static int AvoidForChaptersAfterPlay { get; set; } // For how many chapters a BRB should be avoided after being played (playback chapter included)
        public static int PreferredPlayAfterChapters { get; set; } // When a BRB isn't chosen for that many chapters, it will be played very soon
        public static int ChapterHistoryConsidered { get; set; } // How many previous chapters should be considered for the statistics
        public static int ReservedChanceForPriorityBRBs { get; set; } // When a BRB is chosen, there should be this chance that it is one of the priority ones, if there are any
        public static int AutoGuaranteedPlaysForNewBRBs { get; set; } = 0; // New BRBs automatically get assigned this many "Guaranteed" plays. Initial Setup will use 0 here; this is intended
        public static int AutoPriorityPlaysForNewBRBs { get; set; } = 0; // New BRBs automatically get assigned this many "Priority" plays. Initial Setup will use 0 here; this is intended
        public static double FavouriteMultiplier { get; set; } // If a BRB is marked as favourite, its urgency score is multiplied by this number
        public static BRBPlaylistSortingMode SortingMode { get; set; } // How the generator should sort the playlist at the end. "Interwoven" means long-short-long-short-etc.

        // Playback
        public static int StandardPlayerVolume { get; set; } // The volume the player is initially set to when starting the application
        public static int InterBRBCountdown { get; set; } // How long the countdown in InterBRBs should be in seconds
        public static int TimeUntilHobbVLC { get; set; } // How long the end screen should wait in seconds for Hob before engaging hobbVLC mode
        public static int HobbVLCCountdown { get; set; } // How long the countdown in the hobbVLC screen should be in seconds
        public static int HobbVLCMaxDuration { get; set; } // Maximum playtime for a hobbVLC BRB
        public static int HobbVLCIgnoreMaxDurationAfterTries { get; set; } // After this many short hobbVLC videos have been played, allow hobbVLCs of unlimited duration. Set to -1 to disable.
    }
}
