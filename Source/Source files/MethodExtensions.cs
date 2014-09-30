using System;
using System.Net.Sockets;

namespace server
{
    public static class CustomSocket
    {
        public static string GetIPAddress(this Socket s)
        {
            return s.RemoteEndPoint.ToString().Split(':')[0];
        }

        public static int GetPort(this Socket s)
        {
            return Convert.ToInt32(s.RemoteEndPoint.ToString().Split(':')[1]);
        }

        public static CHARACTER GetCharacter(this Socket s)
        {
            return Manager.FindCharacter(s);
        }

        public static void CreateCharacter(this Socket s)
        {
            Manager.InitializeCharacter(s);
        }

        public static void SendPacket(this Socket s, dynamic d)
        {
            s.Send(Packet_Info.EncodePacket(d));
        }
    }
}
