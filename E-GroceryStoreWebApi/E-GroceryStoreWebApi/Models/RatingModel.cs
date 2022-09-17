using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStoreWebApi.Models
{
    public class RatingModel
    {
        [Key]
        public int RatingId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int ContactNumber { get; set; }
        public string Message { get; set; }
    }
}
