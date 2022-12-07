using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pry100.Utilitario.Idiomas_v2.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pry04.View.Idiomas_v2
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Principal.frmFormularioPadre()) ; 
        }
    }
}
