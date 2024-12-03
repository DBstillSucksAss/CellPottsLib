using CellPottsLib.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.DataStructs
{
    public struct Cell
    {
        public int Identity { get; private set; }
        public List<IntVector2D> Positions { get; private set; }
        public int? Volume { get; set; } = null;
        public int? Circumference { get; set; } = null;

        public Cell(int identity, List<IntVector2D> positions)
        {
            Identity = identity;
            Positions = positions;
        }
        public Cell(int identity)
        {
            Identity = identity;
            Positions = new List<IntVector2D>();
        }

        public void SetPositions(List<IntVector2D> positions)
        {
            Positions = positions;
        }
        public void AddPosition(IntVector2D position)
        {
            Positions.Add(position);
        }
        public void RemovePosition(IntVector2D position)
        {
            Positions.Remove(position);
        }
    }
}
