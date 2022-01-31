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
                new McuConnection((IPAddress.Parse("192.168.140.121"), 2000));
            var resp = connection.Connect();
            if (resp.Response == InstructionResponses.CreatedConnection)
            {
                Console.WriteLine("weeehooo");
            }
            else
            {
                Console.WriteLine(resp.Response);
                Console.WriteLine(resp.ErrorResponse);
            }

            
            while (true)
            {
                string input = Console.ReadLine();
                if (input[0] is 'l')
                {
                    connection.SendInstructionCode(InstructionCodes.LockHandBrake);
                } else if (input[0] is 'u')
                {
                    connection.SendInstructionCode(InstructionCodes.UnlockHandBrake);
                } else if (input[0] == 's')
                {
                    Console.WriteLine(connection.SendInstructionCode(InstructionCodes.GetRemainingBatteryCharge).ParsedData);
                } else if (input[0] is 'q')
                {
                    connection.Disconnect();
                    break;
                }
            }
        }
    }
}