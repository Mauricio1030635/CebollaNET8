using Cebolla.Domain.Entities;
using Cebolla.Domain.Interfaces;
using Cebolla.Infrastructure.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace Cebolla.Infrastructure.EF.Repositories
{
    public class PersonaRepositoryEf : IPersonaRepository
    {
        private readonly AppDbContext _context;

        public PersonaRepositoryEf(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas.ToListAsync();
        }

        public async Task<Persona?> GetByIdAsync(int id)
        {
            return await _context.Personas.FindAsync(id);
        }

        public async Task AddAsync(Persona entity)
        {
            _context.Personas.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Persona entity)
        {
            _context.Personas.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Persona>> ObtenerPorApellidoAsync(string apellido)
        {
            return await _context.Personas
                .Where(p => p.Apellido.Contains(apellido))
                .ToListAsync();
        }
    }
}
