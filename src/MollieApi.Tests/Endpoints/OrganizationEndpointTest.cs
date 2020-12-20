using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class OrganizationEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestGetOrganization()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/organizations/org_12345678")
            };

            var responseContent = new Organization
            {
                Resource = "organization",
                Id = "org_12345678",
                Name = "Mollie B.V.",
                Email = "info@mollie.com",
                Locale = new CultureInfo("nl_NL"),
                Address = new Address
                {
                    StreetAndNumber = "Keizersgracht 313",
                    PostalCode = "1016 EE",
                    City = "Amsterdam",
                    Country = "NL"
                },
                RegistrationNumber = "30204462",
                VatNumber = "NL815839091B01",
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/organizations/org_12345678"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/organizations-api/get-organization"),
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

            var organization = await _apiClient.Organizations.Get("org_12345678");

            AssertOrganization(organization);
        }

        [TestMethod]
        public async Task TestGetCurrentOrganization()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/organizations/me")
            };

            var responseContent = new Organization
            {
                Resource = "organization",
                Id = "org_12345678",
                Name = "Mollie B.V.",
                Email = "info@mollie.com",
                Locale = new CultureInfo("nl_NL"),
                Address = new Address
                {
                    StreetAndNumber = "Keizersgracht 313",
                    PostalCode = "1016 EE",
                    City = "Amsterdam",
                    Country = "NL"
                },
                RegistrationNumber = "30204462",
                VatNumber = "NL815839091B01",
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/organizations/org_12345678"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/organizations-api/get-organization"),
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

            var organization = await _apiClient.Organizations.Current();

            AssertOrganization(organization);
        }

        private void AssertOrganization(Organization organization)
        {
            Assert.IsInstanceOfType(organization, typeof(Organization));

            Assert.AreEqual("org_12345678", organization.Id);
            Assert.AreEqual("Mollie B.V.", organization.Name);
            Assert.AreEqual("info@mollie.com", organization.Email);
            Assert.AreEqual(new CultureInfo("nl_NL"), organization.Locale);

            Assert.AreEqual(new Address
            {
                StreetAndNumber = "Keizersgracht 313",
                PostalCode = "1016 EE",
                City = "Amsterdam",
                Country = "NL"
            }, organization.Address);

            Assert.AreEqual("30204462", organization.RegistrationNumber);
            Assert.AreEqual("NL815839091B01", organization.VatNumber);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/organizations/org_12345678", "application/hal+json"), organization.Links.Self);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/organizations-api/get-organization", "text/html"), organization.Links.Documentation);
        }
    }
}
