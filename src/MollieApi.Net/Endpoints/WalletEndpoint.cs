using MollieApi.Net.Resources;
using System.Threading.Tasks;

namespace MollieApi.Net.Endpoints
{
    public class WalletEndpoint : EndpointAbstract<BaseResource, BaseCollection<BaseResource>>
    {
        public WalletEndpoint(MollieApiClient client) : base(client) { }

        public async Task<ApplePayPaymentResponse> RequestApplePayPaymentSession(ApplePayPaymentRequest body)
        {
            return await _client.PerformHttpCall<ApplePayPaymentResponse>(MollieApiClient.HTTP_POST, "wallets/applepay/sessions", ParseRequestBody(body));
        }
    }
}
