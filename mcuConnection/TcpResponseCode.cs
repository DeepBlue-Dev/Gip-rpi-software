using System;

namespace mcuConnection
{
    [Flags]
    public enum TcpResponseCode
    {
        EndpointNotConnected = 0,
        SocketWriteFailed = 1,
        Succes = 2,
        CreatingConnectionFailed = 3,
    }
}