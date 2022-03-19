using System;

namespace mcuConnection
{
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
        SendingTotalCapacity,
        ConnectionError,
        SendingRemainingBatteryCharge,


    }
}