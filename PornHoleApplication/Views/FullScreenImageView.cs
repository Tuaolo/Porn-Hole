using PornHole.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PornHole.Views
{
    public partial class FullScreenImageView : Form, IFullScreenImageView
    {
        private PornHoleController controller;
        private Point mouseLoc;
        private bool controlsVisible = false;
        private bool fromButtonsVisible = false;
        private int hideControlsAfterSeconds = 5;

        public FullScreenImageView()
        {
            InitializeComponent();

            tmrMouseMove.Interval = (hideControlsAfterSeconds * 1000);
        }

        #region Interface Methods

        public void setController(PornHoleController controller)
        {
            this.controller = controller;
        }

        public void setVisible(bool isVisible)
        {
            this.Visible = isVisible;
        }

        public void setImage(string imagePath)
        {
            bigPicture.ImageLocation = imagePath;
        }

        public void setControlsToPlaying()
        {
            btnShow.Text = "||";
            fromButtonsVisible = false;
        }

        public void setControlsToPaused()
        {
            btnShow.Text = "▷";
        }

        public void showFromButtons()
        {
            fromButtonsVisible = true;
        }

        public void openAtLocation(Point location)
        {
            //maximized windows won't move, so need to normalize it, move it, then maximize it again.
            this.WindowState = FormWindowState.Normal;
            this.Location = location;
            this.WindowState = FormWindowState.Maximized;
            btnFromHere.Left = (int)((.3333 * this.Width) - (.5 * btnFromHere.Width));
            btnFromPaused.Left = (int)((.6667 * this.Width) - (.5 * btnFromHere.Width));
            this.Visible = true;
        }

        #endregion

        #region Other Event Handlers

        // Right Clicking or hitting the escape key exit full window mode.
        private void FullScreenImage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Visible = false;
                controller.hideFullScreen();
            }
        }

        private void FullScreenImage_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                this.Visible = false;
                controller.hideFullScreen();
            }
        }

        private void bigPicture_MouseMove(object sender, MouseEventArgs e)
        {
            // turns out that MouseMove constantly fires when the mouse is over the control
            // even when it's NOT MOVING. So we have to manually keep track of it's location (grr)
            if (mouseLoc != e.Location)
            {
                // if it did move, make the controls visible, restart the "didn't move" timer
                // and note the new location
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

        private void tmrMouseMove_Tick(object sender, EventArgs e)
        {
            //when the "didn't move" timer actually ticks, stop it and hide the controls
            tmrMouseMove.Stop();
            controlsVisible = false;
            setControlsVisible(controlsVisible);
        }

        #endregion

        #region Button Click Event Handlers

        private void btnBack_Click(object sender, EventArgs e)
        {
            controller.btnBackClicked();
            setControlsVisible(controlsVisible);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            controller.btnNextClicked();
            setControlsVisible(controlsVisible);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            controller.btnPlayPauseClicked();
            setControlsVisible(controlsVisible);
        }

        private void btnFromPaused_Click(object sender, EventArgs e)
        {
            controller.startSlideShow();
            setControlsVisible(controlsVisible);
        }

        private void btnFromHere_Click(object sender, EventArgs e)
        {
            controller.startSlideShowFromHere();
            setControlsVisible(controlsVisible);
        }

        #endregion

        #region Utility Methods

        private void setControlsVisible(bool controlsVisible)
        {
            btnBack.Visible = controlsVisible;
            btnNext.Visible = controlsVisible;
            
            btnFromHere.Visible = fromButtonsVisible && controlsVisible;
            btnFromPaused.Visible = fromButtonsVisible && controlsVisible;
            btnShow.Visible = !fromButtonsVisible && controlsVisible;
        }

        #endregion

    }
}
