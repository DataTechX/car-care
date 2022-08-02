using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Car_Wash.Models
{
    public class PetModel
    {
        //Fields
        private int id;
        private string name;
        private string type;
        private string colour;
        //private string typeName;

        //Properties - Validations
        [DisplayName("ไอดี")]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DisplayName("ทะเบียนรถ")]
        [Required(ErrorMessage = "ระบุทะเบียนรถให้ถุกต้อง")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "ทะเบียนรถต้องมีความยาวระหว่าง 3 ถึง 7 ตัวอักษร")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DisplayName("ประเภท")]
        [Required(ErrorMessage = "จำเป็นต้องระบุประเภท")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "ประเภทการเข้าล้างต้องอยู่ระหว่าง 3 ถึง 100 ตัวอักษร")]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        [DisplayName("สีรถ")]
        [Required(ErrorMessage = "ระบุสีรถ")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "สีของรถต้องอยู่ระหว่าง 3 ถึง 50 ตัวอักษร")]
        public string Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        //[DisplayName("ประเภทรถ")]
        //[Required(ErrorMessage = "ระบุประเภทรถ")]
        //[StringLength(50, MinimumLength = 1, ErrorMessage = "ประเภทของรถต้องอยู่ระหว่าง 3 ถึง 50 ตัวอักษร")]
        //public string TypeName
        //{
        //    get { return typeName; }
        //    set { typeName = value; }
        //}
    }
}
