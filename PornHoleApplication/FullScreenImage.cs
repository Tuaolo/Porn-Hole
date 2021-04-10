using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class FullScreenImage : Form
    {
        private PornHoleController parentController;
        private bool controlsVisible = false;
        Point mouseLoc;
        public bool showFromButtons = false;

        public FullScreenImage(PornHoleController parentController)
        {
            InitializeComponent();
            this.parentController = parentController;
            // Set the timer to tick 5 seconds after the mouse stops moving
            tmrMouseMove.Interval = (5 * 1000);
        }

        public String FileLocation
        {
            set { bigPicture.ImageLocation = value; }
        }

        // Right Clicking or hitting the escape key exit full window mode.
        private void FullScreenImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void FullScreenImage_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                this.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            parentController.btnBack_Click(null, null);
            setControlsVisible(controlsVisible);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            parentController.btnNext_Click(null, null);
            setControlsVisible(controlsVisible);
        }

        private void tmrMouseMove_Tick(object sender, EventArgs e)
        {
            tmrMouseMove.Stop();
            controlsVisible = false;
            setControlsVisible(controlsVisible);
        }

        private void setControlsVisible(bool controlsVisible)
        {
            btnBack.Visible = controlsVisible;
            btnNext.Visible = controlsVisible;
            
            btnFromHere.Visible = showFromButtons && controlsVisible;
            btnFromPaused.Visible = showFromButtons && controlsVisible;
            btnShow.Visible = !showFromButtons && controlsVisible;
        }

        private void bigPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if(mouseLoc != e.Location)
            {
                if (!controlsVisible)
                {
                    controlsVisible = true;
                    setControlsVisible(controlsVisible);
                }
                tmrMouseMove.Stop();
                tmrMouseMove.Start();
                mouseLoc = e.Location;
            }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            parentController.btnShow_Click(null, null);
            setControlsVisible(controlsVisible);
        }

        public void setBtnShowText(string text)
        {
            btnShow.Text = text;
        }

        private void btnFromPaused_Click(object sender, EventArgs e)
        {
            parentController.btnFromPaused_Click(null, null);
            setControlsVisible(controlsVisible);
        }

        private void btnFromHere_Click(object sender, EventArgs e)
        {
            parentController.btnFromHere_Click(null, null);
            setControlsVisible(controlsVisible);
        }
    }
}
