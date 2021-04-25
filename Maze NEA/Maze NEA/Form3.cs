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
    public partial class SettingsTab : Form
    {
        public SettingsTab()
        {
            InitializeComponent();
        }

        private void SubmitX_Click(object sender, EventArgs e) // the submit of the entered x value when customising the maze size
        {
            try
            {
                int newSize = Convert.ToInt32(NewX.Text); // try to convert it into an interger
                if(newSize > 1 && newSize <= 100) // if the number is within the range of 1 to 100
                {
                    Grid.gridSizeX = newSize; // resize the grid to the specified size
                    NewX.Text = string.Empty; // empty the text box
                    MessageBox.Show("Size changed successfully", "Success!"); // give feedback to the user that their entry was sucessful
                }
                else
                {
                    throw new Exception(); // throw an exception which leads to the catch statement below
                }
                
            }
            catch
            {
                MessageBox.Show("Only numbers between 1 and 100 are allowed as inputs","Error"); // creates a textbox that shows the user the allowed inputs
                NewX.Text = string.Empty; // empty the textbox
            }
        }

        private void SubmitY_Click(object sender, EventArgs e) // works the same way as SubmitX_Click
        {
            try
            {
                int newSize = Convert.ToInt32(NewY.Text);
                if (newSize > 1 && newSize <= 100)
                {
                    Grid.gridSizeY = newSize;
                    NewY.Text = string.Empty;
                    MessageBox.Show("Size changed successfully", "Success!");
                }
                else
                {
                    throw new Exception();
                }

            }
            catch
            {
                MessageBox.Show("Only numbers between 1 and 100 are allowed as inputs", "Error");
                NewX.Text = string.Empty;
            }
        }

        private void DefaultStart_CheckedChanged(object sender, EventArgs e) // if the user has changed the check in the box
        {
            if (DefaultStart.Checked) // if the user has switched TO default start
            {
                PlayerOptions.randomEnd = false; // set the player option for randomEnd to false
                RandomStart.Checked = false; // uncheck the randomEnd box
            }
        }

        private void RandomStart_CheckedChanged(object sender, EventArgs e) // works the opposite to DefaultStart_CheckedChanged
        {
            if (RandomStart.Checked)
            {
                PlayerOptions.randomEnd = true;
                DefaultStart.Checked = false;
            }
        }

        private void DefaultEnd_CheckedChanged(object sender, EventArgs e) // works the same as DefaultStart_CheckedChanged
        {
            if (DefaultEnd.Checked)
            {
                PlayerOptions.randomStart = false;
                RandomEnd.Checked = false;
            }
        }

        private void RandomEnd_CheckedChanged(object sender, EventArgs e) // works the opposite to DefaultEnd_CheckedChanged
        {
            if (RandomEnd.Checked)
            {
                PlayerOptions.randomStart = true;
                DefaultEnd.Checked = false;
            }
        }

        private void BotDifficulty_Scroll(object sender, EventArgs e) // if the bot difficulty slider is changed
        {
            PlayerOptions.botDifficulty = BotDifficulty.Value; // change the bot difficulty
        }

        private void MenuButton_Click(object sender, EventArgs e) // if the user clicks the back to the menu button
        {
            MenuForm menu = new MenuForm();
            this.Hide(); // close this window
            menu.ShowDialog(); // show the menu
        }
    }
}
