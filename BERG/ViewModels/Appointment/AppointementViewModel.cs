using BERG.Models;
using BERG.ViewModels.Appointment;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.ViewModels
{
    public class AppointementViewModel
    {
        public int AppointmentID { get; set; }
        public List<BERG.Models.Appointment> Appointments { get; set; }
        [Required]
        [DateValidate]
        public DateTime Time { get; set; }
        public bool Urgent { get; set; }
        public List<SelectListItem> Users { get; set; }
        public string UserID { get; set; }

        public List<SelectListItem> Patients { get; set; }
        public int PatientID { get; set; }
        public bool GotRecord { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }


        public AppointementViewModel()
        {
            Appointments = new List<BERG.Models.Appointment>();
            Users = new List<SelectListItem>();
            Patients = new List<SelectListItem>();
            From = DateTime.Now;
            To = DateTime.Now;
        }
    }
}
