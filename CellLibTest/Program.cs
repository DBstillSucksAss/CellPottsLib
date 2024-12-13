using CellPottsLib;
using CellPottsLib.DataStructs;
using CellPottsLib.Grid;
using CellPottsLib.Grid.CellTypes;
using CellPottsLib.Logic;
using CellPottsLib.Logic.Units;

namespace CellLibTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Simulation sim = new Simulation(new IntVector2D(10, 10));
            VolumeEnergyUnit veu = new VolumeEnergyUnit();
            sim.AddLogicUnit(veu);
            CellTypeDefinition ctd = new StandartType("Test", 1, 200);
            ctd.TargetVolume = 10;
            sim.Grid.DefineCellType(ctd);
            sim.Grid.SetPixel(new IntVector2D(5, 5), 1);
            sim.Grid.SetPixel(new IntVector2D(6, 4), 1);

            DrawGrid(sim.Grid);
            Logger.SetLogPath("C:\\Users\\seege\\Source\\Repos\\DBstillSucksAss\\CellPottsLib\\CellPottsLib\\log.txt");
            Logger.Clearlog();
            Console.ReadKey();

            for (int i = 0; i < 1000; i++)
            {
                Timestep(sim);
                Thread.Sleep(10);
                Logger.Log($"Step {i} done.   Volume: {sim.Grid.GetCell(1).Volume}" , sim);
            }
            Console.ReadKey();
        }

        private static void Timestep(Simulation sim)
        {
            sim.Step(1);
            DrawGrid(sim.Grid);
        }
        private static void DrawGrid(I2DGrid grid)
        {
            int[,] currentGrid = grid.CurrentGrid;
            for (int x = 0; x < currentGrid.GetLength(0); x++)
            {
                for (int y = 0; y < currentGrid.GetLength(1); y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(currentGrid[x, y]);
                }
            }
        }
    }
}
