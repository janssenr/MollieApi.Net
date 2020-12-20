using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class WalletEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestRequestApplePayPaymentSession()
        {
            var requestContent = new ApplePayPaymentRequest
            {
                Domain = "pay.mywebshop.com",
                ValidationUrl = new Uri("https://apple-pay-gateway-cert.apple.com/paymentservices/paymentSession")
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/wallets/applepay/sessions"),
                Content = new StringContent(JsonHelper.Serialize(requestContent))
            };

            var responseContent = new ApplePayPaymentResponse
            {
                EpochTimestamp = new TimeSpan(1555507053169),
                ExpiresAt = new TimeSpan(1555510653169),
                MerchantSessionIdentifier = "SSH2EAF8AFAEAA94DEEA898162A5DAFD36E_916523AAED1343F5BC5815E12BEE9250AFFDC1A17C46B0DE5A943F0F94927C24",
                Nonce = "0206b8db",
                MerchantIdentifier = "BD62FEB196874511C22DB28A9E14A89E3534C93194F73EA417EC566368D391EB",
                DomainName = "pay.mywebshop.com",
                DisplayName = "Chuck Norris's Store",
                Signature = "308006092a864886f7...8cc030ad3000000000000"
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var domain = "pay.mywebshop.com";
            var validationUrl = new Uri("https://apple-pay-gateway-cert.apple.com/paymentservices/paymentSession");

            var applePayPaymentResponse = await _apiClient.Wallets.RequestApplePayPaymentSession(new ApplePayPaymentRequest
            {
                Domain = domain,
                ValidationUrl = validationUrl
            });

            Assert.IsInstanceOfType(applePayPaymentResponse, typeof(ApplePayPaymentResponse));
            Assert.AreEqual(new TimeSpan(1555507053169), applePayPaymentResponse.EpochTimestamp);
            Assert.AreEqual(new TimeSpan(1555510653169), applePayPaymentResponse.ExpiresAt);
            Assert.AreEqual("SSH2EAF8AFAEAA94DEEA898162A5DAFD36E_916523AAED1343F5BC5815E12BEE9250AFFDC1A17C46B0DE5A943F0F94927C24", applePayPaymentResponse.MerchantSessionIdentifier);
            Assert.AreEqual("0206b8db", applePayPaymentResponse.Nonce);
            Assert.AreEqual("BD62FEB196874511C22DB28A9E14A89E3534C93194F73EA417EC566368D391EB", applePayPaymentResponse.MerchantIdentifier);
            Assert.AreEqual("pay.mywebshop.com", applePayPaymentResponse.DomainName);
            Assert.AreEqual("Chuck Norris's Store", applePayPaymentResponse.DisplayName);
            Assert.AreEqual("308006092a864886f7...8cc030ad3000000000000", applePayPaymentResponse.Signature);
        }
    }
}
