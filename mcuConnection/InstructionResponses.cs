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
		HandbrakeUnlocked,
		HandbrakeLocked,
		CalibrationStarted,
		CalibrationStopped,
		SendingCalibrationResult,
		SendingTotalCapacity,
		ConnectionError,
		SendingRemainingBatteryCharge,
	}
}