using CellPottsLib.DataStructs;
using CellPottsLib.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Logic.Units
{
    public class CircumferenceEnergyUnit : EnergyUnitBase
    {
        public CircumferenceEnergyUnit(double weighting = 1) : base("CEU")
        {
            Weighting = weighting;
        }

        public override double CalculateEnergy(I2DGrid grid)
        {
            List<Cell> Cells = grid.GetCells();
            double Energy = 0;
            foreach (Cell cell in Cells)
            {
                Energy += CalculateCircumferenceEnergy(cell,grid);
            }
            return Energy;
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

            //if Identity is background Identity, there is no Circumference Energy for that Identity
            if (!(IdentityCell1 == Registry.BackgroundIdentity))
            {
                Cell1Old = grid.GetCell(IdentityCell1);
                Cell1New = newGrid.GetCell(IdentityCell1);
            }
            if (!(IdentityCell2 == Registry.BackgroundIdentity))
            {
                Cell2Old = grid.GetCell(IdentityCell2);
                Cell2New = newGrid.GetCell(IdentityCell2);
            }

            double EnergyChange = 0;

            if (Cell1Old != null && Cell1New != null)
            {
                EnergyChange += CalculateCircumferenceEnergy(Cell1New, grid) - CalculateCircumferenceEnergy(Cell1Old, grid);
            }
            if(Cell2Old != null && Cell2New != null)
            {
                EnergyChange += CalculateCircumferenceEnergy(Cell2New, grid) - CalculateCircumferenceEnergy(Cell2Old, grid);
            }

            return EnergyChange;
        }

        //Don't use if not necessary, this has a really fucking bad performance. Only needs to be used if more than one Pixel is changed between old and new state
        public override double CalculateEnergyChange(I2DGrid OldGrid, I2DGrid newGrid)
        {
            return CalculateEnergy(newGrid) - CalculateEnergy(OldGrid);
        }

        public override double CalculateEnergyChange(I2DGrid OldGrid, Move move)
        {
            IntVector2D Position = move.Target;
            int NewState = OldGrid.CurrentGrid[move.Source.x, move.Source.y];
            return CalculateEnergyChange(OldGrid, Position, NewState);
        }

        private double CalculateCircumferenceEnergy(Cell cell, I2DGrid grid)
        {
            double Energyfactor = grid.GetCellType(cell.Identity).GetEnergyFactor("circumference") ?? Registry.CircumferenceFactor;
            int TargetCircumference = grid.GetCellType(cell.Identity).TargetCircumference;
            int Circumference = cell.Circumference;
            return Math.Pow(Circumference - TargetCircumference, 2) * Energyfactor;
        }
    }
}
