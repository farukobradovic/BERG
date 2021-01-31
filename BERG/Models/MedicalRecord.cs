using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.Models
{
    public class MedicalRecord
    {
        [Key]
        public int MedicalRecordID { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [ForeignKey("AppointmentID")]
        public Appointment Appointment { get; set; }
        public int AppointmentID { get; set; }
    }
}
