using AutoMapper;
using Cebolla.Application.DTOs;
using Cebolla.Application.Interfaces;
using Cebolla.Domain.Entities;
using Cebolla.Domain.Interfaces;

namespace Cebolla.Application.Services
{
    public class PersonaService : IPersonaService
    {

        //private readonly IPersonaRepository personaRepositoryx;


        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        //public PersonaService(IPersonaRepository personaRepository, IMapper mapper)
        //{
        //    personaRepositoryx = personaRepository;
        //    mapperx = mapper;
        //}

        public PersonaService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonaDto>> ObtenerTodasAsync()
        {
            var personasx = await _uow.PersonaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonaDto>>(personasx);
        }

        public async Task<PersonaDto?> ObtenerPorIdAsync(int id)
        {
            var personax = await _uow.PersonaRepository.GetByIdAsync(id);
            return _mapper.Map<PersonaDto?>(personax);
        }

        public async Task CrearAsync(PersonaDto personaDto)
        {
            var personax = _mapper.Map<Persona>(personaDto);
            await _uow.PersonaRepository.AddAsync(personax);
        }

        public async Task ActualizarAsync(PersonaDto personaDto)
        {
            var personax = _mapper.Map<Persona>(personaDto);
            await _uow.PersonaRepository.UpdateAsync(personax);
        }

        public async Task EliminarAsync(int id)
        {
            await _uow.PersonaRepository.DeleteAsync(id);
        }
    }
}
