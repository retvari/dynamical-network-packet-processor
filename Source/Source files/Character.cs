using System;
using System.Net.Sockets;
using System.Threading;

namespace server
{
    public class CHARACTER
    {
        private int         m_iVirtualID;
        private string      m_strName;
        private DateTime    m_stConnected;
        private string      m_strDeviceID;
        private DateTime    m_stPongRecvTime;
        private Socket      m_sSocket;


        public void         SetPongRecvTime(DateTime stPongRecvTime)        {     m_stPongRecvTime = stPongRecvTime;     }
        public DateTime     GetPongRecvTime()                               {     return m_stPongRecvTime;               }

        public void         SetDeviceID(string strDeviceID)                 {     m_strDeviceID = strDeviceID;           }
        public string       GetDeviceID()                                   {     return m_strDeviceID;                  }

        public void         SetConnectedTime(DateTime stConnected)          {     m_stConnected = stConnected;           }
        public DateTime     GetConnectedTime()                              {     return m_stConnected;                  }

        public void         SetName(string strName)                         {     m_strName = strName;                   }
        public string       GetName()                                       {     return m_strName;                      }

        public void         SetVirtualID(int iAccountID)                    {     m_iVirtualID = iAccountID;             }
        public int          GetVirtualID()                                  {     return m_iVirtualID;                   }

        public void         SetSocket(Socket sSocket)                       {     m_sSocket = sSocket;                   }
        public Socket       GetSocket()                                     {     return m_sSocket;                      }


        /* Operator overloads */

        public static bool operator !    (CHARACTER ch)                     { return ch == null ? true  : false;     }
        public static bool operator true (CHARACTER ch)                     { return ch == null ? false : true;      }
        public static bool operator false(CHARACTER ch)                     { return ch == null ? false : true;      }
    }
}
