using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.ViewModels
{
    public class PatientEditViewModel
    {
        public int PatientID { get; set; }

        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public List<SelectListItem> Genders { get; set; }
        public int GenderID { get; set; }

        public PatientEditViewModel()
        {
            Genders = new List<SelectListItem>();
        }
    }
}
