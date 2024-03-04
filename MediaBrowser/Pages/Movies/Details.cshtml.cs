using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediaBrowser.Models;

namespace MediaBrowser.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly MediaBrowser.Models.BattleCabbageVideoContext _context;

        public DetailsModel(MediaBrowser.Models.BattleCabbageVideoContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.Include(g => g.Genre).Include(c=>c.Actors).Include(d => d.Directors).Include(c => c.Criticreviews).AsNoTracking().FirstOrDefaultAsync(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                Movie = movie;
            }
            return Page();
        }
    }
}
