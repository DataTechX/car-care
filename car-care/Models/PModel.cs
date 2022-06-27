using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace car_care.Models
{
    public class PModel
    {
        //Fields
        private int id;
        private string name;
        private string type;
        private string colour;


        // Properties & Validations

        [DisplayName("ID")]
        public int Id { 
            get => id; 
            set => id = value; 
        }
        [DisplayName("Name")]
        [Required(ErrorMessage = "ต้องระบุ Name")]
        [StringLength(50,MinimumLength =3, ErrorMessage ="Name must be between 3 and 50 chasracters")]
        public string Name
        {
            get => name;
            set => name = value;
        }

        [DisplayName("Type")]
        [Required(ErrorMessage = "ต้องระบุ type")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "type must be between 3 and 50 chasracters")]
        public string Type { 
            get => type; 
            set => type = value; 
        }
        [DisplayName("Colour")]
        [Required(ErrorMessage = "ต้องระบุColour")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Colour must be between 3 and 50 chasracters")]
        public string Colour { 
            get => colour; 
            set => colour = value; 
        }
    }
}
