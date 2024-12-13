using CellPottsLib.DataStructs;
using CellPottsLib.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Logic.Units
{
    public class VolumeEnergyUnit : EnergyUnitBase
    {
        public VolumeEnergyUnit(double weighting = 1) : base("VEU")
        { 
            Weighting = weighting;
        }

        public override double CalculateEnergy(I2DGrid grid)
        {
            double VEnergy = CalculateVolumeEnergy(grid);
            return Weighting * VEnergy;

        }

        public override double CalculateEnergyChange(I2DGrid grid, IntVector2D position, int newState)
        {
            int IdentityCell1 = grid.CurrentGrid[position.x, position.y];
            int IdentityCell2 = newState;

            I2DGrid newGrid = grid.Clone();
            newGrid.CurrentGrid[position.x, position.y] = newState;

            if (IdentityCell1 == IdentityCell2)
            {
                return 0;
            }
            Cell? Cell1Old = null;
            Cell? Cell2Old = null;
            Cell? Cell1New = null;
            Cell? Cell2New = null;

            if(!(IdentityCell1 == Registry.BackgroundIdentity))
            {
                Cell1Old = grid.GetCell(IdentityCell1);
                Cell1New = newGrid.GetCell(IdentityCell1);
            }
            if(!(IdentityCell2 == Registry.BackgroundIdentity))
            {
                Cell2Old = grid.GetCell(IdentityCell2);
                Cell2New = newGrid.GetCell(IdentityCell2);
            }

            double EnergyChange = 0;

            if(Cell1Old != null && Cell1New != null)
            {
                EnergyChange += (Math.Pow((Cell1New.Volume - grid.GetCellType(IdentityCell1).TargetVolume),2) - Math.Pow((Cell1Old.Volume - grid.GetCellType(IdentityCell1).TargetVolume),2));
            }

            if (Cell2Old != null && Cell2New != null)
            {
                EnergyChange += (Math.Pow((Cell2New.Volume - grid.GetCellType(IdentityCell2).TargetVolume), 2) - Math.Pow((Cell2Old.Volume - grid.GetCellType(IdentityCell2).TargetVolume), 2));
            }

            return EnergyChange;
        }

        public override double CalculateEnergyChange(I2DGrid OldGrid, Move move)
        {
            return CalculateEnergyChange(OldGrid, move.Target, OldGrid.CurrentGrid[move.Source.x,move.Source.y]);
        }

        public override double CalculateEnergyChange(I2DGrid OldGrid, I2DGrid newGrid)
        {
            return CalculateEnergy(newGrid) - CalculateEnergy(OldGrid);
        }

        private double CalculateVolumeEnergy(I2DGrid grid)
        {
            double energy = 0;
            List<Cell> cells = grid.GetCells();
            if (cells.Count == 0)
            {
                return 0;
            }
            foreach (Cell cell in cells)
            {
                if (grid.GetCellType(cell.Identity) == null)
                {
                    throw new ArgumentException($"Cell {cell.Identity} has no CellType");
                }
                double targetVolume = grid.GetCellType(cell.Identity).TargetVolume;
                energy += Math.Pow((targetVolume - cell.Volume), 2);
            }

            return energy;
        }

        private double CalculateCircumferenceEnergy(I2DGrid grid)
        {
            double energy = 0;
            List<Cell> cells = grid.GetCells();
            if (cells.Count == 0)
            {
                return 0;
            }
            foreach (Cell cell in cells)
            {
                if (grid.GetCellType(cell.Identity) == null)
                {
                    throw new ArgumentException($"Cell {cell.Identity} has no CellType");
                }
                energy += Math.Pow((grid.GetCellType(cell.Identity).TargetCircumference - cell.Circumference), 2);
            }
            return energy;
        }

    }
}
