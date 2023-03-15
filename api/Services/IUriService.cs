using admissionapi.api.Requests.Queries;

namespace admissionapi.api.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationQuery query, string route);
        public string GetBaseRoot();
    }
}
