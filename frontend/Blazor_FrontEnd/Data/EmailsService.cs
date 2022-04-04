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
                EmailConfiguration conf = manager.ReadConfig<EmailConfiguration>(new EmailConfiguration());   //  fetch the config
                if(conf is null) { throw new Exception("No configuration file was found"); }
                if(conf is null || conf.Recipients.Count == 0)
                {
                    throw new Exception("No recipients in configuration file");
                }
                return Task.FromResult<(List<string>,string?)>((conf.Recipients, null));    //  return the emails as a taskresult
            }
            catch (Exception ex)
            {
                return Task.FromResult<(List<string>,string?)>((new List<string>(), ex.Message));   //  return the errormessage as a taskresult
            }
        }

        public Task<string?> UpdateEmails(List<string> updatedEmails)
        {
            try
            {
                EmailConfiguration config = manager.ReadConfig<EmailConfiguration>(new EmailConfiguration()); //  fetch the existing config
                config.Recipients.Clear();  //  clear the list, to completely update it
                config.Recipients.AddRange(updatedEmails);  //  add the emails
                manager.WriteConfig<EmailConfiguration>(config);    //  write to disk
                return Task.FromResult<string?>(null);

            }catch (Exception ex)
            {
                return Task.FromResult<string?>(ex.Message);
            }
           
        }
    }
}
