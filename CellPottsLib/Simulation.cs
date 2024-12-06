using CellPottsLib.Grid;
using CellPottsLib.Logic;

namespace CellPottsLib
{
    public class Simulation
    {
        private I2DGrid grid;
        private ILogicHandler logic;

        public I2DGrid Grid { get {  return grid; } }

        public void Step(int AmountOfSteps = 1) { throw new NotImplementedException(); }
     
        public void AddLogicUnit(ILogicUnit unit)
        {
            logic.AddLogicUnit(unit);
        }
        public void RemoveLogicUnit(string ID, LogicUnitType type)
        {
            logic.RemoveLogicUnit(ID, type);
        }
        public ILogicUnit? GetLogicUnit(string ID, LogicUnitType type)
        {
            return logic.GetLogicUnit(ID, type);
        }

    }
}
