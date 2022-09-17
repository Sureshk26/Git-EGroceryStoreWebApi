using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStoreWebApi.Models
{
    public class CartModel
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Username { get; set; }

    }
}
