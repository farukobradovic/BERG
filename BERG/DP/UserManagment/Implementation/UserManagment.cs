using BERG.Data;
using BERG.DP.UserManagment.Interfaces;
using BERG.Models;
using BERG.ViewModels;
using BERG.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.DP.UserManagment.Implementation
{
    public class UserManagment : IUserManagment
    {
        private IUserDP userDP;
        private readonly SignInManager<User> signInManager;
        private readonly DataContext db;
        private readonly UserManager<User> userManager;

        public UserManagment(IUserDP userDP, SignInManager<User> signInManager, DataContext db, UserManager<User> usermanager)
        {
            this.userDP = userDP;
            this.signInManager = signInManager;
            this.db = db;
            this.userManager = usermanager;
        }


        public bool CreateUser(RegisterViewModel model)
        {
            var user = new User
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                TitleID = model.TitleID,
                Email = model.Email,
                UserName = model.Firstname.ToLower() + "." + model.Lastname.ToLower(),
                Code = Guid.NewGuid()
            };

            var isCreated = userDP.CreateUser(user, model.Password);
            return isCreated;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            var user = userDP.FindByEmailAddress(email);
            if (user != null)
            {
                return await userDP.SignIn(user.UserName, password);
            }
            return false;
        }

        public async Task<bool> SignOut()
        {
            await signInManager.SignOutAsync();
            return true;
        }

        public async Task<User> GetLogged()
        {
            var user = await userDP.GetLoggedUser();
            return user;
        }
        public void UpdateUser(ProfileViewModel model)
        {
            userDP.UpdateUser(model);
        }

        public List<User> ListAllUsers()
        {
            var users = userManager.Users.Include(c => c.Title).ToList();
            return users;
        }

        public async Task DeleteUser(string userID)
        {
            var user =  userManager.Users.SingleOrDefault(c => c.Id == userID);
            if(user != null)
            {
                var result = await userManager.DeleteAsync(user);
            }
           
        }
    }
}
