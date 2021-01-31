using BERG.Data;
using BERG.DP.UserManagment.Interfaces;
using BERG.Models;
using BERG.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.DP.UserManagment.Implementation
{
  
    public class UserDP : IUserDP
    {
        DataContext db;
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        IHttpContextAccessor contextAccessor;

        public UserDP(DataContext db, UserManager<User> userManager, SignInManager<User> signInManager,
            IHttpContextAccessor contextAccessor)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.contextAccessor = contextAccessor;
        }

        public User FindByUsername(string username)
        {
            User user = (User)db.Users.SingleOrDefault(c => c.UserName == username);
            return user;
        }

        public User FindByEmailAddress(string emailAddress)
        {
            User user = (User)db.Users.SingleOrDefault(c => c.Email == emailAddress);
            return user;
        }

        public bool CreateUser(User user, string password)
        {
            IdentityResult result = userManager.CreateAsync(user, password).Result;
            if (result.Succeeded)
            {
                db.SaveChanges();
            }
            return result.Succeeded;
        }

        public async Task<bool> SignIn(string username, string password)
        {
            var result = await signInManager.PasswordSignInAsync(username, password, false, true);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<User> GetLoggedUser()
        {
            return await userManager.GetUserAsync(contextAccessor.HttpContext.User);
        }

        public void UpdateUser(ProfileViewModel model)
        {
            User user = (User)db.Users.SingleOrDefault(c => c.Id == model.UserID);
            user.Firstname = model.Firstname;
            user.Lastname = model.Lastname;
            user.TitleID = model.TitleID;

            db.SaveChanges();

        }
    }
}
