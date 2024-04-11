using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediaBrowser.Models;

namespace MediaBrowser.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MediaBrowser.Models.BattleCabbageVideoContext _context;
        private Random random = new Random();

        public IndexModel(MediaBrowser.Models.BattleCabbageVideoContext context)
        {
            _context = context;
        }

        public FrontPageSummary FrontPageSummary { get; set; } = default!;

        public async Task OnGetAsync()
        {
            int randMovieId = random.Next(1, _context.Movies.Count());
            FrontPageSummary = new FrontPageSummary
            {
                MostRecentMovies = await _context.Movies.OrderByDescending(m => m.ReleaseDate).Take(5).ToListAsync(),
                TopRatedMovies = await _context.Movies.Include(c => c.Criticreviews).AsNoTracking().Select(a => new MovieWithRating { Movie = a, Rating = (a.PopularityScore + a.Criticreviews.First().CriticScore)/2 }).OrderByDescending(m => m.Rating).Take(5).ToListAsync(),
                WorstRatedMovies = await _context.Movies.Include(c => c.Criticreviews).AsNoTracking().Select(a => new MovieWithRating { Movie = a, Rating = (a.PopularityScore + a.Criticreviews.First().CriticScore) / 2 }).OrderBy(m => m.Rating).Take(5).ToListAsync(),
                RandomMovies = await _context.Movies.OrderBy(r => Guid.NewGuid()).Take(3).ToListAsync(),
                PopularGenres = await _context.Genres.Select(a => new GenreWithCount { Genre = a, MovieCount = a.Movies.Count() }).OrderByDescending(m => m.MovieCount).Take(5).ToListAsync(),
                PopularDirectors = await _context.Directors.Select(a => new DirectorWithCount { Director = a, MovieCount = a.Movies.Count() }).OrderByDescending(m => m.MovieCount).Take(5).ToListAsync(),
                PopularActors = await _context.Actors.Select(a => new ActorWithCount { Actor = a, MovieCount = a.Movies.Count() }).OrderByDescending(m => m.MovieCount).Take(5).ToListAsync()
            };
        }
    }
}
