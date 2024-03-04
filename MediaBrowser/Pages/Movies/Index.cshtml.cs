using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MediaBrowser.Models;

namespace MediaBrowser.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MediaBrowser.Models.BattleCabbageVideoContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(BattleCabbageVideoContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public PaginatedList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync(int? pageIndex)
        {
            var pageSize = Configuration.GetValue("PageSize", 5);

            Movie = await PaginatedList<Movie>.CreateAsync(
                          _context.Movies.Include(m => m.Genre).OrderByDescending(m => m.MovieId), pageIndex ?? 1, pageSize);
        }
    }
}
