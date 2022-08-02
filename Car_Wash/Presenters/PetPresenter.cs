using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Car_Wash.Models;
using Car_Wash.Views;


namespace Car_Wash.Presenters
{
    public class PetPresenter
    {

        //Fields
        private IPetView view;
        private IPetRepository repository;
        private BindingSource petsBindingSource;
        private IEnumerable<PetModel> petList;

        //Constructor
        public PetPresenter(IPetView view, IPetRepository repository)
        {
            this.petsBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;
            //Subscribe event handler methods to view events
            this.view.SearchEvent += SearchPet;
            this.view.AddNewEvent += AddNewPet;
            this.view.EditEvent += LoadSelectedPetToEdit;
            this.view.DeleteEvent += DeleteSelectedPet;
            this.view.SaveEvent += SavePet;
            this.view.CancelEvent += CancelAction;
            //Set pets bindind source
            this.view.SetPetListBindingSource(petsBindingSource);
            //Load pet list view
            LoadAllPetList();
            //Show view
            this.view.Show();
        }
        //Methods
        private void LoadAllPetList()
        {
            petList = repository.GetAll();
            petsBindingSource.DataSource = petList;//Set data source.
        }
        private void SearchPet(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                petList = repository.GetByValue(this.view.SearchValue);
            else petList = repository.GetAll();
            petsBindingSource.DataSource = petList;
        }
        private void AddNewPet(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }
        private void LoadSelectedPetToEdit(object sender, EventArgs e)
        {
            var pet = (PetModel)petsBindingSource.Current;
            view.PetId = pet.Id.ToString();
            view.PetName = pet.Name;
            view.PetType = pet.Type;
            view.PetColour = pet.Colour;
            //view.PetTypeName = pet.TypeName;
            view.IsEdit = true;
        }
        private void SavePet(object sender, EventArgs e)
        {
            var model = new PetModel();
            model.Id = Convert.ToInt32(view.PetId);
            model.Name = view.PetName;
            model.Type = view.PetType;
            model.Colour = view.PetColour;
            //model.TypeName = view.PetTypeName;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)//Edit model
                {
                    repository.Edit(model);
                    view.Message = "แก้ไขสำเร็จ";
                }
                else //Add new model
                {
                    repository.Add(model);
                    view.Message = "เพิ่มสำเร็จ";
                }
                view.IsSuccessful = true;
                LoadAllPetList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void CleanviewFields()
        {
            view.PetId = "0";
            view.PetName = "";
            view.PetType = "";
            view.PetColour = "";
            //view.PetTypeName = "";
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanviewFields();
        }
        private void DeleteSelectedPet(object sender, EventArgs e)
        {
            try
            {
                var pet = (PetModel)petsBindingSource.Current;
                repository.Delete(pet.Id);
                view.IsSuccessful = true;
                view.Message = "ลบสำเร็จ";
                LoadAllPetList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "เกิดข้อผิดพลาด ไม่สามารถลบได้!!";
            }
        }
    }
}
