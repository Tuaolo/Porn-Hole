using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using PornHole.Controllers;

namespace PornHole.Views
{
    public partial class PornHoleView : Form, IPornHoleView
    {
        private PornHoleController controller;

        public PornHoleView()
        {
            InitializeComponent();  
        }

        #region Interface Methods

        public void setController(PornHoleController controller)
        {
            this.controller = controller;

            //set the initial timer value
            controller.setTimerInterval((int)numInterval.Value);
        }

        public void setVisible(bool isVisible)
        {
            this.Visible = isVisible;
        }

        public void setImage(string imagePath)
        {
            pictureBox.ImageLocation = imagePath;
        }

        public void setControlsToPlaying()
        {
            btnShow.Text = "Pause";
            btnShow.Visible = true;
            btnFromHere.Visible = false;
            btnFromPaused.Visible = false;
            btnFullScreen.Enabled = true;
            txtDirectory.Enabled = false;
            btnSelectFolder.Enabled = false;
            chkSubdirs.Enabled = false;
        }

        public void setControlsToPaused()
        {
            btnShow.Text = "Resume";
            btnFullScreen.Enabled = false;
            txtDirectory.Enabled = true;
            btnSelectFolder.Enabled = true;
            chkSubdirs.Enabled = true;
        }

        public void showFromButtons()
        {
            btnShow.Visible = false;
            btnFromHere.Visible = true;
            btnFromPaused.Visible = true;
        }

        #endregion

        #region Button Click Event Handlers

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            //open the file browser
            folderBrowser.ShowDialog();
        }

        public void btnShow_Click(object sender, EventArgs e)
        {
            controller.btnPlayPauseClicked();
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            controller.showFullScreen(this.Location);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            controller.btnBackClicked();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            controller.btnNextClicked();
        }

        private void btnFromPaused_Click(object sender, EventArgs e)
        {
            controller.startSlideShow();
        }

        private void btnFromHere_Click(object sender, EventArgs e)
        {
            controller.startSlideShowFromHere();
        }

        #endregion

        #region Other Event Handlers

        private void folderBrowser_FileOk(object sender, CancelEventArgs e)
        {
            //when a folder is selected, put the path in the textbox
            txtDirectory.Text = Path.GetDirectoryName(folderBrowser.FileName);
            controller.setDirectory(@txtDirectory.Text);
        }

        private void numInterval_ValueChanged(object sender, EventArgs e)
        {
            // change the interval between images
            //timer.Stop();
            controller.setTimerInterval((int)numInterval.Value);
            //timer.Start();
        }

        private void chkSubdirs_CheckedChanged(object sender, EventArgs e)
        {
            controller.setIncludeSubdirs(chkSubdirs.Checked);
        }

        #endregion
    }
}
