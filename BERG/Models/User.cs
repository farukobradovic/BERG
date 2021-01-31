using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [ForeignKey("TitleID")]
        public Title Title { get; set; }
        public int TitleID { get; set; }
        [Required]
        public Guid Code { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

    }
}
