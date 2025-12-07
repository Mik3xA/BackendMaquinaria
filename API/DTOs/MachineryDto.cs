namespace API.DTOs
{
    public class MachineryDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; } 
        public string ImageUrl { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty; 
        public string ListingType { get; set; } = "Renta"; 
        public bool IsPromotion { get; set; } = false;
    }
}