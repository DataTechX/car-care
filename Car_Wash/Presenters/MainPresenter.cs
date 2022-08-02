using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Car_Wash.Views;
using Car_Wash.Models;
using Car_Wash._Repositories;
using System.Windows.Forms;

namespace Car_Wash.Presenters
{
    public class MainPresenter
    {
        private IMainView mainView;
        private readonly string sqlConnectionString;

        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowPetView += ShowPetsView;
        }

        private void ShowPetsView(object sender, EventArgs e)
        {
            IPetView view = PetView.GetInstace((MainView)mainView);
            IPetRepository repository = new PetRepository(sqlConnectionString);
            new PetPresenter(view, repository);
        }
    }
}
