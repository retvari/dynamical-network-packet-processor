using System;
using System.Net;
using System.Net.Sockets;

namespace server
{
    class Network
    {
        public static void Start()
        {
            Globals.ServerSocket.Bind(new IPEndPoint(IPAddress.Parse(Globals.IP), Globals.PORT));

            Globals.ServerSocket.Listen(8192);

            Globals.ServerSocket.BeginAccept(Connect, 0);

            Log.AddEntry("Server has been started successfully at {0}", DateTime.Now);
        }

        private static void Connect(IAsyncResult AsyncResult)
        {
            Socket s = Globals.ServerSocket.EndAccept(AsyncResult);

            s.BeginReceive(Globals.ServerBuffer, 0, Globals.ServerBuffer.Length, SocketFlags.None, Input, s);

            Globals.ServerSocket.BeginAccept(Connect, 0);

            Manager.InitializeCharacter(s);
        }

        private static void Input(IAsyncResult AsyncResult)
        {
            Socket s = (Socket)AsyncResult.AsyncState;

            try
            {
                server.Input.Analyze(Common.ReconstructPacket(Globals.ServerBuffer, s.EndReceive(AsyncResult)), s);

                s.BeginReceive(Globals.ServerBuffer, 0, Globals.ServerBuffer.Length, SocketFlags.None, Input, s);

            }
            catch(SocketException e)
            {
                switch ((SocketError)e.ErrorCode)
                {
                    case SocketError.ConnectionReset:   // Connection lost with the user

                        // ------

                        break;

                    case SocketError.Disconnecting:     // The user disconnected gracefully

                        // ------

                        break;
                }

                Manager.Destroy(s);
            }
        }
    }
}
