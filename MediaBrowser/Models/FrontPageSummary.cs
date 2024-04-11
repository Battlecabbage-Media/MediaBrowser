namespace MediaBrowser.Models
{
    public class FrontPageSummary
    {
        public List<ActorWithCount> PopularActors { get; set; }
        public List<DirectorWithCount> PopularDirectors { get; set; }
        public List<GenreWithCount> PopularGenres { get; set; }
        public List<Movie> MostRecentMovies { get; set; }
        public List<Movie> RandomMovies { get; set; }
        public List<MovieWithRating> TopRatedMovies { get; set; }
        public List<MovieWithRating> WorstRatedMovies { get; set; }
    }
}
