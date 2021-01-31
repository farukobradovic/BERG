using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BERG.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BERG.ViewModels
{
    public class ProfileViewModel
    {
        public string UserID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int TitleID { get; set; }
        public Guid Code { get; set; }
        public List<SelectListItem> Titles { get; set; }
        public ProfileViewModel()
        {
            Titles = new List<SelectListItem>();
        }


    }
}
