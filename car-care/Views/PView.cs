using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace car_care.Views
{
    public partial class PView : Form, IPView
    {
        private string message;
        private bool isSuccessful;
        private bool isEdit;
        public PView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
        }

        public string PID { 
            get { return txtID.Text; }
            set { txtID.Text = value; }
        }
        public string PName { 
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }
        public string PType {
            get { return txtType.Text; }
            set { txtType.Text = value; }
        }
        public string PColour { 
            get { return txtColur.Text; }
            set { txtColur.Text = value; }
        }
        public string SearchValue { 
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public bool IsEdit { 
            get  { return isEdit; }
            set  { isEdit = value; }
        }
        public bool IsSuccessful { 
            get  { return isSuccessful; } 
            set  { isSuccessful = value; }
        }
        public string Message { 
            get  { return message; }
            set  { message = value; }
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;


        public void SetPetListBindingSource(BindingSource petList)
        {
            throw new NotImplementedException();
        }

        private void PView_Load(object sender, EventArgs e)
        {
            MessageBox.Show("He LynnHoo My Project Car Care System V1.2", "Alert", MessageBoxButtons.OK);
        }
    }
}
