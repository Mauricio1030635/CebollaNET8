using Cebolla.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cebolla.Application.Interfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaDto>> ObtenerTodasAsync();
        Task<PersonaDto?> ObtenerPorIdAsync(int id);
        Task CrearAsync(PersonaDto personaDto);
        Task ActualizarAsync(PersonaDto personaDto);
        Task EliminarAsync(int id);
    }
}
