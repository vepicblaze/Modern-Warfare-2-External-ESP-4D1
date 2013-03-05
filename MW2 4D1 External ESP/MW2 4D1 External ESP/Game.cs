using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MW2_4D1_External_ESP
{
    /// <summary>
    /// Singleton class with information about the game (4D1 MW2).
    /// </summary>
    public static class Game
    {
        public const string CLASSNAME = "IW4";

        public static IntPtr hWnd;
        public static IntPtr hProcess;

        #region Entities
        public static Player[] Players = new Player[ClientInfo.LENGTH];
        public static Player LocalPlayer;
        #endregion

        #region View Origin
        // Same ViewOrigin as in the RefDef struct. But for some reason
        // the one in the RefDef struct is very unstable so I use this one
        // instead as it's more precise.
        public static Vector ViewOrigin;
        #endregion

        #region Structures
        public static RefDef RefDef;
        public static Entity[] Entities;
        public static ClientInfo[] Clients;
        public static Camera Camera;
        public static ClientGame CG;
        public static ClientGameState CGS;
        #endregion

        public static bool IsGameWindowInForeground()
        {
            return hWnd == Native.GetForegroundWindow();
        }

        public static bool IsGameRunning()
        {
            hWnd = Native.FindWindow(CLASSNAME, null);
            return hWnd != IntPtr.Zero;
        }

        public static bool IsPlayerInGame()
        {
            return CG.time != 0;
        }

        public static bool OpenProcess()
        {
            int processID;
            Native.GetWindowThreadProcessId(hWnd, out processID);
            hProcess = Native.OpenProcess(Native.PROCESS_VM_READ, false, processID);
            return hProcess != IntPtr.Zero;
        }

        public static bool CloseProcess()
        {
            if (hProcess == IntPtr.Zero)
                return false;

            return Native.CloseHandle(hProcess);
        }

        public static void ReadGame()
        {
            ReadStructs();

            for (int i = 0; i < ClientInfo.LENGTH; i++) {
                var entity = Entities[i];
                var client = Clients[i];

                var player = new Player();

                player.ClientNum = client.clientNum;
                player.Origin = entity.origin;
                player.Angles = client.angles;
                player.Flag = entity.flags;
                player.IsAlive = (entity.isValid & 1) == 1;
                player.IsValid = (client.isAlive & 1) == 1;
                player.Name = client.name;
                player.Team = client.team1 == Clients[CG.clientNum].team1 
                    && Clients[CG.clientNum].team2 != 0
                    ? PlayerTeam.Friendly : PlayerTeam.Hostile;
                player.Rank = client.rank + 1;
                player.Score = client.score;

                if (player.ClientNum == CG.clientNum)
                    LocalPlayer = player;

                Players[i] = player;
            }
        }

        private static void ReadStructs()
        {
            if (hProcess == IntPtr.Zero)
                throw new SystemException("Failed to read structs from the game");

            ViewOrigin = ProcessMemory.Read<Vector>(hProcess, Address.ViewOrigin);
            RefDef = ProcessMemory.Read<RefDef>(hProcess, Address.RefDef);
            Entities = ProcessMemory.ReadArray<Entity>(hProcess, Address.Entity, Entity.LENGTH, Entity.SIZE);
            Clients = ProcessMemory.ReadArray<ClientInfo>(hProcess, Address.ClientInfo, ClientInfo.LENGTH, ClientInfo.SIZE);
            Camera = ProcessMemory.Read<Camera>(hProcess, Address.Camera);
            CG = ProcessMemory.Read<ClientGame>(hProcess, Address.ClientGame);
            CGS = ProcessMemory.Read<ClientGameState>(hProcess, Address.ClientGameState);
        }

        public static class Address
        {
            public static readonly IntPtr ViewOrigin = new IntPtr(0x7A21E8);
            public static readonly IntPtr RefDef = new IntPtr(0x85B6F0);
            public static readonly IntPtr Entity = new IntPtr(0x8F3CA8);
            public static readonly IntPtr ClientInfo = new IntPtr(0x8E77B0);
            public static readonly IntPtr Camera = new IntPtr(0xB2F890);
            public static readonly IntPtr ClientGame = new IntPtr(0x7F0F78);
            public static readonly IntPtr ClientGameState = new IntPtr(0x7ED3B8);
        }
    }
}
