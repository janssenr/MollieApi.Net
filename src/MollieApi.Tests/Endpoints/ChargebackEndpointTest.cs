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
    public class ChargebackEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestListChargebacks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/chargebacks")
            };

            var content = new ChargebackCollection
            {
                new Chargeback
                {
                    Resource = "chargeback",
                    Id = "chb_n9z0tp",
                    Amount = new Amount
                    {
                        Value = "-13.00",
                        Currency = "EUR"
                    },
                    CreatedAt = new DateTime(2018,3,28,11,44,32),
                    PaymentId = "tr_44aKxzEbr8",
                    SettlementAmount = new Amount
                    {
                        Value = "-13.00",
                        Currency = "EUR"
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8/chargebacks/chb_n9z0tp"),
                            Type = "application/hal+json"
                        },
                        Payment = new Url {
                            Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8"),
                            Type = "application/hal+json"
                        },
                        Documentation = new Url
                        {
                            Href = new Uri("https://docs.mollie.com/reference/v2/chargebacks-api/get-chargeback"),
                            Type = "text/html"
                        }
                    }
                },
                new Chargeback
                {
                    Resource = "chargeback",
                    Id = "chb_6cqlwf",
                    Amount = new Amount
                    {
                        Value = "-0.37",
                        Currency = "EUR"
                    },
                    CreatedAt = new DateTime(2018,3,28,11,44,32),
                    PaymentId = "tr_nQKWJbDj7j",
                    SettlementAmount = new Amount
                    {
                        Value = "-0.37",
                        Currency = "EUR"
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/payments/tr_nQKWJbDj7j/chargebacks/chb_6cqlwf"),
                            Type = "application/hal+json"
                        },
                        Payment = new Url {
                            Href = new Uri("https://api.mollie.com/v2/payments/tr_nQKWJbDj7j"),
                            Type = "application/hal+json"
                        },
                        Documentation = new Url
                        {
                            Href = new Uri("https://docs.mollie.com/reference/v2/chargebacks-api/get-chargeback"),
                            Type = "text/html"
                        }
                    }
                }
            };
            content.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/chargebacks-api/list-chargebacks"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/chargebacks"),
                    Type = "application/hal+json"
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(content))
            };

            MockApiCall(request, response);

            var chargebacks = await _apiClient.Chargebacks.Page();

            Assert.IsInstanceOfType(chargebacks, typeof(ChargebackCollection));
            Assert.AreEqual(2, chargebacks.Count);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/chargebacks-api/list-chargebacks", "text/html"), chargebacks.Links.Documentation);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/chargebacks", "application/hal+json"), chargebacks.Links.Self);
            AssertChargeback(chargebacks[0], "tr_44aKxzEbr8", "chb_n9z0tp", "-13.00");
            AssertChargeback(chargebacks[1], "tr_nQKWJbDj7j", "chb_6cqlwf", "-0.37");
        }

        private void AssertChargeback(Chargeback chargeback, string paymentId, string chargebackId, string amount)
        {
            Assert.IsInstanceOfType(chargeback, typeof(Chargeback));
            Assert.AreEqual("chargeback", chargeback.Resource);
            Assert.AreEqual(chargebackId, chargeback.Id);
            Assert.AreEqual(new Amount(amount, "EUR"), chargeback.Amount);
            Assert.AreEqual(new Amount(amount, "EUR"), chargeback.SettlementAmount);
            Assert.AreEqual(new DateTime(2018, 3, 28, 11, 44, 32), chargeback.CreatedAt);
            Assert.AreEqual(paymentId, chargeback.PaymentId);
            Assert.AreEqual(new Url($"https://api.mollie.com/v2/payments/{paymentId}/chargebacks/{chargebackId}", "application/hal+json"), chargeback.Links.Self);
            Assert.AreEqual(new Url($"https://api.mollie.com/v2/payments/{paymentId}", "application/hal+json"), chargeback.Links.Payment);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/chargebacks-api/get-chargeback", "text/html"), chargeback.Links.Documentation);
        }
    }
}
