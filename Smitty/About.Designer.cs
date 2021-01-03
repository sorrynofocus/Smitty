namespace Smitty
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonAboutClose = new System.Windows.Forms.Button();
            this.labelAboutTitle = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(11, 164);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(311, 20);
            this.textBoxDescription.TabIndex = 0;
            this.textBoxDescription.Text = " C:\\ProgramData\\Microsoft\\Crypto\\RSA\\MachineKeys\\517efac85db7042e2b9ae54b76f4e58d" +
    "_3f9d48c8-592d-44ea-8b04-7e4d589b5d67";
            this.textBoxDescription.Visible = false;
            // 
            // buttonAboutClose
            // 
            this.buttonAboutClose.Location = new System.Drawing.Point(9, 155);
            this.buttonAboutClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAboutClose.Name = "buttonAboutClose";
            this.buttonAboutClose.Size = new System.Drawing.Size(32, 24);
            this.buttonAboutClose.TabIndex = 1;
            this.buttonAboutClose.Text = "buttonAboutClose";
            this.buttonAboutClose.UseVisualStyleBackColor = true;
            this.buttonAboutClose.Visible = false;
            this.buttonAboutClose.Click += new System.EventHandler(this.ButtonAboutClose_Click);
            // 
            // labelAboutTitle
            // 
            this.labelAboutTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelAboutTitle.Location = new System.Drawing.Point(150, 51);
            this.labelAboutTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelAboutTitle.Name = "labelAboutTitle";
            this.labelAboutTitle.Size = new System.Drawing.Size(185, 69);
            this.labelAboutTitle.TabIndex = 2;
            this.labelAboutTitle.Text = "Smitty is a utility that can provide maintenance.  Use Smitty to gather drive inf" +
    "romation, find and remove files based on age, or extract packages.";
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(150, 9);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(94, 13);
            this.labelProductName.TabIndex = 4;
            this.labelProductName.Text = "labelProductName";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(180, 26);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(64, 13);
            this.labelVersion.TabIndex = 5;
            this.labelVersion.Text = "labelVersion";
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.AutoSize = true;
            this.labelCompanyName.Location = new System.Drawing.Point(171, 133);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(173, 13);
            this.labelCompanyName.TabIndex = 6;
            this.labelCompanyName.Text = "System maintenance interface utilty";
            // 
            // labelCopyright
            // 
            this.labelCopyright.AutoSize = true;
            this.labelCopyright.Location = new System.Drawing.Point(174, 149);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(69, 13);
            this.labelCopyright.TabIndex = 7;
            this.labelCopyright.Text = "Chris Winters";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(137, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 174);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelCompanyName);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelProductName);
            this.Controls.Add(this.labelAboutTitle);
            this.Controls.Add(this.buttonAboutClose);
            this.Controls.Add(this.textBoxDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonAboutClose;
        private System.Windows.Forms.Label labelAboutTitle;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}