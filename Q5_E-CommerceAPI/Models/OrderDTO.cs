namespace Q5_E_CommerceAPI.Models
{
    public class OrderDTO
    {
        public int ProductId { get; set; }
        public int Piece { get; set; }
        public string Address { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
