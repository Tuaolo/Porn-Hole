namespace PornHole.Views
{
    partial class PornHoleView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PornHoleView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.lblExitFullScreen = new System.Windows.Forms.Label();
            this.btnFromPaused = new System.Windows.Forms.Button();
            this.btnFromHere = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.chkSubdirs = new System.Windows.Forms.CheckBox();
            this.btnFullScreen = new System.Windows.Forms.Button();
            this.lblDirectory = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.lblInterval = new System.Windows.Forms.Label();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.folderBrowser = new System.Windows.Forms.OpenFileDialog();
            this.ttpOpenFile = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpenFile);
            this.panel1.Controls.Add(this.lblExitFullScreen);
            this.panel1.Controls.Add(this.btnFromPaused);
            this.panel1.Controls.Add(this.btnFromHere);
            this.panel1.Controls.Add(this.btnNext);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.chkSubdirs);
            this.panel1.Controls.Add(this.btnFullScreen);
            this.panel1.Controls.Add(this.lblDirectory);
            this.panel1.Controls.Add(this.btnSelectFolder);
            this.panel1.Controls.Add(this.txtDirectory);
            this.panel1.Controls.Add(this.btnShow);
            this.panel1.Controls.Add(this.lblInterval);
            this.panel1.Controls.Add(this.numInterval);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(324, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 296);
            this.panel1.TabIndex = 0;
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.BackgroundImage = global::PornHole.Properties.Resources.Hopstarter_Soft_Scraps_Folder_Open_256;
            this.btnOpenFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenFile.Location = new System.Drawing.Point(5, 260);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(30, 30);
            this.btnOpenFile.TabIndex = 13;
            this.ttpOpenFile.SetToolTip(this.btnOpenFile, "Open File in Folder");
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // lblExitFullScreen
            // 
            this.lblExitFullScreen.AutoSize = true;
            this.lblExitFullScreen.Location = new System.Drawing.Point(66, 280);
            this.lblExitFullScreen.Name = "lblExitFullScreen";
            this.lblExitFullScreen.Size = new System.Drawing.Size(185, 13);
            this.lblExitFullScreen.TabIndex = 12;
            this.lblExitFullScreen.Text = "*ESC or Right-Click to exit Full Screen";
            // 
            // btnFromPaused
            // 
            this.btnFromPaused.Location = new System.Drawing.Point(180, 154);
            this.btnFromPaused.Name = "btnFromPaused";
            this.btnFromPaused.Size = new System.Drawing.Size(117, 28);
            this.btnFromPaused.TabIndex = 11;
            this.btnFromPaused.Text = "Resume from Paused";
            this.btnFromPaused.UseVisualStyleBackColor = true;
            this.btnFromPaused.Visible = false;
            this.btnFromPaused.Click += new System.EventHandler(this.btnFromPaused_Click);
            // 
            // btnFromHere
            // 
            this.btnFromHere.Location = new System.Drawing.Point(20, 154);
            this.btnFromHere.Name = "btnFromHere";
            this.btnFromHere.Size = new System.Drawing.Size(117, 28);
            this.btnFromHere.TabIndex = 10;
            this.btnFromHere.Text = "Resume from Here";
            this.btnFromHere.UseVisualStyleBackColor = true;
            this.btnFromHere.Visible = false;
            this.btnFromHere.Click += new System.EventHandler(this.btnFromHere_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(158, 192);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(43, 23);
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(99, 192);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(43, 23);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // chkSubdirs
            // 
            this.chkSubdirs.AutoSize = true;
            this.chkSubdirs.Location = new System.Drawing.Point(180, 43);
            this.chkSubdirs.Margin = new System.Windows.Forms.Padding(2);
            this.chkSubdirs.Name = "chkSubdirs";
            this.chkSubdirs.Size = new System.Drawing.Size(99, 17);
            this.chkSubdirs.TabIndex = 7;
            this.chkSubdirs.Text = "Include Subdirs";
            this.chkSubdirs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSubdirs.UseVisualStyleBackColor = true;
            this.chkSubdirs.CheckedChanged += new System.EventHandler(this.chkSubdirs_CheckedChanged);
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Enabled = false;
            this.btnFullScreen.Location = new System.Drawing.Point(110, 249);
            this.btnFullScreen.Margin = new System.Windows.Forms.Padding(2);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(84, 28);
            this.btnFullScreen.TabIndex = 6;
            this.btnFullScreen.Text = "Full Screen";
            this.btnFullScreen.UseVisualStyleBackColor = true;
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            // 
            // lblDirectory
            // 
            this.lblDirectory.AutoSize = true;
            this.lblDirectory.Location = new System.Drawing.Point(26, 43);
            this.lblDirectory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDirectory.Name = "lblDirectory";
            this.lblDirectory.Size = new System.Drawing.Size(49, 13);
            this.lblDirectory.TabIndex = 5;
            this.lblDirectory.Text = "Directory";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(200, 82);
            this.btnSelectFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(76, 19);
            this.btnSelectFolder.TabIndex = 4;
            this.btnSelectFolder.Text = "Select Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(28, 62);
            this.txtDirectory.Margin = new System.Windows.Forms.Padding(2);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(248, 20);
            this.txtDirectory.TabIndex = 3;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(122, 154);
            this.btnShow.Margin = new System.Windows.Forms.Padding(2);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(57, 28);
            this.btnShow.TabIndex = 2;
            this.btnShow.Text = "Start";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(26, 107);
            this.lblInterval.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(91, 13);
            this.lblInterval.TabIndex = 1;
            this.lblInterval.Text = "Interval (seconds)";
            // 
            // numInterval
            // 
            this.numInterval.Location = new System.Drawing.Point(122, 106);
            this.numInterval.Margin = new System.Windows.Forms.Padding(2);
            this.numInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(38, 20);
            this.numInterval.TabIndex = 0;
            this.numInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInterval.ValueChanged += new System.EventHandler(this.numInterval_ValueChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(324, 296);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // folderBrowser
            // 
            this.folderBrowser.CheckFileExists = false;
            this.folderBrowser.FileName = "Folder Selection.";
            this.folderBrowser.ValidateNames = false;
            this.folderBrowser.FileOk += new System.ComponentModel.CancelEventHandler(this.folderBrowser_FileOk);
            // 
            // PornHoleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 296);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PornHoleView";
            this.Text = "Porn Hole";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PornHoleView_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.Label lblDirectory;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.OpenFileDialog folderBrowser;
        private System.Windows.Forms.Button btnFullScreen;
        private System.Windows.Forms.CheckBox chkSubdirs;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFromPaused;
        private System.Windows.Forms.Button btnFromHere;
        private System.Windows.Forms.Label lblExitFullScreen;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.ToolTip ttpOpenFile;
    }
}

