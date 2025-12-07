using API.Data;
using API.DTOs;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class MachineryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MachineryService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Machinery>> GetAll()
        {
            return await _context.Machineries.ToListAsync();
        }

        public async Task<Machinery?> GetById(int id)
        {
            return await _context.Machineries.FindAsync(id);
        }

        public async Task<Machinery> Create(MachineryDto dto)
        {
            var machinery = _mapper.Map<Machinery>(dto);
            
            _context.Machineries.Add(machinery);
            await _context.SaveChangesAsync();

            return machinery;
        }

        public async Task Delete(int id)
        {
            var machine = await _context.Machineries.FindAsync(id);
            if (machine != null)
            {
                _context.Machineries.Remove(machine);
                await _context.SaveChangesAsync();
            }
        }
    }
}