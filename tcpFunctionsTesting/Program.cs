using System;
using System.Net;
using mcuConnection;

namespace tcpFunctionsTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            McuConnection connection =
                new McuConnection((IPAddress.Parse(Dns.GetHostAddresses("rpi")[0].ToString()), 51337));
            var resp = connection.Connect();
            if (resp.Response == InstructionResponses.CreatedConnection)
            {
                Console.WriteLine("weeehooo");
            }
        }
    }
}