using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_NEA
{
    class PlayerOptions
    {
        public static bool randomStart = false;
        public static bool randomEnd = false;
        public static int botDifficulty = 5;
    }
    class Grid
    {
        public static int gridSizeX = 7;
        public static int gridSizeY = 7;
        public static Cell[,] coordinates = new Cell[Grid.gridSizeX, Grid.gridSizeY];
        public static bool[,] InterpretedGrid;
        //public List<Node> AStarSolved = ;
    }
    class Cell
    {
        public bool[] walls;
        public int getX;
        public int getY;
        public Cell(int xCord, int yCord)
        {
            walls = new bool[] { true, true, true, true };
            getX = xCord;
            getY = yCord;
        }
    }
    class MazeCreation
    {
        public static void DrawNodeConnections()
        {
            bool[,] visitedCells = new bool[Grid.gridSizeX, Grid.gridSizeY];
            for (int i = 0; i < Grid.gridSizeX; i++)
            {
                for (int j = 0; j < Grid.gridSizeY; j++)
                {
                    visitedCells[i, j] = false;
                }
            }
            String[] directions = new String[] { "up", "down", "left", "right" };
            Cell currentCell = new Cell(0, 0);
            visitedCells[currentCell.getX, currentCell.getY] = true;
            Collection<Cell> cellColl = new Collection<Cell>();
            Random rnd = new Random();
            bool allCellsVisited = false;
            do
            {
                cellColl.Add(currentCell);
                string[] directionsRand = directions.OrderBy(x => rnd.Next()).ToArray();
                Array.Resize(ref directionsRand, 5);
                directionsRand[4] = "back";
                int cur = 0;
                bool moveComplete = false;
                while (moveComplete == false && cur < 5)
                {
                    switch (directionsRand[cur])
                    {
                        case "up":
                            if (currentCell.getY + 1 < Grid.gridSizeY == true)
                            {
                                if (visitedCells[(currentCell.getX), (currentCell.getY) + 1] == false)
                                {
                                    currentCell.walls[0] = false;
                                    currentCell = new Cell(currentCell.getX, currentCell.getY + 1);
                                    moveComplete = true;
                                    break;
                                }
                            }
                            cur++;
                            break;
                        case "down":
                            if (currentCell.getY - 1 >= 0 == true)
                            {
                                if (visitedCells[(currentCell.getX), (currentCell.getY) - 1] == false)
                                {
                                    currentCell.walls[1] = false;
                                    currentCell = new Cell(currentCell.getX, currentCell.getY - 1);
                                    moveComplete = true;
                                    break;
                                }
                            }
                            cur++;
                            break;
                        case "left":
                            if (currentCell.getX - 1 >= 0 == true)
                            {
                                if (visitedCells[(currentCell.getX) - 1, (currentCell.getY)] == false)
                                {
                                    currentCell.walls[2] = false;
                                    currentCell = new Cell(currentCell.getX - 1, currentCell.getY);
                                    moveComplete = true;
                                    break;
                                }
                            }
                            cur++;
                            break;
                        case "right":
                            if (currentCell.getX + 1 < Grid.gridSizeX)
                            {
                                if (visitedCells[(currentCell.getX) + 1, (currentCell.getY)] == false)
                                {
                                    currentCell.walls[3] = false;
                                    currentCell = new Cell(currentCell.getX + 1, currentCell.getY);
                                    moveComplete = true;
                                    break;
                                }
                            }
                            cur++;
                            break;
                        case "back":
                            if (cellColl.Count == 1)
                            {
                                moveComplete = true;
                                allCellsVisited = true;
                            }
                            else
                            {
                                cellColl.RemoveAt(cellColl.Count - 1);
                                currentCell = cellColl[cellColl.Count - 1];
                                cur = 0;
                            }
                            break;
                        default:
                            allCellsVisited = true;
                            break;
                    }
                    visitedCells[(currentCell.getX), (currentCell.getY)] = true;
                    Grid.coordinates[currentCell.getX, currentCell.getY] = currentCell;
                }
            } while (allCellsVisited == false);
        }
    }
}
