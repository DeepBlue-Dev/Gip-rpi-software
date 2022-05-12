using mcuConnection;

namespace Blazor_FrontEnd.Data.RequestCodes
{
    public enum RequestCodes : byte
    {
        GetSocketData,
        GetOnlineStatus,
        GetHandbrakeStatus,
        GetBatteryPercentage,
    }
}
