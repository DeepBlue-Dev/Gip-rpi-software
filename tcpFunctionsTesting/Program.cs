using System;
using System.Net;
using mcuConnection;

namespace tcpFunctionsTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            McuConnection conn = new McuConnection((IPAddress.Parse("127.0.0.1"), 6969));
            
        }
    }
}