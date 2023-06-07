using Microsoft.EntityFrameworkCore;
using RazorPagesMegadesk.Data;

namespace RazorPagesMegadesk.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMegadeskContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMegadeskContext>>()))
            {
                if (context == null || context.Desk == null)
                {
                    throw new ArgumentNullException("Null MegaDeskContext");
                }

                // Look for any Desks.
                if (context.Desk.Any())
                {
                    return; // DB has been seeded.
                }

                context.Desk.AddRange(
                    new Desk
                    {
                        Name = "Bill Gates",
                        Width = 24,
                        Depth = 12,
                        Drawers = 1,
                        Surface = Surface.Laminate,
                        RushOrder = "3 Day",
                        Date = DateTime.Parse("2023-6-6"),
                        TotalCost = 500
                    },
                    new Desk
                    {
                        Name = "Mark Zuckerberg",
                        Width = 30,
                        Depth = 15,
                        Drawers = 3,
                        Surface = Surface.Oak,
                        RushOrder = "7 Day",
                        Date = DateTime.Parse("2023-6-6"),
                        TotalCost = 600
                    });
                context.SaveChanges();
            }
        }

    }
}
