using API.DTOs;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineryController : ControllerBase
    {
        private readonly MachineryService _service;

        public MachineryController(MachineryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Machinery>>> GetAll()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Machinery>> GetById(int id)
        {
            var machine = await _service.GetById(id);
            if (machine == null)
            {
                return NotFound();
            }
            return Ok(machine);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Machinery>> Create(MachineryDto dto)
        {
            var created = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var machine = await _service.GetById(id);
            if (machine == null) return NotFound();

            await _service.Delete(id);
            return NoContent();
        }
    }
}