using E_GroceryStoreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStoreWebApi.DataAccess
{
    public class GroceryStoreDbContext : DbContext
    {
        public GroceryStoreDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<CartModel> cartModel { get; set; }
        public DbSet<CategoryModel> categoryModel { get; set; }
        public DbSet<GroceryItemsModel> groceryItemModel { get; set; }
        public DbSet<OrderModel> orderModel { get; set; }
        public DbSet<RatingModel> ratingModel { get; set; }
        public DbSet<UserModel> userModels { get; set; }
    }
}
