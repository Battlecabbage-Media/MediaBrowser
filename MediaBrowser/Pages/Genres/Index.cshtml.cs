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
    public class IndexModel : PageModel
    {
        private readonly MediaBrowser.Models.BattleCabbageVideoContext _context;

        public IndexModel(MediaBrowser.Models.BattleCabbageVideoContext context)
        {
            _context = context;
        }

        public IList<GenreWithCount> Genre { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Genre = await _context.Genres.Select(a => new GenreWithCount { Genre = a, MovieCount = a.Movies.Count() }).ToListAsync();
        }
    }
}
