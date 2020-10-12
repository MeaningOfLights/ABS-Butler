using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace ABSButler
{
    public class DownloadHelper
    {
        public const string ABSFILETORUNCSV = "RunSheet.tsv";
        public Action<int> UpdateProgress;
        public Action<int, string> UpdateLastWorkingTimeSeries;

        private WebClient wc = new WebClient();

        private List<string> RunSheetFailures = new List<string>();
        private JSONConfig jsonConfigObj = null;
        
        
       
        private string DEBUGUserPID = "EmployeeID";
        private string DEBUGPassword = "DEVPASSWORD";
        private string DEBUGDomain = "DEV";

        public DownloadHelper()
        {
            this.jsonConfigObj = jsonConfigObj;
        }

        public string DownloadOldABSFiles(string appStartupPath)
        {
            string timeSeriesPage = string.Empty;
            string lastTimeSeriesPage = string.Empty;
            string subDirectory = string.Empty;
            string error = string.Empty;
            try
            {
                //Check the RunSheet exists
                string configFile = Path.Combine(appStartupPath, ABSFILETORUNCSV);
                if (!File.Exists(configFile)) return ABSFILETORUNCSV + " file does not exist in the Applications Startup Folder: " + appStartupPath;

                //Open the configuration csv
                string[] filesToDownload = FileHelper.ReadFileTextWithEncoding(configFile).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                //Test to see the Config.csv file is in correct format
                if (!filesToDownload[0].Contains("Directory to Download") && !filesToDownload[0].Contains("Links to Include Words")) return "RunSheet.tsv file is not in correct format.";

                for (int lnCount = 1; lnCount < filesToDownload.Length; lnCount++)
                {
                    if (string.IsNullOrWhiteSpace(filesToDownload[lnCount])) continue;

                    string[] fileToDownload = filesToDownload[lnCount].Split('\t');
                    subDirectory = fileToDownload[0];
                    string[] linksIncludeKeywords = fileToDownload[1].Split(',');
                    timeSeriesPage = fileToDownload[2];
                    lastTimeSeriesPage = fileToDownload[3];

                    //Check the Download Sub Directory exists, if not create it
                    if (!Directory.Exists(subDirectory)) Directory.CreateDirectory(subDirectory);

                    UpdateProgress(lnCount);

                    //The very initial run we wont have the "old/last working in TSV file" spreadsheets downloaded 
                    //Here we check if the directory already exists - and assume if one of the files have been initially downloaded 
                    //we have inititally populated the directory and further runs we can see if there are later files to download.
                    if (Directory.GetFiles(subDirectory).Length > 0) continue;
                    
                    Download(lastTimeSeriesPage, subDirectory, linksIncludeKeywords, null);

                }
            }
            catch (Exception ex)
            {
                AddReportFailure("FF0000", "Error in processing OLD ABS Download: " + ex.Message, lastTimeSeriesPage, subDirectory, "");
                return ex.Message;
            }
            return "";
        }

        public string DownloadRunSheetABSFiles(string appStartupPath, int maxMonthsToLookBack)
        {
            string timeSeriesPage = string.Empty;
            string lastTimeSeriesPage = string.Empty; 
            string subDirectory = string.Empty;
            string error = string.Empty;
            string url = string.Empty;
            try
            {
                //Check the RunSheet exists
                string configFile = Path.Combine(appStartupPath, ABSFILETORUNCSV);
                if (!File.Exists(configFile)) return ABSFILETORUNCSV + " file does not exist in the Applications Startup Folder: " + appStartupPath;

                //Open the configuration csv
                string[] filesToDownload = FileHelper.ReadFileTextWithEncoding(configFile).Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                //Test to see the Config.csv file is in correct format
                if (!filesToDownload[0].Contains("Directory to Download") && !filesToDownload[0].Contains("Links to Include Words")) return "RunSheet.tsv file is not in correct format.";

                for (int lnCount = 1; lnCount < filesToDownload.Length; lnCount++)
                {
                    if (string.IsNullOrWhiteSpace(filesToDownload[lnCount])) continue;

                    string[] fileToDownload = filesToDownload[lnCount].Split('\t');
                    subDirectory = fileToDownload[0];
                    string[] linksIncludeKeywords = fileToDownload[1].Split(',');
                    timeSeriesPage = fileToDownload[2];
                    lastTimeSeriesPage = fileToDownload[3];

                    //Check the Download Sub Directory exists, if not create it
                    if (!Directory.Exists(subDirectory)) Directory.CreateDirectory(subDirectory);

                    UpdateProgress(lnCount);

                    //Check if the URL has a month in it, if it does the ABS might have released an update for a couple of months ago
                    //in this case we need to wind back the Month and Year till we get the same URL as the last successsful scan - this can be trick
                    bool downloadPage = false;
                    byte[] byteArray = null;

                    bool lookYearsInPast = timeSeriesPage.Contains("[yyyy]") && !timeSeriesPage.Contains("[M");
                    if (lookYearsInPast)
                    {
                        int yearsInPast = 0;
                        while (lookYearsInPast)
                        {
                            //Get the URL of the Spreadsheet to download considering months may be expressed as 3 or 4 chars
                            url = ReplaceTimeSeriesPageTokens(timeSeriesPage, 0, yearsInPast);
                            
                            //If its the same as the lastTimeSeriesPage skip to next file to download
                            if (url == lastTimeSeriesPage) break;

                            //Check if the ABS released stats for a few months ago
                            byteArray = TestForHTTP404(url);
                            if (byteArray != null)
                            {
                                downloadPage = true;
                                timeSeriesPage = url;
                                break;
                            }

                            yearsInPast++;
                            if (yearsInPast > 2) break;
                        }
                    }

                    bool lookMonthsInPast = timeSeriesPage.Contains("[M");
                    if (lookMonthsInPast && !lookYearsInPast)
                    {
                       
                        int monthsInPast = 0;
                        while (lookMonthsInPast)
                        {
                            string monthReplaced = string.Empty;
                            url = ReplaceTimeSeriesPageTokens(timeSeriesPage, monthsInPast);

                            //If its the same as the lastTimeSeriesPage skip to next file to download
                            if (url == lastTimeSeriesPage) break;
                            
                            //Check if the ABS released stats for a few months ago
                            byteArray = TestForHTTP404(url);
                            if (byteArray != null)
                            {
                                downloadPage = true;
                                timeSeriesPage = url;
                                break;
                            }

                            //The ABS do not have a consistent naming for pages with June and July vs Jun and Jul, so we try both
                            string month = GetMonthPageTokens(timeSeriesPage, monthsInPast);
                            byteArray = TestForInconsistentUrlFormats(ref url, month, lastTimeSeriesPage);
                            if (url == lastTimeSeriesPage) break;
                            if (byteArray != null)
                            {
                                downloadPage = true;
                                timeSeriesPage = url;
                                break;                            
                            }
                            
                            monthsInPast++;

                            if (monthsInPast > maxMonthsToLookBack) break;
                        };

                    }
                    else if (!lookMonthsInPast && !lookYearsInPast)
                    {
                        timeSeriesPage = ReplaceTimeSeriesPageTokens(timeSeriesPage);
                        if (timeSeriesPage != lastTimeSeriesPage)
                        {
                            byteArray = TestForHTTP404(timeSeriesPage);
                            if (byteArray != null)
                            {
                                downloadPage = true;
                            }
                        }
                    }

                    if (downloadPage)
                    {
                        bool success = Download(timeSeriesPage, subDirectory, linksIncludeKeywords, byteArray);
                        if (success) UpdateLastWorkingTimeSeries(lnCount, timeSeriesPage);
                    }
                }
            }
            catch (Exception ex)
            {
                AddReportFailure("FF0000", "Error in processing: " + ex.Message, timeSeriesPage, subDirectory, url);
                return ex.Message;
            }

            return "";
        }

        private byte[] TestForHTTP404(string url)
        {
            try
            {
            //For strict environments, typically Corp Netrworks you need to set the creds (if working in a dev environment) AND User Agent again
#if DEBUG
            wc.Credentials = new NetworkCredential(DEBUGUserPID, DEBUGPassword, DEBUGDomain);
#endif 
            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
            wc.Headers.Add("Accept-Charset", "ISO-8859-1");
        
                return wc.DownloadData(url);
            }
            catch (WebException webEx)
            {
                //A 404, keep trying
            }
            catch (Exception ex)
            {
                //Something else unknown, meh?
            }
            return null;
        }
        
        private byte[] TestForInconsistentUrlFormats(ref string url, string month, string lastTimeSeriesPage)
        {
            //May has 3 letters
            if (month.Length == 3) return null;

            string letterMonth3 = month.Substring(0,3);
            string letterMonth4 = month.Substring(0,4);
            string MonthLong = month;

            //The ABS do not have a consistent naming for pages with June and July vs Jun and Jul, so we try both
            if (url.Contains(letterMonth3))
            {
                string tempurl = url.Replace(letterMonth3, letterMonth4);

                //If its the same as the lastTimeSeriesPage skip to next file to download
                if (tempurl == lastTimeSeriesPage) return null;
                byte[] temp = TestForHTTP404(tempurl);

                if (temp != null)
                {
                    url = tempurl;
                    return temp;
                }

                tempurl = url.Replace(letterMonth3, MonthLong);

                //If its the same as the lastTimeSeriesPage skip to next file to download
                if (tempurl == lastTimeSeriesPage) return null;
                temp = TestForHTTP404(tempurl);
                if (temp != null)
                {
                    url = tempurl;
                    return temp;
                }
            }
            return null;
        }

        public string ReplaceTimeSeriesPageTokens(string url, int monthsToLookBack = 0, int yearsToLookBack = 0)
        {
            string replacedUrl = url;
            
            if (monthsToLookBack > 12)
            {
                yearsToLookBack = Convert.ToInt32(Math.Floor(monthsToLookBack / 12f));
                monthsToLookBack -= 12;
            }
            if (monthsToLookBack >= DateTime.Now.Month && yearsToLookBack == 0)
            {
                yearsToLookBack = Convert.ToInt32(Math.Floor((monthsToLookBack + (12 - DateTime.Now.Month)) / 12f));
            }

            //Due to Jun/June and Sep/Sept/September
            replacedUrl = replacedUrl.Replace("[MMM]", DateTime.Now.AddMonths(-monthsToLookBack).ToString("MMM"));
            replacedUrl = replacedUrl.Replace("[MM]", DateTime.Now.AddMonths(-monthsToLookBack).ToString("MM"));
            replacedUrl = replacedUrl.Replace("[M]", DateTime.Now.AddMonths(-monthsToLookBack).ToString("M"));

            replacedUrl = replacedUrl.Replace("[yyyy]", DateTime.Now.AddYears(-yearsToLookBack).ToString("yyyy"));
            replacedUrl = replacedUrl.Replace("[yy]", DateTime.Now.AddYears(-yearsToLookBack).ToString("yy"));

            //Replace Years
            for (int i = 1; i < 5; i++)
            {
                replacedUrl = replacedUrl.Replace("[yyyy-" + i.ToString() + "]", DateTime.Now.AddYears(-i).ToString("yyyy"));
                replacedUrl = replacedUrl.Replace("[yy-" + i.ToString() + "]", DateTime.Now.AddYears(-i).ToString("yy"));
            }

            return replacedUrl;
        }

        public string GetMonthPageTokens(string url, int monthsToLookBack = 0, int yearsToLookBack = 0)
        {
            string replacedUrl = url;

            if (monthsToLookBack > 12)
            {
                yearsToLookBack = Convert.ToInt32(Math.Floor(monthsToLookBack / 12f));
                monthsToLookBack -= 12;
            }
            if (monthsToLookBack >= DateTime.Now.Month && yearsToLookBack == 0)
            {
                yearsToLookBack = Convert.ToInt32(Math.Floor((monthsToLookBack + (12 - DateTime.Now.Month)) / 12f));
            }
            return DateTime.Now.AddMonths(-monthsToLookBack).ToString("MMMM");
        }

        public bool Download(string url, string destination, string[] keywordsInUrl, byte[] byteArray)
        {
            bool success = true;
            string fileName = string.Empty;
            string fileURL = string.Empty;
            try
            {                
                if (byteArray == null) byteArray = wc.DownloadData(url);
                string s = Encoding.UTF8.GetString(byteArray);

                foreach (LinkItem i in LinkFinder.Find(s))
                {
                    bool hasAllKeywordsInURL = true;
                    for (int j = 0; j < keywordsInUrl.Length; j++)
                    {
                        if (i.Href == null)
                        {
                            hasAllKeywordsInURL = false;
                            break;
                        }
                        else if (!i.Href.Contains(keywordsInUrl[j]))
                        {
                            hasAllKeywordsInURL = false;
                            break;
                        }
                    }

                    if (hasAllKeywordsInURL)
                    {
                        fileURL = i.Href;

                        //Sometimes this URL gets blocked: "http://www.ausstats.abs.gov.au/ausstats/ABS@Archive.nsf/0/99BB5EE4DB2659B2CA257FE10013B04B/$File/5232012.xls"
                        //So I've added exception handling at the file level - not the page level
                        try
                        {
                           //For strict environments, typically Corp Netrworks you need to set the creds (if working in a dev environment) AND User Agent again
#if DEBUG
                            wc.Credentials = new NetworkCredential(DEBUGUserPID, DEBUGPassword, DEBUGDomain);
#endif 
                            wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                            wc.Headers.Add("Accept-Charset", "ISO-8859-1");
        
                            var downloadFileByteArray = wc.DownloadData(fileURL);
                            
                            //Resort to naming the file based on the KeyWords found in the link
                            fileName = GetFileNameFromUrl(fileURL, keywordsInUrl, destination);
                             
                            File.WriteAllBytes(fileName, downloadFileByteArray);

                            AddReportFailure("00AA00", "Updated  Successfully!", fileName, fileURL, url);

                        }
                        catch (Exception Ex)
                        {
                            AddReportFailure("0000FF", "File Exception: " + Ex.Message, "", fileURL, url);
                            //Dont update the last URL for this page as we've missed a download, usually because the user has this file open
                            success = false;
                        }
                    }
                }

                return success;
            }
            catch (WebException webEx)
            {
                AddReportFailure("0000FF", "Page Exception: " + ((HttpWebResponse)webEx.Response).StatusCode + " Message: " + webEx.Message, destination,fileURL, url);
                return false;
            }
            catch (Exception Ex)
            {
                AddReportFailure("FF0000", "Error: " + Ex.Message, fileName, fileURL, url);
                return false;
            }
        }

        private string GetFileNameFromUrl(string fileURL, string[] keywordsInUrl, string destination)
        {           
            var fileName = Path.GetFileName(fileURL);

            int indexOfTimeSeriesNumber = fileName.IndexOf(keywordsInUrl[0]);
            int indexOfFileExtension = fileName.IndexOf(keywordsInUrl[1]);
            if (indexOfTimeSeriesNumber > indexOfFileExtension)
            {
                //example of the anomoly: http://abs.gov.au/AUSSTATS/subscriber.nsf/log?openagent&june%20quarter%202016.xls&5519.0.55.001&Data%20Cubes&A23C4DDB023BEA6DCA25802500125385&0&June%20Quarter%202016&06.09.2016&Latest
                int indexOfAmpersandBeforeFileExtension = fileName.IndexOf("&");
                fileName = fileName.Substring(indexOfAmpersandBeforeFileExtension + 1, indexOfTimeSeriesNumber - indexOfAmpersandBeforeFileExtension - 2);
            }
            else
            {
                if (indexOfTimeSeriesNumber < 0) indexOfTimeSeriesNumber = 0;
                fileName = fileName.Substring(indexOfTimeSeriesNumber, indexOfFileExtension - indexOfTimeSeriesNumber + keywordsInUrl[1].Length);
            }
            

            string cleanFileName = String.Join("", fileName.Split(Path.GetInvalidFileNameChars()));
            string dir = String.Join("", destination.Split(Path.GetInvalidPathChars()));
            fileName = Path.Combine(dir, cleanFileName);
            return fileName;
        }

        internal void AddReportFailure(string colour, string col1, string col2, string col3, string col4, [CallerMemberName] string memberName = "",
         [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (colour == "00AA00") //success
            {
                RunSheetFailures.Add("<tr><td style=\"color:#" + colour + "\">" + col1 + "</td><td>" + col2 + " </td><td>" + col3 + " </td><td>" + col4.Replace(" ", "%20") + "</td></tr>");
            }
            else
            {
                RunSheetFailures.Add("<tr><td style=\"color:#" + colour + "\">" + col1 + "<BR>Function: " + memberName + "<BR>Line Number: " + sourceLineNumber + "</td><td>" + col2 + " </td><td>" + col3 + " </td><td>" + col4.Replace(" ", "%20") + "</td></tr>");
            }
        }

        internal void ReportFailures(string startupPath, string emailTo, string emailFrom)
        {
            if (RunSheetFailures.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("<h2>ABS Butler Report</h2>");
                sb.Append("<BR><BR>");
                
                sb.Append("<BR><BR>");
                sb.Append("By: ");
                sb.Append(Environment.UserName);
                sb.Append(", on machine: ");
                sb.Append(Environment.MachineName);
                sb.Append(" from: ");
                sb.Append(startupPath);
                sb.Append("<BR><BR>");
                sb.Append("<Table border=1>");

                sb.Append("<tr><td width=100><b>Status</b></td><td width=100><b>File Name</b></td><td width=100><b></b></td>Download URL<td width=300><b>ABS Page</b></td></tr>");

                foreach (string line in RunSheetFailures)
                {
                    sb.AppendLine(line);
                }

                sb.Append("</Table>");
                
                EmailSMTP.SendEmail(emailTo, "", "", "ABS Butler Report", sb.ToString(), null, jsonConfigObj.FromEmail, jsonConfigObj.SMTPPassword, jsonConfigObj.SMTPDomain, jsonConfigObj.SMTPHost, jsonConfigObj.SMTPPort, jsonConfigObj.SMTPTLSEnabled);
            }
        }
    }

    public struct LinkItem
    {
        public string Href;
        public string Text;

        public override string ToString()
        {
            return Href + "\n\t" + Text;
        }
    }

    static class LinkFinder
    {
        public static List<LinkItem> Find(string file)
        {
            List<LinkItem> list = new List<LinkItem>();

            // 1.
            // Find all matches in file.
            MatchCollection m1 = Regex.Matches(file, @"(<a.*?>.*?</a>)",
                RegexOptions.Singleline);

            // 2.
            // Loop over each match.
            foreach (Match m in m1)
            {
                string value = m.Groups[1].Value;
                LinkItem i = new LinkItem();

                // 3.
                // Get href attribute.
                Match m2 = Regex.Match(value, @"href=\""(.*?)\""",
                RegexOptions.Singleline);
                if (m2.Success)
                {
                    i.Href = m2.Groups[1].Value;
                }

                // 4.
                // Remove inner tags from text.
                string t = Regex.Replace(value, @"\s*<.*?>\s*", "",RegexOptions.Singleline);
                i.Text = t;

                list.Add(i);
            }
            return list;
        }
    }
}
