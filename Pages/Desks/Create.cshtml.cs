using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesMegadesk.Data;
using RazorPagesMegadesk.Models;

namespace RazorPagesMegadesk.Pages.Desks
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMegadesk.Data.RazorPagesMegadeskContext _context;

        public CreateModel(RazorPagesMegadesk.Data.RazorPagesMegadeskContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Desk Desk { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Desk == null || Desk == null)
            {
                return Page();
            }

            _context.Desk.Add(Desk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
