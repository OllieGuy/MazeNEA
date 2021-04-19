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

        private void SettingsTab_Load(object sender, EventArgs e)
        {

        }
        private void SubmitX_Click(object sender, EventArgs e)
        {
            try
            {
                int newSize = Convert.ToInt32(NewX.Text);
                if(newSize > 1 && newSize <= 100)
                {
                    Grid.gridSizeX = newSize;
                    NewX.Text = string.Empty;
                    MessageBox.Show("Size changed successfully", "Success!");
                }
                else
                {
                    throw new Exception();
                }
                
            }
            catch
            {
                MessageBox.Show("Only numbers between 1 and 100 are allowed as inputs","Error");
                NewX.Text = string.Empty;
            }
        }

        private void SubmitY_Click(object sender, EventArgs e)
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

        private void DefaultStart_CheckedChanged(object sender, EventArgs e)
        {
            if (DefaultStart.Checked)
            {
                PlayerOptions.randomEnd = false;
                RandomStart.Checked = false;
            }
        }

        private void RandomStart_CheckedChanged(object sender, EventArgs e)
        {
            if (RandomStart.Checked)
            {
                PlayerOptions.randomEnd = true;
                DefaultStart.Checked = false;
            }
        }

        private void DefaultEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (DefaultEnd.Checked)
            {
                PlayerOptions.randomStart = false;
                RandomEnd.Checked = false;
            }
        }

        private void RandomEnd_CheckedChanged(object sender, EventArgs e)
        {
            if (RandomEnd.Checked)
            {
                PlayerOptions.randomStart = true;
                DefaultEnd.Checked = false;
            }
        }

        private void BotDifficulty_Scroll(object sender, EventArgs e)
        {
            PlayerOptions.botDifficulty = BotDifficulty.Value;
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            MenuForm menu = new MenuForm();
            this.Hide();
            menu.ShowDialog();
            //this.Show();
        }
    }
}
