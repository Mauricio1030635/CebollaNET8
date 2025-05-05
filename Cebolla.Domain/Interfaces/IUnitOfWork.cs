using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cebolla.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository PersonaRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
