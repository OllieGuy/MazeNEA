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
    public partial class Form1 : Form
    {
        protected GridPictureBox mazeGrid;
        protected Navigation nav;
        public Form1() // creates the maze grid and solves the maze
        {
            mazeGrid = new GridPictureBox(this);
            mazeGrid.InterpretGrid();
            nav = new Navigation();
            InitializeComponent();
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e) // draws the maze for the user to see
        {
            mazeGrid.Draw(e.Graphics);
            mazeGrid.SetBoxDimensions();
        }
        private void Form1_Resize(object sender, EventArgs e) // when the form has been resized, set the box dimensions to be in line with this
        {
            mazeGrid.SetBoxDimensions();
        }
        private void Form1_KeyPress(object sender, KeyEventArgs e) // when a key is pressed, pass it to Navigation, which will perform the necessary operations with this information
        {
            nav.Movement(e.KeyData);
        }
    }
}
