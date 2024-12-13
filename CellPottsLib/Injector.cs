using CellPottsLib.DataStructs;
using CellPottsLib.Grid;
using CellPottsLib.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib
{
    public class Injector
    {
        public virtual IEnergyCalculator GetEnergyCalculator()
        {
            return new EnergyCalculator();
        }

        public virtual IMoveHandler GetMoveHandler()
        {
            return new MoveHandler();
        }

        public virtual ILogicHandler GetLogicHandler()
        {
            return new LogicHandler(new EnergyCalculator());
        }
        public virtual I2DGrid Get2DGrid(IntVector2D size)
        {
            return new Grid2D(size);
        }
    }
}
