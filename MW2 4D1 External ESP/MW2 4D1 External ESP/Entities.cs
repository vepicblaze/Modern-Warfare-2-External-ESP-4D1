using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MW2_4D1_External_ESP
{
    /// <summary>
    /// This object stores the information of a player in the lobby.
    /// The information gathered in this object will come from the
    /// structs that are read from the game at runtime.
    /// </summary>
    public class Player
    {
        public int ClientNum { get; set; }
        public Vector Origin { get; set; }
        public Vector Angles { get; set; }
        public Flags Flag { get; set; }
        public bool IsAlive { get; set; }
        public bool IsValid { get; set; }
        public string Name { get; set; }
        public PlayerTeam Team { get; set; }
        public int Rank { get; set; }
        public int Score { get; set; }
    }

    public class Turret
    {
        public Vector Origin { get; set; }
        public const string NAME = "[TURRET]";
    }

    public class Helicopter
    {
        public Vector Origin { get; set; }
        public const string NAME = "[HELICOPTER]";
    }

    public class Plane
    {
        public Vector Origin { get; set; }
        public const string NAME = "[PLANE]";
    }
}
