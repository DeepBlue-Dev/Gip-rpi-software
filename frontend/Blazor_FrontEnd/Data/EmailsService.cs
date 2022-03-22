using System.Threading.Tasks;
using System.Collections.Generic;
using Configurations.EmailConfiguration;
using Configurations;
using System;

namespace Blazor_FrontEnd.Data
{
    public class EmailsService
    {
        ConfigurationManager manager = new ConfigurationManager();

        public Task<(List<string>, string?)> GetStoredEmails()
        {
            try
            {
                EmailConfiguration conf = manager.ReadConfig<EmailConfiguration>(new EmailConfiguration());
                if(conf is null || conf.Recipients.Count == 0)
                {
                    throw new Exception("No recipients in configuration file");
                }
                return Task.FromResult<(List<string>,string?)>((conf.Recipients.ConvertAll(adress => adress.ToString()), null));
            }
            catch (Exception ex)
            {
                return Task.FromResult<(List<string>,string?)>((new List<string>(), ex.Message));
            }

        }

        public Task<string?> UpdateEmails(List<string> updatedEmails)
        {
            try
            {
                EmailConfiguration conf = new EmailConfiguration();
                manager.ReadConfigEX<EmailConfiguration>(conf);
                conf.Recipients.AddRange(updatedEmails.ConvertAll(adress => MimeKit.MailboxAddress.Parse(adress)));
                manager.WriteConfig<EmailConfiguration>(conf);
                return Task.FromResult<string?>(null);
            }catch (Exception ex)
            {
                return Task.FromResult<string?>(ex.Message);
            }
           
        }
    }
}
