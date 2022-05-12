using System;
using IPC.Server;
using email;
using mcuConnection;
using Blazor_FrontEnd.Data.RequestCodes;
using Configurations.ForkliftConfiguration;
using System.Linq;
using System.Text;


namespace Backend_Process
{
    public class Program
    {
        private static Configurations.ConfigurationManager configManager = new Configurations.ConfigurationManager();
        private static PipeServer pipeServer = new PipeServer();
        private static Email email = new Email();
        private static McuConnection mcuConnection = new McuConnection();
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
           

            timer.Elapsed += new System.Timers.ElapsedEventHandler(Tick);   //  add event handler
            timer.Interval = 60000; //  1-minute interval

            try
            {
                mcuConnection.Connect();

            }catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            while (true)
            {
                if (pipeServer.NewCommandArrived())
                {
                    switch (((RequestCodes)Convert.ToByte(pipeServer.ReadString())))
                    {
                        case RequestCodes.GetHandbrakeStatus:
                            if (mcuConnection.SendInstructionCode(InstructionCodes.UnlockHandBrake).Response == InstructionResponses.HandBrakeUnlocked)
                            {
                                pipeServer.WriteString("True");
                            } else
                            {
                                pipeServer.WriteString("False");
                            }
                            break;
                        case RequestCodes.GetOnlineStatus:
                            pipeServer.WriteString(mcuConnection.Connected.ToString());
                            break;
                        case RequestCodes.GetBatteryPercentage:
                            pipeServer.WriteString(((float)CurrentBatteryCharge / (float)MaxBatteryCapacity).ToString());
                            break;
                        case RequestCodes.GetSocketData:
                            pipeServer.WriteString(mcuConnection._connectionInfo.ip.ToString());
                            pipeServer.WriteString(mcuConnection._connectionInfo.port.ToString());
                            break;
                    }
                }

                if(CurrentBatteryCharge < (configManager.ReadConfig<ForkliftConfiguration>(new ForkliftConfiguration()).TresholdWarning * MaxBatteryCapacity) && !WarningEmailSent)
                {
                    WarningEmailSent = true;
                    email.SendBatteryLowEmail();
                }
            }
        }
    }
}
