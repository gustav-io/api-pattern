using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VisualSoftware.Application.DTO.DTO;
using VisualSoftware.Domain.Models;

namespace VisualSoftware.Application.Mapper
{
    public class ModelToDtoMappingPerson : Profile
    {
        public ModelToDtoMappingPerson()
        {
            PersonDtoMap();
        }

        private void PersonDtoMap()
        {
            CreateMap<Person, PersonDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(x => x.Sobrenome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email));
        }
    }
}
