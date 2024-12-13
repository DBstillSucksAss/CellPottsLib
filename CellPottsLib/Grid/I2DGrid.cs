using CellPottsLib.DataStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Grid
{
    public interface I2DGrid
    {
        public int[,] CurrentGrid { get; }
        public IntVector2D GridSize { get; }
        public I2DGrid Clone();
        public Cell? GetCell(int identity);
        public List<Cell> GetCells();
        public List<int> GetIdentitys();
        public void DefineCellType(CellTypeDefinition typeDefinition);
        public CellTypeDefinition GetCellType(int identity);
        public void SetPixel(int x, int y, int value);
        public void SetPixel(IntVector2D pos, int value);
        public int GetPixel(int x, int y);
        public int GetPixel(IntVector2D pos);
        public List<IntVector2D> GetNeighbours(IntVector2D pos, bool diagonalNeighbours = true);

    }
}
