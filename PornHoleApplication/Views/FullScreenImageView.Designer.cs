using System.Windows.Forms;
namespace PornHole.Views
{
    partial class FullScreenImageView
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
            this.bigPicture = new System.Windows.Forms.PictureBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.tmrMouseMove = new System.Windows.Forms.Timer(this.components);
            this.btnShow = new System.Windows.Forms.Button();
            this.btnFromHere = new System.Windows.Forms.Button();
            this.btnFromPaused = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bigPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // bigPicture
            // 
            this.bigPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bigPicture.Location = new System.Drawing.Point(0, 0);
            this.bigPicture.Name = "bigPicture";
            this.bigPicture.Size = new System.Drawing.Size(1426, 839);
            this.bigPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bigPicture.TabIndex = 0;
            this.bigPicture.TabStop = false;
            this.bigPicture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bigPicture_MouseMove);
            this.bigPicture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FullScreenImage_MouseUp);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("MS Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnBack.Location = new System.Drawing.Point(0, 394);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(57, 51);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<<";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("MS Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnNext.Location = new System.Drawing.Point(1369, 394);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(57, 51);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tmrMouseMove
            // 
            this.tmrMouseMove.Tick += new System.EventHandler(this.tmrMouseMove_Tick);
            // 
            // btnShow
            // 
            this.btnShow.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShow.BackColor = System.Drawing.Color.Transparent;
            this.btnShow.FlatAppearance.BorderSize = 0;
            this.btnShow.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnShow.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.Font = new System.Drawing.Font("MS Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnShow.Location = new System.Drawing.Point(685, 788);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(57, 51);
            this.btnShow.TabIndex = 3;
            this.btnShow.Text = "||";
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnFromHere
            // 
            this.btnFromHere.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFromHere.BackColor = System.Drawing.Color.Transparent;
            this.btnFromHere.FlatAppearance.BorderSize = 0;
            this.btnFromHere.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFromHere.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFromHere.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromHere.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromHere.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnFromHere.Location = new System.Drawing.Point(205, 796);
            this.btnFromHere.Name = "btnFromHere";
            this.btnFromHere.Size = new System.Drawing.Size(230, 40);
            this.btnFromHere.TabIndex = 4;
            this.btnFromHere.Text = "▷ from Here";
            this.btnFromHere.UseVisualStyleBackColor = false;
            this.btnFromHere.Visible = false;
            this.btnFromHere.Click += new System.EventHandler(this.btnFromHere_Click);
            // 
            // btnFromPaused
            // 
            this.btnFromPaused.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFromPaused.BackColor = System.Drawing.Color.Transparent;
            this.btnFromPaused.FlatAppearance.BorderSize = 0;
            this.btnFromPaused.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnFromPaused.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnFromPaused.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFromPaused.Font = new System.Drawing.Font("MS Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFromPaused.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnFromPaused.Location = new System.Drawing.Point(989, 796);
            this.btnFromPaused.Name = "btnFromPaused";
            this.btnFromPaused.Size = new System.Drawing.Size(230, 40);
            this.btnFromPaused.TabIndex = 5;
            this.btnFromPaused.Text = "▷ from Paused";
            this.btnFromPaused.UseVisualStyleBackColor = false;
            this.btnFromPaused.Visible = false;
            this.btnFromPaused.Click += new System.EventHandler(this.btnFromPaused_Click);
            // 
            // FullScreenImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1426, 839);
            this.Controls.Add(this.btnFromPaused);
            this.Controls.Add(this.btnFromHere);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.bigPicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FullScreenImage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FullScreenImage";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FullScreenImage_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bigPicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox bigPicture;
        private Button btnBack;
        private Button btnNext;
        private Timer tmrMouseMove;
        private Button btnShow;
        private Button btnFromHere;
        private Button btnFromPaused;
    }
}