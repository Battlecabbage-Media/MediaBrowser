namespace MediaBrowser.Models
{
    public class MovieWithRating
    {
        public Movie Movie { get; set; } = null!;
        public decimal? Rating { get; set; }
    }
}
