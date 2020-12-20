using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class CustomerSubscriptionEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestCreateWorks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/subscriptions")
            };

            var responseContent = new Subscription
            {
                Resource = "subscription",
                Id = "sub_wByQa6efm6",
                Mode = "test",
                CreatedAt = new DateTime(2018, 4, 24, 11, 41, 55),
                Status = "active",
                Amount = new Amount
                {
                    Value = "10.00",
                    Currency = "EUR"
                },
                Description = "Order 1234",
                Method = null,
                Times = null,
                Interval = "1 month",
                StartDate = new DateTime(2018, 4, 24),
                WebhookUrl = null,
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/subscriptions/sub_wByQa6efm6"),
                        Type = "application/hal+json"
                    },
                    Customer = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/subscriptions-api/create-subscription"),
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

            var subscription = await _apiClient.CustomerSubscriptions.CreateFor(customer, new Subscription
            {
                Amount = new Amount
                {
                    Value = "10.00",
                    Currency = "EUR"
                },
                Interval = "1 month",
                Description = "Order 1234"
            });

            Assert.IsInstanceOfType(subscription, typeof(Subscription));
            Assert.AreEqual("subscription", subscription.Resource);
            Assert.AreEqual("sub_wByQa6efm6", subscription.Id);
            Assert.AreEqual("test", subscription.Mode);
            Assert.AreEqual(new DateTime(2018, 4, 24, 11, 41, 55), subscription.CreatedAt);
            Assert.AreEqual(SubscriptionStatus.STATUS_ACTIVE, subscription.Status);
            Assert.AreEqual(new Amount("10.00", "EUR"), subscription.Amount);
            Assert.AreEqual("Order 1234", subscription.Description);
            Assert.IsNull(subscription.Method);
            Assert.IsNull(subscription.Times);
            Assert.AreEqual("1 month", subscription.Interval);
            Assert.AreEqual(new DateTime(2018, 4, 24), subscription.StartDate);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/subscriptions/sub_wByQa6efm6", "application/hal+json"), subscription.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n", "application/hal+json"), subscription.Links.Customer);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/subscriptions-api/create-subscription", "text/html"), subscription.Links.Documentation);
        }

        [TestMethod]
        public async Task TestGetWorks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/subscriptions/sub_wByQa6efm6")
            };

            var responseContent = new Subscription
            {
                Resource = "subscription",
                Id = "sub_wByQa6efm6",
                Mode = "test",
                CreatedAt = new DateTime(2018, 4, 24, 11, 41, 55),
                Status = "active",
                Amount = new Amount
                {
                    Value = "10.00",
                    Currency = "EUR"
                },
                Description = "Order 1234",
                Method = null,
                Times = null,
                Interval = "1 month",
                StartDate = new DateTime(2018, 4, 24),
                WebhookUrl = null,
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/subscriptions/sub_wByQa6efm6"),
                        Type = "application/hal+json"
                    },
                    Customer = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/subscriptions-api/create-subscription"),
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

            var subscription = await _apiClient.CustomerSubscriptions.GetFor(customer, "sub_wByQa6efm6");

            Assert.IsInstanceOfType(subscription, typeof(Subscription));
            Assert.AreEqual("subscription", subscription.Resource);
            Assert.AreEqual("sub_wByQa6efm6", subscription.Id);
            Assert.AreEqual("test", subscription.Mode);
            Assert.AreEqual(new DateTime(2018, 4, 24, 11, 41, 55), subscription.CreatedAt);
            Assert.AreEqual(SubscriptionStatus.STATUS_ACTIVE, subscription.Status);
            Assert.AreEqual(new Amount("10.00", "EUR"), subscription.Amount);
            Assert.AreEqual("Order 1234", subscription.Description);
            Assert.IsNull(subscription.Method);
            Assert.IsNull(subscription.Times);
            Assert.AreEqual("1 month", subscription.Interval);
            Assert.AreEqual(new DateTime(2018, 4, 24), subscription.StartDate);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/subscriptions/sub_wByQa6efm6", "application/hal+json"), subscription.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n", "application/hal+json"), subscription.Links.Customer);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/subscriptions-api/create-subscription", "text/html"), subscription.Links.Documentation);
        }

        [TestMethod]
        public async Task TestListWorks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/subscriptions")
            };

            var responseContent = new SubscriptionCollection
            {
                new Subscription
                {
                    Resource = "subscription",
                    Id = "sub_wByQa6efm6",
                    Mode = "test",
                    CreatedAt = new DateTime(2018, 4, 24, 11, 41, 55),
                    Status = "active",
                    Amount = new Amount
                    {
                        Value = "10.00",
                        Currency = "EUR"
                    },
                    Description = "Order 1234",
                    Method = null,
                    Times = null,
                    Interval = "1 month",
                    StartDate = new DateTime(2018, 4, 24),
                    WebhookUrl = null,
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/subscriptions/sub_wByQa6efm6"),
                            Type = "application/hal+json"
                        },
                        Customer = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n"),
                            Type = "application/hal+json"
                        },
                        Documentation = new Url
                        {
                            Href = new Uri("https://docs.mollie.com/reference/v2/subscriptions-api/create-subscription"),
                            Type = "text/html"
                        }
                    }
                }
            };
            responseContent.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/subscriptions-api/list-subscriptions"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/subscriptions?limit=50"),
                    Type = "application/hal+json"
                },
                Previous = null,
                Next = null
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var customer = GetCustomer();

            var subscriptions = await _apiClient.CustomerSubscriptions.ListFor(customer);

            Assert.IsInstanceOfType(subscriptions, typeof(SubscriptionCollection));
            Assert.AreEqual(1, subscriptions.Count);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/subscriptions-api/list-subscriptions", "text/html"), subscriptions.Links.Documentation);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/subscriptions?limit=50", "application/hal+json"), subscriptions.Links.Self);

            foreach (var subscription in subscriptions)
            {
                Assert.IsInstanceOfType(subscription, typeof(Subscription));
                Assert.AreEqual("subscription", subscription.Resource);
                Assert.AreEqual("sub_wByQa6efm6", subscription.Id);
                Assert.AreEqual("test", subscription.Mode);
                Assert.AreEqual(new DateTime(2018, 4, 24, 11, 41, 55), subscription.CreatedAt);
                Assert.AreEqual(SubscriptionStatus.STATUS_ACTIVE, subscription.Status);
                Assert.AreEqual(new Amount("10.00", "EUR"), subscription.Amount);
                Assert.AreEqual("Order 1234", subscription.Description);
                Assert.IsNull(subscription.Method);
                Assert.IsNull(subscription.Times);
                Assert.AreEqual("1 month", subscription.Interval);
                Assert.AreEqual(new DateTime(2018, 4, 24), subscription.StartDate);

                Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/subscriptions/sub_wByQa6efm6", "application/hal+json"), subscription.Links.Self);
                Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n", "application/hal+json"), subscription.Links.Customer);
                Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/subscriptions-api/create-subscription", "text/html"), subscription.Links.Documentation);
            }
        }

        [TestMethod]
        public async Task TestCancelWorks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/subscriptions/sub_wByQa6efm6")
            };

            var responseContent = new Subscription
            {
                Resource = "subscription",
                Id = "sub_wByQa6efm6",
                Mode = "test",
                CreatedAt = new DateTime(2018, 4, 24, 11, 41, 55),
                Status = "active",
                Amount = new Amount
                {
                    Value = "10.00",
                    Currency = "EUR"
                },
                Description = "Order 1234",
                Method = null,
                Times = null,
                Interval = "1 month",
                StartDate = new DateTime(2018, 4, 24),
                WebhookUrl = null,
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/subscriptions/sub_wByQa6efm6"),
                        Type = "application/hal+json"
                    },
                    Customer = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/subscriptions-api/create-subscription"),
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

            var customer = GetCustomer();

            var subscription = await _apiClient.CustomerSubscriptions.CancelFor(customer, "sub_wByQa6efm6");

            Assert.IsInstanceOfType(subscription, typeof(Subscription));
            Assert.AreEqual("subscription", subscription.Resource);
            Assert.AreEqual("sub_wByQa6efm6", subscription.Id);
            Assert.AreEqual("test", subscription.Mode);
            Assert.AreEqual(new DateTime(2018, 4, 24, 11, 41, 55), subscription.CreatedAt);
            Assert.AreEqual(SubscriptionStatus.STATUS_ACTIVE, subscription.Status);
            Assert.AreEqual(new Amount("10.00", "EUR"), subscription.Amount);
            Assert.AreEqual("Order 1234", subscription.Description);
            Assert.IsNull(subscription.Method);
            Assert.IsNull(subscription.Times);
            Assert.AreEqual("1 month", subscription.Interval);
            Assert.AreEqual(new DateTime(2018, 4, 24), subscription.StartDate);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/subscriptions/sub_wByQa6efm6", "application/hal+json"), subscription.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n", "application/hal+json"), subscription.Links.Customer);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/subscriptions-api/create-subscription", "text/html"), subscription.Links.Documentation);
        }

        [TestMethod]
        public async Task TestThatUpdateSubscriptionWorks()
        {
            var expectedAmountValue = "12.00";
            var expectedAmountCurrency = "EUR";
            var expectedStartDate = new DateTime(2018, 12, 12);

            var request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/subscriptions/sub_DRjwaT5qHx")
            };

            var responseContent = new Subscription
            {
                Resource = "subscription",
                Id = "sub_DRjwaT5qHx",
                CustomerId = "cst_VhjQebNW5j",
                Mode = "live",
                CreatedAt = new DateTime(2018, 7, 17, 7, 45, 52),
                Status = "active",
                Amount = new Amount
                {
                    Value = expectedAmountValue,
                    Currency = expectedAmountCurrency
                },
                Description = "Mollie Recurring subscription #1",
                Method = null,
                Times = 42,
                Interval = "15 days",
                StartDate = expectedStartDate,
                WebhookUrl = new Uri("https://example.org/webhook"),
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("http://api.mollie.test/v2/customers/cst_VhjQebNW5j/subscriptions/sub_DRjwaT5qHx"),
                        Type = "application/hal+json"
                    },
                    Customer = new Url
                    {
                        Href = new Uri("http://api.mollie.test/v2/customers/cst_VhjQebNW5j"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/subscriptions-api/update-subscription"),
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

            var subscription = GetSubscription();
            var expectedAmount = new Amount
            {
                Value = expectedAmountValue,
                Currency = expectedAmountCurrency
            };
            subscription.Amount = expectedAmount;
            subscription.StartDate = expectedStartDate;

            var customer = GetCustomer();

            subscription = await _apiClient.CustomerSubscriptions.UpdateFor(customer, subscription);

            Assert.AreEqual(expectedStartDate, subscription.StartDate);
            Assert.AreEqual(expectedAmount, subscription.Amount);
        }

        private Subscription GetSubscription()
        {
            return new Subscription
            {
                Resource = "subscription",
                Id = "sub_DRjwaT5qHx",
                CustomerId = "cst_VhjQebNW5j",
                Mode = "live",
                CreatedAt = new DateTime(2018, 7, 17, 7, 45, 52),
                Status = "active",
                Amount = new Amount
                {
                    Value = "10.00",
                    Currency = "EUR"
                },
                Description = "Mollie Recurring subscription #1",
                Method = null,
                Times = 42,
                Interval = "15 days",
                StartDate = new DateTime(2018, 12, 12),
                WebhookUrl = new Uri("https://example.org/webhook"),
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("http://api.mollie.test/v2/customers/cst_VhjQebNW5j/subscriptions/sub_DRjwaT5qHx"),
                        Type = "application/hal+json"
                    },
                    Customer = new Url
                    {
                        Href = new Uri("http://api.mollie.test/v2/customers/cst_VhjQebNW5j"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/subscriptions-api/update-subscription"),
                        Type = "text/html"
                    }
                }
            };
        }
    }
}
