using System;
namespace mcuConnection
{
    [Flags]
    public enum InstructionCodes:byte
    {
        Nop = 0x00,
        CreateConnection = 0x01,
        CloseConnection = 0x02,
        SendDataFromMemory = 0x03,
        UnlockHandBrake = 0x04,
        LockHandBrake = 0x05,
        StartCalibration = 0x06,
        StopCalibration = 0x07,
        GetCalibrationResult = 0x08,
        GetTotalCapacity = 0x09,
        GetRemainingBatteryCharge = 0x0A,

    }

    [Flags]
    public enum InstructionResponses : byte
    {
        Nop = 0x00,
        CreatedConnection = 0x01,
        SendingMemData = 0x02,
        HandBrakeUnlocked = 0x03,
        HandbrakeLocked = 0x04,
        CalibrationStarted = 0x05,
        CalibrationStopped = 0x06,
        SendingCalibrationResult = 0x07,
        SendingTotalCapacity = 0x08,
        ConnectionError = 0x09,
        
    }
}