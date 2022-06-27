using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using car_care.Models;
using car_care.Views;
namespace car_care.Presenter
{
    public class PPresenter
    {
        //Fields
        private IPView view;
        private IPRepository repository;
        private BindingSource petsBindingSource;
        private IEnumerable<PModel> petList;


        //Constructor
        public PPresenter(IPView view, IPRepository repository)
        {
            this.petsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            //Sub event handler methods to view events
            this.view.SearchEvent += SearchPet;
            this.view.AddNewEvent += AddNewPet;
            this.view.EditEvent += LoadSelectedPetToEdit;
            this.view.DeleteEvent += DeleteSelectedPet;
            this.view.SaveEvent += SavePet;
            this.view.CancelEvent += CancelAction;

            //Set pets binding source
            this.view.SetPetListBindingSource(petsBindingSource);

            //Load pet list view
            LoadAllPetList();

            //Show view
            this.view.Show();

        }

        private void LoadAllPetList()
        {
            petList = repository.GetAll();
            petsBindingSource.DataSource = petList; //setdata source
        }
        private void SearchPet(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                petList = repository.GetByValue(this.view.SearchValue);
            else petList = repository.GetAll();
            petsBindingSource.DataSource = petList;


        }

        private void CancelAction(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void SavePet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void DeleteSelectedPet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void LoadSelectedPetToEdit(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void AddNewPet(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

    }
}
