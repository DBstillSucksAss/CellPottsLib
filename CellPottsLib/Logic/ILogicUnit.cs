using CellPottsLib.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Logic
{
    public interface ILogicUnit
    {
        string ID { get; }
        LogicUnitType Type { get; }
    }

    public enum LogicUnitType
    {
        Cell,
        EnergyCalculator,
    }
}
