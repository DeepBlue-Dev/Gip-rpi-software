using System.Collections.Generic;
using MimeKit;
using System;
using Configurations;

namespace Configurations.EmailConfiguration
{
    public record EmailConfiguration:IParsable
    {
        public string ConfigurationFileName => Storage.StorageConfig.EmailConfigurationName;

        //  the people who will receive the emails
        public List<MailboxAddress> Recipients;
        public MimeKit.InternetAddress Sender;
        public String MailServer = "smtp.gmail.com";
        public int MailServerPort = 587;
        public bool UseSecureSocketOptions = false;

        public EmailConfiguration()
        {
            
        }
        

    }
}