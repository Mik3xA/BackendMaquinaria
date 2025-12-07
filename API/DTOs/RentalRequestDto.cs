namespace API.DTOs
{
    public class RentalRequestDto
    {
        public int MachineryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}