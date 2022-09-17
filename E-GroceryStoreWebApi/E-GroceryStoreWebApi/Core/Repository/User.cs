using E_GroceryStoreWebApi.Core.Interface;
using E_GroceryStoreWebApi.DataAccess;
using E_GroceryStoreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStoreWebApi.Core.Repository
{
    public class User : IUser
    {
        private readonly GroceryStoreDbContext groceryStoreDbContext;
        public User(GroceryStoreDbContext groceryStoreDbContext)
        {
            this.groceryStoreDbContext = groceryStoreDbContext;
        }
        public async Task<UserModel> Login(string Email, string Password)
        {
            try
            {
                var result = await groceryStoreDbContext.userModels.FirstOrDefaultAsync(x => x.Email == Email && x.Password == Password);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            try
            {
                var result = await groceryStoreDbContext.userModels.ToListAsync();
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<UserModel> AddUser(UserModel userModel)
        {
            try
            {
                var result = await groceryStoreDbContext.userModels.AddAsync(userModel);
                await groceryStoreDbContext.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task DeleteUser(int userId)
        {
            try
            {
                var result = await groceryStoreDbContext.userModels.FirstOrDefaultAsync(x => x.UserId == userId);
                if (result != null)
                {
                    groceryStoreDbContext.userModels.Remove(result);
                    await groceryStoreDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<UserModel> GetUser(int userId)
        {
            try
            {
                var result = await groceryStoreDbContext.userModels.FirstOrDefaultAsync(x => x.UserId == userId);
                return result;
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<UserModel> UpdateUser(UserModel userModel)
        {
            try
            {
                var result = await groceryStoreDbContext.userModels.FirstOrDefaultAsync(x => x.UserId == userModel.UserId);
                if (result != null)
                {
                    result.UserId = userModel.UserId;
                    result.UserName = userModel.UserName;
                    result.Email = userModel.Email;
                    result.Password = userModel.Password;
                    result.ContactNumber = userModel.ContactNumber;
                    result.IsSeller = userModel.IsSeller;
                    result.IsBuyer = userModel.IsBuyer;
                    await groceryStoreDbContext.SaveChangesAsync();
                    return result;
                }
                return null;
            }
            catch (Exception ex) { throw ex; }

        }
    }
}
