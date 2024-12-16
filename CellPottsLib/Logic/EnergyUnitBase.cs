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
        public virtual string ID { get; private set; }
        public LogicUnitType Type { get { return LogicUnitType.EnergyCalculator; } }
        public double PotentialMaxEnergyChange { get; set; } = 0;
        public double Weighting { get; set; } = 1;

        public EnergyUnitBase(string iD)
        {
            ID = iD;
        }


        public void DisableNormalization()
        {
            PotentialMaxEnergyChange = 0;
        }
        public void SetNormalization(double maxEnergyDifference)
        {
            PotentialMaxEnergyChange = maxEnergyDifference;
        }
        public abstract double CalculateEnergy(I2DGrid grid);
        public abstract double CalculateEnergyChange(I2DGrid grid, IntVector2D position, int newState);
        public abstract double CalculateEnergyChange(I2DGrid OldGrid, I2DGrid newGrid);
        public abstract double CalculateEnergyChange(I2DGrid OldGrid, Move move);

    }
}
