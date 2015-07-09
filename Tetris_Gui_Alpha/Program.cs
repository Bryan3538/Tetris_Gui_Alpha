using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris_Gui_Alpha
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TetrisForm());
            } catch(Exception e)
            {
                Console.WriteLine("STACK TRACE:\n" + e.StackTrace);
                Console.WriteLine("MESSAGE:\t" + e.Message);
                Environment.Exit(-1);
            }
        }
    }
}
