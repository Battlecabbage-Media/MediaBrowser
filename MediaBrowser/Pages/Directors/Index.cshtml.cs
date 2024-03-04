using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediaBrowser.Models;

namespace MediaBrowser.Pages.Directors
{
    public class IndexModel : PageModel
    {
        private readonly MediaBrowser.Models.BattleCabbageVideoContext _context;

        public IndexModel(MediaBrowser.Models.BattleCabbageVideoContext context)
        {
            _context = context;
        }

        public IList<DirectorWithCount> Director { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Director = await _context.Directors.Select(a => new DirectorWithCount { Director = a, MovieCount = a.Movies.Count() }).ToListAsync();
        }
    }
}
