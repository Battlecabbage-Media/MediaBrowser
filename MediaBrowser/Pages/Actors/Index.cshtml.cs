using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MediaBrowser.Models;

namespace MediaBrowser.Pages.Actors
{
    public class IndexModel : PageModel
    {
        private readonly MediaBrowser.Models.BattleCabbageVideoContext _context;

        public IndexModel(MediaBrowser.Models.BattleCabbageVideoContext context)
        {
            _context = context;
        }

        public IList<ActorWithCount> Actor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Actor = await _context.Actors.Select(a => new ActorWithCount{Actor = a, MovieCount = a.Movies.Count()}).ToListAsync();
        }
    }
}
