using Cebolla.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cebolla.Domain.Interfaces
{
    public interface IPersonaRepository : IGenericRepository<Persona>
    {        
        Task<IEnumerable<Persona>> ObtenerPorApellidoAsync(string apellido);
    }
}
