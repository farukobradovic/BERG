using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.ViewModels.User
{
    public class RegisterViewModel
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public List<SelectListItem> Titles { get; set; }
        public int TitleID { get; set; }

        public RegisterViewModel()
        {
            Titles = new List<SelectListItem>();
        }
    }
}
