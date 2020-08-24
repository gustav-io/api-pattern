using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisualSoftware.Domain.Core.Interfaces.Services;
using VisualSoftware.Domain.Core.Queries;

namespace VisualSoftware.Domain.Services
{
    public class ServiceUri : IServiceUri
    {
        private readonly string _baseUri;

        public ServiceUri(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetRequestUri(string requestId)
        {

            return new Uri(_baseUri);
        }

        public Uri GetAllRequestsUri(PaginationQuery paginationQuery = null)
        {
            var uri = new Uri(_baseUri);

            if (paginationQuery == null)
            {
                return uri;
            }

            var modifiedUri = QueryHelpers.AddQueryString(_baseUri.ToString(), "pageNumber", paginationQuery.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", paginationQuery.PageSize.ToString());

            return new Uri(modifiedUri);
        }
    }
}
