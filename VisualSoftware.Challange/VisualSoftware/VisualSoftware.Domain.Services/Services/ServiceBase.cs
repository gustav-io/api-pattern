using System;
using System.Collections.Generic;
using System.Text;
using VisualSoftware.Domain.Core.Interfaces.Services;
using VisualSoftware.Domain.Models;

namespace VisualSoftware.Domain.Services.Services
{
    public abstract class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> Repository)
        {
            _repository = Repository;
        }
        public virtual void Add(TEntity obj)
        {
            _repository.Add(obj);
        }
        public virtual TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
        public virtual IEnumerable<TEntity> GetAll(PaginationFilter paginationFilter = null)
        {
            if (paginationFilter == null)
            {
                return _repository.GetAll();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

            return _repository.GetAll(paginationFilter);
            
        }
        public virtual void Update(TEntity obj)
        {
            _repository.Update(obj);
        }
        public virtual void Remove(TEntity obj)
        {
            _repository.Remove(obj);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
