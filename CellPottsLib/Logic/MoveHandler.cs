using CellPottsLib.DataStructs;
using CellPottsLib.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Logic
{
    public class MoveHandler : IMoveHandler
    {
        public MoveHandler() { }

        public void ApplyMove(Move move, I2DGrid grid)
        {
            if(move.Valid == false) { return; }
            grid.SetPixel(move.Target, grid.GetPixel(move.Source));
        }

        public Move GenerateMove(I2DGrid grid)
        {
            int maxX = grid.GridSize.x -1;
            int maxY = grid.GridSize.y -1;

            Random random = new Random();

            int x = random.Next(0, maxX);
            int y = random.Next(0, maxY);
            IntVector2D Source = new IntVector2D(x, y);
            List<IntVector2D> Destination = grid.GetNeighbours(Source);
            IntVector2D dest = Destination[random.Next(0, Destination.Count)];

            return new Move(Source, dest);
        }

        public void ValidateMove(Move move, I2DGrid grid, IEnergyCalculator energyCalculator)
        {
            double energy = energyCalculator.CalculateEnergyChange(grid, move.Target, grid.GetPixel(move.Source));

            bool IsValid = false;
            if(energy <= 0) 
            { 
                IsValid = true; 
            }
            else
            {
                double random = new Random().NextDouble();
                if (random < Math.Exp(-energy)) { IsValid = true; }
            }
            move.Valid = IsValid;
        }
    }
}
