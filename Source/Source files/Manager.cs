using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace server
{
    class Manager
    {
        private static List<CHARACTER> m_ConnectedUsers = new List<CHARACTER>();

        public static CHARACTER FindCharacter(Socket s)
        {
            foreach (CHARACTER ch in m_ConnectedUsers.ToArray())
            {
                if (ch.GetSocket() == s)
                    return ch;
            }

            return null;
        }

        public static CHARACTER FindCharacter(string strName)
        {
            foreach (CHARACTER ch in m_ConnectedUsers.ToArray())
            {
                if (ch.GetName() == strName)
                    return ch;
            }

            return null;
        }

        public static void Destroy(Socket s)
        {
            Log.AddEntry("{0} has been destroyed at {1}", s.GetCharacter().GetVirtualID(), DateTime.Now);

            m_ConnectedUsers.Remove(s.GetCharacter());

            // --------
        }

        public static void InitializeCharacter(Socket s)
        {
            if (s.GetCharacter())
                return;

            CHARACTER ch = new CHARACTER();

            ch.SetSocket(s);
            ch.SetVirtualID(Common.GetRandomVirtualID());
            ch.SetConnectedTime(DateTime.Now);

            m_ConnectedUsers.Add(ch);

            Log.AddEntry("{0} connected to the server from {1} at {2}", ch.GetVirtualID(), s.GetIPAddress(), DateTime.Now);
        }
    }
}
