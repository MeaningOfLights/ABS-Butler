using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ABSButler
{
    public partial class frmMain : DevComponents.DotNetBar.Office2007Form
    {
        private JSONConfig jsonConfigObj = new JSONConfig();
        private bool AutoRunFromCommandLineParameter = false;
        private DataTable dataTable = new DataTable();

        public frmMain(string[] args)
        {
            InitializeComponent();

            if (args?.Length > 0)
            {
                //Kick off the job as its being run from a Scheduled Task
                AutoRunFromCommandLineParameter = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //Note no need to test these private methods, espcially if they populate 4 obvious fields on App Start Up
                LoadConfiguration();
                LoadRunSheet();
                
                if (AutoRunFromCommandLineParameter)
                {
                    btnGo_Click(null, null);
                    Environment.Exit(0);
                }

                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                string version = fvi.FileVersion;
                this.Text = "ABS Butler v" + version;
            }
            catch (Exception ex)
            {
                EmailSMTP.SendEmail(jsonConfigObj.EmailAlerts, "", "", "Exception in ABSButler!! Form1_Load", "Message: " + ex.Message + "<BR><BR>StackTrace:<BR>" + ex.StackTrace, null, jsonConfigObj.FromEmail, jsonConfigObj.SMTPPassword, jsonConfigObj.SMTPDomain, jsonConfigObj.SMTPHost, jsonConfigObj.SMTPPort, jsonConfigObj.SMTPTLSEnabled);
            }
        }

        private void LoadConfiguration()
        {
            string configJSONFile = Path.Combine(Application.StartupPath.Replace("\\bin\\Debug", ""), "Configuration.json");
            if (!File.Exists(configJSONFile))
            {
                MessageBox.Show("The Configuration.json file does not exist in the Applications Startup Folder: " + Application.StartupPath + Environment.NewLine + Environment.NewLine + "ABSButler will now quit.", "Cannot find config file...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(1);
            }

            try
            {
                for (int i = 0; i < 25; i++) cboMaxMonths.Items.Add(i.ToString());

                string jsonConfigFileContents = FileHelper.ReadFileTextWithEncoding(configJSONFile);
                jsonConfigObj = fastJSON.JSON.ToObject<JSONConfig>(jsonConfigFileContents);
                txtEmailAlerts.Text = jsonConfigObj.EmailAlerts;
                txtEmailFrom.Text = jsonConfigObj.FromEmail;
                txtSMTPHost.Text =jsonConfigObj.SMTPHost;
                txtSMTPDomain.Text = jsonConfigObj.SMTPDomain;
                txtEmailFromPassword.Text = jsonConfigObj.SMTPPassword;
                txtSMTPPort.Text = jsonConfigObj.SMTPPort.ToString();
                chkTLS.Checked = Convert.ToBoolean(jsonConfigObj.SMTPTLSEnabled);
                cboMaxMonths.SelectedIndex = Convert.ToInt32(jsonConfigObj.MaxMonthsToLookBack);
            }
            catch (Exception ex)
            {
                if (AutoRunFromCommandLineParameter)
                {
                    EmailSMTP.SendEmail(jsonConfigObj.EmailAlerts, "", "", "ABSButler Error", "WARNING: The Configuration.json file failed to load, Exception: " + ex.Message + "<BR><BR>StackTrace:<BR>" + ex.StackTrace, null, jsonConfigObj.FromEmail, jsonConfigObj.SMTPPassword, jsonConfigObj.SMTPDomain, jsonConfigObj.SMTPHost, jsonConfigObj.SMTPPort, jsonConfigObj.SMTPTLSEnabled);
                }
                else
                {
                    MessageBox.Show("The Configuration.json file failed to load, Exception: " + ex.Message + Environment.NewLine + Environment.NewLine + "ABSButler will now quit.", "Failed to load config file...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                Environment.Exit(2);
            }
        }

        private void LoadRunSheet()
        {
            string runSheetFile = Path.Combine(Application.StartupPath.Replace("\\bin\\Debug", ""), "RunSheet.tsv");
            if (!File.Exists(runSheetFile))
            {
                if (AutoRunFromCommandLineParameter)
                {
                    EmailSMTP.SendEmail(jsonConfigObj.EmailAlerts, "", "", "ABSButler Error", "WARNING: The " + DownloadHelper.ABSFILETORUNCSV + " file does not exist in the Applications Startup Folder: " + Application.StartupPath + Environment.NewLine + Environment.NewLine + "ABSButler will now quit.", null, jsonConfigObj.FromEmail, jsonConfigObj.SMTPPassword, jsonConfigObj.SMTPDomain, jsonConfigObj.SMTPHost, jsonConfigObj.SMTPPort, jsonConfigObj.SMTPTLSEnabled);
                }
                else
                {
                    MessageBox.Show("The RunSheet.tsv file does not exist in the Applications Startup Folder: " + Application.StartupPath + Environment.NewLine + Environment.NewLine + "ABSButler will now quit.", "Cannot find run sheet file...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                    Environment.Exit(3);
            }

            List<string[]> rows = FileHelper.ReadFileTextWithEncoding(runSheetFile).Split(new string[] { Environment.NewLine }, StringSplitOptions.None).Select(x => x.Split('\t')).ToList();
            
            dataTable.Columns.Add("Directory to Download");
            dataTable.Columns.Add("Links Include Words");
            dataTable.Columns.Add("Time Series Page");
            dataTable.Columns.Add("Last Working URL");
            try
            {
                //Skip the header record in the RunSheet.tsv file and load the remaining records into a DataTable
                rows.Skip(1).ToList().ForEach(x => { dataTable.Rows.Add(x); });
            }
            catch (Exception ex)
            {
                if (AutoRunFromCommandLineParameter)
                {
                    EmailSMTP.SendEmail(jsonConfigObj.EmailAlerts, "", "", "ABSButler Error", "WARNING: The " + DownloadHelper.ABSFILETORUNCSV + " file failed to load, Exception: " + ex.Message + "<BR><BR>StackTrace:<BR>" + ex.StackTrace, null, jsonConfigObj.FromEmail, jsonConfigObj.SMTPPassword, jsonConfigObj.SMTPDomain, jsonConfigObj.SMTPHost, jsonConfigObj.SMTPPort, jsonConfigObj.SMTPTLSEnabled);
                }
                else
                {
                    MessageBox.Show("The RunSheet.tsv file failed to load, Exception: " + ex.Message + Environment.NewLine + Environment.NewLine + "ABSButler will now quit.", "Failed to load config file...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Environment.Exit(4);
            }

            if (string.IsNullOrEmpty(dataTable.Rows[dataTable.Rows.Count-1][0].ToString())) dataTable.Rows.RemoveAt(dataTable.Rows.Count-1);
            dgv.DataSource = dataTable;
            
            dgv.Columns[0].Width = 790;
            dgv.Columns[1].Width = 125;
            dgv.Columns[2].Width = 124;
            dgv.Columns[3].Width = 543;

            progressBar1.Maximum = dataTable.Rows.Count;
        }
        
        private void btnGo_Click(object sender, EventArgs e)
        {

            //Check if there are old files first - we need to compare and have a baseline!
            var dlHelp = new DownloadHelper(jsonConfigObj);
            dlHelp.UpdateProgress = UpdateProgress;
            string errors = dlHelp.DownloadOldABSFiles(Application.StartupPath);
            if (!string.IsNullOrEmpty(errors))
            {
                MessageBox.Show("Problem initially downloading files. Error occurred executing " + DownloadHelper.ABSFILETORUNCSV + ".\r\n\r\n" + errors, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dlHelp.ReportFailures(Application.StartupPath, jsonConfigObj.EmailAlerts, jsonConfigObj.FromEmail);
                return;
            }

            //Run it
            dlHelp.UpdateLastWorkingTimeSeries = UpdateLastWorkingTimeSeries;
            errors = dlHelp.DownloadRunSheetABSFiles(Application.StartupPath, (int)cboMaxMonths.SelectedIndex);
            SaveRunSheet();
            if (!string.IsNullOrEmpty(errors))
            {
                MessageBox.Show("An error occurred executing " + DownloadHelper.ABSFILETORUNCSV +  ".\r\n\r\n" + errors, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dlHelp.ReportFailures(Application.StartupPath, jsonConfigObj.EmailAlerts, jsonConfigObj.FromEmail);
            progressBar1.Value = progressBar1.Maximum;

            if (!AutoRunFromCommandLineParameter) MessageBox.Show(DownloadHelper.ABSFILETORUNCSV + " successfully processed!", "Successfully run.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            string configJSONFile = Path.Combine(Application.StartupPath.Replace("\\bin\\Debug", ""), "Configuration.json");
            jsonConfigObj.EmailAlerts = txtEmailAlerts.Text;
            jsonConfigObj.FromEmail = txtEmailFrom.Text;
            jsonConfigObj.SMTPHost = txtSMTPHost.Text;
            jsonConfigObj.SMTPDomain = txtSMTPDomain.Text;
            jsonConfigObj.SMTPPassword = txtEmailFromPassword.Text;
            bool isRealNumberPort = int.TryParse(txtSMTPPort.Text, out int port);
            if (isRealNumberPort)jsonConfigObj.SMTPPort = port;
            jsonConfigObj.SMTPTLSEnabled = chkTLS.Checked;
            jsonConfigObj.MaxMonthsToLookBack = cboMaxMonths.SelectedIndex.ToString();
            
            string jsonSettings = fastJSON.JSON.ToNiceJSON(jsonConfigObj);
            File.WriteAllText(configJSONFile, jsonSettings);

            LoadConfiguration();

            if (SaveRunSheet())
            {
                MessageBox.Show("Settings updated and saved Successfully!", "Save Settings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Save settings failed!\r\nPlease close the " + DownloadHelper.ABSFILETORUNCSV + " and make sure the file exists.", "Save Settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private bool SaveRunSheet()
        {
            try
            {
                string runSheetTSVFile = Path.Combine(Application.StartupPath.Replace("\\bin\\Debug", ""), DownloadHelper.ABSFILETORUNCSV);

                var sb = new StringBuilder();
                var headers = dgv.Columns.Cast<DataGridViewColumn>();
                sb.AppendLine(string.Join("\t", headers.Select(column => column.HeaderText).ToArray()));
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (string.IsNullOrEmpty(row.Cells[0].ToString())) continue;
                    var cells = row.Cells.Cast<DataGridViewCell>();
                    sb.AppendLine(string.Join("\t", cells.Select(cell =>  cell.Value ).ToArray()));
                }
                File.WriteAllText(runSheetTSVFile, sb.ToString());
            }
            catch (Exception ex)
            {
                if (AutoRunFromCommandLineParameter)
                {
                    EmailSMTP.SendEmail(jsonConfigObj.EmailAlerts, "", "", "ABSButler Error", "WARNING: You need to make sure the " + DownloadHelper.ABSFILETORUNCSV + " file has Read Write permissions. Exception: " + ex.Message + "<BR><BR>StackTrace:<BR>" + ex.StackTrace, null, jsonConfigObj.FromEmail, jsonConfigObj.SMTPPassword, jsonConfigObj.SMTPDomain, jsonConfigObj.SMTPHost, jsonConfigObj.SMTPPort, jsonConfigObj.SMTPTLSEnabled);
                }
                else
                {
                    MessageBox.Show("WARNING: You need to make sure the " + DownloadHelper.ABSFILETORUNCSV + " file has Read Write permissions otherwise you will download all files from the ABS everyday! Exception: " + ex.Message);
                }

                return false;
            }
            return true;
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            LoadConfiguration();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmRunSheet runSheet = new frmRunSheet();
            runSheet.ShowDialog();
            if (runSheet.Tag == null) return;
            if (runSheet.Tag.ToString() == "save")
            {
                dataTable.Rows.Add(runSheet.txtDownloadDir.Text, runSheet.txtLinksToIncludeWords.Text, runSheet.txtTimeSeriesPage.Text);
                SaveRunSheet();
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(Application.StartupPath.Replace("\\bin\\Debug", ""), "Help.docx"));
        }
        
        int currentMouseOverRow = 0;
 
        private void dgv_MouseDown(object sender, MouseEventArgs e)
        {
            currentMouseOverRow = dgv.HitTest(e.X, e.Y).RowIndex;
            dgv.ClearSelection();
            if (currentMouseOverRow >= 0) dgv.Rows[currentMouseOverRow].Selected = true;
        }

        private void mnuEdit_Click(object sender, EventArgs e)
        {
            if (currentMouseOverRow >= 0)
            {
                frmRunSheet runSheet = new frmRunSheet(dgv[0, currentMouseOverRow].Value.ToString(), dgv[1, currentMouseOverRow].Value.ToString(), dgv[2, currentMouseOverRow].Value.ToString(), dgv[3, currentMouseOverRow].Value.ToString());
                runSheet.ShowDialog();

                if (runSheet.Tag == null) return;
                if (runSheet.Tag.ToString() == "save")
                {
                    dgv[0, currentMouseOverRow].Value = runSheet.txtDownloadDir.Text;
                    dgv[1, currentMouseOverRow].Value = runSheet.txtLinksToIncludeWords.Text;
                    dgv[2, currentMouseOverRow].Value = runSheet.txtTimeSeriesPage.Text;
                    dgv[3, currentMouseOverRow].Value = runSheet.txtLastWorkingURL.Text;
                    SaveRunSheet();
                }
            }
        }

        private void mnuOpenURL_Click(object sender, EventArgs e)
        {
            if (currentMouseOverRow >= 0)
            {
                if (!string.IsNullOrEmpty(dgv[3, currentMouseOverRow].Value.ToString()))
                {
                    Process.Start(dgv[3, currentMouseOverRow].Value.ToString());
                }
            }
        }
        
        public void UpdateProgress(int indexInGrid)
        {
            dgv.ClearSelection();
            if (indexInGrid >= 0) dgv.Rows[indexInGrid - 1].Selected = true;
            dgv.FirstDisplayedScrollingRowIndex = indexInGrid - 1;
            dgv.Refresh();
            progressBar1.Value = indexInGrid - 1;
        }

        public void UpdateLastWorkingTimeSeries(int indexInGrid, string lastWorkingTimeSeriesPage)
        {            
            if (indexInGrid >= 0) dgv[3,indexInGrid - 1].Value = lastWorkingTimeSeriesPage;
        }

        private void btnSendTest_Click(object sender, EventArgs e)
        {
            EmailSMTP.SendEmail(txtEmailAlerts.Text, "", "", "ABSButler Report", "TEST", null, jsonConfigObj.FromEmail, jsonConfigObj.SMTPPassword, jsonConfigObj.SMTPDomain, jsonConfigObj.SMTPHost, jsonConfigObj.SMTPPort, jsonConfigObj.SMTPTLSEnabled);
        }
    }
}
