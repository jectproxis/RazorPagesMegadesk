using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMegadesk.Data;
using RazorPagesMegadesk.Models;

namespace RazorPagesMegadesk.Pages.Desks
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMegadeskContext _context;

        public CreateModel(RazorPagesMegadeskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Desk Desk { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Desk.RushOrder += " Days";

            Desk.Date = DateTime.Now;

            // Calculate the total cost
            Desk.CalculateTotalCost();

            _context.Desk.Add(Desk);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
