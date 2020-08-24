using System;
using System.Collections.Generic;
using System.Text;
using VisualSoftware.Domain.Core.Interfaces.Services;
using VisualSoftware.Domain.Models;
using VisualSoftware.Infrastructure.Data;

namespace VisualSoftware.Infrastructure.Repository.Repositories
{
    public class RepositoryPerson : RepositoryBase<Person>, IRepositoryPerson
    {
        private readonly SqlContext _context;
        public RepositoryPerson(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
