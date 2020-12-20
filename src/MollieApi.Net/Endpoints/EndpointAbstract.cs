using MollieApi.Net.Exceptions;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public abstract class EndpointAbstract<T1, T2> where T1 : BaseResource
    {
        private const string REST_CREATE = MollieApiClient.HTTP_POST;
        private const string REST_UPDATE = MollieApiClient.HTTP_PATCH;
        private const string REST_READ = MollieApiClient.HTTP_GET;
        private const string REST_LIST = MollieApiClient.HTTP_GET;
        private const string REST_DELETE = MollieApiClient.HTTP_DELETE;

        protected readonly MollieApiClient _client;
        private string _resourcePath;
        private string _parentId;

        protected EndpointAbstract(MollieApiClient client)
        {
            _client = client;
        }

        protected string BuildQueryString(Dictionary<string, string> filters)
        {
            if (_client.UsesOAuth())
            {
                if (filters == null)
                    filters = new Dictionary<string, string>();
                filters.Add("testmode", "true");
            }

            if (filters == null || !filters.Any())
                return "";

            var queryParameters = string.Join("&",
                filters.Select(
                    p =>
                        string.IsNullOrEmpty(p.Value)
                            ? Uri.EscapeDataString(p.Key)
                            : $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value)}"));
            if (!string.IsNullOrWhiteSpace(queryParameters))
            {
                return "?" + queryParameters;
            }
            return "";
        }

        protected async Task<T1> RestCreate(T1 body, Dictionary<string, string> filters)
        {
            return await _client.PerformHttpCall<T1>(REST_CREATE, GetResourcePath() + BuildQueryString(filters), ParseRequestBody(body));
        }

        protected async Task<T1> RestUpdate(T1 body, Dictionary<string, string> filters)
        {
            string id = body.Id;
            body.Id = null;
            body.Resource = null;
            return await _client.PerformHttpCall<T1>(REST_UPDATE, $"{GetResourcePath()}/{id}" + BuildQueryString(filters), ParseRequestBody(body));
        }

        protected async Task<T1> RestRead(string id, Dictionary<string, string> filters)
        {
            if (string.IsNullOrEmpty(id))
                throw new ApiException("Invalid resource id.");

            id = Uri.EscapeDataString(id);
            return await _client.PerformHttpCall<T1>(REST_READ, $"{GetResourcePath()}/{id}" + BuildQueryString(filters));
        }

        protected async Task<T1> RestDelete(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new ApiException("Invalid resource id.");

            id = Uri.EscapeDataString(id);
            return await _client.PerformHttpCall<T1>(REST_DELETE, $"{GetResourcePath()}/{id}");
        }

        protected async Task<T2> RestList(string from, int? limit, Dictionary<string, string> filters)
        {
            if (filters == null) filters = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(from))
                filters.Add("from", from);
            if (limit.HasValue)
                filters.Add("limit", $"{limit.Value}");

            return await _client.PerformHttpCall<T2>(REST_LIST, GetResourcePath() + BuildQueryString(filters));
        }

        protected void SetResourcePath(string resourcePath)
        {
            _resourcePath = resourcePath.ToLower();
        }

        protected string GetResourcePath()
        {
            if (_resourcePath.Contains("_"))
            {
                string[] resources = _resourcePath.Split(new char[] { '_' }, 2);
                string parentResource = resources[0];
                string childResource = resources[1];

                if (string.IsNullOrEmpty(_parentId))
                    throw new ApiException($"Subresource '{_resourcePath}' used without parent '{parentResource}' ID.");

                return $"{parentResource}/{_parentId}/{childResource}";
            }

            return _resourcePath;
        }

        protected void SetParentId(string parentId)
        {
            _parentId = parentId;
        }

        protected string ParseRequestBody<T>(T body)
        {
            if (body == null)
                return null;

            string encoded;
            try
            {
                encoded = JsonHelper.Serialize(body);
            }
            catch (Exception e)
            {
                throw new ApiException("Error encoding parameters into JSON: '" + e.Message + "'.");
            }

            return encoded;
        }
    }
}
