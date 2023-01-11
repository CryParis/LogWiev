using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics; //This is for EventLog



namespace _3._LogView
{
    static class Program
    {
       //private static readonly ILogger log = new EventLogger();

        static void Main()
        {
            
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}
