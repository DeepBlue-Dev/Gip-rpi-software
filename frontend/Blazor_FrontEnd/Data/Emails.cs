using System.Collections.Generic;
using Configurations;
namespace Blazor_FrontEnd.Data
{
    public record Emails : IParsable 
    {
        public string ConfigurationFileName { get { return "EmailConfig.json"; } }
        public List<string> Recipients { get; set; }
        public string Sender { get; }
        public string SmtpServerHost { get; set; }
        public int SmtpServerPort { get; set; }
    }
}
