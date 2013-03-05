using System.Runtime.InteropServices;

namespace MW2_4D1_External_ESP
{
    // The structures from the game

    [StructLayout(LayoutKind.Sequential)]
    public struct Entity
    {
        public const int SIZE = 0x204;
        public const int LENGTH = 2048;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        private byte[] _0x0000;
        public Vector origin;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 72)]
        private byte[] _0x0024;
        public int isZooming;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        private byte[] _0x0070;
        public Vector oldOrigin;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
        private byte[] _0x0088;
        public int clientNum;
        public EntityType type;
        public Flags flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        private byte[] _0x00E8;
        public Vector newOrigin;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 108)]
        private byte[] _0x0100;
        public int pickupItemID;
        private int clientNum2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 52)]
        private byte[] _0x0174;
        public byte weaponID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 51)]
        private byte[] _0x01A9;
        public int isValid;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        private byte[] _0x01E0;
        private int clientNum3;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ClientInfo
    {
        public const int SIZE = 0x52C;
        public const int LENGTH = 18;

        public int isAlive;
        private int isAlive2;
        public int clientNum;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string name;
        public int team1;
        public int team2;
        public int rank;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _0x0028;
        public int perk;
        public int kills;
        public int score;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 968)]
        private byte[] _0x0038;
        public Vector angles;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 136)]
        private byte[] _0x040C;
        public int isShooting;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _0x0498;
        public int isZoomed;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 68)]
        private byte[] _0x04A0;
        public int weaponID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        private byte[] _0x04E8;
        private int weaponID2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        private byte[] _0x0504;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RefDef
    {
        public const int SIZE = 0x4080;

        public int x;
        public int y;
        public int width;
        public int height;
        public float fovX;
        public float fovY;
        public Vector origin;
        public Vector viewAxis1;
        public Vector viewAxis2;
        public Vector viewAxis3;
        public Vector viewAngles;
        public int time;
        public int menu;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16128)]
        private byte[] _0x0060;
        public Vector viewAngles2;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 276)]
        private byte[] _0x3F6C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ClientGame
    {
        public const int SIZE = 0x3C80;

        public int time;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 13132)]
        private byte[] _0x0004;
        public int clientNum;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2348)]
        private byte[] _0x3354;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ClientGameState
    {
        public const int SIZE = 0x580;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] _0x0000;
        public int width;
        public int height;
        public int scale;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _0x0010;
        public int time;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _0x001C;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string gameType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 288)]
        private byte[] _0x0024;
        public int maxPlayers;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] _0x0148;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string map;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1012)]
        private byte[] _0x018C;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Camera
    {
        public const int SIZE = 0x80;

        public Vector recoil;
        public Vector origin;
        public float viewAngleY;
        public float viewAngleX;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
        public byte[] _0x002C;
    }
}
