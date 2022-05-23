using mcuConnection;

namespace Blazor_FrontEnd.Data.RequestCodes
{
    public enum RequestCodes : byte
    {
        GetSocketData = 45,
        GetOnlineStatus = 46,
        GetHandbrakeStatus = 47,
        GetBatteryPercentage = 48,
        SetHandbrakeOn = 49,
        SetHandbrakeOff = 50,
    }
}
