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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, EventArgs e) // click on the play button
        {
            MazeCreation.DrawNodeConnections(); // creates the maze that will be interpreted
            Form1 mainMaze = new Form1();
            this.Hide(); // hide the menu when the play button is pressed
            mainMaze.ShowDialog();
        }

        private void SettingsButton_Click(object sender, EventArgs e) // click on the settings button
        {
            SettingsTab settings = new SettingsTab();
            this.Hide(); // hide the menu when the settings button is pressed
            settings.ShowDialog(); // show the settings
        }

        private void QuitButton_Click(object sender, EventArgs e) // click on the quit button
        {
            Application.Exit(); // exit the whole app
        }
    }
}
