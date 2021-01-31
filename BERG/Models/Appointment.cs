using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [ForeignKey("UserID")]
        public User User { get; set; }
        public string UserID { get; set; }
        [ForeignKey("PatientID")]
        public Patient Patient { get; set; }
        public int PatientID { get; set; }
        public DateTime Time { get; set; }
        public bool Urgently { get; set; }

    }
}
