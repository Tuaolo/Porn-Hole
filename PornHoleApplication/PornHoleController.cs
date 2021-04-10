using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using PornHole;

namespace WindowsFormsApplication1
{
    public partial class PornHoleController : Form
    {
        private Random randnum = new Random();
        private FileInfo[] fileArray;
        private LinkedList<ImageInfo> currentImageList;
        private LinkedList<ImageInfo> previousImageList;
        private LinkedListNode<ImageInfo> currentNode;
        private LinkedListNode<ImageInfo> manualNode;
        private String currentDir = "";
        private bool currentSubdirCheck = false;
        private FullScreenImage fullScreenImage;

        public PornHoleController()
        {
            InitializeComponent();

            //set the initial timer value
            timer.Interval = ((int)numInterval.Value) * 1000;
        }

        private void showNextImage()
        {
            if (manualNode != null)
            {
                // to be in here, we know we also have a currentNode and a currentImageList.
                // If not, something is very wrong and we deserve to puke on any exceptions.

                // if we've been browsing and we're back where we stopped the slideshow
                // (or resuming from where we stopped browsing), move to the next image.
                // otherwise do nothing (will show the image where the show was stopped as
                // the next image and then continue)
                if (manualNode == currentNode)
                {
                    if (previousImageList != null && currentNode == previousImageList.Last)
                    {
                        currentNode = currentImageList.First;
                    }
                    else if (currentNode == currentImageList.Last)
                    {
                        currentNode = null;
                    }
                    else
                    {
                        currentNode = currentNode.Next;
                    }
                }
                manualNode = null;
            }
            else if (currentImageList != null && currentNode != null)
            {
                if (currentNode == currentImageList.Last)
                {
                    currentNode = null;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }

            // If we don't have a current image list or a current node, or a new directory has been selected,
            // or the option to include subdirs has changed, regenerate the list.
            if (currentImageList == null || currentImageList.Count == 0 || currentNode == null ||
                (!currentDir.Equals(txtDirectory.Text, StringComparison.CurrentCultureIgnoreCase)) ||
                !(chkSubdirs.Checked == currentSubdirCheck))
            {
                loadRandomizedImageList();
            }

            // if the list is still null/empty or we're still missing a node, stop the program
            if (currentImageList == null || currentImageList.Count == 0 || currentNode == null)
            {
                stopSlideShow();
                MessageBox.Show("No images to display.",
                        "No Images", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // grab the image key from the top of the list, set that image to the
            // mini-viewer and the full screen viewer (if the full screen viewer is active)
            pictureBox.ImageLocation = currentNode.Value.ImagePath;
            if (fullScreenImage != null)
            {
                fullScreenImage.FileLocation = currentNode.Value.ImagePath;
            }
        }

        #region File Loading Functions

        private bool loadFileList()
        {
            // read in the file list from the selected directory and subdirs (if applicable)
            DirectoryInfo d = new DirectoryInfo(@txtDirectory.Text);
            try
            {
                if (chkSubdirs.Checked)
                {
                    fileArray = d.GetFiles("*", SearchOption.AllDirectories);
                }
                else
                {
                    fileArray = d.GetFiles();
                }
                currentDir = txtDirectory.Text;
                currentSubdirCheck = chkSubdirs.Checked;
            }
            catch
            {
                // if there's a failure, stop the slideshow
                stopSlideShow();
                MessageBox.Show("Error loading images. Review the directory/subdir checkbox and try again.",
                    "Error Loading Images", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void loadRandomizedImageList()
        {
            // if the selected directory or the option to include subdirs has changed, 
            // read in all the files in the directory/ies
            if (!currentDir.Equals(txtDirectory.Text, StringComparison.CurrentCultureIgnoreCase)
                || !(chkSubdirs.Checked == currentSubdirCheck))
            {
                if(!loadFileList())
                {
                    return;
                }
            }

            // Build a linked list of ImageInfo objects sorted by randomized SortIDs
            LinkedList<ImageInfo> newList = new LinkedList<ImageInfo>();
            foreach (FileInfo file in fileArray)
            {
                ImageInfo imageInfo = new ImageInfo();
                imageInfo.SortID = randnum.Next();
                imageInfo.ImagePath = file.FullName;

                InsertSorted(ref newList, ref imageInfo);
            }

            // Set the previous and current lists and assign the current node
            previousImageList = currentImageList;
            currentImageList = newList;
            currentNode = currentImageList.First;
        }

        private void InsertSorted(ref LinkedList<ImageInfo> list, ref ImageInfo newNode)
        {
            // if the list is empty or the new node has the lowest value, add it first
            if(list.First == null || list.First.Value.SortID > newNode.SortID)
            {
                list.AddFirst(newNode);
                return;
            }

            // if the new node has the largest value, insert last
            if(list.Last.Value.SortID < newNode.SortID)
            {
                list.AddLast(newNode);
                return;
            }

            // iterate through the nodes (starting from the second because we already know
            // it doesn't go before the first) and drop it in the appropriate place
            LinkedListNode<ImageInfo> compNode = list.First.Next;
            while(compNode.Value.SortID < newNode.SortID)
            {
                compNode = compNode.Next;
            }

            list.AddBefore(compNode, newNode);
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
            // If a directory has been selected and the user is trying to start the show
            if (!String.IsNullOrWhiteSpace(txtDirectory.Text) && btnShow.Text != "Pause")
            {
                //lock down the controls (except the interval selector), enable full screen
                //mode, start the timer, and show the first image
                startSlideShow();
            }
            else
            {
                //otherwise reset the controls back to the initial state
                stopSlideShow();
            }
        }

        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            // create a new full screen instance and put the current image into it
            fullScreenImage = new FullScreenImage(this);
            fullScreenImage.FileLocation = pictureBox.ImageLocation;
            fullScreenImage.Location = this.Location;

            fullScreenImage.Show();
        }

        public void btnBack_Click(object sender, EventArgs e)
        {
            stopSlideShow();
            showFromButtons();

            // if we don't have a manual "browsing" node, make it from the current one
            if (manualNode == null)
            {
                manualNode = currentNode;
            }

            if (previousImageList != null)
            {
                // go back to the end of the previous list
                if (manualNode == currentImageList.First)
                {
                    manualNode = previousImageList.Last;
                }
                // stop at the start of the previous list
                else if (manualNode != previousImageList.First)
                {
                    manualNode = manualNode.Previous;
                }
            }
            else
            {
                // stop at the start of the current list (no previous)
                if (manualNode != currentImageList.First)
                {
                    manualNode = manualNode.Previous;
                }
            }

            pictureBox.ImageLocation = manualNode.Value.ImagePath;
            if (fullScreenImage != null)
            {
                fullScreenImage.FileLocation = manualNode.Value.ImagePath;
            }
        }

        public void btnNext_Click(object sender, EventArgs e)
        {
            stopSlideShow();
            showFromButtons();
            // if we don't have a manual "browsing" node, make it from the current one
            if (manualNode == null)
            {
                manualNode = currentNode;
            }

            // wrap to the start of the current list from the previous
            if (previousImageList != null && manualNode == previousImageList.Last)
            {
                manualNode = currentImageList.First;
            }
            // stop at the end of the current list
            else if (manualNode != currentImageList.Last)
            {
                manualNode = manualNode.Next;
            }

            //TODO: clicking NEXT from the currentImageList.Last generates new list instead of stopping?
            //what happens if we try to go past the end of the new list?

            pictureBox.ImageLocation = manualNode.Value.ImagePath;
            if (fullScreenImage != null)
            {
                fullScreenImage.FileLocation = manualNode.Value.ImagePath;
            }
        }

        public void btnFromPaused_Click(object sender, EventArgs e)
        {
            startSlideShow();
        }

        public void btnFromHere_Click(object sender, EventArgs e)
        {
            currentNode = manualNode;
            startSlideShow();
        }

        #endregion

        #region Other Event Handlers

        private void folderBrowser_FileOk(object sender, CancelEventArgs e)
        {
            //when a folder is selected, put the path in the textbox
            txtDirectory.Text = Path.GetDirectoryName(folderBrowser.FileName);
        }

        private void numInterval_ValueChanged(object sender, EventArgs e)
        {
            // change the interval between images
            //timer.Stop();
            timer.Interval = ((int)numInterval.Value) * 1000;
            //timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // when the timer expires, show the next image
            showNextImage();
        }

        #endregion

        #region Supporting Functions

        private void startSlideShow()
        {
            btnShow.Text = "Pause";
            if (fullScreenImage != null)
            {
                fullScreenImage.setBtnShowText("||");
                fullScreenImage.showFromButtons = false;
            }
            btnShow.Visible = true;
            btnFromHere.Visible = false;
            btnFromPaused.Visible = false;
            btnFullScreen.Enabled = true;
            txtDirectory.Enabled = false;
            btnSelectFolder.Enabled = false;
            chkSubdirs.Enabled = false;
            if (currentNode == null)
            {
                showNextImage();
            }
            timer.Start();
        }

        private void stopSlideShow()
        {
            timer.Stop();
            btnShow.Text = "Resume";
            if (fullScreenImage != null)
            {
                fullScreenImage.setBtnShowText("▷");
            }
            btnFullScreen.Enabled = false;
            txtDirectory.Enabled = true;
            btnSelectFolder.Enabled = true;
            chkSubdirs.Enabled = true;
        }

        private void showFromButtons()
        {
            btnShow.Visible = false;
            btnFromHere.Visible = true;
            btnFromPaused.Visible = true;
            if (fullScreenImage != null)
            {
                fullScreenImage.showFromButtons = true;
            }
        }

        #endregion




    }
}
