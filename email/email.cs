using System;
using MailKit.Net.Smtp;
using MimeKit;
using Configurations.McuConnectionConfiguration.EmailConfiguration;
using Configurations.McuConnectionConfiguration;

namespace email
{
    public class Email
    {
        private readonly EmailConfiguration _configuration;

        public Email()
        {
            //  Get the configuration
            ConfigurationManager manager = new ConfigurationManager();
            _configuration = manager.ReadConfig<EmailConfiguration>(new EmailConfiguration()); 
        }
        public void SendDummyEmail()
        {

            MimeMessage msg = new MimeMessage();
            msg.From.Add(_configuration.Sender);
            msg.To.AddRange(_configuration.Recipients);
            msg.Subject = "This is a test, you can skip it";
            msg.Body = new TextPart("plain")
            {
                Text = "this is a test, you can skip it"
            };

            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect(_configuration.MailServer, _configuration.MailServerPort,
                        _configuration.UseSecureSocketOptions);
                    client.Authenticate(Environment.GetEnvironmentVariable("Authentication").ToString(),
                        _configuration.Sender);
                    client.Send(msg);
                }
            }
            catch (NullReferenceException)
            {
                Console.Error.WriteLine("Nullreference exception because of env variable that is not present"); //  catch the possible nullref exc
            }
        }
    }
}