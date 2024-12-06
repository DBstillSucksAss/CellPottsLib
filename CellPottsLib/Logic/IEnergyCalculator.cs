using CellPottsLib.DataStructs;
using CellPottsLib.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Logic
{
    public interface IEnergyCalculator
    {
        public double CalculateEnergy(I2DGrid grid);
        public double CalculateEnergyChange(I2DGrid grid, IntVector2D position, int newState);
        public double CalculateEnergyChange(I2DGrid OldGrid, I2DGrid newGrid);
        public void EnableNormalizationAllUnits();
        public void EnableNormalization(string UnitID);
        public void DisableNormalization(string UnitID);
        public void DisableNormalizationAllUnits();
        public void SetNormalizationValue(string UnitID, double maxEnergyDifference);
        public void AddEnergyUnit(EnergyUnitBase unit, double maxEnergyDifference = 0);
        public void RemoveEnergyUnit(string ID);
        public EnergyUnitBase? GetEnergyUnit(string ID);
        public List<EnergyUnitBase> GetEnergyUnits();

    }
}
