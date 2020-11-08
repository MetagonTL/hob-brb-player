using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hob_BRB_Player
{
    public partial class FormAutoMuteData : Form
    {
        private BRBEpisode episode;

        public FormAutoMuteData(BRBEpisode episode)
        {
            InitializeComponent();

            this.episode = episode;
            this.Text = "Displaying AutoMute Data of " + episode.Filename;

            if (episode.AutoMutes.Count == 0)
            {
                txtBegin.Text = "";
                txtEnd.Text = "";
                txtInfo.Text = "";
            }
            else
            {
                foreach (BRBEpisode.AutoMuteSpan span in episode.AutoMutes)
                {
                    drpAutoMuteTrigger.Items.Add((!span.Enabled ? "[Disabled] " : "") + BRBManager.TimeSpanToMMSS(span.Begin) + " \u2013 " + BRBManager.TimeSpanToMMSS(span.End) + " / " + span.Info);
                }

                drpAutoMuteTrigger.SelectedIndex = 0;

                UpdateAutoMuteData();
            }
        }

        private void drpAutoMuteTrigger_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAutoMuteData();
        }

        public void UpdateAutoMuteData()
        {
            if (drpAutoMuteTrigger.SelectedIndex == -1)
            {
                txtBegin.Text = "";
                txtEnd.Text = "";
                txtInfo.Text = "";
            }
            else
            {
                BRBEpisode.AutoMuteSpan span = episode.AutoMutes[drpAutoMuteTrigger.SelectedIndex];

                txtBegin.Text = span.Begin.TotalSeconds.ToString("F4");
                txtEnd.Text = span.End.TotalSeconds.ToString("F4");
                txtInfo.Text = span.Info;
            }
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // TODO: Editing of AutoMute Data
    }
}
