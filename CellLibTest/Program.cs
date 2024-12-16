using CellPottsLib;
using CellPottsLib.DataStructs;
using CellPottsLib.Grid;
using CellPottsLib.Grid.CellTypes;
using CellPottsLib.Logging;
using CellPottsLib.Logic;
using CellPottsLib.Logic.Units;
using System.Runtime.CompilerServices;

namespace CellLibTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Simulation sim = new Simulation(new IntVector2D(50, 20), "C:\\Users\\daniel.seeger\\source\\repos\\CellPottsLib\\CellPottsLib\\Logging\\Log.json");
            sim.AddLogicUnit(new VolumeEnergyUnit());
            sim.AddLogicUnit(new CircumferenceEnergyUnit());
            sim.Grid.DefineCellType(new StandartType("test1", 1, 100) { TargetVolume = 20, TargetCircumference = 5 });
            sim.Grid.SetPixel(10, 10, 1);
            sim.Grid.SetPixel(10, 11, 2);
            sim.Grid.SetPixel(10, 12, 3);
            Logger.Clearlog();

            DrawGrid(sim.Grid);
            Console.ReadKey();


            for (int i = 0; i < 100; i++)
            {
                Timestep(sim);
                DrawGrid(sim.Grid);
                foreach(Cell cell in sim.Grid.GetCells())
                {
                    LogEntry entry = new LogEntry() { Type = "DEBUG", Time = DateTime.Now, Message = $"Step {i}", Data = new { Circumference = cell.Circumference, Volume = cell.Volume }, Sender = "cell " +  cell.Identity.ToString() };
                    Logger.Log(entry);
                }
            }
            Logger.FinalizeLog();
            Console.ReadKey();
        }

        private static void Timestep(Simulation sim)
        {
            sim.Step();
        }
        private static void DrawGrid(I2DGrid grid)
        {
            for(int x = 0; x < grid.GridSize.x; x++)
            {
                for (int y = 0; y < grid.GridSize.y; y++)
                {
                    Console.SetCursorPosition(x, y);
                    Console.Write(grid.GetPixel(x, y));
                }
            }
        }
    }
}
