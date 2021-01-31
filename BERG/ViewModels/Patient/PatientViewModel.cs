using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BERG.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BERG.ViewModels
{
    public class PatientViewModel
    {
        public List<Patient> Patients { get; set; }
        [Required]
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


        public PatientViewModel()
        {
            Patients = new List<Patient>();
            Genders = new List<SelectListItem>();
        }
    }
}
