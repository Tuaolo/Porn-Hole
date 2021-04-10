using PornHole.Controllers;
using PornHole.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PornHole
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
            PornHoleView pornHoleView = new PornHoleView();
            FullScreenImageView fullScreenImageView = new FullScreenImageView();
            Application.Run(new PornHoleController(pornHoleView, fullScreenImageView));
        }
    }
}
