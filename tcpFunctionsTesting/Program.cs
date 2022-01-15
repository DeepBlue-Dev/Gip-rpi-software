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

            McuMessage msg = conn.Connect();
            if (msg.Response is InstructionResponses.CreatedConnection)
            {
                Console.WriteLine("Connection made");
            }
            
            Console.WriteLine("we made it");
        }
    }
}