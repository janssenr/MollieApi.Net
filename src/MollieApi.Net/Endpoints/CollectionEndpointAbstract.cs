using MollieApi.Net.Resources;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public abstract class CollectionEndpointAbstract<T1, T2> : EndpointAbstract<T1, T2> where T1: BaseResource
    {
        protected CollectionEndpointAbstract(MollieApiClient client) : base(client) { }

        public async Task<T2> Navigate(string url)
        {
            return await _client.PerformHttpCallToFullUrl<T2>(MollieApiClient.HTTP_GET, url);
        }
    }
}
