using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisualSoftware.Domain.Core.Queries;

namespace VisualSoftware.Domain.Core.Interfaces.Services
{
    public interface IServiceUri
    {
        Uri GetRequestUri(string requestId);
        Uri GetAllRequestsUri(PaginationQuery paginationQuery = null);
    }
}
