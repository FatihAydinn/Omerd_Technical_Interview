using System.ComponentModel.DataAnnotations;

namespace Q5_E_CommerceAPI.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Piece { get; set; }
        public string Address { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
