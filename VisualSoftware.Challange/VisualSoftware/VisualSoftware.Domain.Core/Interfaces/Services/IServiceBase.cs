using System;
using System.Collections.Generic;
using System.Text;
using VisualSoftware.Domain.Models;

namespace VisualSoftware.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(TEntity obj);
        IEnumerable<TEntity> GetAll(PaginationFilter paginationFilter = null);
        TEntity GetById(int id);
    }
}
