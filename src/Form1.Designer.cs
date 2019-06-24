namespace ABSButler
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSendTest = new DevComponents.DotNetBar.ButtonX();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cboMaxMonths = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPopulateDirectory = new DevComponents.DotNetBar.ButtonX();
            this.btnHelp = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmailAlerts = new System.Windows.Forms.TextBox();
            this.btnSaveSettings = new DevComponents.DotNetBar.ButtonX();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.mnuGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenURL = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGo = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmailFromPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSMTPHost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSMTPDomain = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSMTPPort = new System.Windows.Forms.TextBox();
            this.chkTLS = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.mnuGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkTLS);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtSMTPPort);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSMTPDomain);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSMTPHost);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEmailFromPassword);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEmailFrom);
            this.groupBox1.Controls.Add(this.btnSendTest);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.cboMaxMonths);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnPopulateDirectory);
            this.groupBox1.Controls.Add(this.btnHelp);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtEmailAlerts);
            this.groupBox1.Controls.Add(this.btnSaveSettings);
            this.groupBox1.Controls.Add(this.dgv);
            this.groupBox1.Controls.Add(this.btnGo);
            this.groupBox1.Location = new System.Drawing.Point(8, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1001, 674);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ABS Butler";
            // 
            // btnSendTest
            // 
            this.btnSendTest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSendTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendTest.Location = new System.Drawing.Point(659, 18);
            this.btnSendTest.Name = "btnSendTest";
            this.btnSendTest.Size = new System.Drawing.Size(96, 21);
            this.btnSendTest.TabIndex = 20;
            this.btnSendTest.Text = "Send Test";
            this.btnSendTest.Click += new System.EventHandler(this.btnSendTest_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(417, 633);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(426, 35);
            this.progressBar1.TabIndex = 19;
            // 
            // cboMaxMonths
            // 
            this.cboMaxMonths.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMaxMonths.FormattingEnabled = true;
            this.cboMaxMonths.Location = new System.Drawing.Point(897, 20);
            this.cboMaxMonths.Name = "cboMaxMonths";
            this.cboMaxMonths.Size = new System.Drawing.Size(95, 21);
            this.cboMaxMonths.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(761, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Max Months to look back:";
            // 
            // btnPopulateDirectory
            // 
            this.btnPopulateDirectory.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPopulateDirectory.Location = new System.Drawing.Point(0, 0);
            this.btnPopulateDirectory.Name = "btnPopulateDirectory";
            this.btnPopulateDirectory.Size = new System.Drawing.Size(0, 0);
            this.btnPopulateDirectory.TabIndex = 21;
            // 
            // btnHelp
            // 
            this.btnHelp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnHelp.Location = new System.Drawing.Point(10, 632);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(99, 36);
            this.btnHelp.TabIndex = 2;
            this.btnHelp.Text = "Help";
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(115, 632);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(177, 36);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "New ABS page to download";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Email Reports to:";
            // 
            // txtEmailAlerts
            // 
            this.txtEmailAlerts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailAlerts.Location = new System.Drawing.Point(102, 19);
            this.txtEmailAlerts.Name = "txtEmailAlerts";
            this.txtEmailAlerts.Size = new System.Drawing.Size(549, 20);
            this.txtEmailAlerts.TabIndex = 0;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveSettings.Location = new System.Drawing.Point(298, 632);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(113, 36);
            this.btnSaveSettings.TabIndex = 4;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.ContextMenuStrip = this.mnuGrid;
            this.dgv.Location = new System.Drawing.Point(10, 74);
            this.dgv.Name = "dgv";
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(983, 552);
            this.dgv.TabIndex = 7;
            this.dgv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDown);
            // 
            // mnuGrid
            // 
            this.mnuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.mnuOpenURL});
            this.mnuGrid.Name = "mnuGrid";
            this.mnuGrid.Size = new System.Drawing.Size(128, 48);
            // 
            // mnuEdit
            // 
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(127, 22);
            this.mnuEdit.Text = "Edit";
            this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
            // 
            // mnuOpenURL
            // 
            this.mnuOpenURL.Name = "mnuOpenURL";
            this.mnuOpenURL.Size = new System.Drawing.Size(127, 22);
            this.mnuOpenURL.Text = "Open URL";
            this.mnuOpenURL.Click += new System.EventHandler(this.mnuOpenURL_Click);
            // 
            // btnGo
            // 
            this.btnGo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(849, 632);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(144, 36);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "GO - Download latest files!";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "From Email:";
            // 
            // txtEmailFrom
            // 
            this.txtEmailFrom.Location = new System.Drawing.Point(73, 48);
            this.txtEmailFrom.Name = "txtEmailFrom";
            this.txtEmailFrom.Size = new System.Drawing.Size(138, 20);
            this.txtEmailFrom.TabIndex = 22;
            this.txtEmailFrom.Text = "You@gmail.com";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(216, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "From Email Password:";
            // 
            // txtEmailFromPassword
            // 
            this.txtEmailFromPassword.Location = new System.Drawing.Point(328, 48);
            this.txtEmailFromPassword.Name = "txtEmailFromPassword";
            this.txtEmailFromPassword.PasswordChar = '*';
            this.txtEmailFromPassword.Size = new System.Drawing.Size(100, 20);
            this.txtEmailFromPassword.TabIndex = 24;
            this.txtEmailFromPassword.Text = "12312";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(434, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "SMTP Host:";
            // 
            // txtSMTPHost
            // 
            this.txtSMTPHost.Location = new System.Drawing.Point(501, 48);
            this.txtSMTPHost.Name = "txtSMTPHost";
            this.txtSMTPHost.Size = new System.Drawing.Size(102, 20);
            this.txtSMTPHost.TabIndex = 26;
            this.txtSMTPHost.Text = "smtp.gmail.com";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(608, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "SMTP Domain:";
            // 
            // txtSMTPDomain
            // 
            this.txtSMTPDomain.Location = new System.Drawing.Point(691, 48);
            this.txtSMTPDomain.Name = "txtSMTPDomain";
            this.txtSMTPDomain.Size = new System.Drawing.Size(94, 20);
            this.txtSMTPDomain.TabIndex = 28;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(798, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "SMTP Port:";
            // 
            // txtSMTPPort
            // 
            this.txtSMTPPort.Location = new System.Drawing.Point(862, 48);
            this.txtSMTPPort.Name = "txtSMTPPort";
            this.txtSMTPPort.Size = new System.Drawing.Size(34, 20);
            this.txtSMTPPort.TabIndex = 30;
            this.txtSMTPPort.Text = "25";
            // 
            // chkTLS
            // 
            this.chkTLS.AutoSize = true;
            this.chkTLS.Location = new System.Drawing.Point(914, 50);
            this.chkTLS.Name = "chkTLS";
            this.chkTLS.Size = new System.Drawing.Size(74, 17);
            this.chkTLS.TabIndex = 32;
            this.chkTLS.Text = "Email TLS";
            this.chkTLS.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 696);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "ABS Butler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.mnuGrid.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv;
        private DevComponents.DotNetBar.ButtonX btnGo;
        private DevComponents.DotNetBar.ButtonX btnSaveSettings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmailAlerts;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevComponents.DotNetBar.ButtonX btnHelp;
        private DevComponents.DotNetBar.ButtonX btnPopulateDirectory;
        private System.Windows.Forms.ComboBox cboMaxMonths;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip mnuGrid;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenURL;
        private System.Windows.Forms.ProgressBar progressBar1;
        private DevComponents.DotNetBar.ButtonX btnSendTest;
        private System.Windows.Forms.CheckBox chkTLS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSMTPPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSMTPDomain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSMTPHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmailFromPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmailFrom;
    }
}

