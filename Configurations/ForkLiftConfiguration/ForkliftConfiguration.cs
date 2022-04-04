using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurations.ForkliftConfiguration
{
    public record ForkliftConfiguration : IParsable
    {
        public string ConfigurationFileName => Storage.StorageConfig.ForkliftConfigurationName;
        public float TresholdWarning { get; set; }  //  treshold value when the email will be sent

        public ForkliftConfiguration()
        {

        }
    }
}
