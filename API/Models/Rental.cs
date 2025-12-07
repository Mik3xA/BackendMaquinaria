using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; } 

        public string Status { get; set; } = "Activa"; 

        public int UserId { get; set; }
        public User? User { get; set; }
        public int MachineryId { get; set; }
        public Machinery? Machinery { get; set; }
    }
}