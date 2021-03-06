﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MW2_4D1_External_ESP
{
    public class EntityBase
    {
        public bool IsValid { get; set; }
        public int ClientNum { get; set; }
        public Vector Origin { get; set; }
    }

    public class Player : EntityBase
    {
        public Vector Angles { get; set; }
        public Flags Flag { get; set; }
        public bool IsAlive { get; set; }
        public string Name { get; set; }
        public PlayerTeam Team { get; set; }
        public int Rank { get; set; }
        public int Score { get; set; }
    }

    public class Turret : EntityBase
    {
        public const string NAME = "Turret";
    }

    public class Helicopter : EntityBase
    {
        public const string NAME = "Helicopter";
    }

    public class Plane : EntityBase
    {
        public const string NAME = "Plane";
    }

    public class Explosive : EntityBase
    {
        /// This entity type primarily highlights explosives, but
        /// some of the entities are not explosives (like knives).
        /// So I gave it the name "Equipment".
        public const string NAME = "Equipment";
    }
}
