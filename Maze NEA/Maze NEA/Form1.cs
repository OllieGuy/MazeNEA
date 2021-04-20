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
        public Form1()
        {
            mazeGrid = new GridPictureBox(this);
            mazeGrid.InterpretGrid();
            nav = new Navigation();
            InitializeComponent();
        }
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //mazeGrid.InterpretGrid();
            nav.AStarSolve();
            mazeGrid.Draw(e.Graphics);
            mazeGrid.SetBoxDimensions();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            mazeGrid.SetBoxDimensions();
        }
        private void Form1_KeyPress(object sender, KeyEventArgs e)
        {
            //Navigation moved = new Navigation();
            nav.Movement(e.KeyData);
        }
    }
}
