using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMegadesk.Models;

namespace RazorPagesMegadesk.Data
{
    public class RazorPagesMegadeskContext : DbContext
    {
        public RazorPagesMegadeskContext (DbContextOptions<RazorPagesMegadeskContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMegadesk.Models.Desk> Desk { get; set; } = default!;
    }
}
