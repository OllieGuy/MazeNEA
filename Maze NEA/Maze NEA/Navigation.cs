using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_NEA
{
    public class Navigation
    {
        // uses the createX or createY functions to allow for the random start and end points
        public static int currentPlayerPosX = createX("start"); 
        public static int currentPlayerPosY = createY("start");
        public static int endX = createX("end");
        public static int endY = createY("end");
        private static int createX(string startOrEnd) // exists to create the random x values, taking if it is creating a start or end point as an argument
        {
            int x = -1; // defaults to an unacceptable value, so the program will exit with an error if something is wrong
            if (startOrEnd == "start")
            {
                if (PlayerOptions.randomStart)
                {
                    Random rnd = new Random();
                    x = rnd.Next(1, Grid.gridSizeX); // randomly generates a value
                    x = x * 2 + 1; // interprets it so it is guaranteed to be an open space in the interpreted grid
                    return x;
                }
            }
            else if (startOrEnd == "end")
            {
                if (PlayerOptions.randomEnd)
                {
                    Thread.Sleep(50); // to use a different seed
                    Random rnd = new Random();
                    x = rnd.Next(1, Grid.gridSizeX);
                    x = x * 2 + 1;
                    return x;
                }
                else
                {
                    return 2 * Grid.gridSizeX - 1; // return the default end
                }
            }
            return 1; // returns the default start
        }
        private static int createY(string startOrEnd)
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
                case Keys.Up: // up arrow key
                    if (Grid.InterpretedGrid[currentPlayerPosX, currentPlayerPosY - 1]) // collision detection
                    {
                        currentPlayerPosY = currentPlayerPosY - 1;
                    }
                    break;
                case Keys.Down: // down arrow key
                    if (Grid.InterpretedGrid[currentPlayerPosX, currentPlayerPosY + 1])
                    {
                        currentPlayerPosY = currentPlayerPosY + 1;
                    }
                    break;
                case Keys.Left: // left arrow key
                    if (Grid.InterpretedGrid[currentPlayerPosX - 1, currentPlayerPosY])
                    {
                        currentPlayerPosX = currentPlayerPosX - 1;
                    }
                    break;
                case Keys.Right: // right arrow key
                    if (Grid.InterpretedGrid[currentPlayerPosX + 1, currentPlayerPosY])
                    {
                        currentPlayerPosX = currentPlayerPosX + 1;
                    }
                    break;
                case Keys.Escape: // pause/end button
                    MenuForm menu = new MenuForm();
                    menu.ShowDialog(); // shows the menu
                    break;
                default:
                    break; // nothing will happen if an invalid key is pressed (would interrupt the flow of the game)
            }
        }
        private List<Node> returnOpenCells(Node currentPos, bool[,] closedListCheck) // returns the cells that are able to be traversed to next
        {
            List<Node> returnList = new List<Node>(); // creates the list with nodes to return, originally with nothing in it
            if (Grid.InterpretedGrid[currentPos.x, currentPos.y + 1]) // if the node is accessible, return it
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
            return returnList; // reurn the nodes that can be traversed to
        }
        public List<Node> AStarSolve() // the main solving algorithm that will return a list that will be moved along by the bot
        {
            List<Node> openList = new List<Node>(); // list of nodes that are available to be traversed to that have not been visited
            List<Node> closedList = new List<Node>(); // list of nodes already visited and evaluated
            bool[,] closedListCheck = new bool[(2 * Grid.gridSizeX) + 1, (2 * Grid.gridSizeY) + 1];
            bool[,] openListCheck = new bool[(2 * Grid.gridSizeX) + 1, (2 * Grid.gridSizeY) + 1];
            List<Node> orderedOpenList = new List<Node>(); // creates necessary list so that the open list in order to take the lowest f value
            openList.Add(new Node(currentPlayerPosX,currentPlayerPosY,"")); // creates starting node that uses the g value of 0, since usually g value would call a parent
            while (openList.Count() != 0)
            {
                orderedOpenList = openList.OrderBy(o => o.f).ToList(); // orders openList by the lowest f values to the highest
                Node current = orderedOpenList[0]; // sets current to be the node with the lowest f value
                if (current.x == endX && current.y == endY) // if the distance to the end of the maze is 0, break the loop
                {
                    break;
                }
                openList.Remove(current); // remove current from the openList
                List<Node> successorList = returnOpenCells(current, closedListCheck);// returns a list of the cells that it can traverse to
                for (int i = 0; i < successorList.Count(); i++)
                {
                    double successorCost = current.g + 1; // distance between current and successor will always be 1 since it cannot move diagonally
                    if (openListCheck[successorList[i].x, successorList[i].y]) // if the node is already in the open list
                    {
                        if (successorList[i].g <= successorCost) // if the cost is cheaper
                        {
                            break;
                        }
                    }
                    else if (closedListCheck[successorList[i].x, successorList[i].y]) // if the node is already in the closed list
                    {
                        if (successorList[i].g <= successorCost)
                        {
                            break;
                        }
                        closedList.Remove(successorList[i]); // take the node out the closed list
                        closedListCheck[successorList[i].x, successorList[i].y] = false;
                    }
                    else
                    {
                        openList.Add(successorList[i]); // mostly will direct to here, to add the new element to the open list
                        openListCheck[successorList[i].x, successorList[i].y] = true;
                    }
                    successorList[i].g = successorCost;
                    successorList[i].parent = current; // sets the parent so that it can be used to backtrack through it later to create the final path with no peninsulas
                }
                closedList.Add(current); // add the current to closed list, as it has been evaluated
                closedListCheck[current.x, current.y] = true;
            }
            List<Node> finalList = new List<Node>(); // creates the final list
            finalList = FinalList(closedList[closedList.Count()-1], finalList); // calls the final list using the end of the closed list to start
            finalList.RemoveRange(0, finalList.Count() / 2); // remove the first half of the list as it only contains the end to the start
            return (finalList);
        }
        private List<Node> FinalList(Node current, List<Node> finalList) // recursive function that will call itself until there is no parent in order to create the final list that will be displayed to the user
        {
            if (current.parent != null) // while the current node has a parent
            {
                finalList.Add(current.parent); // add it to the current list
                FinalList(current.parent, finalList); // calls itself, passing the parent of the current node and the current final list
            }
            finalList.Add(current); // adds the last node on to the final list so it will not finish 1 node away from the end
            return finalList;
        }
    }
    
    public class Node : Navigation // the nodes that the A* algorithm can traverse to are created here also inheritence
    {
        public int x; // x coordiante
        public int y; // y coordiante
        public double g; // g cost - cost to move to the node
        public double h; // h cost - distance from the end
        public double f; // f cost - combination of g and f
        public Node parent;
        public Node(int xCoord, int yCoord, Node cur)
        {
            x = xCoord;
            y = yCoord;
            parent = cur;
            g = 1000000; //distance from the start node set to very high by default, so will always be higher than the one calcualted
            h = hCost(x, y); //distance from the end node (pythagoras)
            f = fCost(x,y); //combination of g and f costs
        }
        public Node(int xCoord, int yCoord, string start) // polymorphism used here
        {
            x = xCoord;
            y = yCoord;
            g = 0; //distance from the start node will be 0
            h = hCost(x, y); //distance from the end node (pythagoras)
            f = hCost(x, y); //combination of g and f costs
            this.parent = null;
        }
        private double hCost(int curX, int curY) // calculated hCost
        {
            double result = Math.Sqrt((Math.Pow((endX - curX), 2)) + ((Math.Pow((endY - curY), 2))));
            return result;
        }
        private double fCost(int curX, int curY) // calculates fCost
        {
            double fCost = this.g + hCost(curX, curY);
            return fCost;
        }
    }
}
