using System.Net.Sockets;

namespace server
{
    class Globals
    {
        public static readonly int    PORT  = 56700;
        public static readonly string IP    = "127.0.0.1";

        public static Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static byte[] ServerBuffer = new byte[262144];
    }
}
