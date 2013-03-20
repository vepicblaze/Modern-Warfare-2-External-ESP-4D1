using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace MW2_4D1_External_ESP
{
    public static class MathHelper
    {
        public static bool WorldToScreen(Vector location, out PointF point)
        {
            point = new PointF();

            Vector local = location - Game.ViewOrigin;

            var transform = new Vector();
            transform.x = local.DotProduct(Game.RefDef.viewAxis2);
            transform.y = local.DotProduct(Game.RefDef.viewAxis3);
            transform.z = local.DotProduct(Game.RefDef.viewAxis1);

            if (transform.z < 0.1f)
                return false;

            PointF center = Game.ScreenCenter();

            point.X = center.X * (1.0f - (transform.x / Game.RefDef.fovX / transform.z));
            point.Y = center.Y * (1.0f - (transform.y / Game.RefDef.fovY / transform.z));
            return true;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct Vector
    {
        public float x;
        public float y;
        public float z;

        public Vector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static float Distance(Vector u, Vector v)
        {
            return (u - v).Length;
        }

        public float Length
        {
            get { return (float)Math.Sqrt(x * x + y * y + z * z); }
        }

        public float DotProduct(Vector v)
        {
            return x * v.x + y * v.y + z * v.z;
        }

        public static Vector operator +(Vector u, Vector v)
        {
            return new Vector(u.x + v.x, u.y + v.y, u.z + v.z);
        }

        public static Vector operator -(Vector u, Vector v)
        {
            return new Vector(u.x - v.x, u.y - v.y, u.z - v.z);
        }
    }

    [Flags]
    public enum Flags : int
    {
        Standing = 0x00000000,
        Crouched = 0x00000004,
        Prone = 0x00000008,
        MenuOpen = 0x00000100,
        Dead = 0x00040000,
        Scoped = 0x00080000,
        Firing = 0x00800000
    }

    public enum EntityType : int
    {
        General,
        Player,
        PlayerCorpse,
        Item,
        Explosive,
        Invisible,
        ScriptMover,
        SoundMover,
        FX,
        LoopFX,
        PrimaryLight,
        Turret,
        Helicopter,
        Plane,
        Vehicle,
        VehicleCollmap,
        VehicleCorpse,
        VehicleSpawner
    }

    public enum PlayerTeam : byte
    {
        Friendly,
        Hostile
    }

    public class Distance
    {
        public string Suffix { get; set; }
        public float Const { get; set; }

        private Distance(string suffix, float constant)
        {
            this.Suffix = suffix;
            this.Const = constant;
        }

        public static Distance Meter()
        {
            return new Distance("m", 0.03048f);
        }

        public static Distance Feet()
        {
            return new Distance("ft", 0.1f);
        }
    }
}
