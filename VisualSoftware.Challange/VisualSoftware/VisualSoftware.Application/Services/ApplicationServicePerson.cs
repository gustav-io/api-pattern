using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VisualSoftware.Application.DTO.DTO;
using VisualSoftware.Application.Interfaces;
using VisualSoftware.Application.Responses;
using VisualSoftware.Domain.Core.Interfaces.Services;
using VisualSoftware.Domain.Core.Queries;
using VisualSoftware.Domain.Models;

namespace VisualSoftware.Application.Services
{
    public class ApplicationServicePerson : IApplicationServicePerson
    {
        private readonly IServicePerson _servicePerson;
        private readonly IMapper _mapper;
        private readonly IServiceUri _serviceUri;

        public ApplicationServicePerson(IServicePerson ServicePerson, IMapper mapper, IServiceUri serviceUri)

        {
            _servicePerson = ServicePerson;
            _mapper = mapper;
            _serviceUri = serviceUri;
        }


        public void Add(PersonDTO obj)
        {
            var person = _mapper.Map<Person>(obj);
            person.DataCadastro = DateTime.Now;
            person.Ativo = true;
            _servicePerson.Add(person);
        }

        public void Dispose()
        {
            _servicePerson.Dispose();
        }

        public PagedResponse<PersonDTO> GetAll(PaginationQuery paginationQuery = null)
        {
            var paginationFilter = _mapper.Map<PaginationFilter>(paginationQuery);

            var persons = _servicePerson.GetAll(paginationFilter);

            var paginationResponse = _mapper.Map<IEnumerable<PersonDTO>>(persons);

            if (paginationFilter == null || paginationFilter.PageNumber < 1 || paginationFilter.PageSize < 1)
            {
                return new PagedResponse<PersonDTO>(paginationResponse);
            }

            var nextPage = paginationFilter.PageNumber >= 1 ? _serviceUri.GetAllRequestsUri(new PaginationQuery(paginationFilter.PageNumber + 1, paginationFilter.PageSize)).ToString() : null;

            var previousPage = paginationFilter.PageNumber - 1 >= 1 ? _serviceUri.GetAllRequestsUri(new PaginationQuery(paginationFilter.PageNumber - 1, paginationFilter.PageSize)).ToString() : null;

            return new PagedResponse<PersonDTO> { 
                Data = paginationResponse,
                PageNumber = paginationFilter.PageNumber >= 1 ? paginationFilter.PageNumber : (int?)null,
                PageSize = paginationFilter.PageSize >= 1 ? paginationFilter.PageSize : (int?)null,
                NextPage = paginationResponse.Any() ? nextPage : null,
                PreviousPage = previousPage
            };
        }

        public Response<PersonDTO> GetById(int id)
        {
            var objPerson = _servicePerson.GetById(id);
            return new Response<PersonDTO>(_mapper.Map<PersonDTO>(objPerson));
        }

        public void Remove(PersonDTO obj)
        {
            var objPerson = _mapper.Map<Person>(obj);
            _servicePerson.Remove(objPerson);
        }

        public void Update(PersonDTO obj)
        {
            var objPerson = _mapper.Map<Person>(obj);
            _servicePerson.Update(objPerson);
        }
    }
}
