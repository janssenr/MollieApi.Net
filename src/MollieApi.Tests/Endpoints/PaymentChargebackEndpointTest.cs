using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class PaymentChargebackEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestListChargebacksForPaymentResource()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/payments/tr_44aKxzEbr8/chargebacks")
            };

            var responseContent = new ChargebackCollection
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
                        Payment = new Url
                        {
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
                    PaymentId = "tr_44aKxzEbr8",
                    SettlementAmount = new Amount
                    {
                        Value = "-0.37",
                        Currency = "EUR"
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8/chargebacks/chb_6cqlwf"),
                            Type = "application/hal+json"
                        },
                        Payment = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8"),
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
            responseContent.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/chargebacks-api/list-chargebacks"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8/chargebacks"),
                    Type = "application/hal+json"
                },
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var chargebacks = await _apiClient.PaymentChargebacks.ListFor(GetPayment());

            Assert.IsInstanceOfType(chargebacks, typeof(ChargebackCollection));
            Assert.AreEqual(2, chargebacks.Count);

            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/chargebacks-api/list-chargebacks", "text/html"), chargebacks.Links.Documentation);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_44aKxzEbr8/chargebacks", "application/hal+json"), chargebacks.Links.Self);

            AssertChargeback(chargebacks[0], "tr_44aKxzEbr8", "chb_n9z0tp", "-13.00");
            AssertChargeback(chargebacks[1], "tr_44aKxzEbr8", "chb_6cqlwf", "-0.37");
        }

        [TestMethod]
        public async Task TestGetChargebackForPaymentResource()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/payments/tr_44aKxzEbr8/chargebacks/chb_n9z0tp")
            };

            var responseContent = new Chargeback
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
                    Payment = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/chargebacks-api/get-chargeback"),
                        Type = "text/html"
                    }
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var chargeback = await _apiClient.PaymentChargebacks.GetFor(GetPayment(), "chb_n9z0tp");

            AssertChargeback(chargeback, "tr_44aKxzEbr8", "chb_n9z0tp", "-13.00");
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

        private Payment GetPayment()
        {
            return new Payment
            {
                Resource = "payment",
                Id = "tr_44aKxzEbr8",
                Mode = "test",
                CreatedAt = new DateTime(2018, 3, 19, 12, 17, 57),
                Amount = new Amount
                {
                    Value = "20.00",
                    Currency = "EUR"
                },
                Description = "My first API payment",
                Method = "ideal",
                Metadata = new Dictionary<string, string>
                {
                    { "order_id", "1234" }
                },
                Status = "paid",
                PaidAt = new DateTime(2018, 3, 19, 12, 18, 35),
                AmountRefunded = new Amount
                {
                    Value = "0.00",
                    Currency = "EUR"
                },
                AmountRemaining = new Amount
                {
                    Value = "20.00",
                    Currency = "EUR"
                },
                Details = new Dictionary<string, string>
                {
                    { "consumerName", "T. TEST" },
                    { "consumerAccount", "NL17RABO0213698412" },
                    { "consumerBic", "TESTNL99" },
                },
                Locale = new CultureInfo("nl_NL"),
                CountryCode = "NL",
                ProfileId = "pfl_2A1gacu42V",
                SequenceType = "oneoff",
                RedirectUrl = new Uri("https://example.org/redirect"),
                WebhookUrl = new Uri("https://example.org/webhook"),
                SettlementAmount = new Amount
                {
                    Value = "20.00",
                    Currency = "EUR"
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/payments-api/get-payment"),
                        Type = "text/html"
                    },
                    Chargebacks = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8/chargebacks"),
                        Type = "application/hal+json"
                    }
                }
            };
        }
    }
}
