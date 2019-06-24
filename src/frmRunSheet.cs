using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABSButler
{
    public partial class frmRunSheet : DevComponents.DotNetBar.Office2007Form
    {
        public frmRunSheet()
        {
            InitializeComponent();
        }

        public frmRunSheet(string subDir, string linksToIncludeWords, string timeSeriesPage, string lastWorkingURL) : this()
        {
            txtDownloadDir.Text = subDir;
            txtLinksToIncludeWords.Text = linksToIncludeWords;
            txtTimeSeriesPage.Text = timeSeriesPage;
            txtLastWorkingURL.Text = lastWorkingURL;
        }
        private void btnSaveDir_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK) txtDownloadDir.Text = folderBrowserDialog.SelectedPath;
        }

        private void btnScriptFile_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            txtLinksToIncludeWords.Text = openFileDialog.FileName;
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            this.Tag = "save";
            this.Hide();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Tag = "cancel";
            this.Hide();
        }

    }
}
