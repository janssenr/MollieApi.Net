using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net;
using MollieApi.Net.Exceptions;
using MollieApi.Net.Resources;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class OrderLineEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        [ExpectedException(typeof(ApiException))]

        public async Task TestCancelLinesRequiresLinesArray()
        {
            _httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _apiClient = new MollieApiClient(new HttpClient(_httpMessageHandler.Object));

            await _apiClient.OrderLines.CancelFor(new Order(), null);
        }
    }
}
