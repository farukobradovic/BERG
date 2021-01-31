using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.ViewModels.MedicalRecord
{
    public class MedicalRecordViewModel
    {
        public BERG.Models.Appointment Appointment { get; set; }
        public int AppointmentID { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
