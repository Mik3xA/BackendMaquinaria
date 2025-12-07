using API.Data;
using API.DTOs;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class RentalService
    {
        private readonly ApplicationDbContext _context;

        public RentalService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Rental> RentMachinery(RentalRequestDto dto, int userId)
        {
            var machine = await _context.Machineries.FindAsync(dto.MachineryId);
            if (machine == null) throw new Exception("Máquina no encontrada.");
            var startUtc = DateTime.SpecifyKind(dto.StartDate, DateTimeKind.Utc);
            var endUtc = DateTime.SpecifyKind(dto.EndDate, DateTimeKind.Utc);
            var totalDays = (endUtc - startUtc).Days;
            if (totalDays <= 0) throw new Exception("La fecha de devolución debe ser posterior al inicio.");
            var traslape = await _context.Rentals
                .AnyAsync(r => r.MachineryId == dto.MachineryId 
                            && r.Status == "Activa"
                            && r.StartDate < endUtc 
                            && r.EndDate > startUtc);

            if (traslape) throw new Exception("Esa máquina ya está ocupada en esas fechas.");

            var rental = new Rental
            {
                UserId = userId,
                MachineryId = dto.MachineryId,
                StartDate = startUtc,
                EndDate = endUtc,
                TotalPrice = totalDays * machine.Price,
                Status = "Activa"
            };

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            return rental;
        }

        public async Task<List<Rental>> GetUserRentals(int userId)
        {
            return await _context.Rentals
                .Include(r => r.Machinery)
                .Where(r => r.UserId == userId)
                .OrderByDescending(r => r.StartDate)
                .ToListAsync();
        }
    }
}