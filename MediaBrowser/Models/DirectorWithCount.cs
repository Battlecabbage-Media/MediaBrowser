namespace MediaBrowser.Models
{
    public class DirectorWithCount
    {
        public Director Director { get; set; } = null!;
        public int MovieCount { get; set; }
    }
}
