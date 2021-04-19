using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze_NEA
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MazeCreation.DrawNodeConnections();
            Form1 form = new Form1();
            Application.Run(form);
            //MenuForm form = new MenuForm();
            //Application.Run(form);
        }
    }
}
