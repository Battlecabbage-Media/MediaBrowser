namespace MediaBrowser.Models
{
    public class FrontPageSummary
    {
        public required List<ActorWithCount> PopularActors { get; set; }
        public required List<DirectorWithCount> PopularDirectors { get; set; }
        public required List<GenreWithCount> PopularGenres { get; set; }
        public required List<Movie> MostRecentMovies { get; set; }
        public required List<Movie> RandomMovies { get; set; }
        public required List<MovieWithRating> TopRatedMovies { get; set; }
        public required List<MovieWithRating> WorstRatedMovies { get; set; }
    }
}
