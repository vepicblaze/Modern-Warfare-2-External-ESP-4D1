using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MW2_4D1_External_ESP
{
    public static class Game
    {
        public const string CLASSNAME = "IW4";

        public static IntPtr hWnd;
        public static IntPtr hProcess;

        #region Entities
        public static Player LocalPlayer = new Player();
        public static List<Player> Players = new List<Player>(ClientInfo.LENGTH);
        public static List<Turret> Turrets = new List<Turret>(10);
        public static List<Helicopter> Helis = new List<Helicopter>(6);
        public static List<Plane> Planes = new List<Plane>(6);
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

        public static PointF ScreenCenter()
        {
            return new PointF((float)RefDef.width / 2f, (float)RefDef.height / 2f);
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
            if (hProcess == IntPtr.Zero)
                throw new SystemException("Failed to read structs from the game");

            ViewOrigin = ProcessMemory.Read<Vector>(hProcess, Address.ViewOrigin);
            RefDef = ProcessMemory.Read<RefDef>(hProcess, Address.RefDef);
            Entities = ProcessMemory.ReadArray<Entity>(hProcess, Address.Entity, Entity.LENGTH, Entity.SIZE);
            Clients = ProcessMemory.ReadArray<ClientInfo>(hProcess, Address.ClientInfo, ClientInfo.LENGTH, ClientInfo.SIZE);
            Camera = ProcessMemory.Read<Camera>(hProcess, Address.Camera);
            CG = ProcessMemory.Read<ClientGame>(hProcess, Address.ClientGame);
            CGS = ProcessMemory.Read<ClientGameState>(hProcess, Address.ClientGameState);

            // If the lists arent cleared they will continue to grow with each List<T>.Add() call,
            //  therefore they have to be cleared before content is added to the lists again.
            Players.Clear();
            Turrets.Clear();
            Helis.Clear();
            Planes.Clear();

            for (int i = 0; i < Entities.Length; i++) {
                bool isEntityValid = (Entities[i].isValid & 1) == 1;

                if (Entities[i].type == EntityType.Player) {
                    var player = new Player();
                    player.ClientNum = Clients[i].clientNum;
                    player.Origin = Entities[i].origin;
                    player.Angles = Clients[i].angles;
                    player.Flag = Entities[i].flags;
                    player.IsAlive = isEntityValid;
                    player.Name = Clients[i].name;
                    player.Team = Clients[i].team1 == Clients[CG.clientNum].team1
                        && Clients[CG.clientNum].team2 != 0
                        ? PlayerTeam.Friendly : PlayerTeam.Hostile;
                    player.Rank = Clients[i].rank + 1;
                    player.Score = Clients[i].score;
                    if (player.ClientNum == CG.clientNum)
                        LocalPlayer = player;
                    Players.Add(player);
                } else if (Entities[i].type == EntityType.Turret && isEntityValid) {
                    var turret = new Turret();
                    turret.ClientNum = Entities[i].clientNum;
                    turret.Origin = Entities[i].origin;
                    Turrets.Add(turret);
                } else if (Entities[i].type == EntityType.Helicopter && isEntityValid) {
                    var heli = new Helicopter();
                    heli.ClientNum = Entities[i].clientNum;
                    heli.Origin = Entities[i].origin;
                    Helis.Add(heli);
                } else if (Entities[i].type == EntityType.Plane && isEntityValid) {
                    var plane = new Plane();
                    plane.ClientNum = Entities[i].clientNum;
                    plane.Origin = Entities[i].origin;
                    Planes.Add(plane);
                }
            }
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
