using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.DataStructs
{
    public struct IntVector2D
    {
        public int x;
        public int y;
        public IntVector2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public IntVector2D(IntVector2D v)
        {
            this.x = v.x;
            this.y = v.y;
        }
        public static IntVector2D operator +(IntVector2D a, IntVector2D b)
        {
            return new IntVector2D(a.x + b.x, a.y + b.y);
        }
        public static IntVector2D operator -(IntVector2D a, IntVector2D b)
        {
            return new IntVector2D(a.x - b.x, a.y - b.y);
        }
        public static IntVector2D operator *(IntVector2D a, int b)
        {
            return new IntVector2D(a.x * b, a.y * b);
        }
        public static IntVector2D operator /(IntVector2D a, int b)
        {
            return new IntVector2D(a.x / b, a.y / b);
        }
        public static bool operator ==(IntVector2D a, IntVector2D b)
        {
            return a.x == b.x && a.y == b.y;
        }
        public static bool operator !=(IntVector2D a, IntVector2D b)
        {
            return a.x != b.x || a.y != b.y;
        }
        public override bool Equals(object? obj )
        {
            if (obj == null) { return false; }
            if (obj is IntVector2D)
            {
                IntVector2D v = (IntVector2D)obj;
                return this == v;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return x ^ y;
        }
        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }
}
