using PornHole.Models;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PornHole.Controllers
{
    public class PornHoleController : ApplicationContext
    {
        private IPornHoleView pornHoleView;
        private IFullScreenImageView fullScreenImageView;
        
        private bool fullScreenVisible = false;

        private Random randnum = new Random();
        private FileInfo[] fileArray;
        private LinkedList<ImageInfo> currentImageList;
        private LinkedList<ImageInfo> previousImageList;
        private LinkedListNode<ImageInfo> currentNode;
        private LinkedListNode<ImageInfo> manualNode;
        private String currentDir = "";
        private String newDir;
        private bool currentIncludeSubdirs = false;
        private bool newIncludeSubdirs;
        private Timer timer = new Timer();
        private bool showPlaying = false;

        public PornHoleController(IPornHoleView pornHoleView, IFullScreenImageView fullScreenImageView)
        {
            this.pornHoleView = pornHoleView;
            this.fullScreenImageView = fullScreenImageView;

            pornHoleView.setController(this);
            fullScreenImageView.setController(this);

            pornHoleView.setVisible(true);
            fullScreenImageView.setVisible(fullScreenVisible);

            this.timer.Tick += new System.EventHandler(this.timer_Tick);
        }

        public void exitApp()
        {
            Application.Exit();
        }

        #region Setters
        public void setDirectory(String directory)
        {
            newDir = directory;
        }

        public void setIncludeSubdirs(bool includeSubdirs)
        {
            newIncludeSubdirs = includeSubdirs;
        }

        public void setTimerInterval(int seconds)
        {
            timer.Interval = seconds * 1000;
        }
        #endregion

        private void showNextImage()
        {
            if (manualNode != null)
            {
                // to be in here, we know we also have a currentNode and a currentImageList.
                // If not, something is very wrong and we deserve to puke on any exceptions.

                // if we're back where we stopped the slideshow (or resuming from where we
                // stopped browsing), move to the next image. otherwise do nothing (causing
                // the "current" image from where we paused the slideshow to be shown next,
                // effectively resuming from there)
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
                // If we're in the normal flow of the slideshow, just cycle to the next image
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
                (!currentDir.Equals(newDir, StringComparison.CurrentCultureIgnoreCase)) ||
                !(newIncludeSubdirs == currentIncludeSubdirs))
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
            pornHoleView.setImage(currentNode.Value.ImagePath);
            fullScreenImageView.setImage(currentNode.Value.ImagePath);
        }

        #region File Loading Functions
        private void loadRandomizedImageList()
        {
            // if the selected directory or the option to include subdirs has changed, 
            // read in all the files in the directory/ies
            if (!currentDir.Equals(newDir, StringComparison.CurrentCultureIgnoreCase)
                || !(newIncludeSubdirs == currentIncludeSubdirs))
            {
                if (!loadFileList())
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

        private bool loadFileList()
        {
            // read in the file list from the selected directory and subdirs (if applicable)
            DirectoryInfo d = new DirectoryInfo(newDir);
            try
            {
                if (newIncludeSubdirs)
                {
                    fileArray = d.GetFiles("*", SearchOption.AllDirectories);
                }
                else
                {
                    fileArray = d.GetFiles();
                }
                currentDir = newDir;
                currentIncludeSubdirs = newIncludeSubdirs;
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

        private void InsertSorted(ref LinkedList<ImageInfo> list, ref ImageInfo newNode)
        {
            // if the list is empty or the new node has the lowest value, add it first
            if (list.First == null || list.First.Value.SortID > newNode.SortID)
            {
                list.AddFirst(newNode);
                return;
            }

            // if the new node has the largest value, insert last
            if (list.Last.Value.SortID < newNode.SortID)
            {
                list.AddLast(newNode);
                return;
            }

            // iterate through the nodes (starting from the second because we already know
            // it doesn't go before the first) and drop it in the appropriate place
            LinkedListNode<ImageInfo> compNode = list.First.Next;
            while (compNode.Value.SortID < newNode.SortID)
            {
                compNode = compNode.Next;
            }

            list.AddBefore(compNode, newNode);
        }
        #endregion

        #region Supporting Functions

        public void startSlideShow()
        {
            pornHoleView.setControlsToPlaying();
            fullScreenImageView.setControlsToPlaying();
            if (currentNode == null)
            {
                showNextImage();
            }
            timer.Start();
            showPlaying = true;
        }

        public void startSlideShowFromHere()
        {
            currentNode = manualNode;
            startSlideShow();
        }

        public void stopSlideShow()
        {
            showPlaying = false;
            timer.Stop();
            pornHoleView.setControlsToPaused();
            fullScreenImageView.setControlsToPaused();
        }

        public void showFullScreen(Point location)
        {
            fullScreenImageView.openAtLocation(location);
            fullScreenVisible = true;
        }

        public void hideFullScreen()
        {
            fullScreenVisible = false;
        }

        #endregion

        #region Button Clicked Event Handlers

        public void btnBackClicked()
        {
            stopSlideShow();
            pornHoleView.showFromButtons();
            fullScreenImageView.showFromButtons();

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

            pornHoleView.setImage(manualNode.Value.ImagePath);
            fullScreenImageView.setImage(manualNode.Value.ImagePath);
        }

        public void btnNextClicked()
        {
            stopSlideShow();
            pornHoleView.showFromButtons();
            fullScreenImageView.showFromButtons();

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

            pornHoleView.setImage(manualNode.Value.ImagePath);
            fullScreenImageView.setImage(manualNode.Value.ImagePath);
        }

        public void btnPlayPauseClicked()
        {
            // If a directory has been selected and the user is trying to start the show
            if (!String.IsNullOrWhiteSpace(newDir) && !showPlaying)
            {
                startSlideShow();
            }
            else
            {
                stopSlideShow();
            }
        }

        #endregion

        #region Other Event Handlers

        private void timer_Tick(object sender, EventArgs e)
        {
            showNextImage();
        }

        

        #endregion
    }
}
