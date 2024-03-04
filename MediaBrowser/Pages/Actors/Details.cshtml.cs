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
    public class DetailsModel : PageModel
    {
        private readonly MediaBrowser.Models.BattleCabbageVideoContext _context;

        public DetailsModel(MediaBrowser.Models.BattleCabbageVideoContext context)
        {
            _context = context;
        }

        public Actor Actor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actors.Include(m => m.Movies).AsNoTracking().FirstOrDefaultAsync(m => m.ActorId == id);
            if (actor == null)
            {
                return NotFound();
            }
            else
            {
                Actor = actor;
            }
            return Page();
        }
    }
}
