using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Wash.Models;
using Car_Wash.Presenters;
using Car_Wash._Repositories;
using Car_Wash.Views;
using System.Configuration;

namespace Car_Wash
{
    static class Program
    {
   
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Data Source = (local); Initial Catalog = ChibaDB1; Integrated Security = True
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            IMainView view = new MainView();
            new MainPresenter(view, sqlConnectionString);
            Application.Run((Form)view);
        }
    }
}
