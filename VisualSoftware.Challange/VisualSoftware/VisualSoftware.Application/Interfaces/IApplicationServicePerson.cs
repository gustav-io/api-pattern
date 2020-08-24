using System;
using System.Collections.Generic;
using System.Text;
using VisualSoftware.Application.DTO.DTO;
using VisualSoftware.Application.Responses;
using VisualSoftware.Domain.Core.Queries;
using VisualSoftware.Domain.Models;

namespace VisualSoftware.Application.Interfaces
{
    public interface IApplicationServicePerson
    {
        void Add(PersonDTO obj);

        Response<PersonDTO> GetById(int id);

        PagedResponse<PersonDTO> GetAll(PaginationQuery paginationQuery = null);

        void Update(PersonDTO obj);

        void Remove(PersonDTO obj);

        void Dispose();

    }
}
