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

    [Flags]
    public enum InstructionResponses : byte
    {
        Nop,
        CreatedConnection,
        ClosedConnection,
        SendingMemData,
        HandBrakeUnlocked,
        HandbrakeLocked,
        CalibrationStarted,
        CalibrationStopped,
        SendingCalibrationResult,
        SendingTotalCapacity ,
        ConnectionError,
        SendingRemainingBatteryCharge,
        
    }
}