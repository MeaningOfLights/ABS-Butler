using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSButler
{
    public class JSONConfig : IJSONConfig
    {
        public string EmailAlerts { get; set; }
        public string FromEmail { get; set; }
        public string SMTPHost { get; set; }
        public string SMTPUserNameOrEmail { get; set; }
        public string SMTPPassword { get; set; }
        public string SMTPDomain { get; set; }
        public int SMTPPort { get; set; }
        public bool SMTPTLSEnabled { get; set; }
        public string MaxMonthsToLookBack { get; set; }
        
    }

    interface IJSONConfig
    {
        string EmailAlerts { get; set; }
        string FromEmail { get; set; }
        string SMTPHost { get; set; }
        string SMTPUserNameOrEmail { get; set; }
        string SMTPPassword { get; set; }
        string SMTPDomain { get; set; }
        int SMTPPort { get; set; }
        bool SMTPTLSEnabled { get; set; }
        string MaxMonthsToLookBack { get; set; }
    }
}
