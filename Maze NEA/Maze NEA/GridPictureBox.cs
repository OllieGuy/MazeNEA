using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_NEA
{
    public class GridPictureBox : Grid
    {
        int size = 16; // default size, changed when the size of the window is changed
        Form1 form;
        bool firstDraw = true;
        public bool[,] InterpretGrid() // interprets the grid created into one that may be displayed - very crucial to the program despite only being called once
        {
            bool[,] InterpretedCellGrid = new bool[(2 * Grid.gridSizeX) + 1, (2 * Grid.gridSizeY) + 1];
            for (int i = 0; i < (2 * Grid.gridSizeX) + 1; i++)
            {
                for (int j = 0; j < (2 * Grid.gridSizeY) + 1; j++) // for all the coordinates it can be
                {
                    if (i % 2 == 0 && j % 2 == 0 && i != 0 && j != 0) // if the i and j are even and they are not 0
                    {
                        InterpretedCellGrid[i - 1, j - 1] = true;
                        for (int x = 0; x <= 3; x++)
                        {
                            if (Grid.coordinates[(i - 1) / 2, (j - 1) / 2].walls[x] == false) // if the current wall is broken, clear it in the interpreted grid
                            {
                                switch (x)
                                {
                                    case 0:
                                        InterpretedCellGrid[i - 1, j] = true;
                                        break;
                                    case 1:
                                        InterpretedCellGrid[i - 1, j - 2] = true;
                                        break;
                                    case 2:
                                        InterpretedCellGrid[i - 2, j - 1] = true;
                                        break;
                                    case 3:
                                        InterpretedCellGrid[i, j - 1] = true;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            Grid.InterpretedGrid = InterpretedCellGrid;
            return InterpretedCellGrid;
        }
        public GridPictureBox(Form1 FormPass)
        {
            form = FormPass; // takes in the form so it can look at the width and height
        }

        public void SetBoxDimensions() // resizes the size of the boxes to be in line with the size of the window
        {
            if (form.Width / Grid.gridSizeX < form.Height / Grid.gridSizeY) // if the height is greater than the width of the resized window
            {
                size = (form.Width / (2 * Grid.gridSizeX + (Convert.ToInt32(Math.Round(0.3 * Grid.gridSizeX))))) - 1;
            }
            else
            {
                size = (form.Height / (2 * Grid.gridSizeY + (Convert.ToInt32(Math.Round(0.3 * Grid.gridSizeY))))) - 1;
            }
            form.Refresh(); // redraw with new dimensions
        }
        public void Draw(Graphics g) // draws the grid with the player, end and bot position
        {
            Brush brush; // creates the brushes to draw positions
            Brush playerBrush;
            Brush endBrush;
            Brush botBrush;
            if (firstDraw)
            {
                for (int i = 0; i < (2 * Grid.gridSizeX + 1); i++)
                {
                    for (int j = 0; j < (2 * Grid.gridSizeY + 1); j++)
                    {
                        brush = Brushes.Black; // wall colour by default, when the cell is clear then it is set to white
                        if (Grid.InterpretedGrid[i, j])
                        {
                            brush = Brushes.White;
                        }
                        g.FillRectangle(brush, i * (size), j * (size), size, size);
                    }
                }
            }
            Navigation nav = new Navigation();
            List<Node> solvedList = nav.AStarSolve(); // gets the fastest way to the end of the maze
            Grid.solvedList = solvedList;
            botBrush = Brushes.Red;
            if (Math.Floor(Grid.startTime.Elapsed.TotalSeconds) > ((11-PlayerOptions.botDifficulty)/10)*Grid.botMoves && Grid.botMoves < solvedList.Count()-1) // checks the time and then moves the bot in accordance with the bot difficulty decided by the player in settings
            {
                Grid.botMoves++; // move the bot along the solved list
            }
            /*for (int i = 0; i<solvedList.Count();i++) // code that will display the full bot path
            {
                g.FillRectangle(botBrush, solvedList[i].x * (size), solvedList[i].y * (size), size, size);
            }*/
            g.FillRectangle(botBrush, solvedList[Grid.botMoves].x * (size), solvedList[Grid.botMoves].y * (size), size, size);
            playerBrush = Brushes.Green;
            g.FillRectangle(playerBrush, Navigation.currentPlayerPosX * (size), Navigation.currentPlayerPosY * (size), size, size);
            endBrush = Brushes.Blue;
            g.FillRectangle(endBrush, Navigation.endX * (size), Navigation.endY * (size), size, size);
            if (Navigation.currentPlayerPosX == Navigation.endX && Navigation.currentPlayerPosY == Navigation.endY) // if the end of the maze has been reached
            {
                endBrush = Brushes.Gold;
                g.FillRectangle(endBrush, Navigation.endX * (size), Navigation.endY * (size), size, size);
                Thread.Sleep(250);
                MessageBox.Show("You found the end in " + Math.Floor(Grid.startTime.Elapsed.TotalSeconds) + " seconds!"); // displays to the user they have reached the end and exits the program after a short delay
                Thread.Sleep(1000);
                Application.Exit();
            }
            if (solvedList[Grid.botMoves].x == Navigation.endX && solvedList[Grid.botMoves].y == Navigation.endY) // if the player loses
            {
                endBrush = Brushes.Orange;
                g.FillRectangle(endBrush, Navigation.endX * (size), Navigation.endY * (size), size, size);
                Thread.Sleep(250);
                MessageBox.Show("You lost!"); // displays to the user they have lost and exits the program after a short delay
                Thread.Sleep(1000);
                Application.Exit();
            }
        }
    }
}
