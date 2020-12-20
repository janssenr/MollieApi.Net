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
    public class ProfileMethodEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestEnableProfileMethod()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/profiles/pfl_v9hTwCvYqw/methods")
            };

            var content = new Method
            {
                Resource = "method",
                Id = "bancontact",
                Description = "Bancontact",
                Image = new Image
                {
                    Size1x = new Uri("https://www.mollie.com/external/icons/payment-methods/bancontact.png"),
                    Size2x = new Uri("https://www.mollie.com/external/icons/payment-methods/bancontact%402x.png"),
                    Svg = new Uri("https://www.mollie.com/external/icons/payment-methods/bancontact.svg")
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/methods/bancontact"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/profiles-api/activate-method"),
                        Type = "text/html"
                    }
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonHelper.Serialize(content))
            };

            MockApiCall(request, response);

            var profile = GetProfile();
            var method = await _apiClient.ProfileMethods.CreateFor(profile, new Method { Id = "bancontact" });

            Assert.IsInstanceOfType(method, typeof(Method));
            Assert.AreEqual("bancontact", method.Id);
            Assert.AreEqual("Bancontact", method.Description);
            Assert.AreEqual(new Uri("https://www.mollie.com/external/icons/payment-methods/bancontact.png"), method.Image.Size1x);
            Assert.AreEqual(new Uri("https://www.mollie.com/external/icons/payment-methods/bancontact%402x.png"), method.Image.Size2x);
            Assert.AreEqual(new Uri("https://www.mollie.com/external/icons/payment-methods/bancontact.svg"), method.Image.Svg);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/methods/bancontact", "application/hal+json"), method.Links.Self);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/profiles-api/activate-method", "text/html"), method.Links.Documentation);
        }

        [TestMethod]
        public async Task TestDisableProfileMethod()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(API_ENDPOINT + "/v2/profiles/pfl_v9hTwCvYqw/methods/bancontact")
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent,
                Content = new StringContent("")
            };

            MockApiCall(request, response);

            var profile = GetProfile();
            var result = await _apiClient.ProfileMethods.DeleteFor(profile, "bancontact");

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task TestEnableCurrentProfileMethod()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/profiles/me/methods")
            };

            var content = new Method
            {
                Resource = "method",
                Id = "bancontact",
                Description = "Bancontact",
                Image = new Image
                {
                    Size1x = new Uri("https://www.mollie.com/external/icons/payment-methods/bancontact.png"),
                    Size2x = new Uri("https://www.mollie.com/external/icons/payment-methods/bancontact%402x.png"),
                    Svg = new Uri("https://www.mollie.com/external/icons/payment-methods/bancontact.svg")
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/methods/bancontact"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/profiles-api/activate-method"),
                        Type = "text/html"
                    }
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonHelper.Serialize(content))
            };

            MockApiCall(request, response);

            var method = await _apiClient.ProfileMethods.CreateForCurrentProfile(new Method { Id = "bancontact" });

            Assert.IsInstanceOfType(method, typeof(Method));
            Assert.AreEqual("bancontact", method.Id);
            Assert.AreEqual("Bancontact", method.Description);
            Assert.AreEqual(new Uri("https://www.mollie.com/external/icons/payment-methods/bancontact.png"), method.Image.Size1x);
            Assert.AreEqual(new Uri("https://www.mollie.com/external/icons/payment-methods/bancontact%402x.png"), method.Image.Size2x);
            Assert.AreEqual(new Uri("https://www.mollie.com/external/icons/payment-methods/bancontact.svg"), method.Image.Svg);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/methods/bancontact", "application/hal+json"), method.Links.Self);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/profiles-api/activate-method", "text/html"), method.Links.Documentation);
        }

        [TestMethod]
        public async Task TestDisableCurrentProfileMethod()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(API_ENDPOINT + "/v2/profiles/me/methods/bancontact")
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent,
                Content = new StringContent("")
            };

            MockApiCall(request, response);

            var result = await _apiClient.ProfileMethods.DeleteForCurrentProfile("bancontact");

            Assert.IsNull(result);
        }

        private Profile GetProfile()
        {
            return GetProfileFixture();
        }

        private Profile GetProfileFixture()
        {
            return new Profile
            {
                Resource = "profile",
                Id = "pfl_v9hTwCvYqw",
                Mode = "live",
                Name = "My website name",
                Website = new Uri("http://www.mywebsite.com"),
                Email = "info@mywebsite.com",
                Phone = "31123456789",
                CategoryCode = 5399,
                Status = "verified",
                Review = new Review
                {
                    Status = "pending"
                },
                CreatedAt = new DateTime(2016, 1, 11, 13, 3, 55),
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/profiles/pfl_v9hTwCvYqw"),
                        Type = "application/hal+json"
                    },
                    Chargebacks = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/chargebacks?profileId=pfl_v9hTwCvYqw"),
                        Type = "application/hal+json"
                    },
                    Methods = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/methods?profileId=pfl_v9hTwCvYqw"),
                        Type = "application/hal+json"
                    },
                    Payments = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments?profileId=pfl_v9hTwCvYqw"),
                        Type = "application/hal+json"
                    },
                    Refunds = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/refunds?profileId=pfl_v9hTwCvYqw"),
                        Type = "application/hal+json"
                    },
                    CheckoutPreviewUrl = new Url
                    {
                        Href = new Uri("https://www.mollie.com/payscreen/preview/pfl_v9hTwCvYqw"),
                        Type = "text/html"
                    }
                }
            };
        }
    }
}
