using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesMegadesk.Data;
using RazorPagesMegadesk.Models;

namespace RazorPagesMegadesk.Pages.Desks
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMegadesk.Data.RazorPagesMegadeskContext _context;

        public IndexModel(RazorPagesMegadesk.Data.RazorPagesMegadeskContext context)
        {
            _context = context;
        }

        public IList<Desk> Desk { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Desk != null)
            {
                Desk = await _context.Desk.ToListAsync();
            }
        }
    }
}
