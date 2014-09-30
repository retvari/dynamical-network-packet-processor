using System;
using System.Runtime.InteropServices;

enum HEADER
{
    // Client -> Server (0-99)
    CS_LOGIN            = 1,
    CS_PONG             = 2,

    // Server -> Client (100-255)
    SC_LOGIN            = 100,
    SC_PING             = 101,
};

enum SUBHEADER
{
    LOGIN_SOCKET_ALREADY_HAVE_A_CHARACTER,
    LOGIN_NAME_ALREADY_LOGGED_IN,
    LOGIN_CHARACTER_CREATED,
}

// Client -> Server
struct PacketCSLogin
{
    public PacketCSLogin(dynamic d) : this()
    {
        if (!Object.Equals(null, d))
            this = d;
    }

    public HEADER    bHeader;
                                                            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
    public string    strName;
                                                            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
    public string    strPassword;
}

struct PacketCSPong
{
    public PacketCSPong(dynamic d) : this()
    {
        if (!Object.Equals(null, d))
            this = d;
    }

    public HEADER    bHeader;
}

// Server -> Client
struct PacketSCLogin
{
    public HEADER    bHeader;
    public SUBHEADER bSubheader;
}

struct PacketSCPing
{
    public HEADER    bHeader;
}