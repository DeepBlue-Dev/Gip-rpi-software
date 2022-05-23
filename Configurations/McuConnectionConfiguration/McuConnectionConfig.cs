using System.Net;
using Configurations.Storage;

namespace Configurations.McuConnectionConfiguration
{
    public record McuConnectionConfig:IParsable
    {
        public string ConfigurationFileName => StorageConfig.McuConnectionConfigurationName;
        public (string ip, int port) McuSocket;
        public string EndpointName; //  This will be used in the future, when there are multiple endpoints
        //  emtpy constructor for complying to new() limitation
        //  TODO check comment
        public McuConnectionConfig()
        {
            
        }
        
        
    }
}