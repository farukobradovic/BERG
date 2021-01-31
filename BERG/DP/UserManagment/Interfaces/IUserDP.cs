using BERG.Models;
using BERG.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.DP.UserManagment.Interfaces
{
    public interface IUserDP
    {
        User FindByUsername(string username);
        User FindByEmailAddress(string emailAddress);
        bool CreateUser(User user, string password);
        Task<bool> SignIn(string username, string password);
        Task<User> GetLoggedUser();
        void UpdateUser(ProfileViewModel model);
    }
}
