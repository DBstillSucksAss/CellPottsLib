using CellPottsLib.DataStructs;
using CellPottsLib.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Logic
{
    public abstract class EnergyUnitBase : ILogicUnit
    {
        public string ID { get; private set; }
        public LogicUnitType Type { get; private set; }
        public double PotentialMaxEnergyChange { get; set; } = 0;

        public EnergyUnitBase(string ID, LogicUnitType type)
        {
            this.ID = ID;
            this.Type = LogicUnitType.EnergyCalculator;
        }


        public void DisableNormalization()
        {
            PotentialMaxEnergyChange = 0;
        }
        public void EnableNormalization(double maxEnergyDifference)
        {
            PotentialMaxEnergyChange = maxEnergyDifference;
        }
        public abstract double CalculateEnergy(I2DGrid grid);
        public abstract double CalculateEnergyChange(I2DGrid grid, IntVector2D position, int newState);
        public abstract double CalculateEnergyChange(I2DGrid OldGrid, I2DGrid newGrid);

    }
}
