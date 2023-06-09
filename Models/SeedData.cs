﻿using Microsoft.EntityFrameworkCore;
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
                        RushOrder = "3 Days",
                        Date = DateTime.Parse("2023-6-6"),
                        TotalCost = 410
                    },
                    new Desk
                    {
                        Name = "Mark Zuckerberg",
                        Width = 30,
                        Depth = 15,
                        Drawers = 3,
                        Surface = Surface.Oak,
                        RushOrder = "7 Days",
                        Date = DateTime.Parse("2023-6-6"),
                        TotalCost = 580
                    });
                context.SaveChanges();
            }
        }

    }
}
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using RazorPagesMegadesk.Data;
//using System;
//using System.Linq;

//namespace RazorPagesMegadesk.Models
//{
//    public static class SeedData
//    {
//        public static void Initialize(IServiceProvider serviceProvider)
//        {
//            using (var context = new RazorPagesMegadeskContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMegadeskContext>>()))
//            {
//                if (context == null || context.Desk == null)
//                {
//                    throw new ArgumentNullException("Null MegaDeskContext");
//                }

//                // Look for any Desks.
//                if (context.Desk.Any())
//                {
//                    return; // DB has been seeded.
//                }

//                context.Desk.AddRange(
//                    new Desk
//                    {
//                        Name = "Bill Gates",
//                        Width = 24,
//                        Depth = 12,
//                        Drawers = 1,
//                        Surface = Surface.Laminate,
//                        RushOrder = "3 Day",
//                        Date = new DateTime(2023, 6, 6),
//                    },
//                    new Desk
//                    {
//                        Name = "Mark Zuckerberg",
//                        Width = 30,
//                        Depth = 15,
//                        Drawers = 3,
//                        Surface = Surface.Oak,
//                        RushOrder = "7 Day",
//                        Date = new DateTime(2023, 6, 6),
//                    });

//                context.SaveChanges();
//            }
//        }
//    }
//}
