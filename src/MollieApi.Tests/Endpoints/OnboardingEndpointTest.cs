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
    public class OnboardingEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestGetWorks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/onboarding/me")
            };

            var content = new Onboarding
            {
                Resource = "onboarding",
                Name = "Mollie B.V.",
                SignedUpAt = new DateTime(2018, 12, 20, 10, 49, 8),
                Status = "completed",
                CanReceivePayments = true,
                CanReceiveSettlements = true,
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/onboarding/me"),
                        Type = "application/hal+json"
                    },
                    Dashboard = new Url
                    {
                        Href = new Uri("https://www.mollie.com/dashboard/onboarding"),
                        Type = "text/html"
                    },
                    Organization = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/organization/org_12345"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/onboarding-api/get-onboarding-status"),
                        Type = "text/html"
                    }
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(content))
            };

            MockApiCall(request, response);

            var onboarding = await _apiClient.Onboarding.Get();

            Assert.IsInstanceOfType(onboarding, typeof(Onboarding));
            Assert.AreEqual("onboarding", onboarding.Resource);
            Assert.AreEqual("Mollie B.V.", onboarding.Name);
            Assert.AreEqual(OnboardingStatus.COMPLETED, onboarding.Status);
            Assert.AreEqual(new DateTime(2018, 12, 20, 10, 49, 8), onboarding.SignedUpAt);
            Assert.AreEqual(true, onboarding.CanReceivePayments);
            Assert.AreEqual(true, onboarding.CanReceiveSettlements);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/onboarding/me", "application/hal+json"), onboarding.Links.Self);
            Assert.AreEqual(new Url("https://www.mollie.com/dashboard/onboarding", "text/html"), onboarding.Links.Dashboard);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/organization/org_12345", "application/hal+json"), onboarding.Links.Organization);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/onboarding-api/get-onboarding-status", "text/html"), onboarding.Links.Documentation);
        }

        [TestMethod]
        public async Task TestSubmitWorks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/onboarding/me")
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent,
                Content = new StringContent("")
            };

            MockApiCall(request, response);

            await _apiClient.Onboarding.Submit(new Onboarding());
        }
    }
}
