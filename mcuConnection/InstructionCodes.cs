using System;
namespace mcuConnection
{
    [Flags]
    public enum InstructionCodes:byte
    {
        Nop,
        CreateConnection,
        CloseConnection,
        SendDataFromMemory,
        UnlockHandBrake,
        LockHandBrake,
        StartCalibration,
        StopCalibration ,
        GetCalibrationResult,
        GetTotalCapacity,
        GetRemainingBatteryCharge,

    }

   
}