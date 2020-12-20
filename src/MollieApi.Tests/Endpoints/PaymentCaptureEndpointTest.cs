using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class PaymentCaptureEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestGetCaptureForPaymentResource()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/payments/tr_WDqYK6vllg/captures/cpt_4qqhO89gsT")
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(GetCaptureFixture("tr_WDqYK6vllg", "cpt_4qqhO89gsT")))
            };

            MockApiCall(request, response);

            var capture = await _apiClient.PaymentCaptures.GetFor(GetPayment("tr_WDqYK6vllg"), "cpt_4qqhO89gsT");

            AssertCapture(capture);
        }

        [TestMethod]
        public async Task TestListCapturesForPaymentResource()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/payments/tr_WDqYK6vllg/captures")
            };

            var responseContent = new CaptureCollection
            {
                GetCaptureFixture("tr_WDqYK6vllg", "cpt_4qqhO89gsT")
            };
            responseContent.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/captures-api/list-captures"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.dev/v2/payments/tr_WDqYK6vllg/captures?limit=50"),
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

            var captures = await _apiClient.PaymentCaptures.ListFor(GetPayment("tr_WDqYK6vllg"));

            Assert.AreEqual(1, captures.Count);

            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/captures-api/list-captures", "text/html"), captures.Links.Documentation);
            Assert.AreEqual(new Url("https://api.mollie.dev/v2/payments/tr_WDqYK6vllg/captures?limit=50", "application/hal+json"), captures.Links.Self);
            Assert.IsNull(captures.Links.Previous);
            Assert.IsNull(captures.Links.Next);

            AssertCapture(captures[0]);
        }

        private void AssertCapture(Capture capture)
        {
            Assert.IsInstanceOfType(capture, typeof(Capture));

            Assert.AreEqual("capture", capture.Resource);
            Assert.AreEqual("cpt_4qqhO89gsT", capture.Id);
            Assert.AreEqual("live", capture.Mode);
            Assert.AreEqual("tr_WDqYK6vllg", capture.PaymentId);
            Assert.AreEqual("shp_3wmsgCJN4U", capture.ShipmentId);
            Assert.AreEqual("stl_jDk30akdN", capture.SettlementId);

            Assert.AreEqual(new Amount("1027.99", "EUR"), capture.Amount);
            Assert.AreEqual(new Amount("399.00", "EUR"), capture.SettlementAmount);

            Assert.AreEqual(new DateTime(2018, 8, 2, 9, 29, 56), capture.CreatedAt);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_WDqYK6vllg/captures/cpt_4qqhO89gsT", "application/hal+json"), capture.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_WDqYK6vllg", "application/hal+json"), capture.Links.Payment);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/orders/ord_8wmqcHMN4U/shipments/shp_3wmsgCJN4U", "application/hal+json"), capture.Links.Shipment);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/settlements/stl_jDk30akdN", "application/hal+json"), capture.Links.Settlement);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/captures-api/get-capture", "text/html"), capture.Links.Documentation);
        }

        private Capture GetCaptureFixture(string paymentId = "tr_WDqYK6vllg", string captureId = "cpt_4qqhO89gsT")
        {
            return new Capture
            {
                Resource = "capture",
                Id = captureId,
                Mode = "live",
                Amount = new Amount
                {
                    Value = "1027.99",
                    Currency = "EUR"
                },
                SettlementAmount = new Amount
                {
                    Value = "399.00",
                    Currency = "EUR"
                },
                PaymentId = paymentId,
                ShipmentId = "shp_3wmsgCJN4U",
                SettlementId = "stl_jDk30akdN",
                CreatedAt = new DateTime(2018, 8, 2, 9, 29, 56),
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri($"https://api.mollie.com/v2/payments/{paymentId}/captures/{captureId}"),
                        Type = "application/hal+json"
                    },
                    Payment = new Url
                    {
                        Href = new Uri($"https://api.mollie.com/v2/payments/{paymentId}"),
                        Type = "application/hal+json"
                    },
                    Shipment = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/orders/ord_8wmqcHMN4U/shipments/shp_3wmsgCJN4U"),
                        Type = "application/hal+json"
                    },
                    Settlement = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/settlements/stl_jDk30akdN"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/captures-api/get-capture"),
                        Type = "text/html"
                    }
                }
            };
        }

        private Payment GetPayment(string paymentId = "tr_44aKxzEbr8")
        {
            return new Payment
            {
                Resource = "payment",
                Id = paymentId,
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
                        Href = new Uri($"https://api.mollie.com/v2/payments/{paymentId}"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/payments-api/get-payment"),
                        Type = "text/html"
                    },
                    Refunds = new Url
                    {
                        Href = new Uri($"https://api.mollie.com/v2/payments/{paymentId}/refunds"),
                        Type = "application/hal+json"
                    },
                    Captures = new Url
                    {
                        Href = new Uri($"https://api.mollie.com/v2/payments/{paymentId}/captures"),
                        Type = "application/hal+json"
                    }
                }
            };
        }
    }
}
