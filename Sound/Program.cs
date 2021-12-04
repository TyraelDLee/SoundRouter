using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sound
{
    
    static class Program
    {
        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();
        [DllImport("kernel32.dll")]
        static extern bool FreeConsole();
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //AllocConsole();
            Application.Run(new SoundMapper());
            //FreeConsole();
        }
    }
}