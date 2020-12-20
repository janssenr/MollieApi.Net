using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class PaymentRefundEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestGetRefundForPaymentResource()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/payments/tr_44aKxzEbr8/refunds/re_PsAvxvLsnm")
            };

            var responseContent = new Refund
            {
                Resource = "refund",
                Id = "re_PsAvxvLsnm",
                Amount = new Amount
                {
                    Value = "20.00",
                    Currency = "EUR"
                },
                Status = "pending",
                CreatedAt = new DateTime(2018, 3, 19, 12, 33, 37),
                Description = "My first API payment",
                PaymentId = "tr_44aKxzEbr8",
                SettlementAmount = new Amount
                {
                    Value = "-20.00",
                    Currency = "EUR"
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments/tr_Tgxm3amJBT/refunds/re_PmEtpvSsnm"),
                        Type = "application/hal+json"
                    },
                    Payment = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/refunds-api/get-refund"),
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

            var refund = await _apiClient.PaymentRefunds.GetFor(GetPayment(), "re_PsAvxvLsnm");

            Assert.IsInstanceOfType(refund, typeof(Refund));
            Assert.AreEqual("re_PsAvxvLsnm", refund.Id);

            Assert.AreEqual(new Amount("20.00", "EUR"), refund.Amount);

            Assert.AreEqual("pending", refund.Status);
            Assert.AreEqual(new DateTime(2018, 3, 19, 12, 33, 37), refund.CreatedAt);
            Assert.AreEqual("My first API payment", refund.Description);
            Assert.AreEqual("tr_44aKxzEbr8", refund.PaymentId);

            Assert.AreEqual(new Amount("-20.00", "EUR"), refund.SettlementAmount);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_Tgxm3amJBT/refunds/re_PmEtpvSsnm", "application/hal+json"), refund.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_44aKxzEbr8", "application/hal+json"), refund.Links.Payment);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/refunds-api/get-refund", "text/html"), refund.Links.Documentation);
        }

        [TestMethod]
        public async Task TestCreateRefund()
        {
            var requestContent = new Refund
            {
                Amount = new Amount
                {
                    Currency = "EUR",
                    Value = "20.00"
                }
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/payments/tr_44aKxzEbr8/refunds"),
                Content = new StringContent(JsonHelper.Serialize(requestContent))
            };

            var responseContent = new Refund
            {
                Resource = "refund",
                Id = "re_PsAvxvLsnm",
                Amount = new Amount
                {
                    Value = "20.00",
                    Currency = "EUR"
                },
                Status = "pending",
                CreatedAt = new DateTime(2018, 3, 19, 12, 33, 37),
                Description = "My first API payment",
                PaymentId = "tr_44aKxzEbr8",
                SettlementAmount = new Amount
                {
                    Value = "-20.00",
                    Currency = "EUR"
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments/tr_Tgxm3amJBT/refunds/re_PmEtpvSsnm"),
                        Type = "application/hal+json"
                    },
                    Payment = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/refunds-api/get-refund"),
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

            var refund = await _apiClient.PaymentRefunds.CreateFor(GetPayment(), new Refund
            {
                Amount = new Amount
                {
                    Currency = "EUR",
                    Value = "20.00"
                }
            });

            Assert.IsInstanceOfType(refund, typeof(Refund));
            Assert.AreEqual("re_PsAvxvLsnm", refund.Id);

            Assert.AreEqual(new Amount("20.00", "EUR"), refund.Amount);

            Assert.AreEqual("pending", refund.Status);
            Assert.AreEqual(new DateTime(2018, 3, 19, 12, 33, 37), refund.CreatedAt);
            Assert.AreEqual("My first API payment", refund.Description);
            Assert.AreEqual("tr_44aKxzEbr8", refund.PaymentId);

            Assert.AreEqual(new Amount("-20.00", "EUR"), refund.SettlementAmount);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_Tgxm3amJBT/refunds/re_PmEtpvSsnm", "application/hal+json"), refund.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_44aKxzEbr8", "application/hal+json"), refund.Links.Payment);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/refunds-api/get-refund", "text/html"), refund.Links.Documentation);
        }

        [TestMethod]
        public async Task TestGetRefundsOnPaymentResource()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/payments/tr_44aKxzEbr8/refunds")
            };

            var responseContent = new RefundCollection
            {
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
                        }
                    }
                }
            };
            responseContent.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("http://api.mollie.nl/v2/payments/tr_44aKxzEbr8/refunds?limit=10"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("http://api.mollie.nl/v2/payments/tr_44aKxzEbr8/refunds?limit=10"),
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

            var refunds = await _apiClient.PaymentRefunds.ListFor(GetPayment());

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
                    { "consumerBic", "TESTNL99" }
                },
                Locale = new CultureInfo("nl_NL"),
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
                    Refunds = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8/refunds"),
                        Type = "application/hal+json"
                    }
                }
            };
        }
    }
}
