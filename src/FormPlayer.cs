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
				// Episode was added at end of break. Automatically play this new BRB
				ChangePlayerState(BRBPlayerState.InBetweenBRBs);
				UnpauseAndHideControls();
			}
		}

		public BRBEpisode NextOrCurrentBRB
		{
			get { return BRBPlaylist[NextOrCurrentBRBIndex]; }
		}

		public MediaPlayer VLCPlayer { get; }

		private int volume = Config.StandardPlayerVolume;
		private bool muted = false;

		private long lastScrubUpdateTicks = 0;
		private double scrubBuffer = 0;

		// Common = Wt 25, Uncommon = Wt 10, Rare = Wt 5, Epic = Wt 2, Legendary = Wt 1
		private string[] hobEmotes = {
			"E|2Head.png",
			"C|AYAYA.png",
			"E|BALDERS.gif",
			"U|BOOBA.gif",
			"U|FeelsMattMan.png",
			"L|HeyListen.gif",
			"U|haHAA.png",
			"E|hobbAim.gif",
			"R|hobbBald.png",
			"E|hobbBeep.png",
			"U|hobbBlanket.png",
			"R|hobbBowl.png",
			"U|hobbBrexit.png",
			"C|hobbBrit.png",
			"C|hobbBrow.png",
			"R|hobbBuffer.gif",
			"E|hobbChoke.png",
			"R|hobbClap.gif",
			"R|hobbCloud.png",
			"U|hobbCray.png",
			"E|hobbCrazy.png",
			"C|hobbCry.png",
			"C|hobbDab.png",
			"C|hobbDerp.png",
			"L|hobbDiva.png",
			"U|hobbDuck.png",
			"R|hobbEmo.png",
			"E|hobbF.png",
			"U|hobbFart.png",
			"R|hobbFive.png",
			"C|hobbGasm.png",
			"C|hobbH.png",
			"C|hobbHands.png",
			"C|hobbHi.png",
			"R|hobbHOP.gif",
			"U|hobbHype.png",
			"U|hobbIncel.png",
			"C|hobbJedi.png",
			"L|hobbK.png",
			"R|hobbKEK.png",
			"E|hobbKet.png",
			"U|hobbKeys.png",
			"C|hobbLink.png",
			"C|hobbLUL.png",
			"R|hobbLurk.png",
			"E|hobbMan.gif",
			"R|hobbMind.png",
			"L|hobbMorg.png",
			"R|hobbNan.png",
			"U|hobbNed.png",
			"E|hobbNGT.png",
			"U|hobbNotes.png",
			"L|hobbP.png",
			"C|hobbPega.png",
			"U|hobbPoo.png",
			"E|hobbPray.png",
			"R|hobbPride.png",
			"U|hobbRage.png",
			"U|hobbRed.png",
			"R|hobbRings.png",
			"C|hobbS.png",
			"C|hobbSif.png",
			"C|hobbSleeper.png",
			"L|hobbSmash.gif",
			"E|hobbSmile.png",
			"C|hobbStall.png",
			"U|hobbT.png",
			"C|hobbTos.png",
			"C|hobbTroll.png",
			"L|hobbUnagi.png",
			"L|hobbVIP.png",
			"U|hobbW.png",
			"C|hobbWeird.png",
			"R|hobbWheel.gif",
			"U|hobbWoah.png",
			"C|hobbY.png",
			"U|hobbYoda.png",
			"C|KEKW.png",
			"C|PETHOB.gif",
			"U|PETLINK.gif",
			"E|PETTHEMATT.gif",
			"R|PETTHEMEG.gif",
			"E|PotPie.png",
			"L|RareHob.gif"
		};

		// Common: AYAYA, hobbBrit, hobbBrow, hobbCry, hobbDab, hobbDerp, hobbGasm, hobbH, hobbHands, hobbHi, hobbJedi, hobbLink, hobbLUL, hobbPega, hobbS, hobbSif, hobbSleeper, hobbStall,
		//         hobbStare, hobbTos, hobbTroll, hobbWeird, hobbY, KEKW, PETHOB (24)
		// Uncommon: BOOBA, FeelsMattMan, haHAA, hobbBlanket, hobbBrexit, hobbCray, hobbDuck, hobbFart, hobbHype, hobbIncel, hobbKeys, hobbNed, hobbNotes, hobbPoo, hobbRage, hobbRed, hobbT, hobbW,
		//           hobbWoah, hobbYoda, PETLINK (21)
		// Rare: hobbBald, hobbBowl, hobbBuffer, hobbClap, hobbCloud, hobbEmo, hobbFive, hobbHOP, hobbKEK, hobbLurk, hobbMind, hobbNan, hobbPride, hobbRings, hobbWheel, PETTHEMEG (16)
		// Epic: 2Head, BALDERS, hobbAim, hobbBeep, hobbChoke, hobbCrazy, hobbF, hobbKet, hobbMan, hobbNGT, hobbPray, hobbSmile, PETTHEMATT, PotPie (14)
		// Legendary: HeyListen, hobbDiva, hobbK, hobbMorg, hobbP, hobbSmash, hobbUnagi, hobbVIP, RareHob (9)
		// SUM: 84 with wt 927; Common 64.7 %, 2.70 % each; Uncommon 22.7 %, 1.08 % each; Rare 8.63 %, 0.54 % each; Epic 3.02 %, 0.22 % each; Legendary 0.97 %, 0.11 % each


		private List<string> weightedHobEmotes = new List<string>(); // Compiled only once, then saved for future uses


		public FormPlayer(List<BRBEpisode> brbsToPlay)
		{
			InitializeComponent();
			ReCenterControls();

			// Display correct app version at the bottom in every screen
			lblBRBManagerCreditsPre.Text = "The_Happy_Hob BRB Manager and Player by MetagonTL – Version " + Config.Version;
			lblBRBManagerCreditsInter.Text = "The_Happy_Hob BRB Manager and Player by MetagonTL – Version " + Config.Version;
			lblBRBManagerCreditsPost.Text = "The_Happy_Hob BRB Manager and Player by MetagonTL – Version " + Config.Version;
			lblBRBManagerCreditsHobbVLC.Text = "The_Happy_Hob BRB Manager and Player by MetagonTL – Version " + Config.Version;
			lblBRBManagerCreditsError.Text = "The_Happy_Hob BRB Manager and Player by MetagonTL – Version " + Config.Version;

			// Load the VLC media player in for convenience
			VLCPlayer = Program.VLCPlayer;
			videoView.MediaPlayer = VLCPlayer;

			pnlTestMode.Visible = Config.TestMode;

			this.TopMost = Config.MakePlayerTopMost;

			LoadIcons();

			BRBPlaylist = brbsToPlay;
		}

		private void LoadIcons()
		{
			btnConfirmBRBPlayback.Image = Image.FromFile("icons\\checklistok.png");
			btnSwitchScreen.Image = Image.FromFile("icons\\switchscreen.png");
			btnFinishBRBPlayback.Image = Image‌.FromFile("icons\\closeplayer.png");
			picHobbVLC.Image = new Bitmap(Image.FromFile("images\\hobEmotes\\hobbVLC.png"), 100, 100);
		}

		public void ReCenterControls()
        {
			// Make sure "PAUSED" (and "TEST MODE") are centered properly
			Rectangle oldbounds = pnlPaused.Bounds;
			pnlPaused.SetBounds(Screen.FromControl(this).Bounds.Width / 2 - pnlPaused.Width / 2, oldbounds.Y, oldbounds.Width, oldbounds.Height);
			oldbounds = pnlTestMode.Bounds;
			pnlTestMode.SetBounds(Screen.FromControl(this).Bounds.Width / 2 - pnlTestMode.Width / 2, oldbounds.Y, oldbounds.Width, oldbounds.Height);

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
						dispNextBRBName.Text = NextOrCurrentBRB.Title != "" ? NextOrCurrentBRB.Title : NextOrCurrentBRB.Filename;
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
						dispNextBRBNameHobbVLC.Text = NextOrCurrentBRB.Title != "" ? NextOrCurrentBRB.Title : NextOrCurrentBRB.Filename;
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
			switch (PlayerState)
			{
				case BRBPlayerState.Playback:
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
					break;

					// For InterBRBs etc., loop the background video (but that should rarely happen)
				case BRBPlayerState.BeginningOfBreak:
					ThreadPool.QueueUserWorkItem((o) => {
						VLCPlayer.Media = new Media(Program.VLC, new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "images\\screens\\preBRB.mkv")));
						VLCPlayer.Play();
					});
					break;

				case BRBPlayerState.InBetweenBRBs:
					ThreadPool.QueueUserWorkItem((o) => {
						VLCPlayer.Media = new Media(Program.VLC, new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "images\\screens\\interBRB.mkv")));
						VLCPlayer.Play();
					});
					break;

				case BRBPlayerState.EndOfBreak:
					ThreadPool.QueueUserWorkItem((o) => {
						VLCPlayer.Media = new Media(Program.VLC, new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "images\\screens\\postBRB.mkv")));
						VLCPlayer.Play();
					});
					break;

				case BRBPlayerState.HobbVLC:
					ThreadPool.QueueUserWorkItem((o) => {
						VLCPlayer.Media = new Media(Program.VLC, new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "images\\screens\\hobbVLC.mkv")));
						VLCPlayer.Play();
					});
					break;
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

			ThreadPool.QueueUserWorkItem((o) => {
				VLCPlayer.Media = new Media(Program.VLC, new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "images\\screens\\preBRB.mkv")));
				VLCPlayer.Play();
			});

			pnlUIPreBRB.Visible = true;
		}

		// Shows screen between BRBs with countdown timer and information on next BRB
		private void DisplayBetweenBRBScreen()
		{
			Rectangle oldbounds = pnlUIInterBRB.Bounds;
			pnlUIInterBRB.SetBounds(0, Screen.FromControl(this).Bounds.Height / 2 - pnlUIInterBRB.Height / 2, Screen.FromControl(this).Bounds.Width, oldbounds.Height);
			int remMins = (int)Math.Round(GetRemainingBreakTime().TotalMinutes);
			dispHobIsTakingABreak.Text = "Hob is taking a break. He will be back in about " + remMins + " minute" + (remMins == 1 ? "" : "s") + ". In the meantime, please enjoy the memes.";

			dispNextBRBName.Text = NextOrCurrentBRB.Title != "" ? NextOrCurrentBRB.Title : NextOrCurrentBRB.Filename;
			dispCountdown.Text = ((int)Math.Ceiling(secondCountdown)).ToString();
			dispMoreInfoOnBRB.Text = NextOrCurrentBRB.Title != "" ? "Filename: " + NextOrCurrentBRB.Filename + (NextOrCurrentBRB.Credits != "" ? "  –  " : "") : "";
			dispMoreInfoOnBRB.Text += NextOrCurrentBRB.Credits != "" ? "Authors: " + NextOrCurrentBRB‌.Credits : "";
			if (NextOrCurrentBRB.AutoMuteEnabled)
			{
				dispMoreInfoOnBRB.Text += dispMoreInfoOnBRB.Text != "" ? "  –  " : "";
				dispMoreInfoOnBRB.Text += "[AutoMute on]";
			}

			string randomEmote = GetRandomHobEmote();
			picRandomHobEmote.Image = Image.FromFile("images\\hobEmotes\\" + randomEmote.Split('|')[1]);
			lblRandomHobEmote.Text = "Random Hob Emote –\r\n";
			switch (randomEmote.Split('|')[0])
			{
				case "C": lblRandomHobEmote.Text += "Common"; break;
				case "U": lblRandomHobEmote.Text += "Uncommon"; break;
				case "R": lblRandomHobEmote.Text += "Rare"; break;
				case "E": lblRandomHobEmote.Text += "Epic"; break;
				case "L": default: lblRandomHobEmote.Text += "Legendary"; break;
			}

			dispCurrentChapterNumber.Text = "The current chapter is " + Config.Chapter + ". If this is wrong, please remind Hob to update it.";

			ThreadPool.QueueUserWorkItem((o) => {
				VLCPlayer.Media = new Media(Program.VLC, new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "images\\screens\\interBRB.mkv")));
				VLCPlayer.Play();
			});

			pnlUIInterBRB.Visible = true;
		}

		// Shows screen after the last BRB with post-playback checklist
		private void DisplayPostBRBScreen()
		{
			Rectangle oldbounds = pnlUIPostBRB.Bounds;
			pnlUIPostBRB.SetBounds(0, Screen.FromControl(this).Bounds.Height / 2 - pnlUIPostBRB.Height / 2, Screen.FromControl(this).Bounds.Width, oldbounds.Height);

			ThreadPool.QueueUserWorkItem((o) => {
				VLCPlayer.Media = new Media(Program.VLC, new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "images\\screens\\postBRB.mkv")));
				VLCPlayer.Play();
			});

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

			dispNextBRBNameHobbVLC.Text = NextOrCurrentBRB.Title != "" ? NextOrCurrentBRB.Title : NextOrCurrentBRB.Filename;
			dispCountdownHobbVLC.Text = ((int)Math.Ceiling(secondCountdown)).ToString();
			dispMoreInfoOnBRBHobbVLC.Text = NextOrCurrentBRB.Title != "" ? "Filename: " + NextOrCurrentBRB.Filename + (NextOrCurrentBRB.Credits != "" ? "  –  " : "") : "";
			dispMoreInfoOnBRBHobbVLC.Text += NextOrCurrentBRB.Credits != "" ? "Authors: " + NextOrCurrentBRB‌.Credits : "";
			if (NextOrCurrentBRB.AutoMuteEnabled)
			{
				dispMoreInfoOnBRBHobbVLC.Text += dispMoreInfoOnBRBHobbVLC.Text != "" ? "  –  " : "";
				dispMoreInfoOnBRBHobbVLC.Text += "[AutoMute on]";
			}

			dispCurrentChapterNumberHobbVLC.Text = "The current chapter is " + Config.Chapter + ". If this is wrong, please remind Hob to update it.";

			ThreadPool.QueueUserWorkItem((o) => {
				VLCPlayer.Media = new Media(Program.VLC, new Uri(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "images\\screens\\hobbVLC.mkv")));
				VLCPlayer.Play();
			});

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
			// Compile weighted list once if not done already
			if (weightedHobEmotes.Count == 0)
            {
				foreach (string emoteInfo in hobEmotes)
                {
					int weight;
					switch (emoteInfo.Split('|')[0])
                    {
						case "C": weight = 25; break;
						case "U": weight = 10; break;
						case "R": weight = 5; break;
						case "E": weight = 2; break;
						case "L": default: weight = 1; break;
					}
					for (int i = 0; i < weight; i++)
                    {
						weightedHobEmotes.Add(emoteInfo);
                    }
                }
            }

			int randomIndex = Program.Rand.Next(0, weightedHobEmotes.Count);

			return weightedHobEmotes[randomIndex];
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

		// If a BRB is currently playing, pause it and show the BRB controls
		public void PauseAndShowControls(bool fromEscape = false)
		{
			if (PlayerState == BRBPlayerState.BeginningOfBreak || PlayerState == BRBPlayerState.EndOfBreak) // Paused automatically by form, cannot be unpaused
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
			if (PlayerState == BRBPlayerState.InBetweenBRBs || PlayerState == BRBPlayerState.HobbVLC) // "Pause" means "Pause timer" here
            {
				tmrTenthSecond.Stop();
				Program.ShowCursor();
				Program.MainForm.OnBRBPause();
				Paused = true;
				pnlPaused.Visible = true;
			}
			if (PlayerState == BRBPlayerState.ErrorOccurred) // Paused automatically by form, cannot be unpaused
			{
				Program.ShowCursor();
                Program.MainForm.OnBRBPause();
				Paused = true;
            }
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
		}

		// Hide cursor if mouse enters video player
		private void videoView_MouseEnter(object sender, EventArgs e)
		{
			if (PlayerState == BRBPlayerState.Playback && !Paused)
            {
				Program.HideCursor();
            }
		}

		public void ScrubTo(double seconds)
        {
			if (PlayerState == BRBPlayerState.Playback)
            {
				if ((DateTime.Now.Ticks - lastScrubUpdateTicks) / TimeSpan.TicksPerMillisecond >= 250)
				{
					VLCPlayer.Position = (float)seconds / ((float)VLCPlayer.Length / 1000.0f);
					lastScrubUpdateTicks = DateTime.Now.Ticks;
					scrubBuffer = seconds;
					tmrUpdateScrub.Enabled = false;
				}
				else
                {
					scrubBuffer = seconds;
					tmrUpdateScrub.Enabled = true;
                }
			}
		}

		private void tmrUpdateScrub_Tick(object sender, EventArgs e)
		{
			if ((DateTime.Now.Ticks - lastScrubUpdateTicks) / TimeSpan.TicksPerMillisecond >= 250)
			{
				VLCPlayer.Position = (float)scrubBuffer / ((float)VLCPlayer.Length / 1000.0f);
				lastScrubUpdateTicks = DateTime.Now.Ticks;
				tmrUpdateScrub.Enabled = false;
			}
		}

		public void SetVolume(int volume)
        {
			this.volume = volume;
			UpdatePlayerVolume();
		}

		public void SetMuted(bool muted)
        {
			this.muted = muted;
			UpdatePlayerVolume();
		}

		// VLC seems to reset volume on media change (or at least not reliably use new settings), so need to periodically call this
		// Also, consider AutoMutes here
		private void UpdatePlayerVolume()
        {
			if (PlayerState == BRBPlayerState.Playback)
			{
				// Causes an app freeze if called in an error state
				VLCPlayer.Volume = volume;
				VLCPlayer.Mute = muted || NextOrCurrentBRB.ShouldMuteAt(new TimeSpan((long)(VLCPlayer.Position * (double)VLCPlayer.Length * TimeSpan.TicksPerMillisecond)));
			}
		}

		private void tmrUpdateVolume_Tick(object sender, EventArgs e)
		{
			UpdatePlayerVolume();
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
				ThreadPool.QueueUserWorkItem((o) => { VLCPlayer.Stop(); });
			}
			HideAllUIScreens();
			tmrTenthSecond.Stop();
			// videoView.Visible = false; Not necessary anymore since now, videos play in the background of UI screens as well

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
					VLCPlayer.Media = new Media(Program.VLC, new Uri(Path.GetFullPath(Path.Combine(Config.BRBDirectory, BRBPlaylist[NextOrCurrentBRBIndex].Filename))));
					// videoView.Visible = true;
					if (!Paused)
					{
						VLCPlayer.Play();
						// Deadlock should not occur here since Playback should not be triggered out of playback
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
			VLCPlayer.Stop();
			PlayerState = BRBPlayerState.Exiting;
			this.Close();
		}

		// Prevent accidental Alt-F4 closing, but not Task Manager closing, for instance. However, do pause and display controls
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
			catch (IOException)
			{
				MessageBox.Show("Cannot write to file MediaError.log. Ensure the application has write permissions in its directory.", "Error writing media error to file",
								MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
    }
}
