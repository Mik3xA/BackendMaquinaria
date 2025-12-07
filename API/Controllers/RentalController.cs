using API.Data;
using API.DTOs;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RentalController : ControllerBase
    {
        private readonly RentalService _service;
        private readonly ApplicationDbContext _context;

        public RentalController(RentalService service, ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }
        private int GetUserId()
        {
            var claim = User.FindFirst("id") ?? User.FindFirst(ClaimTypes.NameIdentifier);
            
            if (claim != null && int.TryParse(claim.Value, out int userId))
            {
                return userId;
            }
            throw new Exception("No se pudo identificar al usuario en el Token.");
        }

        [HttpPost("rent")]
        public async Task<IActionResult> Rent(RentalRequestDto dto)
        {
            try
            {
                int userId = GetUserId();
                var rental = await _service.RentMachinery(dto, userId);
                return Ok(rental);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("my-rentals")]
        public async Task<IActionResult> GetMyRentals()
        {
            try
            {
                int userId = GetUserId(); 
                var rentals = await _service.GetUserRentals(userId);
                return Ok(rentals);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("return/{id}")]
        public async Task<IActionResult> ReturnMachine(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental == null) return NotFound(new { message = "Renta no encontrada." });

            rental.Status = "Finalizada";
            await _context.SaveChangesAsync();
            
            return Ok(new { message = "Equipo devuelto correctamente." });
        }
    }
}