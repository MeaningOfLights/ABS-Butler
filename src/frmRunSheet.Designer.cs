namespace ABSButler
{
    partial class frmRunSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRunSheet));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLastWorkingURL = new System.Windows.Forms.TextBox();
            this.btnSaveDir = new DevComponents.DotNetBar.ButtonX();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLinksToIncludeWords = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimeSeriesPage = new System.Windows.Forms.TextBox();
            this.txtDownloadDir = new System.Windows.Forms.TextBox();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.btnSaveSettings = new DevComponents.DotNetBar.ButtonX();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtLastWorkingURL);
            this.groupBox1.Controls.Add(this.btnSaveDir);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtLinksToIncludeWords);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTimeSeriesPage);
            this.groupBox1.Controls.Add(this.txtDownloadDir);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(894, 171);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Last Working URL:";
            // 
            // txtLastWorkingURL
            // 
            this.txtLastWorkingURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastWorkingURL.Location = new System.Drawing.Point(127, 135);
            this.txtLastWorkingURL.Name = "txtLastWorkingURL";
            this.txtLastWorkingURL.Size = new System.Drawing.Size(709, 20);
            this.txtLastWorkingURL.TabIndex = 20;
            // 
            // btnSaveDir
            // 
            this.btnSaveDir.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDir.Location = new System.Drawing.Point(842, 19);
            this.btnSaveDir.Name = "btnSaveDir";
            this.btnSaveDir.Size = new System.Drawing.Size(37, 20);
            this.btnSaveDir.TabIndex = 19;
            this.btnSaveDir.Text = "...";
            this.btnSaveDir.Click += new System.EventHandler(this.btnSaveDir_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Links to Include Words:";
            // 
            // txtLinksToIncludeWords
            // 
            this.txtLinksToIncludeWords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLinksToIncludeWords.Location = new System.Drawing.Point(127, 60);
            this.txtLinksToIncludeWords.Name = "txtLinksToIncludeWords";
            this.txtLinksToIncludeWords.Size = new System.Drawing.Size(709, 20);
            this.txtLinksToIncludeWords.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Time Series Page:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Directory to Download:";
            // 
            // txtTimeSeriesPage
            // 
            this.txtTimeSeriesPage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimeSeriesPage.Location = new System.Drawing.Point(127, 98);
            this.txtTimeSeriesPage.Name = "txtTimeSeriesPage";
            this.txtTimeSeriesPage.Size = new System.Drawing.Size(709, 20);
            this.txtTimeSeriesPage.TabIndex = 13;
            // 
            // txtDownloadDir
            // 
            this.txtDownloadDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDownloadDir.Location = new System.Drawing.Point(127, 19);
            this.txtDownloadDir.Name = "txtDownloadDir";
            this.txtDownloadDir.Size = new System.Drawing.Size(709, 20);
            this.txtDownloadDir.TabIndex = 14;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonX2.Location = new System.Drawing.Point(617, 198);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(140, 36);
            this.buttonX2.TabIndex = 11;
            this.buttonX2.Text = "Cancel";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.Location = new System.Drawing.Point(763, 198);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(143, 36);
            this.btnSaveSettings.TabIndex = 10;
            this.btnSaveSettings.Text = "OK";
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // frmRunSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 240);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRunSheet";
            this.Text = "Run Sheet Item";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtTimeSeriesPage;
        public System.Windows.Forms.TextBox txtDownloadDir;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX btnSaveSettings;
        private DevComponents.DotNetBar.ButtonX btnSaveDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox txtLinksToIncludeWords;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtLastWorkingURL;
    }
}