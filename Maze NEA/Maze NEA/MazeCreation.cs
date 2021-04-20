using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_NEA
{
    class PlayerOptions // options that can be edited within settings
    {
        public static bool randomStart = false;
        public static bool randomEnd = false;
        public static int botDifficulty = 5;
    }
    class Grid // the basic information about the grid
    {
        public static int gridSizeX = 7;
        public static int gridSizeY = 7;
        public static Cell[,] coordinates = new Cell[Grid.gridSizeX, Grid.gridSizeY];
        public static bool[,] InterpretedGrid;
        //public List<Node> AStarSolved = ;
    }
    class Cell // the class that is used as the intermediary translator between the initial grid creation and the interpreted grid
    {
        public bool[] walls;
        public int getX;
        public int getY;
        public Cell(int xCord, int yCord)
        {
            walls = new bool[] { true, true, true, true }; // up, down, left, right
            getX = xCord;
            getY = yCord;
        }
    }
    class MazeCreation
    {
        public static void DrawNodeConnections() // initial maze creation
        {
            bool[,] visitedCells = new bool[Grid.gridSizeX, Grid.gridSizeY];
            for (int i = 0; i < Grid.gridSizeX; i++) // sets all the cells to not visited
            {
                for (int j = 0; j < Grid.gridSizeY; j++)
                {
                    visitedCells[i, j] = false;
                }
            }
            String[] directions = new String[] { "up", "down", "left", "right" }; // corresponds with order of walls
            Cell currentCell = new Cell(0, 0); // creates the current cell at (0,0), although this could be set to any value
            visitedCells[currentCell.getX, currentCell.getY] = true;
            Collection<Cell> cellColl = new Collection<Cell>(); // creates a collection of cells to be used like a stack
            Random rnd = new Random();
            bool allCellsVisited = false;
            do // used since the check must be at the end
            {
                cellColl.Add(currentCell);
                string[] directionsRand = directions.OrderBy(x => rnd.Next()).ToArray(); // randomly shuffles the directions
                Array.Resize(ref directionsRand, 5); // resizes the direction so "back" can be appended
                directionsRand[4] = "back";
                int cur = 0;
                bool moveComplete = false;
                while (moveComplete == false && cur < 5)
                {
                    switch (directionsRand[cur]) // checks which direction it is trying to go, makes sure it can travel there then does and breaks the appropriate wall of the cell
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
                        case "back": // the literal "back" bone of the recursive backtracking algorithm
                            if (cellColl.Count == 1) // if the cell collection only contains one entry, everywhere else has been visited so the generation is complete
                            {
                                moveComplete = true;
                                allCellsVisited = true;
                            }
                            else
                            {
                                cellColl.RemoveAt(cellColl.Count - 1); // remove the top cell from the cell collection
                                currentCell = cellColl[cellColl.Count - 1]; // moves on to the next cell
                                cur = 0; // makes it so that the walls can now be rechecked
                            }
                            break;
                        default: // should never be reached
                            allCellsVisited = true;
                            break;
                    }
                    visitedCells[(currentCell.getX), (currentCell.getY)] = true; // sets the new current cell to be visited
                    Grid.coordinates[currentCell.getX, currentCell.getY] = currentCell;
                }
            } while (allCellsVisited == false);
        }
    }
}
