using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_GroceryStoreWebApi.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderName { get; set; }
        public string UserName { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public int GrandTotal { get; set; }
        public int PostalCode { get; set; }
    }
}
