using E_GroceryStoreWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStoreWebApi.Core.Interface
{
    public interface IUser
    {
        Task<UserModel> Login(string Email, string Password);
        Task<IEnumerable<UserModel>> GetUsers();
        Task<UserModel> GetUser(int userId);
        Task<UserModel> AddUser(UserModel userModel);
        Task<UserModel> UpdateUser(UserModel userModel);
        Task DeleteUser(int userId);
    }
}
