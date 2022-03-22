using Configurations;
using System.Net;
using System;

namespace Blazor_FrontEnd.Data
{
    public record McuConnection : IParsable
    {
        //  this is all the stored stuff
        public string ConfigurationFileName { get { return "McuConnectionConfig.json"; } }
        public string McuIPAdress { get; set; }
        public UInt16 McuPort { get;set; }
        public string DnsName { get; set; } //  added this for future use
        public float ConnectionInterval { get; set; }

        //  this is all the active connection stuff -- God save me when i implement this --
        public UInt16 McuPort_Active { get;set; }
        public string McuIPadress { get; set; }
        
    }
}
