using AutoMapper;
using Cebolla.Application.DTOs;
using Cebolla.Domain.Entities;

namespace Cebolla.Application.MappingProfiles
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            CreateMap<Persona, PersonaDto>().ReverseMap();
        }
    }
}
