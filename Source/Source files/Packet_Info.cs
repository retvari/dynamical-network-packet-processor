using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace server
{
    class Packet_Info
    {
        private static Dictionary<Tuple<byte, Type>, Action<CHARACTER, dynamic>> SecurePackets = new Dictionary<Tuple<byte, Type>, Action<CHARACTER, dynamic>>
        {                                       
		    {new Tuple<byte, Type>((byte)       HEADER.CS_LOGIN, 		    typeof(PacketCSLogin)), 		    Input.Login},
		    {new Tuple<byte, Type>((byte)       HEADER.CS_PONG,			    typeof(PacketCSPong)), 			    Input.Pong}
        };

        public static bool ExecuteMethod(byte[] bPacket, CHARACTER ch)
        {
            foreach (KeyValuePair<Tuple<byte, Type>, Action<CHARACTER, dynamic>> PacketList in SecurePackets)
            {
                if (PacketList.Key.Item1 == bPacket[0] && Marshal.SizeOf(PacketList.Key.Item2) == bPacket.Length)
                {
                    PacketList.Value(ch, DecodePacket(bPacket, PacketList.Key.Item2));
                    Log.AddEntry("{0}[{1}] received from {2}", PacketList.Key.Item2, PacketList.Key.Item1, ch.GetName());
                    return true;
                }
            }

            return false;
        }

        public static dynamic DecodePacket(byte[] bPacket, Type PacketType)
        {
            int    TypeSize   = Marshal.SizeOf(PacketType);
            IntPtr Buffer     = Marshal.AllocHGlobal(TypeSize);
            Marshal.Copy(bPacket, 0, Buffer, TypeSize);
            dynamic Struct    = Marshal.PtrToStructure(Buffer, PacketType);
            Marshal.FreeHGlobal(Buffer);

            return Struct;
        }

        public static byte[] EncodePacket(dynamic d)
        {
            int Size = Marshal.SizeOf(d);
            byte[] Packet = new byte[Size];
            IntPtr Buffer = Marshal.AllocHGlobal(Size);
            Marshal.StructureToPtr(d, Buffer, true);
            Marshal.Copy(Buffer, Packet, 0, Size);
            Marshal.FreeHGlobal(Buffer);

            return Packet;
        }
    }
}
