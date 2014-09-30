using System;
using System.Collections.Generic;

namespace server
{
    class Common
    {
        private static List<int> m_VirtualIDs = new List<int>();

        public static int GetRandomVirtualID()
        {
            Random r = new Random();
            int iVirtualID = 100;

            do
            {
                iVirtualID = r.Next(100, Int32.MaxValue);
            } 
            while 
            (
                m_VirtualIDs.Contains(iVirtualID)
            );

            m_VirtualIDs.Add(iVirtualID);

            return iVirtualID;
        }

        public static byte[] ReconstructPacket(byte[] bBuffer, int iSize)
        {
            byte[] bPacket = new byte[iSize];
            Array.Copy(bBuffer, bPacket, iSize);

            return bPacket;
        }
    }
}
