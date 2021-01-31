using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        [ForeignKey("GenderID")]
        public Gender Gender { get; set; }
        public int GenderID { get; set; }
        public DateTime Birthdate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        internal object Include()
        {
            throw new NotImplementedException();
        }
    }
}
