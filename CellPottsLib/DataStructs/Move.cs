using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.DataStructs
{
    public class Move
    {
        public IntVector2D Source { get; set; }
        public IntVector2D Target { get; set; }
        public bool? Valid { get; set; }

        public Move(IntVector2D source, IntVector2D target)
        {
            Source = source;
            Target = target;
            Valid = null;
        }

        public override string ToString()
        {
            return $"Source: {Source}, Target: {Target}, Valid: {Valid}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) { return false; }
            if (obj is Move)
            {
                Move move = (Move)obj;
                return move.Source == Source && move.Target == Target && move.Valid == Valid;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Source, Target, Valid);
        }
        public static bool operator ==(Move left, Move right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Move left, Move right)
        {
            return !left.Equals(right);
        }
    }
}
