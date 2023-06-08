using System.ComponentModel.DataAnnotations;

namespace RazorPagesMegadesk.Models
{
    public class Desk
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;

        [Range(24, 96)]
        public int Width { get; set; }

        [Range(12, 48)]
        public int Depth { get; set; }

        [Required(ErrorMessage = "Select this field")]
        public int Drawers { get; set; }


        [Required(ErrorMessage = "Select a Surface Material")]
        public Surface Surface { get; set; }

        [Required(ErrorMessage = "Select an Option.")]
        public string RushOrder { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int TotalCost { get; set; }
    }

    public enum Surface
    {
        Oak,
        Laminate,
        Pine,
        Rosewood,
        Veneer
    }
}
