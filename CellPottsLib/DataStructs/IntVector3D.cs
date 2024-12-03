using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.DataStructs
{
    public struct IntVector3D
    {
        public int x;
        public int y;
        public int z;
        public IntVector3D(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public IntVector3D(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
        }
        public IntVector3D(int x)
        {
            this.x = x;
            this.y = 0;
            this.z = 0;
        }
        public IntVector3D(IntVector3D v)
        {
            this.x = v.x;
            this.y = v.y;
            this.z = v.z;
        }
        public static IntVector3D operator +(IntVector3D a, IntVector3D b)
        {
            return new IntVector3D(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static IntVector3D operator -(IntVector3D a, IntVector3D b)
        {
            return new IntVector3D(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static IntVector3D operator *(IntVector3D a, int b)
        {
            return new IntVector3D(a.x * b, a.y * b, a.z * b);
        }
        public static IntVector3D operator /(IntVector3D a, int b)
        {
            return new IntVector3D(a.x / b, a.y / b, a.z / b);
        }
        public static bool operator ==(IntVector3D a, IntVector3D b)
        {
            return a.x == b.x && a.y == b.y && a.z == b.z;
        }
        public static bool operator !=(IntVector3D a, IntVector3D b)
        {
            return a.x != b.x || a.y != b.y || a.z != b.z;
        }
        public override bool Equals(object obj)
        {
            if (obj is IntVector3D)
            {
                IntVector3D v = (IntVector3D)obj;
                return this == v;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return x ^ y ^ z;
        }
        public override string ToString()
        {
            return "(" + x + ", " + y + ", " + z + ")";
        }
    }
}
