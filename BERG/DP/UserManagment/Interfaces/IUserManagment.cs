using BERG.Models;
using BERG.ViewModels;
using BERG.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BERG.DP.UserManagment.Interfaces
{
    public interface IUserManagment
    {
        bool CreateUser(RegisterViewModel model);
        Task<bool> LoginUser(string email, string password);
        Task<bool> SignOut();
        Task<User> GetLogged();
        void UpdateUser(ProfileViewModel model);
        public List<User> ListAllUsers();
       Task DeleteUser(string userID);
    }
}
