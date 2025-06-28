using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Q5_E_CommerceAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
