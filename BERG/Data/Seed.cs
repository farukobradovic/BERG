using BERG.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.Data
{
    public class Seed
    {
        public static void SeedData (DataContext db, UserManager<User> userManager)
        {
            //db.Database.EnsureCreated();
            if (!db.Genders.Any())
            {
                var genders = new Gender[]
              {
                new Gender{Name= "Musko"},
                new Gender{Name = "Zensko"},
                new Gender{Name = "Nepoznato"}
              };

                foreach (var i in genders)
                {
                    db.Genders.Add(i);
                }
            }

            if (!db.Titles.Any())
            {
                var titles = new Title[]
                  {
                new Title {Name = "Specijalista"},
                new Title {Name = "Specijalizant"},
                new Title {Name = "Medicinska sestra"}
                  };

                foreach (var i in titles)
                {
                    db.Titles.Add(i);
                }
            }

            if (!db.Patients.Any())
            {
                var patients = new Patient[]
              {
                new Patient{Firstname="John", Lastname="Doe", GenderID=1, Address="Centar II Mostar"},
                new Patient{Firstname="Jane", Lastname="Doe", GenderID=2, Address="Tekija Mostar"},
                new Patient{Firstname="Margot", Lastname="Robbie", GenderID=2, Address="Zalik 6 Mostar"},
                new Patient{Firstname="Edin", Lastname="Dzeko", GenderID=1, Address="Zalik 5 Mostar"},
                new Patient{Firstname="Joe", Lastname="Matirx", GenderID=1, Address="Centar III Mostar"},
                new Patient{Firstname="Anna", Lastname="Terry", GenderID=1, Address="Zalik 5 Mostar"}

              };

                foreach (var i in patients)
                {
                    db.Patients.Add(i);
                }
            }

            //if (!userManager.Users.Any())
            //{
            //    var user = new User
            //    {
            //        Id = "b8633e2d-a33b-45e6-8329-1958b3252bbd",
            //        Firstname = "Faruk",
            //        Lastname = "Obradovic",
            //        UserName = "faruk.obradovic",
            //        NormalizedUserName = "FARUK.OBRADOVIC",
            //        Email = "faruk@hotmail.com",
            //        NormalizedEmail = "FARUK@HOTMAIL.COM",
            //        Code = Guid.NewGuid(),
            //        TitleID = 1

            //    };
 
            //     userManager.CreateAsync(user, "Pa$$w0rd");

            //}

            db.SaveChanges();
        }
    }
}
