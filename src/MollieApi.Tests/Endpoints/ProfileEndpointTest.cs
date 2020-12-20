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
    public class ProfileEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestGetProfile()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/profiles/pfl_ahe8z8OPut")
            };

            var responseContent = new Profile
            {
                Resource = "profile",
                Id = "pfl_ahe8z8OPut",
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
                        Href = new Uri("https://api.mollie.com/v2/profiles/pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Chargebacks = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/chargebacks?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Methods = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/methods?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Payments = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Refunds = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/refunds?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    CheckoutPreviewUrl = new Url
                    {
                        Href = new Uri("https://www.mollie.com/payscreen/preview/pfl_ahe8z8OPut"),
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

            var profile = await _apiClient.Profiles.Get("pfl_ahe8z8OPut");

            Assert.IsInstanceOfType(profile, typeof(Profile));
            Assert.AreEqual("pfl_ahe8z8OPut", profile.Id);
            Assert.AreEqual("live", profile.Mode);
            Assert.AreEqual("My website name", profile.Name);
            Assert.AreEqual(new Uri("http://www.mywebsite.com"), profile.Website);
            Assert.AreEqual("info@mywebsite.com", profile.Email);
            Assert.AreEqual("31123456789", profile.Phone);
            Assert.AreEqual(5399, profile.CategoryCode);
            Assert.AreEqual(ProfileStatus.STATUS_VERIFIED, profile.Status);
            Assert.AreEqual(new Review { Status = "pending" }, profile.Review);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/profiles/pfl_ahe8z8OPut", "application/hal+json"), profile.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/chargebacks?profileId=pfl_ahe8z8OPut", "application/hal+json"), profile.Links.Chargebacks);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/methods?profileId=pfl_ahe8z8OPut", "application/hal+json"), profile.Links.Methods);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments?profileId=pfl_ahe8z8OPut", "application/hal+json"), profile.Links.Payments);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/refunds?profileId=pfl_ahe8z8OPut", "application/hal+json"), profile.Links.Refunds);
            Assert.AreEqual(new Url("https://www.mollie.com/payscreen/preview/pfl_ahe8z8OPut", "text/html"), profile.Links.CheckoutPreviewUrl);
        }

        [TestMethod]
        public async Task TestProfileUsingMe()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/profiles/me")
            };

            var responseContent = new Profile
            {
                Resource = "profile",
                Id = "pfl_ahe8z8OPut",
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
                        Href = new Uri("https://api.mollie.com/v2/profiles/pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Chargebacks = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/chargebacks?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Methods = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/methods?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Payments = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Refunds = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/refunds?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    CheckoutPreviewUrl = new Url
                    {
                        Href = new Uri("https://www.mollie.com/payscreen/preview/pfl_ahe8z8OPut"),
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

            var profile = await _apiClient.Profiles.Get("me");

            Assert.IsInstanceOfType(profile, typeof(Profile));
            Assert.AreEqual("pfl_ahe8z8OPut", profile.Id);

            // No need to test it all again...
        }

        [TestMethod]
        public async Task TestGetCurrentProfile()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/profiles/me")
            };

            var responseContent = new Profile
            {
                Resource = "profile",
                Id = "pfl_ahe8z8OPut",
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
                        Href = new Uri("https://api.mollie.com/v2/profiles/pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Chargebacks = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/chargebacks?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Methods = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/methods?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Payments = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Refunds = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/refunds?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    CheckoutPreviewUrl = new Url
                    {
                        Href = new Uri("https://www.mollie.com/payscreen/preview/pfl_ahe8z8OPut"),
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

            var profile = await _apiClient.Profiles.GetCurrent();

            Assert.IsInstanceOfType(profile, typeof(Profile));
            Assert.AreEqual("pfl_ahe8z8OPut", profile.Id);
            Assert.AreEqual("live", profile.Mode);
            Assert.AreEqual("My website name", profile.Name);
            Assert.AreEqual(new Uri("http://www.mywebsite.com"), profile.Website);
            Assert.AreEqual("info@mywebsite.com", profile.Email);
            Assert.AreEqual("31123456789", profile.Phone);
            Assert.AreEqual(5399, profile.CategoryCode);
            Assert.AreEqual(ProfileStatus.STATUS_VERIFIED, profile.Status);
            Assert.AreEqual(new Review { Status = "pending" }, profile.Review);

            Assert.AreEqual(new Url("https://api.mollie.com/v2/profiles/pfl_ahe8z8OPut", "application/hal+json"), profile.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/chargebacks?profileId=pfl_ahe8z8OPut", "application/hal+json"), profile.Links.Chargebacks);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/methods?profileId=pfl_ahe8z8OPut", "application/hal+json"), profile.Links.Methods);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments?profileId=pfl_ahe8z8OPut", "application/hal+json"), profile.Links.Payments);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/refunds?profileId=pfl_ahe8z8OPut", "application/hal+json"), profile.Links.Refunds);
            Assert.AreEqual(new Url("https://www.mollie.com/payscreen/preview/pfl_ahe8z8OPut", "text/html"), profile.Links.CheckoutPreviewUrl);
        }

        [TestMethod]
        public async Task TestListProfiles()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/profiles")
            };

            var responseContent = new ProfileCollection
            {
                new Profile
                {
                    Resource = "profile",
                    Id = "pfl_ahe8z8OPut",
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
                            Href = new Uri("https://api.mollie.com/v2/profiles/pfl_ahe8z8OPut"),
                            Type = "application/hal+json"
                        },
                        Chargebacks = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/chargebacks?profileId=pfl_ahe8z8OPut"),
                            Type = "application/hal+json"
                        },
                        Methods = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/methods?profileId=pfl_ahe8z8OPut"),
                            Type = "application/hal+json"
                        },
                        Payments = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/payments?profileId=pfl_ahe8z8OPut"),
                            Type = "application/hal+json"
                        },
                        Refunds = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/refunds?profileId=pfl_ahe8z8OPut"),
                            Type = "application/hal+json"
                        },
                        CheckoutPreviewUrl = new Url
                        {
                            Href = new Uri("https://www.mollie.com/payscreen/preview/pfl_ahe8z8OPut"),
                            Type = "text/html"
                        }
                    }
                },
                new Profile
                {
                    Resource = "profile",
                    Id = "pfl_znNaTRkJs5",
                    Mode = "live",
                    Name = "My website name 2",
                    Website = new Uri("http://www.mywebsite2.com"),
                    Email = "info@mywebsite2.com",
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
                            Href = new Uri("https://api.mollie.com/v2/profiles/pfl_znNaTRkJs5"),
                            Type = "application/hal+json"
                        },
                        Chargebacks = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/chargebacks?profileId=pfl_znNaTRkJs5"),
                            Type = "application/hal+json"
                        },
                        Methods = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/methods?profileId=pfl_znNaTRkJs5"),
                            Type = "application/hal+json"
                        },
                        Payments = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/payments?profileId=pfl_znNaTRkJs5"),
                            Type = "application/hal+json"
                        },
                        Refunds = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/refunds?profileId=pfl_znNaTRkJs5"),
                            Type = "application/hal+json"
                        },
                        CheckoutPreviewUrl = new Url
                        {
                            Href = new Uri("https://www.mollie.com/payscreen/preview/pfl_znNaTRkJs5"),
                            Type = "text/html"
                        }
                    }
                }
            };
            responseContent.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/profiles-api/list-profiles"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.nl/v2/profiles?limit=50"),
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

            var profiles = await _apiClient.Profiles.Page();

            Assert.IsInstanceOfType(profiles, typeof(ProfileCollection));
            Assert.AreEqual(2, profiles.Count);

            foreach (var profile in profiles)
            {
                Assert.IsInstanceOfType(profile, typeof(Profile));
            }

            Assert.AreEqual(new Url("https://api.mollie.nl/v2/profiles?limit=50", "application/hal+json"), profiles.Links.Self);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/profiles-api/list-profiles", "text/html"), profiles.Links.Documentation);
        }

        [TestMethod]
        public async Task TestUpdateProfile()
        {
            var expectedWebsiteName = "Mollie";
            var expectedEmail = "mollie@mollie.com";
            var expectedPhone = "31123456766";

            var request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(API_ENDPOINT + "/v2/profiles/pfl_ahe8z8OPut")
            };

            var responseContent = new Profile
            {
                Resource = "profile",
                Id = "pfl_ahe8z8OPut",
                Mode = "live",
                Name = expectedWebsiteName,
                Website = new Uri("http://www.mywebsite.com"),
                Email = expectedEmail,
                Phone = expectedPhone,
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
                        Href = new Uri("https://api.mollie.com/v2/profiles/pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Chargebacks = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/chargebacks?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Methods = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/methods?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Payments = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Refunds = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/refunds?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    CheckoutPreviewUrl = new Url
                    {
                        Href = new Uri("https://www.mollie.com/payscreen/preview/pfl_ahe8z8OPut"),
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

            var profile = GetProfile();
            profile.Name = expectedWebsiteName;
            profile.Email = expectedEmail;
            profile.Phone = expectedPhone;

            profile = await _apiClient.Profiles.Update(profile);

            Assert.AreEqual(expectedWebsiteName, profile.Name);
            Assert.AreEqual(expectedEmail, profile.Email);
            Assert.AreEqual(expectedPhone, profile.Phone);
        }

        private Profile GetProfile()
        {
            return new Profile
            {
                Resource = "profile",
                Id = "pfl_ahe8z8OPut",
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
                        Href = new Uri("https://api.mollie.com/v2/profiles/pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Chargebacks = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/chargebacks?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Methods = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/methods?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Payments = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    Refunds = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/refunds?profileId=pfl_ahe8z8OPut"),
                        Type = "application/hal+json"
                    },
                    CheckoutPreviewUrl = new Url
                    {
                        Href = new Uri("https://www.mollie.com/payscreen/preview/pfl_ahe8z8OPut"),
                        Type = "text/html"
                    }
                }
            };
        }
    }
}
