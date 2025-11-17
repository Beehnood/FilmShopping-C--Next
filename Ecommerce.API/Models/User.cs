namespace Ecommerce.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public bool IsAdmin { get; set; } = false;

        public List<Order>? Orders { get; set; }
    }
}
