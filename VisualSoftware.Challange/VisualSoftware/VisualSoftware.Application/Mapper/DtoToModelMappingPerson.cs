using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VisualSoftware.Application.DTO.DTO;
using VisualSoftware.Domain.Models;

namespace VisualSoftware.Application.Mapper
{
    public class DtoToModelMappingPerson : Profile
    {
        public DtoToModelMappingPerson()
        {
            PersonMap();
        }

        private void PersonMap()
        {
            CreateMap<PersonDTO, Person>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id.GetValueOrDefault()))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Sobrenome, opt => opt.MapFrom(x => x.Sobrenome))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.Email))
                .ForMember(dest => dest.DataCadastro, opt => opt.Ignore())
                .ForMember(dest => dest.Ativo, opt => opt.Ignore());
        }
    }
}
