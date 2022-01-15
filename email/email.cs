using System;
using MailKit.Net.Smtp;
using MimeKit;
using Configurations.EmailConfiguration;

namespace email
{
    public class Email
    {
        public void SendEmail()
        {
            EmailConfiguration emailConfig = new EmailConfiguration();
            
            MimeMessage msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("BayKor Service", "baykor.service@gmail.com"));
            msg.To.Add();
        }
    }
}