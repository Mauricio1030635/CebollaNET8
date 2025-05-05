using Cebolla.Domain.Interfaces;
using Cebolla.Infrastructure.EF.Context;
using Cebolla.Infrastructure.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cebolla.Infrastructure.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private IPersonaRepository? _personaRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IPersonaRepository PersonaRepository
            => _personaRepository ??= new PersonaRepositoryEf(_context);

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public void Dispose()
            => _context.Dispose();
    }
}
