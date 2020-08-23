﻿//using AxWMPLib;
using LibVLCSharp;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using WMPLib;

namespace Hob_BRB_Player
{
    public partial class FormPlayer : Form
    {
        public bool Paused { get; private set; } = false;
        public BRBPlayerState PlayerState { get; private set; } = BRBPlayerState.Undefined;
		public int HobbVLCsTriggered { get; private set; } = 0;
        private double secondCountdown;
		public double RemSecsInCurrentInterBRB
        {
			get
            {
				if (PlayerState == BRBPlayerState.InBetweenBRBs || PlayerState == BRBPlayerState.HobbVLC)
                {
					return secondCountdown;
                }
				else if (PlayerState == BRBPlayerState.BeginningOfBreak)
                {
					return Config.InterBRBCountdown;
                }
				else
                {
					return 0;
                }
            }
        }
		public double RemSecsInCurrentBRB
        {
			get
            {
				if (PlayerState == BRBPlayerState.Playback)
				{
					return NextOrCurrentBRB.Duration.TotalSeconds - VLCPlayer.Position * (double)VLCPlayer.Length / 1000.0;
				}
				else if (PlayerState == BRBPlayerState.InBetweenBRBs || PlayerState == BRBPlayerState.BeginningOfBreak || PlayerState == BRBPlayerState.HobbVLC)
				{
					return NextOrCurrentBRB.Duration.TotalSeconds;
				}
				else
                {
					return 0;
                }
			}
        }

        public int NextOrCurrentBRBIndex { get; private set; }

        public List<BRBEpisode> BRBPlaylist { get; private set; }

		// Called by control form if the playlist is changed during playback. The control form ensures only future BRB videos are changed
		public void UpdateBRBPlaylist(List<BRBEpisode> newPlaylist)
        {
			BRBPlaylist = newPlaylist;
        }

		// Called by control form if a new episode is added during playback (which may be done manually or triggered by HobbVLC)
		public void AppendBRB(BRBEpisode episode)
        {
			BRBPlaylist.Add(episode);
			if (PlayerState == BRBPlayerState‌.EndOfBreak)
            {
				// Episode was added manually at end of break. Automatically play this new BRB
				ChangePlayerState(BRBPlayerState.InBetweenBRBs);
				UnpauseAndHideControls();
			}
        }

		public BRBEpisode NextOrCurrentBRB
		{
			get { return BRBPlaylist[NextOrCurrentBRBIndex]; }
		}

		//public AxWindowsMediaPlayer WMPlayer
		//{
		//	get { return axWMPlayer; }
		//}
		public MediaPlayer VLCPlayer { get; }

		private long lastScrubUpdateTicks = 0;

		// Should never be called
		public FormPlayer()
        {
			InitializeComponent();
			// Make sure "PAUSED" is centered properly
			Rectangle oldbounds = pnlPaused.Bounds;
			pnlPaused.SetBounds(Screen.FromControl(this).Bounds.Width / 2 - pnlPaused.Width / 2, oldbounds.Y, oldbounds.Width, oldbounds.Height);

			// Load the VLC media player in for convenience
			VLCPlayer = Program.VLCPlayer;
			videoView.MediaPlayer = VLCPlayer;

			LoadIcons();

			BRBPlaylist = new List<BRBEpisode>();
		}

		private void LoadIcons()
		{
			btnConfirmBRBPlayback.Image = Image.FromFile("icons\\checklistok.png");
			btnSwitchScreen.Image = Image.FromFile("icons\\switchscreen.png");
			btnFinishBRBPlayback.Image = Image‌.FromFile("icons\\closeplayer.png");
			picHobbVLC.Image = new Bitmap(Image.FromFile("images\\hobEmotes\\hobbVLC.png"), 100, 100);
		}

		public FormPlayer(List<BRBEpisode> brbsToPlay)
		{
			InitializeComponent();
			ReCenterControls();

			// Load the VLC media player in for convenience
			VLCPlayer = Program.VLCPlayer;
			videoView.MediaPlayer = VLCPlayer;

			LoadIcons();

			BRBPlaylist = brbsToPlay;
        }

		public void ReCenterControls()
        {
			// Make sure "PAUSED" is centered properly
			Rectangle oldbounds = pnlPaused.Bounds;
			pnlPaused.SetBounds(Screen.FromControl(this).Bounds.Width / 2 - pnlPaused.Width / 2, oldbounds.Y, oldbounds.Width, oldbounds.Height);

			oldbounds = pnlUIPreBRB.Bounds;
			pnlUIPreBRB.SetBounds(0, Screen.FromControl(this).Bounds.Height / 2 - pnlUIPreBRB.Height / 2, Screen.FromControl(this).Bounds.Width, oldbounds.Height);
			oldbounds = pnlUIInterBRB.Bounds;
			pnlUIInterBRB.SetBounds(0, Screen.FromControl(this).Bounds.Height / 2 - pnlUIInterBRB.Height / 2, Screen.FromControl(this).Bounds.Width, oldbounds.Height);
			oldbounds = pnlUIPostBRB.Bounds;
			pnlUIPostBRB.SetBounds(0, Screen.FromControl(this).Bounds.Height / 2 - pnlUIPostBRB.Height / 2, Screen.FromControl(this).Bounds.Width, oldbounds.Height);
			oldbounds = pnlUIHobbVLC.Bounds;
			pnlUIHobbVLC.SetBounds(0, Screen.FromControl(this).Bounds.Height / 2 - pnlUIHobbVLC.Height / 2, Screen.FromControl(this).Bounds.Width, oldbounds.Height);
			oldbounds = pnlUIError.Bounds;
			pnlUIError.SetBounds(0, Screen.FromControl(this).Bounds.Height / 2 - pnlUIError.Height / 2, Screen.FromControl(this).Bounds.Width, oldbounds.Height);
		}

        private void FormPlayer_Shown(object sender, EventArgs e)
        {
			// Configure player to be quasi-fullscreen and difficult to involuntarily disrupt

			/*WMPlayer.uiMode = "none";
			WMPlayer.enableContextMenu = false;
			WMPlayer.windowlessVideo = true;
			WMPlayer.Ctlenabled = false;
			WMPlayer.stretchToFit = true;

			WMPlayer.settings.autoStart = false;
			WMPlayer.settings.enableErrorDialogs = false;*/

			ChangePlayerState(BRBPlayerState.BeginningOfBreak);
		}

        // This method is called every 1/10 second. Depending on BRB stage, handle countdown timer or activate the next stage
        private void tmrTenthSecond_Tick(object sender, EventArgs e)
		{
			switch (PlayerState)
            {
				case BRBPlayerState.InBetweenBRBs:
					if (secondCountdown <= 0)
					{
						ChangePlayerState(BRBPlayerState.Playback);
					}
					else
                    {
						secondCountdown -= 0.1;
						dispNextBRBName.Text = NextOrCurrentBRB.Name != "" ? NextOrCurrentBRB.Name : NextOrCurrentBRB.Filename;
						dispCountdown.Text = ((int)Math.Ceiling(secondCountdown)).ToString();
					}
					break;

				case BRBPlayerState.EndOfBreak:
					if (secondCountdown <= 0)
					{
						ChangePlayerState(BRBPlayerState.HobbVLC);
					}
					else
                    {
						secondCountdown -= 0.1;
                    }
					break;

				case BRBPlayerState.HobbVLC:
					if (secondCountdown <= 0)
					{
						ChangePlayerState(BRBPlayerState.Playback);
					}
					else
					{
						secondCountdown -= 0.1;
						dispNextBRBNameHobbVLC.Text = NextOrCurrentBRB.Name != "" ? NextOrCurrentBRB.Name : NextOrCurrentBRB.Filename;
						dispCountdownHobbVLC.Text = ((int)Math.Ceiling(secondCountdown)).ToString();
					}
					break;
			}
		}

		// Gives an approximation of how much time there is left in the break
		public TimeSpan GetRemainingBreakTime()
        {
			double remSecsBRBPlaytime = RemSecsInCurrentBRB;
			double remSecsInterBRBs = RemSecsInCurrentInterBRB;
			double remSecsPostScreen = PlayerState == BRBPlayerState.EndOfBreak ? secondCountdown : Config.TimeUntilHobbVLC;
			for (int i = NextOrCurrentBRBIndex + 1; i < BRBPlaylist.Count; i++)
			{
				remSecsInterBRBs += Config.InterBRBCountdown + 0.1;
				remSecsBRBPlaytime += BRBPlaylist[i].Duration.TotalSeconds;
			}
			return new TimeSpan((long)((remSecsBRBPlaytime + remSecsInterBRBs + remSecsPostScreen) * TimeSpan.TicksPerSecond));
		}
		
		// Handles activation of the next stage when a BRB video finished playing, and registers BRB as played
		public void OnMediaEndReached(object sender, EventArgs e)
		{
			BRBManager.OnPlayedBack(NextOrCurrentBRB);

			NextOrCurrentBRBIndex++;
			if (NextOrCurrentBRBIndex >= BRBPlaylist.Count)
            {
				ChangePlayerState(BRBPlayerState.EndOfBreak);
			}
			else
            {
				ChangePlayerState(BRBPlayerState.InBetweenBRBs);
            }
		}


		// On hitting Escape, pause playback and show controls
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
			if(keyData == Keys.Escape)
            {
				PauseAndShowControls(true);
				return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

		// Shows screen at beginning with pre-playback checklist and break duration information for Chat
		private void DisplayPreBRBScreen()
		{
			Rectangle oldbounds = pnlUIPreBRB.Bounds;
			pnlUIPreBRB.SetBounds(0, Screen.FromControl(this).Bounds.Height / 2 - pnlUIPreBRB.Height / 2, Screen.FromControl(this).Bounds.Width, oldbounds.Height);
			int remMins = (int)Math.Round(GetRemainingBreakTime().TotalMinutes);
			dispWelcomeToBRBBreak.Text = "Welcome to the best part of the stream. Hob will now take a break for about "
										 + remMins + " minute" + (remMins == 1 ? "" : "s") + " and BRB videos will play.";

			pnlUIPreBRB.Visible = true;
		}

		// Shows screen between BRBs with countdown timer and information on next BRB
		private void DisplayBetweenBRBScreen()
		{
			Rectangle oldbounds = pnlUIInterBRB.Bounds;
			pnlUIInterBRB.SetBounds(0, Screen.FromControl(this).Bounds.Height / 2 - pnlUIInterBRB.Height / 2, Screen.FromControl(this).Bounds.Width, oldbounds.Height);
			int remMins = (int)Math.Round(GetRemainingBreakTime().TotalMinutes);
			dispHobIsTakingABreak.Text = "Hob is taking a break. He will be back in about " + remMins + " minute" + (remMins == 1 ? "" : "s") + ". In the meantime, please enjoy the memes.";

			dispNextBRBName.Text = NextOrCurrentBRB.Name != "" ? NextOrCurrentBRB.Name : NextOrCurrentBRB.Filename;
			dispCountdown.Text = ((int)Math.Ceiling(secondCountdown)).ToString();
			dispMoreInfoOnBRB.Text = NextOrCurrentBRB.Name != "" ? "Filename: " + NextOrCurrentBRB.Filename + (NextOrCurrentBRB.Credits != "" ? "  –  " : "") : "";
			dispMoreInfoOnBRB.Text += NextOrCurrentBRB.Credits != "" ? "Authors: " + NextOrCurrentBRB‌.Credits : "";

			string randomEmote = GetRandomHobEmote();
			picRandomHobEmote.Image = new Bitmap(Image.FromFile("images\\hobEmotes\\" + randomEmote.Split('|')[1] + ".png"), 100, 100);
			lblRandomHobEmote.Text = "Random Hob Emote –\r\n" + randomEmote.Split('|')[0];

			dispCurrentChapterNumber.Text = "The current chapter is " + Config.Chapter + ". If this is wrong, please remind Hob to update it.";

			pnlUIInterBRB.Visible = true;
		}

		// Shows screen after the last BRB with post-playback checklist
		private void DisplayPostBRBScreen()
		{
			Rectangle oldbounds = pnlUIPostBRB.Bounds;
			pnlUIPostBRB.SetBounds(0, Screen.FromControl(this).Bounds.Height / 2 - pnlUIPostBRB.Height / 2, Screen.FromControl(this).Bounds.Width, oldbounds.Height);
			
			pnlUIPostBRB.Visible = true;
		}

		// Shows a modified InterBRB screen for the special case of HobbVLC autoplay
		private void DisplayHobbVLCScreen()
		{
			Rectangle oldbounds = pnlUIHobbVLC.Bounds;
			pnlUIHobbVLC.SetBounds(0, Screen.FromControl(this).Bounds.Height / 2 - pnlUIHobbVLC.Height / 2, Screen.FromControl(this).Bounds.Width, oldbounds.Height);
			int remMins = (int)Math.Round(GetRemainingBreakTime().TotalMinutes);
			dispWelcomeToHobbVLC.Text = "Maybe not – it seems we have a hobbVLC situation on our hands. Please enjoy one more BRB video of about "
				                        + remMins + " minute" + (remMins == 1 ? "" : "s") + ".";

			dispNextBRBNameHobbVLC.Text = NextOrCurrentBRB.Name != "" ? NextOrCurrentBRB.Name : NextOrCurrentBRB.Filename;
			dispCountdownHobbVLC.Text = ((int)Math.Ceiling(secondCountdown)).ToString();
			dispMoreInfoOnBRBHobbVLC.Text = NextOrCurrentBRB.Name != "" ? "Filename: " + NextOrCurrentBRB.Filename + (NextOrCurrentBRB.Credits != "" ? "  –  " : "") : "";
			dispMoreInfoOnBRBHobbVLC.Text += NextOrCurrentBRB.Credits != "" ? "Authors: " + NextOrCurrentBRB‌.Credits : "";

			dispCurrentChapterNumberHobbVLC.Text = "The current chapter is " + Config.Chapter + ". If this is wrong, please remind Hob to update it.";

			pnlUIHobbVLC.Visible = true;
		}

		// Shows screen informing Chat of the fact that the media player encountered an error
		private void DisplayErrorScreen()
		{
			Rectangle oldbounds = pnlUIError.Bounds;
			pnlUIError.SetBounds(0, Screen.FromControl(this).Bounds.Height / 2 - pnlUIError.Height / 2, Screen.FromControl(this).Bounds.Width, oldbounds.Height);

			pnlUIError.Visible = true;
		}

		private void HideAllUIScreens()
        {
			pnlUIPreBRB.Visible = false;
			pnlUIInterBRB.Visible = false;
			pnlUIPostBRB.Visible = false;
			pnlUIHobbVLC.Visible = false;
			pnlUIError.Visible = false;
        }

		private string GetRandomHobEmote()
        {
			// TODO
			return "Common|hobbBrow";
		}

		private void btnSwitchScreen_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Move the playback window to a different screen?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
				== DialogResult.Yes)
            {
				Program.SwitchPlaybackScreen();
			}
		}

		private void btnConfirmBRBPlayback_Click(object sender, EventArgs e)
		{
			ChangePlayerState(BRBPlayerState.InBetweenBRBs);
			UnpauseAndHideControls();
		}

		private void btnFinishBRBPlayback_Click(object sender, EventArgs e)
		{
			Program.FinishBRBPlayback();
		}

		public void PauseAndShowControls(bool fromEscape = false)
		{
			// If a BRB is currently playing, pause it and show the BRB controls
			if (PlayerState == BRBPlayerState.BeginningOfBreak || PlayerState == BRBPlayerState.EndOfBreak)
            {
				if (!fromEscape)
                {
					Paused = true;
					Program.MainForm.OnBRBPause();
					Program.ShowCursor();
					this.Focus();
				}
				else // The pause request comes from the Escape key or from Alt-F4; make sure control form is reachable
                {
					Program.MainForm.Focus();
                }
            }
			if (PlayerState == BRBPlayerState.Playback)
            {
				if (!Paused)
                {
					VLCPlayer.Pause();
					Paused = true;
					pnlPaused.Visible = true;
				}
				// Make sure the control form is always reachable
				Program.ShowCursor();
				Program.MainForm.OnBRBPause();
			}
			if (PlayerState == BRBPlayerState.InBetweenBRBs || PlayerState == BRBPlayerState.HobbVLC)
            {
				tmrTenthSecond.Stop();
				Program.ShowCursor();
				Program.MainForm.OnBRBPause();
				Paused = true;
				pnlPaused.Visible = true;
			}
			if (PlayerState == BRBPlayerState.ErrorOccurred)
            {
				Program.ShowCursor();
                Program.MainForm.OnBRBPause();
				Paused = true;
            }
			// In other cases: TODO
		}

		public void UnpauseAndHideControls()
		{
			pnlPaused.Visible = false;

			if (PlayerState == BRBPlayerState.BeginningOfBreak)
            {
				// Ignore, user needs to click the button in the player form to start playback
            }
			if (PlayerState == BRBPlayerState.Playback && Paused)
			{
				VLCPlayer.Play();
				Program.HideCursor();
				Program.MainForm.OnBRBUnpause();
				Paused = false;
			}
			if ((PlayerState == BRBPlayerState.InBetweenBRBs || PlayerState == BRBPlayerState.HobbVLC) && Paused)
			{
				tmrTenthSecond.Start();
				Program.HideCursor();
				Program.MainForm.OnBRBUnpause();
				Paused = false;
			}
			if (PlayerState == BRBPlayerState.EndOfBreak)
            {
				// Ignore, user needs to click the button in the player form to close the window, add an additional BRB, or wait until hobbVLC triggers
            }
			if (PlayerState == BRBPlayerState.ErrorOccurred)
			{
				// Ignore, user should try to open a new player form instead, or do something else to try and fix the error
			}
			// In other cases: TODO
		}

		// If a BRB video is playing, go back to its InterBRB screen
		// If no BRB video is playing, do nothing
		public void ReplayCurrentBRB()
        {
			if (PlayerState == BRBPlayerState‌.Playback || PlayerState == BRBPlayerState.InBetweenBRBs)
            {
				ChangePlayerState(BRBPlayerState.InBetweenBRBs);
            }
        }

		public void ScrubTo(double seconds)
        {
			if (PlayerState == BRBPlayerState.Playback)
            {
				if ((DateTime.Now.Ticks - lastScrubUpdateTicks) / TimeSpan.TicksPerMillisecond >= 250)
				{
					VLCPlayer.Position = (float)seconds / ((float)VLCPlayer.Length / 1000.0f);
					// Update video so scrub effects are visible
					//WMPlayer.Ctlcontrols.play();
					//WMPlayer.Ctlcontrols.pause(); // TODO: Necessary?
					lastScrubUpdateTicks = DateTime.Now.Ticks;
				}
			}
        }

		public void SetVolume(int volume)
        {
			VLCPlayer.Volume = volume;
		}

		public void SetMuted(bool muted)
        {
			VLCPlayer.Mute = muted;
		}

		// Go back to the InterBRB screen announcing the previous BRB
		public void SkipToPreviousBRB()
        {
			if (PlayerState == BRBPlayerState‌.Playback || PlayerState == BRBPlayerState.InBetweenBRBs || PlayerState == BRBPlayerState.EndOfBreak || PlayerState == BRBPlayerState.HobbVLC)
			{
				if (NextOrCurrentBRBIndex > 0)
                {
					NextOrCurrentBRBIndex--;
                }
				if (PlayerState == BRBPlayerState.EndOfBreak)
				{
					ChangePlayerState(BRBPlayerState.InBetweenBRBs);
					UnpauseAndHideControls();
                }
				else
				{
					ChangePlayerState(BRBPlayerState.InBetweenBRBs);
				}
			}
		}

		// Skip the current BRB and go to the InterBRB screen announcing the next BRB, or go to the end screen if it was the last
		public void SkipToNextBRB()
		{
			if (PlayerState == BRBPlayerState‌.Playback || PlayerState == BRBPlayerState.InBetweenBRBs || PlayerState == BRBPlayerState.HobbVLC)
			{
				NextOrCurrentBRBIndex++;
				if (NextOrCurrentBRBIndex >= BRBPlaylist.Count)
				{
					ChangePlayerState(BRBPlayerState.EndOfBreak);
				}
				else
                {
					ChangePlayerState(BRBPlayerState.InBetweenBRBs);
				}
			}
		}

		// Changes the player to the next state, updates the player form accordingly and informs the control form of the fact
		private void ChangePlayerState(BRBPlayerState newState)
		{
			PlayerState = newState;

			if (VLCPlayer.Media != null)
			{
				ThreadPool.QueueUserWorkItem(_ => { VLCPlayer.Stop(); });
				//VLCPlayer.Media.Dispose();
				//VLCPlayer.Media = null;
			}
			HideAllUIScreens();
			tmrTenthSecond.Stop();
			videoView.Visible = false;

			switch (newState)
            {
				case BRBPlayerState.BeginningOfBreak:
					PauseAndShowControls();
					NextOrCurrentBRBIndex = 0;
					DisplayPreBRBScreen();
					break;

				case BRBPlayerState.InBetweenBRBs:
					secondCountdown = Config.InterBRBCountdown;
					if (!Paused)
                    {
						tmrTenthSecond.Start();
					}
					DisplayBetweenBRBScreen();
					break;

				case BRBPlayerState.Playback:
					HideAllUIScreens();
					VLCPlayer.Media = new Media(Program.VLC, new Uri(Path.Combine(Config.BRBDirectory, BRBPlaylist[NextOrCurrentBRBIndex].Filename)));
					videoView.Visible = true;
					if (!Paused)
					{
						VLCPlayer.Play();
					}
					break;

				case BRBPlayerState.EndOfBreak:
					secondCountdown = Config.TimeUntilHobbVLC;
					PauseAndShowControls();
					tmrTenthSecond.Start();
					DisplayPostBRBScreen();
					break;

				case BRBPlayerState.HobbVLC:
					if (Program.MainForm.AppendHobbVLCEpisode())
                    {
						UnpauseAndHideControls();
						secondCountdown = Config.HobbVLCCountdown;
						tmrTenthSecond.Start();
						HobbVLCsTriggered++;
						DisplayHobbVLCScreen();
					}
					else
                    {
						// Do nothing – the player will remain on a black screen, but this happens only if there are no videos left to play, which will hopefully never happen
                    }
					break;

				case BRBPlayerState.ErrorOccurred:
					PauseAndShowControls();
					DisplayErrorScreen();
					break;
			}

			Program.MainForm.OnBRBPlayerStateChanged();
        }

		public void CloseGracefully()
		{
			PlayerState = BRBPlayerState.Exiting;
			this.Close();
		}

		// Prevent accidental Alt-F4 closing, but not Task Manager closing, for instance (however, do pause and display controls)
		private void FormPlayer_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && PlayerState != BRBPlayerState.Exiting)
			{
				e.Cancel = true;
				PauseAndShowControls(true);
			}
			else
			{
				Program.ShowCursor();
			}
		}
		
		public void OnMediaError(object sender, EventArgs e)
        {
			ChangePlayerState(BRBPlayerState.ErrorOccurred);
			
			MessageBox.Show("The VLC media player encountered an error and was unable to play a BRB video. The BRB playback was stopped.\r\n\r\n"
				            + "The name of the affected BRB file will be written to MediaError.log in the application folder. More details may be available in VLC.log.",
				            "Critical media player error. User action likely required", MessageBoxButtons.OK, MessageBoxIcon.Error);
			try
			{
				File.AppendAllLines("MediaError.log", new string[] { "Error at " + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()
															         + " while playing the BRB episode " + NextOrCurrentBRB.Filename });
			}
			catch
			{
				MessageBox.Show("Cannot write to file MediaError.log. Ensure the application has write permissions in its directory.", "Error writing media error to file",
								MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
    }
}