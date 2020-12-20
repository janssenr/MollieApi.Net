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
    public class SubscriptionEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestListPageOfRootSubscriptionsWorks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/subscriptions")
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
                    Href = new Uri("https://docs.mollie.com/reference/v2/subscriptions-api/list-all-subscriptions"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/subscriptions?limit=50"),
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

            var subscriptions = await _apiClient.Subscriptions.Page();

            Assert.IsInstanceOfType(subscriptions, typeof(SubscriptionCollection));
            Assert.AreEqual(1, subscriptions.Count);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/subscriptions-api/list-all-subscriptions", "text/html"), subscriptions.Links.Documentation);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/subscriptions?limit=50", "application/hal+json"), subscriptions.Links.Self);

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
    }
}
