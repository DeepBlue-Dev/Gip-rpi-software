using System.Threading.Tasks;
using System.Collections.Generic;
using Configurations.EmailConfiguration;
using Configurations;
using System;

namespace Blazor_FrontEnd.Data
{
    public class EmailsService
    {
        private List<string> _emails;
        ConfigurationManager manager = new ConfigurationManager();

        public Task<(List<string>, string?)> GetStoredEmails()
        {


            try
            {
                return Task.FromResult<(List<string>,string?)>((manager.ReadConfig<EmailConfiguration>(new EmailConfiguration()).Recipients.ConvertAll(adress => adress.ToString()), null));
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
                EmailConfiguration conf = manager.ReadConfig<EmailConfiguration>(new EmailConfiguration());
                conf.Recipients = updatedEmails.ConvertAll(adress => MimeKit.MailboxAddress.Parse(adress));
                manager.WriteConfig<EmailConfiguration>(conf);
                return Task.FromResult<string?>(null);
            }catch (Exception ex)
            {
                return Task.FromResult<string?>(ex.Message);
            }
           
        }
    }
}
