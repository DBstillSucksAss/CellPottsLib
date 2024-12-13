using CellPottsLib.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Logic
{
    public interface ILogicHandler
    {
        public IEnergyCalculator EnergyCalculator { get; }
        public void SetEnergyCalculator(IEnergyCalculator calculator);
        public void AddLogicUnit(ILogicUnit unit);
        public void RemoveLogicUnit(string ID, LogicUnitType type);
        public ILogicUnit? GetLogicUnit(string ID, LogicUnitType type);
        public List<ILogicUnit> GetLogicUnits();
        public void UpdateBeforeMoves(I2DGrid grid);
        public void UpdateAfterMoves(I2DGrid grid);
    }
}
