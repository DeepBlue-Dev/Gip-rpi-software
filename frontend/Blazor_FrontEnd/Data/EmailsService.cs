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
                
                EmailConfiguration conf = manager.ReadConfigEX<EmailConfiguration>(new EmailConfiguration());
                if(conf is null) { throw new Exception("conf was null"); }
                if(conf is null || conf.Recipients.Count == 0)
                {
                    throw new Exception("No recipients in configuration file");
                }
                return Task.FromResult<(List<string>,string?)>((conf.Recipients, null));
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
                

                EmailConfiguration config = manager.ReadConfigEX<EmailConfiguration>(new EmailConfiguration());
                config.Recipients.AddRange(updatedEmails);
                manager.WriteConfig<EmailConfiguration>(config);
                return Task.FromResult<string?>(null);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Task.FromResult<string?>(ex.Message);
            }
           
        }
    }
}
