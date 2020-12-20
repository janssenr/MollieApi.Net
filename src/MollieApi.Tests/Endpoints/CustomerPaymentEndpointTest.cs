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
    public class CustomerPaymentEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestCreateCustomerPayment()
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
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/payments"),
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
                    Customer = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/customers-api/create-payment"),
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

            var customer = GetCustomer();

            var payment = await _apiClient.CustomerPayments.CreateFor(customer, new Payment
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

            //AmountObjectTestHelpers.AssertAmountObject("20.00", "EUR", payment.Amount);
            Assert.AreEqual<Amount>(new Amount { Value = "20.00", Currency = "EUR" }, payment.Amount);

            Assert.AreEqual("My first API payment", payment.Description);
            Assert.IsNull(payment.Method);
            //Assert.AreEqual(new Dictionary<string, string> { { "order_id", "1234" } }, payment.Metadata);
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
            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n", "application/hal+json"), payment.Links.Customer);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/customers-api/create-payment", "text/html"), payment.Links.Documentation);
        }

        [TestMethod]
        public async Task TestListCustomerPayments()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/payments?testmode=true"),
            };

            var responseContent = new PaymentCollection
            {
                new Payment
                {
                    Resource = "payment",
                    Id = "tr_admNa2tFfa",
                    Mode = "test",
                    CreatedAt = new DateTime(2018,3,19,15,0,50),
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
                        },
                        Customer = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n"),
                            Type = "application/hal+json"
                        },
                    }
                },
                new Payment
                {
                    Resource = "payment",
                    Id = "tr_bcaLc7hFfa",
                    Mode = "test",
                    CreatedAt = new DateTime(2018,3,19,15,0,50),
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
                        },
                        Customer = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n"),
                            Type = "application/hal+json"
                        },
                    }
                },
                new Payment
                {
                    Resource = "payment",
                    Id = "tr_pslHy1tFfa",
                    Mode = "test",
                    CreatedAt = new DateTime(2018,3,19,15,0,50),
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
                        },
                        Customer = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n"),
                            Type = "application/hal+json"
                        },
                    }
                }
            };
            responseContent.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/customers-api/list-customer-payments"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/customers/cst_TkNdP8yPrH/payments?limit=50"),
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

            MockApiCall(request, response, true);

            var customer = GetCustomer();

            var payments = await _apiClient.CustomerPayments.ListFor(customer);

            Assert.IsInstanceOfType(payments, typeof(PaymentCollection));
            Assert.AreEqual(3, payments.Count);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/customers-api/list-customer-payments", "text/html"), payments.Links.Documentation);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_TkNdP8yPrH/payments?limit=50", "application/hal+json"), payments.Links.Self);
        }
    }
}
