namespace Ecommerce.API.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
        public decimal Price { get; set; }
    }
}