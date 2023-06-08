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

        [BindProperty(SupportsGet = true)]
        public string SearchName { get; set; }

        public string NameSort { get; set; }

        public string DateSort { get; set; }




        public async Task OnGetAsync(string sortOrder)
        {
            /*if (_context.Desk != null)
            {
                Desk = await _context.Desk.ToListAsync();
            }*/
            IQueryable<string> nameQuery = from m in _context.Desk
                                           orderby m.Name
                                           select m.Name;

            
            var desks = from m in _context.Desk
                        select m;

            if (!string.IsNullOrEmpty(SearchName))
            {
                desks = desks.Where(s => s.Name.Contains(SearchName));
            }
            /*NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";*/
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                /*case "Date":
                    desks = desks.OrderBy(m => m.Date);
                    break;*/
                case "date_desc":
                    desks = desks.OrderByDescending(m => m.Date);
                    break;
                default:
                    desks = desks.OrderBy(m => m.Date);
                    break;
            }

            Desk = await desks.ToListAsync();
        }
    }
}
