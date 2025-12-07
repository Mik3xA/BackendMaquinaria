using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Machinery
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty; 

        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; } 

        public string ImageUrl { get; set; } = string.Empty;

        public string Category { get; set; } = "General"; 

        public string ListingType { get; set; } = "Renta"; 

        public bool IsPromotion { get; set; } = false; 

        public bool IsAvailable { get; set; } = true; 
    }
}