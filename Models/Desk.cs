using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMegadesk.Models
{
    public enum Surface
    {
        Laminate,
        Oak,
        Rosewood,
        Veneer,
        Pine
    }

    public class Desk
    {
        // Desk properties
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(24, 96, ErrorMessage = "Width must be between 24 and 96 inches.")]
        public int Width { get; set; }

        [Required]
        [Range(12, 48, ErrorMessage = "Depth must be between 12 and 48 inches.")]
        public int Depth { get; set; }

        [Required]
        [Range(0, 7, ErrorMessage = "Number of drawers must be between 0 and 7.")]
        public int Drawers { get; set; }

        [Required]
        [Display(Name = "Surface Material")]
        public Surface Surface { get; set; }

        [Required]
        [Display(Name = "Rush Order")]
        public string RushOrder { get; set; }

        [Display(Name = "Order Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Total Cost")]
        public int TotalCost { get; set; }

        public void CalculateTotalCost()
        {
            int basePrice = 200;
            int surfacePrice = CalculateSurfacePrice(Surface);
            int rushOrderPrice = CalculateRushOrderPrice(RushOrder);
            int drawersPrice = Drawers * 50;

            TotalCost = basePrice + surfacePrice + rushOrderPrice + drawersPrice;
        }

        private int CalculateSurfacePrice(Surface surface)
        {
            int surfacePrice = 0;

            switch (surface)
            {
                case Surface.Laminate:
                    surfacePrice = 100;
                    break;
                case Surface.Oak:
                    surfacePrice = 200;
                    break;
                case Surface.Rosewood:
                    surfacePrice = 300;
                    break;
                case Surface.Veneer:
                    surfacePrice = 125;
                    break;
                case Surface.Pine:
                    surfacePrice = 50;
                    break;
            }

            return surfacePrice;
        }

        private int CalculateRushOrderPrice(string rushOrder)
        {
            int rushOrderPrice = 0;

            switch (rushOrder)
            {
                case "3 Day":
                    rushOrderPrice = 60;
                    break;
                case "5 Day":
                    rushOrderPrice = 40;
                    break;
                case "7 Day":
                    rushOrderPrice = 30;
                    break;
            }

            return rushOrderPrice;
        }
    }
}
