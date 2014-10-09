using System;
using System.Net.Sockets;

namespace server
{
    class Input
    {
        public static void Analyze(byte[] bPacket, Socket s)
        {
            if (s == null)
                return;

            if (bPacket.Length < 1)
                return;

            CHARACTER ch;
            if (!(ch = s.GetCharacter()))
                return;

            Packet_Info.ExecuteMethod(bPacket, ch);
        }

        public static void Login(CHARACTER ch, dynamic d)
        {
            PacketCSLogin p = new PacketCSLogin(d);

            // -----
        }

        public static void Pong(CHARACTER ch, dynamic d)
        {
            PacketCSPong p = new PacketCSPong(d);

            // -----
        }
    }
}
