using System;
using System.Collections.Generic;
using System.Text;
using VisualSoftware.Domain.Models;

namespace VisualSoftware.Domain.Core.Interfaces.Services
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll(PaginationFilter paginationFilter = null);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();
    }
}
