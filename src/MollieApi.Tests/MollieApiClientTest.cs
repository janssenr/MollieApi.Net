using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net;
using MollieApi.Net.Exceptions;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using Moq;
using Moq.Protected;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MollieApi.Tests
{
    [TestClass]
    public class MollieApiClientTest
    {
        private Mock<HttpMessageHandler> _httpMessageHandler;
        private MollieApiClient _mollieApiClient;

        [TestInitialize]
        public void Setup()
        {
            _httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _mollieApiClient = new MollieApiClient(new HttpClient(_httpMessageHandler.Object));

            _mollieApiClient.SetApiKey("test_foobarfoobarfoobarfoobarfoobar");
        }

        [TestMethod]
        public async Task TestPerformHttpCallReturnBodyAsObject()
        {
            var payment = new Payment
            {
                Resource = "payment"
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(payment))
            };

            _httpMessageHandler
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var parsedResponse = await _mollieApiClient.PerformHttpCall<Payment>("GET", "");

            Assert.AreEqual(payment.Resource, parsedResponse.Resource);
        }

        [ExpectedException(typeof(ApiException))]
        [TestMethod]
        public async Task TestPerformHttpCallCreatesApiExceptionCorrectly()
        {
            var error = new MollieError
            {
                Status = 422,
                Title = "Unprocessable Entity",
                Detail = "Non-existent parameter \"recurringType\" for this API call. Did you mean: \"sequenceType\"?",
                Links = new Links
                {
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/guides/handling-errors"),
                        Type = "text/html"
                    }
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = (HttpStatusCode)422,
                Content = new StringContent(JsonHelper.Serialize(error))
            };
            _httpMessageHandler
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            try
            {
                var parsedResponse = await _mollieApiClient.PerformHttpCall<Payment>("GET", "");
            }
            catch (ApiException e)
            {
                Assert.AreEqual("Error executing API call (422: Unprocessable Entity): Non-existent parameter \"recurringType\" for this API call. Did you mean: \"sequenceType\"?", e.Message);
                throw e;
            }
        }
    }
}
