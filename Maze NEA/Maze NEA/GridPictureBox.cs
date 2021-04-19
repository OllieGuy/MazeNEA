using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_NEA
{
    public class GridPictureBox
    {
        int size = 16;
        Form1 form;
        bool firstDraw = true;
        public bool[,] InterpretGrid()
        {
            bool[,] InterpretedCellGrid = new bool[(2 * Grid.gridSizeX) + 1, (2 * Grid.gridSizeY) + 1];
            for (int i = 0; i < (2 * Grid.gridSizeX) + 1; i++)
            {
                for (int j = 0; j < (2 * Grid.gridSizeY) + 1; j++)
                {
                    if (i % 2 == 0 && j % 2 == 0 && i != 0 && j != 0)
                    {
                        InterpretedCellGrid[i - 1, j - 1] = true;
                        for (int x = 0; x <= 3; x++)
                        {
                            if (Grid.coordinates[(i - 1) / 2, (j - 1) / 2].walls[x] == false)
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
            form = FormPass;
        }

        public GridPictureBox()
        {
        }

        public void SetBoxDimensions()
        {
            if (form.Width / Grid.gridSizeX < form.Height / Grid.gridSizeY)
            {
                size = (form.Width / (2 * Grid.gridSizeX + (Convert.ToInt32(Math.Round(0.3 * Grid.gridSizeX))))) - 1;
            }
            else
            {
                size = (form.Height / (2 * Grid.gridSizeY + (Convert.ToInt32(Math.Round(0.3 * Grid.gridSizeY))))) - 1;
            }
            form.Refresh();
        }
        /*public void CreatePath()
        {
            
            Navigation nav = new Navigation();
            List<Node> solvedList = nav.AStarSolve();
        }*/
        

        public void Draw(Graphics g)
        {
            Brush brush;
            /*Brush playerBrush;
            Brush endBrush;
            if (firstDraw)
            {
                for (int i = 0; i < (2 * Grid.gridSizeX + 1); i++)
                {
                    for (int j = 0; j < (2 * Grid.gridSizeY + 1); j++)
                    {
                        brush = Brushes.Black;
                        if (Grid.InterpretedGrid[i, j])
                        {
                            brush = Brushes.White;
                        }
                        g.FillRectangle(brush, i * (size), j * (size), size, size);
                    }
                }
            }
            playerBrush = Brushes.Green;
            g.FillRectangle(playerBrush, Navigation.currentPlayerPosX * (size), Navigation.currentPlayerPosY * (size), size, size);
            endBrush = Brushes.Blue;
            g.FillRectangle(endBrush, Navigation.endX * (size), Navigation.endY * (size), size, size);
            if (Navigation.currentPlayerPosX == Navigation.endX && Navigation.currentPlayerPosY == Navigation.endY)
            {
                endBrush = Brushes.Gold;
                g.FillRectangle(endBrush, Navigation.endX * (size), Navigation.endY * (size), size, size);
            }*/
            List<Node> solvedList = Navigation.solvedList;
            Console.WriteLine(solvedList.Count());
            for (int i = 0; i < (2 * Grid.gridSizeX + 1); i++)
            {
                for (int j = 0; j < (2 * Grid.gridSizeY + 1); j++)
                {
                    for (int k = 0; k < solvedList.Count(); k++)
                    {
                        brush = Brushes.Red;
                        if (solvedList[k].x == i && solvedList[k].y == j)
                        {
                            brush = Brushes.Orange;
                        }
                        g.FillRectangle(brush, i * (size), j * (size), size, size);
                    }
                }
            }
        }
    }
}
