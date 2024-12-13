using CellPottsLib.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.DataStructs
{
    public class Cell
    {
        public int Identity { get; private set; }
        public List<IntVector2D> Positions { get; private set; }
        public int Volume
        {
            get
            {
                return Positions.Count;
            }
        }
        public int Circumference { get { CalculateCircumference(); return circumference; } }

        private int circumference;
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

        //TODO : TEST that shit
        private void CalculateCircumference()
        {
            int newCircumference = 0;
            foreach (IntVector2D pos in Positions)
            {
                List<IntVector2D> neighbours = new List<IntVector2D>();
                neighbours.Add(new IntVector2D(pos.x + 1, pos.y));
                neighbours.Add(new IntVector2D(pos.x - 1, pos.y));
                neighbours.Add(new IntVector2D(pos.x, pos.y + 1));
                neighbours.Add(new IntVector2D(pos.x, pos.y - 1));
                foreach (IntVector2D neighbour in neighbours)
                {
                    if (!Positions.Contains(neighbour))
                    {
                        newCircumference++;
                    }
                }
            }
            circumference = newCircumference;
        }
}
