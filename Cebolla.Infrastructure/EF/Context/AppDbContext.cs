using Cebolla.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cebolla.Infrastructure.EF.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Persona> Personas => Set<Persona>();

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
