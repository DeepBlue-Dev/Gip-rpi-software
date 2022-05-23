using System;
using System.Threading.Tasks;
using IPC.Server;
using email;
using mcuConnection;
using Blazor_FrontEnd.Data.RequestCodes;
using Configurations.ForkliftConfiguration;
using System.Linq;
using System.Text;
using NetMQ.Sockets;
using NetMQ;

namespace Backend_Process
{
    public class Program
    {

        static void Main()
        {
            using (ResponseSocket server = new ResponseSocket())
            {
                McuConnection mcuConnection = new McuConnection();
                mcuConnection.Connect();
                server.Bind("tcp://localhost:2100");
                while (true)
                {
                    var message = server.ReceiveFrameBytes();
                    Console.WriteLine($"message: {message[0]}");
                    var code = Enum.ToObject(typeof(RequestCodes), message[0]);

                    switch (code)
                    {
                        case RequestCodes.GetHandbrakeStatus:
                            if (mcuConnection.SendInstructionCode(InstructionCodes.UnlockHandbrake).Response == InstructionResponses.HandbrakeUnlocked)
                            {
                                server.SendFrame("True");
                            }
                            else
                            {
                                server.SendFrame("False");
                            }
                            Console.WriteLine(mcuConnection.SendInstructionCode(InstructionCodes.UnlockHandbrake).Response);
                            break;
                        case RequestCodes.GetOnlineStatus:
                            server.SendFrame(mcuConnection.Connected.ToString());
                            break;
                        case RequestCodes.GetBatteryPercentage:
                            server.SendFrame(mcuConnection.SendInstructionCode(InstructionCodes.GetRemainingBatteryCharge).ParsedData);
                            break;
                        case RequestCodes.GetSocketData:
                            Console.WriteLine("req to socketdata");
                            server.SendFrame($"{mcuConnection._connectionInfo.ip.ToString()}:{mcuConnection._connectionInfo.port.ToString()}");
                            Console.WriteLine("sent socket data");
                            break;
                        case RequestCodes.SetHandbrakeOff:
                            var obj = mcuConnection.SendInstructionCode(InstructionCodes.UnlockHandbrake);
                            Console.WriteLine(obj.Response);
                            server.SendFrameEmpty();
                            break;
                        case RequestCodes.SetHandbrakeOn:
                            var resp = mcuConnection.SendInstructionCode(InstructionCodes.LockHandbrake);
                            Console.WriteLine(resp.Response);
                            server.SendFrameEmpty();
                            break;
                        default:
                            Console.WriteLine($"hit edge case {code}");
                            server.SendFrame("NOP");
                            break;
                    }
                }
            }
        }

        private static async Task MainAsync()
        {
            
        }

        /*
        private static Configurations.ConfigurationManager configManager;
        private static PipeServer pipeServer;
        // private static Email email = new Email();
        private static McuConnection mcuConnection;
        private static System.Timers.Timer timer = new System.Timers.Timer();
        private static UInt32 MaxBatteryCapacity = 25000;  //  this is a temporary solution
        private static UInt32 CurrentBatteryCharge = 18000;    //  idem dito
        private static bool WarningEmailSent = false;

        private static void Tick(object src, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                mcuConnection.Connect();
                CurrentBatteryCharge = Convert.ToUInt32(mcuConnection.SendInstructionCode(InstructionCodes.GetRemainingBatteryCharge).ParsedData);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
           
            configManager = new Configurations.ConfigurationManager();
            pipeServer = new PipeServer();
            //mcuConnection = new McuConnection();

            timer.Elapsed += new System.Timers.ElapsedEventHandler(Tick);   //  add event handler
            timer.Interval = 60000; //  1-minute interval
            //timer.Enabled = true;

            try
            {
                //mcuConnection.Connect();
                //pipeServer.Start();
                //Console.WriteLine($"Server connected: {pipeServer._pipeServerStream.IsConnected}");
            }catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw new Exception(ex.Message);
            }
            
            while (true)
            {
                pipeServer.FrontendOutBackendIn.WaitForConnection();
                Console.WriteLine("Connected");
                while (pipeServer.FrontendOutBackendIn.IsConnected)
                {

                    if (pipeServer.NewCommandArrived())
                    {
                        Console.WriteLine($"Command Arrived");

                        RequestCodes? code = pipeServer.GetCommandFromPipe();
                        if (code is null)
                        {
                            Console.WriteLine("Command was null");
                            
                        } else
                        {
                            Console.WriteLine($"command arrived {code.Value}");
                        }
                        
                        
                        switch (code)
                        {
                            case RequestCodes.GetHandbrakeStatus:
                                if (mcuConnection.SendInstructionCode(InstructionCodes.UnlockHandBrake).Response == InstructionResponses.HandBrakeUnlocked)
                                {
                                    pipeServer.WriteString("True");
                                }
                                else
                                {
                                    pipeServer.WriteString("False");
                                }
                                break;
                            case RequestCodes.GetOnlineStatus:
                                pipeServer.WriteString(mcuConnection.Connected.ToString());
                                break;
                            case RequestCodes.GetBatteryPercentage:
                                pipeServer.WriteString(
                                mcuConnection.SendInstructionCode(InstructionCodes.GetRemainingBatteryCharge).ParsedData);
                                break;
                            case RequestCodes.GetSocketData:
                                Console.WriteLine("req to socketdata");
                                pipeServer.WriteString(mcuConnection._connectionInfo.ip.ToString());
                                pipeServer.WriteString(mcuConnection._connectionInfo.port.ToString());
                                Console.WriteLine("sent socket data");
                                break;
                            default:
                                Console.WriteLine($"hit edge case {code}");
                                pipeServer.WriteString("NOP");
                                break;
                        }
                    }

                    if (CurrentBatteryCharge < (configManager.ReadConfig<ForkliftConfiguration>(new ForkliftConfiguration()).TresholdWarning * MaxBatteryCapacity) && !WarningEmailSent)
                    {
                        WarningEmailSent = true;
                        //email.SendBatteryLowEmail();
                    }
                }
                pipeServer.Start();
            }
        }
        */
    }
}
