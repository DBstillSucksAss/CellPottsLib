using CellPottsLib.DataStructs;
using CellPottsLib.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Logic
{
    public interface IMoveHandler
    {
        public Move GenerateMove(I2DGrid grid);
        public void ValidateMove(Move move, I2DGrid grid, IEnergyCalculator energyCalculator);
        public void ApplyMove(Move move, I2DGrid grid);

    }
}
