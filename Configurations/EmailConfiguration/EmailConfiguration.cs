using System.Collections.Generic;
using MimeKit;

namespace Configurations.EmailConfiguration
{
    public record EmailConfiguration:IParsable
    {
        public string ConfigurationFileName => Storage.StorageConfig.EmailConfigurationName;

        //  the people who will receive the emails
        public List<MailboxAddress> Recipients;
        public MailboxAddress Sender;
        

    }
}