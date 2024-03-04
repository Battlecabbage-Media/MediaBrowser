namespace MediaBrowser.Models
{
    public class ActorWithCount
    {
        public Actor Actor { get; set; } = null!;
        public int MovieCount { get; set; }
    }
}
