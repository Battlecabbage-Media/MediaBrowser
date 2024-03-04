namespace MediaBrowser.Models
{
    public class GenreWithCount
    {
        public Genre Genre { get; set; } = null!;
        public int MovieCount { get; set; }
    }
}
