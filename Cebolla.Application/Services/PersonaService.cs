using AutoMapper;
using Cebolla.Application.DTOs;
using Cebolla.Application.Interfaces;
using Cebolla.Domain.Entities;
using Cebolla.Domain.Interfaces;

namespace Cebolla.Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository personaRepositoryx;
        private readonly IMapper mapperx;

        public PersonaService(IPersonaRepository personaRepository, IMapper mapper)
        {
            personaRepositoryx = personaRepository;
            mapperx = mapper;
        }

        public async Task<IEnumerable<PersonaDto>> ObtenerTodasAsync()
        {
            var personasx = await personaRepositoryx.GetAllAsync();
            return mapperx.Map<IEnumerable<PersonaDto>>(personasx);
        }

        public async Task<PersonaDto?> ObtenerPorIdAsync(int id)
        {
            var personax = await personaRepositoryx.GetByIdAsync(id);
            return mapperx.Map<PersonaDto?>(personax);
        }

        public async Task CrearAsync(PersonaDto personaDto)
        {
            var personax = mapperx.Map<Persona>(personaDto);
            await personaRepositoryx.AddAsync(personax);
        }

        public async Task ActualizarAsync(PersonaDto personaDto)
        {
            var personax = mapperx.Map<Persona>(personaDto);
            await personaRepositoryx.UpdateAsync(personax);
        }

        public async Task EliminarAsync(int id)
        {
            await personaRepositoryx.DeleteAsync(id);
        }
    }
}
