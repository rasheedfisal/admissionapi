using admissionapi.api.Requests.Queries;
using admissionapi.api.Services;
using Microsoft.AspNetCore.WebUtilities;

namespace MotorX.Api.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public string GetBaseRoot()
        {
            return _baseUri;
        }

        public Uri GetPageUri(PaginationQuery query, string route)
        {
            var _enpointUri = new Uri(string.Concat(_baseUri, route));
            var modifiedUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "pageNumber", query.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", query.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
