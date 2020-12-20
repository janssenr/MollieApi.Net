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
    public class RefundEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestListRefunds()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/refunds")
            };

            var responseContent = new RefundCollection {
                new Refund
                {
                    Resource = "refund",
                    Id = "re_haCsig5aru",
                    Amount = new Amount
                    {
                        Value = "2.00",
                        Currency = "EUR"
                    },
                    Status = "pending",
                    CreatedAt = new DateTime(2018, 3, 28, 10, 56, 10),
                    Description = "My first API payment",
                    PaymentId = "tr_44aKxzEbr8",
                    SettlementAmount = new Amount
                    {
                        Value = "-2.00",
                        Currency = "EUR"
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8/refunds/re_haCsig5aru"),
                            Type = "application/hal+json"
                        },
                        Payment = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8"),
                            Type = "application/hal+json"
                        },
                    }
                }
            };
            responseContent.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/refunds-api/list-refunds"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("http://api.mollie.nl/v2/refunds?limit=10"),
                    Type = "application/hal+json"
                },
                Previous = null,
                Next = null
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var refunds = await _apiClient.Refunds.Page();

            Assert.IsInstanceOfType(refunds, typeof(RefundCollection));
            Assert.AreEqual(1, refunds.Count);

            var refund = refunds[0];

            Assert.IsInstanceOfType(refund, typeof(Refund));
            Assert.AreEqual("re_haCsig5aru", refund.Id);
            Assert.AreEqual("2.00", refund.Amount.Value);
            Assert.AreEqual("EUR", refund.Amount.Currency);
            Assert.AreEqual("pending", refund.Status);
            Assert.AreEqual(new DateTime(2018, 3, 28, 10, 56, 10), refund.CreatedAt);
            Assert.AreEqual("My first API payment", refund.Description);
            Assert.AreEqual("tr_44aKxzEbr8", refund.PaymentId);
            Assert.AreEqual("-2.00", refund.SettlementAmount.Value);
            Assert.AreEqual("EUR", refund.SettlementAmount.Currency);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_44aKxzEbr8/refunds/re_haCsig5aru", "application/hal+json"), refund.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_44aKxzEbr8", "application/hal+json"), refund.Links.Payment);
        }
    }
}
