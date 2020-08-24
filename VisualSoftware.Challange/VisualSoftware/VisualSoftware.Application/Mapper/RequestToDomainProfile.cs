using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VisualSoftware.Domain.Core.Queries;
using VisualSoftware.Domain.Models;

namespace VisualSoftware.Application.Mapper
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            RequestMap();
        }

        private void RequestMap()
        {
            CreateMap<PaginationQuery, PaginationFilter>()
                .ForMember(x => x.PageNumber, opt => opt.MapFrom(x => x.PageNumber))
                .ForMember(x => x.PageSize, opt => opt.MapFrom(x => x.PageSize));
        }
    }
}
