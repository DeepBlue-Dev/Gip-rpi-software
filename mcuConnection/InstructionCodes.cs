using System;
namespace mcuConnection
{
    [Flags]
    public enum InstructionCodes:byte
    {
		nop,
		CreateConnection,
		CloseConnection,
		SendDataFromMemory,
		UnlockHandbrake,
		LockHandbrake,
		StartCalibration,
		StopCalibration,
		GetCalibrationResult,
		GetTotalCapacity,
		GetRemainingBatteryCharge,

	}

   
}