using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediaBrowser.Models;

namespace MediaBrowser.Pages.Genres
{
    public class DetailsModel : PageModel
    {
        private readonly MediaBrowser.Models.BattleCabbageVideoContext _context;

        public DetailsModel(MediaBrowser.Models.BattleCabbageVideoContext context)
        {
            _context = context;
        }

        public Genre Genre { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres.Include(m => m.Movies).AsNoTracking().FirstOrDefaultAsync(m => m.GenreId == id);
            if (genre == null)
            {
                return NotFound();
            }
            else
            {
                Genre = genre;
            }
            return Page();
        }
    }
}
