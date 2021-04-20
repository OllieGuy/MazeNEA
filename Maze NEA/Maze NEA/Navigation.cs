using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_NEA
{
    public class Navigation //: Form1
    {
        public static int currentPlayerPosX = createX("start");
        public static int currentPlayerPosY = createY("start");
        public static int endX = createX("end");
        public static int endY = createY("end");
        public static List<Node> solvedList = new List<Node>();
        public GridPictureBox gridPictureBox;
        public static int createX(string startOrEnd) // exists to create the random x values, taking if it is creating a start or end point as an argument
        {
            int x = -1;
            if (startOrEnd == "start")
            {
                if (PlayerOptions.randomStart)
                {
                    Random rnd = new Random();
                    x = rnd.Next(1, Grid.gridSizeX);
                    x = x * 2 + 1;
                    return x;
                }
            }
            else if (startOrEnd == "end")
            {
                if (PlayerOptions.randomEnd)
                {
                    Thread.Sleep(50);
                    Random rnd = new Random();
                    x = rnd.Next(1, Grid.gridSizeX);
                    x = x * 2+1;
                    return x;
                }
                else
                {
                    return 2 * Grid.gridSizeX - 1;
                }
            }
            return 1; // returns the default start
        }
        public static int createY(string startOrEnd)
        {
            Thread.Sleep(100); // so that the generation of the random numbers is different (time is used as a seed)
            int y = -1;
            if (startOrEnd == "start")
            {
                if (PlayerOptions.randomStart)
                {
                    Random rnd = new Random();
                    y = rnd.Next(1, Grid.gridSizeY);
                    y = y * 2 + 1;
                    return y;
                }
            }
            else if (startOrEnd == "end")
            {
                if (PlayerOptions.randomEnd)
                {
                    Thread.Sleep(50);
                    Random rnd = new Random();
                    y = rnd.Next(1, Grid.gridSizeY);
                    y = y * 2 + 1;
                    return y;
                }
                else
                {
                    return 2 * Grid.gridSizeY - 1;
                }
            }
            return 1; // returns the default start
        }
        public void Movement(Keys k)
        {
            switch (k) // looks at whick key has been pressed and interprets that into where the player will go with the inbuilt collision detection in the interpreted grid
            {
                case Keys.Up:
                    if (Grid.InterpretedGrid[currentPlayerPosX, currentPlayerPosY - 1])
                    {
                        currentPlayerPosY = currentPlayerPosY - 1;
                    }
                    break;
                case Keys.Down:
                    if (Grid.InterpretedGrid[currentPlayerPosX, currentPlayerPosY + 1])
                    {
                        currentPlayerPosY = currentPlayerPosY + 1;
                    }
                    break;
                case Keys.Left:
                    if (Grid.InterpretedGrid[currentPlayerPosX - 1, currentPlayerPosY])
                    {
                        currentPlayerPosX = currentPlayerPosX - 1;
                    }
                    break;
                case Keys.Right:
                    if (Grid.InterpretedGrid[currentPlayerPosX + 1, currentPlayerPosY])
                    {
                        currentPlayerPosX = currentPlayerPosX + 1;
                    }
                    break;
                case Keys.Escape: // pause/end button
                    MenuForm menu = new MenuForm();
                    menu.ShowDialog();
                    break;
                default:
                    break;
            }
        }
        private List<Node> returnOpenCells(Node currentPos) // returns the cells that are able to be traversed to next
        {
            List<Node> returnList = new List<Node>();
            if (Grid.InterpretedGrid[currentPos.x, currentPos.y + 1])
            {
                returnList.Add(new Node(currentPos.x, currentPos.y + 1, currentPos));
            }
            if (Grid.InterpretedGrid[currentPos.x, currentPos.y - 1])
            {
                returnList.Add(new Node(currentPos.x, currentPos.y - 1, currentPos));
            }
            if (Grid.InterpretedGrid[currentPos.x - 1, currentPos.y])
            {
                returnList.Add(new Node(currentPos.x - 1, currentPos.y, currentPos));
            }
            if (Grid.InterpretedGrid[currentPos.x + 1, currentPos.y])
            {
                returnList.Add(new Node(currentPos.x + 1, currentPos.y, currentPos));
            }
            return returnList;
        }
        public List<Node> AStarSolve() // the main solving algorithm that will return a list that will be moved along by the bot
        {
            List<Node> openList = new List<Node>();
            List<Node> closedList = new List<Node>();
            bool[,] closedListCheck = new bool[(2 * Grid.gridSizeX) + 1, (2 * Grid.gridSizeY) + 1];
            List<Node> orderedOpenList = new List<Node>(); // creates necessary lists
            openList.Add(new Node(1,1,"")); // creates starting node that uses the g value of 0, since usually g value would call a parent
            while (openList.Count() != 0)
            {
                orderedOpenList = openList.OrderBy(o => o.f).ToList(); // orders openList by the lowest f values to the highest
                Node current = orderedOpenList[0]; // sets current to be the node with the lowest f value
                if (current.x == endX && current.y == endY) // if the distance to the end of the maze is 0, break the loop
                {
                    //Console.WriteLine(endX.ToString(), endY.ToString());
                    //Console.WriteLine(current.x.ToString(), current.y.ToString());
                    break;
                }
                openList.Remove(current); // remove current from the openList
                //closedList.Add(current); // adds current to the closed list
                List<Node> successorList = returnOpenCells(current); // returns a list of the cells that it can traverse to
                for (int i = 0; i < successorList.Count(); i++) // for each node in the successor list
                {
                    ///
                    /// key thing : the closed list is not checked by the function meaning things can be added to the open list if its already closed
                    /// the parent function is not used to backtrack
                    ///
                    double tentativeGCur = current.g + 1;
                    if (tentativeGCur < successorList[i].g && !closedListCheck[successorList[i].x, successorList[i].y])
                    {
                        closedList.Add(current);
                        closedListCheck[successorList[i].x, successorList[i].y] = true;
                        successorList[i].g = tentativeGCur;
                        successorList[i].f = successorList[i].g + (Math.Sqrt((Math.Pow((endX - successorList[i].x), 2)) + ((Math.Pow((endY - successorList[i].y), 2)))));
                        bool found = false;
                        for (int j = 0; j < (openList.Count()); j++)
                        {
                            if (openList[j].x == successorList[i].x && openList[j].y == successorList[i].y)
                            {
                                found = true;
                                //openList.Add(successorList[i]);
                                break;
                            }
                        }
                        if (!found)
                        {
                            openList.Add(successorList[i]);
                        }
                    }
                }
            }
            if (closedList.Count > 50)
            {
            }
            List<Node> finalList = new List<Node>();
            closedList.Reverse();
            /*for (int i = 0; i < closedList.Count(); i++)
            {
                while (closedList[i].parent != null)
                {
                    finalList.Add(closedList[i].parent);
                }
            }*/
            //finalList.Reverse();
            return (closedList);
        }
    }
    public class Node : Navigation // the nodes that the A* algorithm can traverse to are created here
    {
        public int x;
        public int y;
        public double g;
        public double h;
        public double f;
        public Node parent;
        public Node(int xCoord, int yCoord, Node cur)
        {
            x = xCoord;
            y = yCoord;
            parent = cur;
            g = 1000000; //gCost(x, y); //distance from the start node (pythagoras)
            h = hCost(x, y); //distance from the end node (pythagoras)
            f = 1000000; //fCost(x, y); //combination of g and f costs
        }
        public Node(int xCoord, int yCoord, string start)
        {
            x = xCoord;
            y = yCoord;
            g = 0; //distance from the start node (pythagoras)
            h = hCost(x, y); //distance from the end node (pythagoras)
            f = hCost(x, y); //combination of g and f costs
            this.parent = null;
        }
        protected double gCost(int curX, int curY)
        {
            //double result = Math.Sqrt((Math.Pow((1 - curX), 2)) + ((Math.Pow((1 - curY), 2))));
            double result = this.parent.g + 1.0;
            return result;
        }
        private double hCost(int curX, int curY)
        {
            double result = Math.Sqrt((Math.Pow((endX - curX), 2)) + ((Math.Pow((endY - curY), 2))));
            return result;
        }
        private double fCost(int curX, int curY)
        {
            //chris is a prick: Convert.ToInt32(10 * (gCost(curX, curY) + hCost(curX, curY)));
            double fCost = gCost(curX, curY) + hCost(curX, curY);
            return fCost;
        }
    }
}
