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
    public partial class FormPlayerTest : Form
    {
        private bool closing = false;

        public FormPlayerTest()
        {
            InitializeComponent();
        }

        // Paint a rectangle exactly along the edge of the screen
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Pen red1px = new Pen(Color.Red, 1.0f);
            Rectangle screenRect = Screen.FromControl(this).Bounds;
            int x = 0; // While screenRect uses absolute coordinates, the coordinates used when drawing should be relative to this form
            int y = 0;
            int w = screenRect.Width;
            int h = screenRect.Height;
            e.Graphics.DrawRectangle(red1px, x, y, x + w - 1, y + h - 1);
            e.Graphics.DrawLine(red1px, x,         y,         x + 10,     y + 10    );
            e.Graphics.DrawLine(red1px, x + w - 1, y,         x + w - 11, y + 10    );
            e.Graphics.DrawLine(red1px, x,         y + h - 1, x + 10,     y + h - 11);
            e.Graphics.DrawLine(red1px, x + w - 1, y + h - 1, x + w - 11, y + h - 11);
        }

        // Automatically redraw lines every second (just to make sure)
        private void tmrRefresh_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Refresh();
            }
        }

        // Called by Initial Setup once it finishes and this form is no longer needed
        public void ConfirmClose()
        {
            closing = true;
            this.Close();
        }

        // Prevent accidental Alt-F4 closing, but not Task Manager closing, for instance
        private void FormPlayer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing && !closing)
            {
                e.Cancel = true;
            }
        }
    }
}
