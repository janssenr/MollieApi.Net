using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;
using MollieApi.Tests.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class PaymentEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestCreatePayment()
        {
            var requestContent = new Payment
            {
                Amount = new Amount
                {
                    Value = "20.00",
                    Currency = "EUR"
                },
                Description = "My first API payment",
                RedirectUrl = new Uri("https://example.org/redirect"),
                WebhookUrl = new Uri("https://example.org/webhook"),
                Metadata = new Dictionary<string, string>
                {
                    { "order_id", "1234" }
                }
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/payments"),
                Content = new StringContent(JsonHelper.Serialize(requestContent))
            };

            var responseContent = new Payment
            {
                Resource = "payment",
                Id = "tr_44aKxzEbr8",
                Mode = "test",
                CreatedAt = new DateTime(2018, 3, 13, 14, 2, 29),
                Amount = new Amount
                {
                    Value = "20.00",
                    Currency = "EUR"
                },
                Description = "My first API payment",
                Method = null,
                Metadata = new Dictionary<string, string>
                {
                    { "order_id", "1234" }
                },
                Status = "open",
                IsCancelable = false,
                ExpiresAt = new DateTime(2018, 3, 13, 14, 17, 29),
                Details = null,
                ProfileId = "pfl_2A1gacu42V",
                SequenceType = "oneoff",
                RedirectUrl = new Uri("https://example.org/redirect"),
                WebhookUrl = new Uri("https://example.org/webhook"),
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments/tr_44aKxzEbr8"),
                        Type = "application/hal+json"
                    },
                    Checkout = new Url
                    {
                        Href = new Uri("https://www.mollie.com/payscreen/select-method/44aKxzEbr8"),
                        Type = "text/html"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/payments-api/create-payment"),
                        Type = "text/html"
                    }
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var payment = await _apiClient.Payments.Create(new Payment
            {
                Amount = new Amount
                {
                    Value = "20.00",
                    Currency = "EUR"
                },
                Description = "My first API payment",
                RedirectUrl = new Uri("https://example.org/redirect"),
                WebhookUrl = new Uri("https://example.org/webhook"),
                Metadata = new Dictionary<string, string>
                {
                    { "order_id", "1234" }
                }
            });

            Assert.IsInstanceOfType(payment, typeof(Payment));
            Assert.AreEqual("tr_44aKxzEbr8", payment.Id);
            Assert.AreEqual("test", payment.Mode);
            Assert.AreEqual(new DateTime(2018, 3, 13, 14, 2, 29), payment.CreatedAt);

            Assert.AreEqual(new Amount("20.00", "EUR"), payment.Amount);

            Assert.AreEqual("My first API payment", payment.Description);
            Assert.IsNull(payment.Method);
            Assert.IsTrue(payment.Metadata.ContentEquals(new Dictionary<string, string> { { "order_id", "1234" } }));
            Assert.AreEqual(PaymentStatus.STATUS_OPEN, payment.Status);
            Assert.IsFalse(payment.IsCancelable);
            Assert.AreEqual(new DateTime(2018, 3, 13, 14, 17, 29), payment.ExpiresAt);
            Assert.IsNull(payment.Details);
            Assert.AreEqual("pfl_2A1gacu42V", payment.ProfileId);
            Assert.AreEqual(SequenceType.SEQUENCETYPE_ONEOFF, payment.SequenceType);
            Assert.AreEqual(new Uri("https://example.org/redirect"), payment.RedirectUrl);
            Assert.AreEqual(new Uri("https://example.org/webhook"), payment.WebhookUrl);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_44aKxzEbr8", "application/hal+json"), payment.Links.Self);
            Assert.AreEqual(new Url("https://www.mollie.com/payscreen/select-method/44aKxzEbr8", "text/html"), payment.Links.Checkout);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/payments-api/create-payment", "text/html"), payment.Links.Documentation);
        }

        [TestMethod]
        public async Task TestUpdatePayment()
        {
            var requestContent = new Payment
            {
                Description = "Order #98765",
                RedirectUrl = new Uri("https://example.org/webshop/order/98765/"),
                WebhookUrl = new Uri("https://example.org/webshop/payments/webhook/"),
                Metadata = new Dictionary<string, string>
                {
                    { "order_id", "98765" }
                }
            };
            var request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(API_ENDPOINT + "/v2/payments/tr_7UhSN1zuXS"),
                //Content = new StringContent(JsonHelper.Serialize(requestContent))
            };

            var responseContent = new Payment
            {
                Resource = "payment",
                Id = "tr_7UhSN1zuXS",
                Mode = "test",
                CreatedAt = new DateTime(2018, 3, 20, 9, 13, 37),
                Amount = new Amount
                {
                    Value = "10.00",
                    Currency = "EUR"
                },
                Description = "Order #98765",
                Method = null,
                Metadata = new Dictionary<string, string>
                {
                    { "order_id", "98765" }
                },
                Status = "open",
                IsCancelable = false,
                ExpiresAt = new DateTime(2018, 3, 20, 9, 28, 37),
                Details = null,
                ProfileId = "pfl_QkEhN94Ba",
                SequenceType = "oneoff",
                RedirectUrl = new Uri("https://example.org/webshop/order/98765/"),
                WebhookUrl = new Uri("https://example.org/webshop/payments/webhook/"),
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments/tr_7UhSN1zuXS"),
                        Type = "application/hal+json"
                    },
                    Checkout = new Url
                    {
                        Href = new Uri("https://www.mollie.com/payscreen/select-method/7UhSN1zuXS"),
                        Type = "text/html"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/payments-api/update-payment"),
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

            // Get Payment stub
            var payment = new Payment
            {
                Id = "tr_7UhSN1zuXS",
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments/tr_7UhSN1zuXS"),
                        Type = "application/json"
                    }
                }
            };

            // Modify fields
            payment.Description = "Order #98765";
            payment.RedirectUrl = new Uri("https://example.org/webshop/order/98765/");
            payment.WebhookUrl = new Uri("https://example.org/webshop/payments/webhook/");
            payment.Metadata = new Dictionary<string, string> { { "order_id", "98765" } };

            payment = await _apiClient.Payments.Update(payment);

            Assert.AreEqual("payment", payment.Resource);
            Assert.AreEqual("tr_7UhSN1zuXS", payment.Id);

            Assert.AreEqual("Order #98765", payment.Description);
            Assert.AreEqual(new Uri("https://example.org/webshop/order/98765/"), payment.RedirectUrl);
            Assert.AreEqual(new Uri("https://example.org/webshop/payments/webhook/"), payment.WebhookUrl);
            Assert.IsTrue(payment.Metadata.ContentEquals(new Dictionary<string, string> { { "order_id", "98765" } }));
            Assert.AreEqual("oneoff", payment.SequenceType);
            Assert.AreEqual("pfl_QkEhN94Ba", payment.ProfileId);
            Assert.IsNull(payment.Details);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_7UhSN1zuXS", "application/hal+json"), payment.Links.Self);
            Assert.AreEqual(new Url("https://www.mollie.com/payscreen/select-method/7UhSN1zuXS", "text/html"), payment.Links.Checkout);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/payments-api/update-payment", "text/html"), payment.Links.Documentation);
        }

        [TestMethod]
        public async Task TestGetPayment()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/payments/tr_44aKxzEbr8?testmode=true")
            };

            var responseContent = new Payment
            {
                Resource = "payment",
                Id = "tr_44aKxzEbr8",
                Mode = "test",
                CreatedAt = new DateTime(2018, 3, 13, 14, 2, 29),
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
                    }
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var payment = await _apiClient.Payments.Get("tr_44aKxzEbr8", new Dictionary<string, string> { { "testmode", "true" } });

            Assert.IsInstanceOfType(payment, typeof(Payment));
            Assert.AreEqual("tr_44aKxzEbr8", payment.Id);
            Assert.AreEqual("test", payment.Mode);
            Assert.AreEqual(new DateTime(2018, 3, 13, 14, 2, 29), payment.CreatedAt);

            Assert.AreEqual(new Amount("20.00", "EUR"), payment.Amount);

            Assert.AreEqual("My first API payment", payment.Description);
            Assert.AreEqual("ideal", payment.Method);
            Assert.IsTrue(payment.Metadata.ContentEquals(new Dictionary<string, string> { { "order_id", "1234" } }));
            Assert.AreEqual(PaymentStatus.STATUS_PAID, payment.Status);

            Assert.AreEqual(new Amount("0.00", "EUR"), payment.AmountRefunded);
            Assert.AreEqual(new Amount("20.00", "EUR"), payment.AmountRemaining);

            var details = new Dictionary<string, string>
            {
                { "consumerName", "T. TEST" },
                { "consumerAccount", "NL17RABO0213698412" },
                { "consumerBic", "TESTNL99" }
            };
            Assert.IsTrue(details.ContentEquals(payment.Details));
            Assert.AreEqual("pfl_2A1gacu42V", payment.ProfileId);
            Assert.AreEqual(SequenceType.SEQUENCETYPE_ONEOFF, payment.SequenceType);
            Assert.AreEqual(new Uri("https://example.org/redirect"), payment.RedirectUrl);
            Assert.AreEqual(new Uri("https://example.org/webhook"), payment.WebhookUrl);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_44aKxzEbr8", "application/hal+json"), payment.Links.Self);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/payments-api/get-payment", "text/html"), payment.Links.Documentation);
        }

        [TestMethod]
        public async Task TestListPayment()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/payments?limit=3")
            };

            var responseContent = new PaymentCollection
            {
                new Payment
                {
                    Resource = "payment",
                    Id = "tr_admNa2tFfa",
                    Mode = "test",
                    CreatedAt = new DateTime(2018, 3, 19, 15, 0, 50),
                    Amount = new Amount
                    {
                        Value = "100.00",
                        Currency = "EUR"
                    },
                    Description = "Payment no 1",
                    Method = null,
                    Metadata = null,
                    Status = "open",
                    IsCancelable = false,
                    ExpiresAt = new DateTime(2018,3,19,15,15,50),
                    Details = null,
                    Locale = new CultureInfo("nl_NL"),
                    ProfileId = "pfl_7N5qjbu42V",
                    SequenceType = "oneoff",
                    RedirectUrl = new Uri("https://www.example.org/"),
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/payments/tr_admNa2tFfa"),
                            Type = "application/hal+json"
                        },
                        Checkout = new Url
                        {
                            Href = new Uri("https://www.mollie.com/payscreen/select-method/admNa2tFfa"),
                            Type = "text/html"
                        }
                    }
                },
                new Payment
                {
                    Resource = "payment",
                    Id = "tr_bcaLc7hFfa",
                    Mode = "test",
                    CreatedAt = new DateTime(2018, 3, 19, 15, 0, 50),
                    Amount = new Amount
                    {
                        Value = "100.00",
                        Currency = "EUR"
                    },
                    Description = "Payment no 2",
                    Method = null,
                    Metadata = null,
                    Status = "open",
                    IsCancelable = false,
                    ExpiresAt = new DateTime(2018,3,19,15,15,50),
                    Details = null,
                    Locale = new CultureInfo("nl_NL"),
                    ProfileId = "pfl_7N5qjbu42V",
                    SequenceType = "oneoff",
                    RedirectUrl = new Uri("https://www.example.org/"),
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/payments/tr_bcaLc7hFfa"),
                            Type = "application/hal+json"
                        },
                        Checkout = new Url
                        {
                            Href = new Uri("https://www.mollie.com/payscreen/select-method/bcaLc7hFfa"),
                            Type = "text/html"
                        }
                    }
                },
                new Payment
                {
                    Resource = "payment",
                    Id = "tr_pslHy1tFfa",
                    Mode = "test",
                    CreatedAt = new DateTime(2018, 3, 19, 15, 0, 50),
                    Amount = new Amount
                    {
                        Value = "100.00",
                        Currency = "EUR"
                    },
                    Description = "Payment no 3",
                    Method = null,
                    Metadata = null,
                    Status = "open",
                    IsCancelable = false,
                    ExpiresAt = new DateTime(2018,3,19,15,15,50),
                    Details = null,
                    Locale = new CultureInfo("nl_NL"),
                    ProfileId = "pfl_7N5qjbu42V",
                    SequenceType = "oneoff",
                    RedirectUrl = new Uri("https://www.example.org/"),
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/payments/tr_pslHy1tFfa"),
                            Type = "application/hal+json"
                        },
                        Checkout = new Url
                        {
                            Href = new Uri("https://www.mollie.com/payscreen/select-method/pslHy1tFfa"),
                            Type = "text/html"
                        }
                    }
                }
            };
            responseContent.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/payments-api/list-payments"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("http://api.mollie.com/v2/payments?limit=3"),
                    Type = "application/hal+json"
                },
                Previous = null,
                Next = new Url
                {
                    Href = new Uri("http://api.mollie.com/v2/payments?from=tr_eW8f5kzUkF&limit=3"),
                    Type = "application/hal+json"
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var payments = await _apiClient.Payments.Page(null, 3);

            Assert.IsInstanceOfType(payments, typeof(PaymentCollection));
            Assert.AreEqual(3, payments.Count);

            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/payments-api/list-payments", "text/html"), payments.Links.Documentation);
            Assert.AreEqual(new Url("http://api.mollie.com/v2/payments?limit=3", "application/hal+json"), payments.Links.Self);
            Assert.IsNull(payments.Links.Previous);
            Assert.AreEqual(new Url("http://api.mollie.com/v2/payments?from=tr_eW8f5kzUkF&limit=3", "application/hal+json"), payments.Links.Next);
        }
    }
}
