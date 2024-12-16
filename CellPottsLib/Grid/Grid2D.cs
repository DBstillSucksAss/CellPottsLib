using CellPottsLib.DataStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPottsLib.Grid
{
    public class Grid2D : I2DGrid
    {
        public int[,] CurrentGrid => grid;
        public IntVector2D GridSize => new IntVector2D(grid.GetLength(0),grid.GetLength(1));

        private List<CellTypeDefinition> cellTypes;
        private List<int> UsedIdentitys;
        private int[,] grid;

        public Grid2D(IntVector2D size, List<CellTypeDefinition>? typeDefonitions = null)
        {
            grid = new int[size.x, size.y];
            if(typeDefonitions == null)
            {
                cellTypes = new List<CellTypeDefinition>();
            }
            else
            {
                cellTypes = typeDefonitions;
            }
            UsedIdentitys = new();
        }

        public I2DGrid Clone()
        {
            Grid2D newGrid = new Grid2D(GridSize,cellTypes);
            newGrid.SetUsedIdentitys(UsedIdentitys);
            newGrid.grid = (int[,])grid.Clone();
            return newGrid;
        }

        public void DefineCellType(CellTypeDefinition typeDefinition)
        {
            if(cellTypes.Any(x => x.Name == typeDefinition.Name))
            {
                throw new ArgumentException("Cell type with same Name already defined");
            }
            foreach (CellTypeDefinition type in cellTypes)
            {
                if (type.IntersectsWith(typeDefinition))
                {
                    throw new ArgumentException("Indentity range of this Cell type intersects with that of an already defined Type");
                }
            }
            cellTypes.Add(typeDefinition);
        }

        public Cell? GetCell(int identity)
        {
            if(!UsedIdentitys.Contains(identity))
            {
                return null;
            }
            List<IntVector2D> cells = new List<IntVector2D>();
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    if (grid[x, y] == identity)
                    {
                        cells.Add(new IntVector2D(x, y));
                    }
                }
            }
            return new Cell(identity, cells);
        }

        public CellTypeDefinition? GetCellType(int identity)
        {
            foreach (CellTypeDefinition type in cellTypes)
            {
                if (type.Contains(identity))
                {
                    return type;
                }
            }
            return null;
        }

        public List<IntVector2D> GetNeighbours(IntVector2D pos, bool diagonalNeighbours = true)
        {
            List<IntVector2D> neighbours = new List<IntVector2D>();
            List<int> xPos = new List<int>() { pos.x };
            List<int> yPos = new List<int>() { pos.y };
            if(pos.x > 0) { xPos.Add(pos.x -1); }
            if(pos.y > 0) { yPos.Add(pos.y - 1); }
            if(pos.x < GridSize.x - 1) { xPos.Add(pos.x + 1); }
            if(pos.y < GridSize.y - 1) { yPos.Add(pos.y +1); }
            for (int x = 0; x < xPos.Count; x++)
            {
                for(int y =0; y < yPos.Count; y++)
                {
                    if(xPos[x] == pos.x && yPos[y] == pos.y)
                    {
                        continue;
                    }
                    if (!diagonalNeighbours)
                    {
                        if (xPos[x] - pos.x == -1 || xPos[x] - pos.x == 1)
                        {
                            if (yPos[y] -pos.y == -1 || yPos[y] - pos.y == 1)
                            {
                                continue;
                            }
                        }
                    }
                    neighbours.Add(new IntVector2D(xPos[x], yPos[y]));
                }
            }
            return neighbours;  
        }

        public int GetPixel(int x, int y)
        {
            return grid[x, y];
        }

        public int GetPixel(IntVector2D pos)
        {
            return grid[pos.x, pos.y];
        }

        public void SetPixel(int x, int y, int value)
        {
            if(!UsedIdentitys.Contains(value) && value != Registry.BackgroundIdentity)
            {
                UsedIdentitys.Add(value);
            }
            grid[x, y] = value;
        }

        public void SetPixel(IntVector2D pos, int value)
        {
            if (!UsedIdentitys.Contains(value))
            {
                UsedIdentitys.Add(value);
            }
            grid[pos.x, pos.y] = value;
        }

        public void SetUsedIdentitys(List<int> usedIdentitys)
        {
            UsedIdentitys = usedIdentitys;
        }

        public List<Cell> GetCells()
        {
            List<Cell> cells = new List<Cell>();
            foreach (int identity in UsedIdentitys)
            {
                if(identity == Registry.BackgroundIdentity)
                {
                    continue;
                }
                Cell? tempcell = GetCell(identity);
                if (tempcell != null)
                {
                    cells.Add((Cell)tempcell);
                }
            }
            return cells;
        }

        public List<int> GetIdentitys()
        {
            return UsedIdentitys;
        }
    }
}
