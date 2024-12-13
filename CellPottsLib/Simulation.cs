using CellPottsLib.DataStructs;
using CellPottsLib.Grid;
using CellPottsLib.Logic;
using System.Runtime.CompilerServices;

namespace CellPottsLib
{
    public class Simulation
    {
        private I2DGrid grid;
        private ILogicHandler logic;
        private IMoveHandler moveHandler;


        public Simulation(IntVector2D size)
        {
            Injector inj = new Injector();
            grid = inj.Get2DGrid(size);
            logic = inj.GetLogicHandler();
            moveHandler = inj.GetMoveHandler();
        }
        public I2DGrid Grid { get {  return grid; } }

        public void Step(int AmountOfSteps = 1)
        {
            for (int i = 0; i < AmountOfSteps; i++)
            {
                OneStep();
            }
        }

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

        private void OneStep()
        {
            Move move = moveHandler.GenerateMove(grid);
            moveHandler.ValidateMove(move, grid, logic.EnergyCalculator);
            moveHandler.ApplyMove(move, grid);
        }
    }
}
