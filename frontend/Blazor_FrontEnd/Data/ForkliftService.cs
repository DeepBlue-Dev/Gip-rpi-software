using Configurations.ForkliftConfiguration;
using Configurations;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Blazor_FrontEnd.Data
{
    public class ForkliftService
    {
        private ConfigurationManager _manager = new ConfigurationManager();

        public Task<(float treshold, string? error)> GetStoredTreshold()
        {
            try
            {
                ForkliftConfiguration conf = _manager.ReadConfig<ForkliftConfiguration>(new ForkliftConfiguration());   //  fetch the config
                if (conf is null) { throw new Exception("No configuration file was found"); }

                return Task.FromResult<(float treshold, string? error)>((treshold: conf.TresholdWarning, error: null));    //  return the emails as a taskresult
            }
            catch (Exception ex)
            {
                return Task.FromResult<(float treshold, string? error)>((treshold: 0.0F, error: ex.Message));   //  return the errormessage as a taskresult
            }
        }

        public Task<string?> UpdateStoredTreshold(float newTreshold)
        {
            try
            {
                ForkliftConfiguration config = _manager.ReadConfig<ForkliftConfiguration>(new ForkliftConfiguration()); //  fetch the existing config
                config.TresholdWarning = newTreshold;
                _manager.WriteConfig<ForkliftConfiguration>(config);    //  write to disk
                return Task.FromResult<string?>(null);

            }
            catch (Exception ex)
            {
                return Task.FromResult<string?>(ex.Message);
            }
        }
    }
}
