using SimpleImpersonation;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace ABSButler
{
    public static class EmailSMTP
    {
        public static bool SendEmail(string emailTo, string emailCc, string emailBcc, string emailSubject, string emailBody, string[] emailFileAttachments, string emailFrom, string emailPassword, string domain, string smtpHost, int smtpPort, bool smtpTLSEnabled)
        {
            var credentials = new UserCredentials(domain, emailFrom, emailPassword);
            Impersonation.RunAsUser(credentials, LogonType.NewCredentials, () =>
            {
                SmtpClient client = new SmtpClient();
                client.Port = smtpPort;
                client.Host = smtpHost;
                client.EnableSsl = smtpTLSEnabled;

                try
                {               
                    MailMessage mmsg = new MailMessage();
                    mmsg.From = new MailAddress(emailFrom);
                    if (!string.IsNullOrEmpty(emailTo)) mmsg.To.Add(emailTo);
                    if (!string.IsNullOrEmpty(emailCc)) mmsg.CC.Add(emailCc);
                    if (!string.IsNullOrEmpty(emailBcc)) mmsg.Bcc.Add(emailBcc);
                    mmsg.Body = emailBody;
                    mmsg.BodyEncoding = Encoding.UTF8;
                    mmsg.IsBodyHtml = true;
                    mmsg.Subject = emailSubject;
                    mmsg.SubjectEncoding = Encoding.UTF8;

                    if (emailFileAttachments != null)
                    {
                        foreach (var attachment in emailFileAttachments)
                        {
                            mmsg.Attachments.Add(new Attachment(attachment));
                        }
                    }
                    client.Send(mmsg);
                    mmsg.Dispose();
                    client.Dispose();                
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Check the Configuration.json file for incorrect SMTP settings, change them and restart the program and click the Send Test Email button." + Environment.NewLine + Environment.NewLine + "Exception: " + Environment.NewLine + ex.Message);
                }

            });
            return true;
        }
    }
}
