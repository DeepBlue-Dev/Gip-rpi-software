using mcuConnection;

namespace Blazor_FrontEnd.Data
{
    public enum RequestCodes: byte
    {
        GetSocketData,
        GetOnlineStatus,
        GetHandbrakeStatus,
        GetBatteryPercentage,
    }
}
