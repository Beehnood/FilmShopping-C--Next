namespace Ecommerce.API.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public string PosterUrl { get; set; } = "";
        public string VideoUrl { get; set; } = ""; // lien du film (streaming ou téléchargement)
        public string Genre { get; set; } = "";
        public DateTime ReleaseDate { get; set; }
        public double Rating { get; set; }
    }
}

