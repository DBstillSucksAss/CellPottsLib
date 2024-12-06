using CellPottsLib.DataStructs;
using CellPottsLib.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Logic
{
    public class EnergyCalculator : IEnergyCalculator
    {
        private List<EnergyUnitBase> EnergyUnits;

        public EnergyCalculator()
        {
            EnergyUnits = new List<EnergyUnitBase>();
        }

        public void AddEnergyUnit(EnergyUnitBase unit, double maxEnergyDifference = 0)
        {
            if(!EnergyUnits.Any(x => x.ID == unit.ID))
            {
                EnergyUnits.Add(unit);
                unit.SetNormalization(maxEnergyDifference);
            }
        }

        public double CalculateEnergy(I2DGrid grid)
        {
            double Energy = 0;
            foreach (EnergyUnitBase unit in EnergyUnits)
            {
                Energy += unit.CalculateEnergy(grid);
            }
            return Energy;
        }

        public double CalculateEnergyChange(I2DGrid grid, IntVector2D position, int newState)
        {
            I2DGrid newGrid = grid.Clone();
            newGrid.SetPixel(position, newState);
            return CalculateEnergyChange(grid, newGrid);
        }

        public double CalculateEnergyChange(I2DGrid OldGrid, I2DGrid newGrid)
        {
            double EnergyChange = 0;
            foreach (EnergyUnitBase unit in EnergyUnits)
            {
                EnergyChange += unit.CalculateEnergyChange(OldGrid, newGrid);
            }
            return EnergyChange;
        }

        public void DisableNormalization(string UnitID)
        {
            EnergyUnitBase? unit = GetEnergyUnit(UnitID);
            if (unit != null)
            {
                unit.DisableNormalization();
            }
        }

        public void DisableNormalizationAllUnits()
        {
            foreach (EnergyUnitBase unit in EnergyUnits)
            {
                unit.DisableNormalization();
            }
        }

        public void EnableNormalization(string UnitID)
        {
            EnergyUnitBase? unit = GetEnergyUnit(UnitID);
            if(unit != null)
            {
                unit.SetNormalization(unit.PotentialMaxEnergyChange);
            }
        }


        public void EnableNormalizationAllUnits()
        {
            foreach (EnergyUnitBase unit in EnergyUnits)
            {
                unit.SetNormalization(unit.PotentialMaxEnergyChange);
            }
        }

        public EnergyUnitBase? GetEnergyUnit(string ID)
        {
            return EnergyUnits.Find(x => x.ID == ID) ?? null;
        }

        public List<EnergyUnitBase> GetEnergyUnits()
        {
            return EnergyUnits;
        }

        public void RemoveEnergyUnit(string ID)
        {
            EnergyUnits.Remove(EnergyUnits.Find(x => x.ID == ID));
        }

        public void SetNormalizationValue(string UnitID, double maxEnergyDifference)
        {
            EnergyUnitBase? unit = GetEnergyUnit(UnitID);
            if (unit != null)
            {
                unit.SetNormalization(maxEnergyDifference);
            }

        }
    }
}
