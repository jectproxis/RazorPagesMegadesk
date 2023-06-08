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
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesMegadesk.Data.RazorPagesMegadeskContext _context;

        public DetailsModel(RazorPagesMegadesk.Data.RazorPagesMegadeskContext context)
        {
            _context = context;
        }

      public Desk Desk { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Desk == null)
            {
                return NotFound();
            }

            var desk = await _context.Desk.FirstOrDefaultAsync(m => m.Id == id);
            if (desk == null)
            {
                return NotFound();
            }
            else 
            {
                Desk = desk;
            }
            return Page();
        }
    }
}
