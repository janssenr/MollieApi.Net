using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class MethodEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestGetMethod()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/methods/ideal")
            };

            var content = new Method
            {
                Resource = "method",
                Id = "ideal",
                Description = "iDEAL",
                MinimumAmount = new Amount
                {
                    Value = "0.01",
                    Currency = "EUR"
                },
                MaximumAmount = new Amount
                {
                    Value = "50000.00",
                    Currency = "EUR"
                },
                Image = new Image
                {
                    Size1x = new Uri("https://www.mollie.com/images/payscreen/methods/ideal.png"),
                    Size2x = new Uri("https://www.mollie.com/images/payscreen/methods/ideal%402x.png")
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/methods/ideal"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/methods-api/get-method"),
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

            var idealMethod = await _apiClient.Methods.Get("ideal");

            Assert.IsInstanceOfType(idealMethod, typeof(Method));
            Assert.AreEqual("ideal", idealMethod.Id);
            Assert.AreEqual("iDEAL", idealMethod.Description);
            Assert.AreEqual(new Amount("0.01", "EUR"), idealMethod.MinimumAmount);
            Assert.AreEqual(new Amount("50000.00", "EUR"), idealMethod.MaximumAmount);
            Assert.AreEqual(new Uri("https://www.mollie.com/images/payscreen/methods/ideal.png"), idealMethod.Image.Size1x);
            Assert.AreEqual(new Uri("https://www.mollie.com/images/payscreen/methods/ideal%402x.png"), idealMethod.Image.Size2x);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/methods/ideal", "application/hal+json"), idealMethod.Links.Self);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/methods-api/get-method", "text/html"), idealMethod.Links.Documentation);
        }

        [TestMethod]
        public async Task TestGetMethodWithIncludeIssuers()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/methods/ideal?include=issuers")
            };

            var content = new Method
            {
                Resource = "method",
                Id = "ideal",
                Description = "iDEAL",
                MinimumAmount = new Amount
                {
                    Value = "0.01",
                    Currency = "EUR"
                },
                MaximumAmount = new Amount
                {
                    Value = "50000.00",
                    Currency = "EUR"
                },
                Image = new Image
                {
                    Size1x = new Uri("https://www.mollie.com/images/payscreen/methods/ideal.png"),
                    Size2x = new Uri("https://www.mollie.com/images/payscreen/methods/ideal%402x.png")
                },
                Issuers = new IssuerCollection
                {
                    new Issuer
                    {
                        Resource = "issuer",
                        Id = "ideal_TESTNL99",
                        Name = "TBM Bank",
                        Method = "ideal",
                        Image = new Image
                        {
                            Size1x = new Uri("https://www.mollie.com/images/checkout/v2/ideal-issuer-icons/TESTNL99.png"),
                            Size2x = new Uri("https://www.mollie.com/images/checkout/v2/ideal-issuer-icons/TESTNL99.png")
                        }
                    }
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/methods/ideal"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/methods-api/get-method"),
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

            var idealMethod = await _apiClient.Methods.Get("ideal", new Dictionary<string, string> { { "include", "issuers" } });

            Assert.IsInstanceOfType(idealMethod, typeof(Method));
            Assert.AreEqual("ideal", idealMethod.Id);
            Assert.AreEqual("iDEAL", idealMethod.Description);
            Assert.AreEqual(new Amount("0.01", "EUR"), idealMethod.MinimumAmount);
            Assert.AreEqual(new Amount("50000.00", "EUR"), idealMethod.MaximumAmount);
            Assert.AreEqual(new Uri("https://www.mollie.com/images/payscreen/methods/ideal.png"), idealMethod.Image.Size1x);
            Assert.AreEqual(new Uri("https://www.mollie.com/images/payscreen/methods/ideal%402x.png"), idealMethod.Image.Size2x);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/methods/ideal", "application/hal+json"), idealMethod.Links.Self);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/methods-api/get-method", "text/html"), idealMethod.Links.Documentation);

            var issuers = idealMethod.Issuers;
            //Assert.IsInstanceOfType(issuers, typeof(IssuerCollection));
            Assert.IsInstanceOfType(issuers, typeof(IList<Issuer>));
            Assert.AreEqual(1, issuers.Count);

            var testIssuer = issuers[0];

            Assert.IsInstanceOfType(testIssuer, typeof(Issuer));
            Assert.AreEqual("ideal_TESTNL99", testIssuer.Id);
            Assert.AreEqual("TBM Bank", testIssuer.Name);
            Assert.AreEqual("ideal", testIssuer.Method);

            var expectedSize1xImageLink = new Uri("https://www.mollie.com/images/checkout/v2/ideal-issuer-icons/TESTNL99.png");
            Assert.AreEqual(expectedSize1xImageLink, testIssuer.Image.Size1x);

            var expectedSize2xImageLink = new Uri("https://www.mollie.com/images/checkout/v2/ideal-issuer-icons/TESTNL99.png");
            Assert.AreEqual(expectedSize2xImageLink, testIssuer.Image.Size2x);
        }

        [TestMethod]
        public async Task TestGetMethodWithIncludePricing()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/methods/ideal?include=pricing")
            };

            var content = new Method
            {
                Resource = "method",
                Id = "ideal",
                Description = "iDEAL",
                MinimumAmount = new Amount
                {
                    Value = "0.01",
                    Currency = "EUR"
                },
                MaximumAmount = new Amount
                {
                    Value = "50000.00",
                    Currency = "EUR"
                },
                Image = new Image
                {
                    Size1x = new Uri("https://www.mollie.com/images/payscreen/methods/ideal.png"),
                    Size2x = new Uri("https://www.mollie.com/images/payscreen/methods/ideal%402x.png"),
                    Svg = new Uri("https://www.mollie.com/external/icons/payment-methods/ideal.svg")
                },
                Pricing = new MethodPriceCollection
                {
                    new MethodPrice
                    {
                        Description = "The Netherlands",
                        Fixed = new Amount
                        {
                            Value = "0.29",
                            Currency = "EUR"
                        },
                        Variable = "0"
                    }
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/methods/ideal"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/methods-api/get-method"),
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

            var method = await _apiClient.Methods.Get("ideal", new Dictionary<string, string> { { "include", "pricing" } });

            Assert.IsInstanceOfType(method, typeof(Method));
            Assert.AreEqual("ideal", method.Id);
            Assert.AreEqual("iDEAL", method.Description);
            Assert.AreEqual(new Amount("0.01", "EUR"), method.MinimumAmount);
            Assert.AreEqual(new Amount("50000.00", "EUR"), method.MaximumAmount);
            Assert.AreEqual(new Uri("https://www.mollie.com/images/payscreen/methods/ideal.png"), method.Image.Size1x);
            Assert.AreEqual(new Uri("https://www.mollie.com/images/payscreen/methods/ideal%402x.png"), method.Image.Size2x);
            Assert.AreEqual(new Uri("https://www.mollie.com/external/icons/payment-methods/ideal.svg"), method.Image.Svg);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/methods/ideal", "application/hal+json"), method.Links.Self);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/methods-api/get-method", "text/html"), method.Links.Documentation);

            var price = method.Pricing[0];

            Assert.AreEqual("The Netherlands", price.Description);
            Assert.AreEqual(new Amount("0.29", "EUR"), price.Fixed);
            Assert.AreEqual("0", price.Variable);

            var methodPrices = method.Pricing;

            //Assert.IsInstanceOfType(methodPrices, typeof(MethodPriceCollection));
            Assert.IsInstanceOfType(methodPrices, typeof(IList<MethodPrice>));

            var methodPrice = methodPrices[0];
            Assert.IsInstanceOfType(methodPrice, typeof(MethodPrice));
            Assert.AreEqual(new Amount("0.29", "EUR"), methodPrice.Fixed);
            Assert.AreEqual("0", methodPrice.Variable);
        }

        [TestMethod]
        public async Task TestGetTranslatedMethod()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/methods/sofort?locale=de_DE")
            };

            var content = new Method
            {
                Resource = "method",
                Id = "sofort",
                Description = "SOFORT \u00dcberweisung",
                MinimumAmount = new Amount
                {
                    Value = "0.01",
                    Currency = "EUR"
                },
                MaximumAmount = new Amount
                {
                    Value = "50000.00",
                    Currency = "EUR"
                },
                Image = new Image
                {
                    Size1x = new Uri("https://www.mollie.com/images/payscreen/methods/sofort.png"),
                    Size2x = new Uri("https://www.mollie.com/images/payscreen/methods/sofort%402x.png"),
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/methods/sofort"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/methods-api/get-method"),
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

            var method = await _apiClient.Methods.Get("sofort", new Dictionary<string, string> { { "locale", "de_DE" } });

            Assert.IsInstanceOfType(method, typeof(Method));
            Assert.AreEqual("sofort", method.Id);
            Assert.AreEqual("SOFORT Überweisung", method.Description);
            Assert.AreEqual(new Amount("0.01", "EUR"), method.MinimumAmount);
            Assert.AreEqual(new Amount("50000.00", "EUR"), method.MaximumAmount);
            Assert.AreEqual(new Uri("https://www.mollie.com/images/payscreen/methods/sofort.png"), method.Image.Size1x);
            Assert.AreEqual(new Uri("https://www.mollie.com/images/payscreen/methods/sofort%402x.png"), method.Image.Size2x);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/methods/sofort", "application/hal+json"), method.Links.Self);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/methods-api/get-method", "text/html"), method.Links.Documentation);
        }

        [TestMethod]
        public async Task TestListAllActiveMethods()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/methods")
            };

            var content = new MethodCollection
            {
                new Method
                {
                    Resource = "method",
                    Id = "ideal",
                    Description = "iDEAL",
                    MinimumAmount = new Amount
                    {
                        Value = "0.01",
                        Currency = "EUR"
                    },
                    MaximumAmount = new Amount
                    {
                        Value = "50000.00",
                        Currency = "EUR"
                    },
                    Image = new Image
                    {
                        Size1x = new Uri("https://www.mollie.com/images/payscreen/methods/ideal.png"),
                        Size2x = new Uri("https://www.mollie.com/images/payscreen/methods/ideal%402x.png"),
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/methods/ideal"),
                            Type = "application/hal+json"
                        }
                    }
                },
                new Method
                {
                    Resource = "method",
                    Id = "creditcard",
                    Description = "Credit card",
                    MinimumAmount = new Amount
                    {
                        Value = "0.01",
                        Currency = "EUR"
                    },
                    MaximumAmount = new Amount
                    {
                        Value = "2000.00",
                        Currency = "EUR"
                    },
                    Image = new Image
                    {
                        Size1x = new Uri("https://www.mollie.com/images/payscreen/methods/creditcard.png"),
                        Size2x = new Uri("https://www.mollie.com/images/payscreen/methods/creditcard%402x.png"),
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/methods/creditcard"),
                            Type = "application/hal+json"
                        }
                    }
                },
                new Method
                {
                    Resource = "method",
                    Id = "mistercash",
                    Description = "Bancontact",
                    MinimumAmount = new Amount
                    {
                        Value = "0.02",
                        Currency = "EUR"
                    },
                    MaximumAmount = new Amount
                    {
                        Value = "50000.00",
                        Currency = "EUR"
                    },
                    Image = new Image
                    {
                        Size1x = new Uri("https://www.mollie.com/images/payscreen/methods/mistercash.png"),
                        Size2x = new Uri("https://www.mollie.com/images/payscreen/methods/mistercash%402x.png"),
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/methods/mistercash"),
                            Type = "application/hal+json"
                        }
                    }
                },
                new Method
                {
                    Resource = "method",
                    Id = "giftcard",
                    Description = "Gift cards",
                    MinimumAmount = new Amount
                    {
                        Value = "0.01",
                        Currency = "EUR"
                    },
                    MaximumAmount = null,
                    Image = new Image
                    {
                        Size1x = new Uri("https://www.mollie.com/images/payscreen/methods/giftcard.png"),
                        Size2x = new Uri("https://www.mollie.com/images/payscreen/methods/giftcard%402x.png"),
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/methods/giftcard"),
                            Type = "application/hal+json"
                        }
                    }
                }
            };
            content.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/methods-api/list-methods"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/methods"),
                    Type = "application/hal+json"
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(content))
            };

            MockApiCall(request, response);

            var methods = await _apiClient.Methods.AllActive();

            Assert.IsInstanceOfType(methods, typeof(MethodCollection));
            Assert.AreEqual(4, methods.Count);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/methods-api/list-methods", "text/html"), methods.Links.Documentation);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/methods", "application/hal+json"), methods.Links.Self);

            var creditcardMethod = methods[1];

            Assert.IsInstanceOfType(creditcardMethod, typeof(Method));
            Assert.AreEqual("creditcard", creditcardMethod.Id);
            Assert.AreEqual("Credit card", creditcardMethod.Description);
            Assert.AreEqual(new Amount("0.01", "EUR"), creditcardMethod.MinimumAmount);
            Assert.AreEqual(new Amount("2000.00", "EUR"), creditcardMethod.MaximumAmount);
            Assert.AreEqual(new Uri("https://www.mollie.com/images/payscreen/methods/creditcard.png"), creditcardMethod.Image.Size1x);
            Assert.AreEqual(new Uri("https://www.mollie.com/images/payscreen/methods/creditcard%402x.png"), creditcardMethod.Image.Size2x);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/methods/creditcard", "application/hal+json"), creditcardMethod.Links.Self);
        }

        [TestMethod]
        public async Task TestListAllAvailableMethods()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/methods/all?include=pricing")
            };

            var content = new MethodCollection
            {
                new Method
                {
                    Resource = "method",
                    Id = "ideal",
                    Description = "iDEAL",
                    MinimumAmount = new Amount
                    {
                        Value = "0.01",
                        Currency = "EUR"
                    },
                    MaximumAmount = new Amount
                    {
                        Value = "50000.00",
                        Currency = "EUR"
                    },
                    Image = new Image
                    {
                        Size1x = new Uri("https://www.mollie.com/images/payscreen/methods/ideal.png"),
                        Size2x = new Uri("https://www.mollie.com/images/payscreen/methods/ideal%402x.png"),
                    },
                    Pricing = new MethodPriceCollection
                    {
                        new MethodPrice
                        {
                        Description = "The Netherlands",
                        Fixed = new Amount
                        {
                            Value = "0.29",
                            Currency = "EUR"
                        },
                        Variable = "0"
                        }
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/methods/ideal"),
                            Type = "application/hal+json"
                        }
                    }
                },
                new Method
                {
                    Resource = "method",
                    Id = "creditcard",
                    Description = "Credit card",
                    MinimumAmount = new Amount
                    {
                        Value = "0.01",
                        Currency = "EUR"
                    },
                    MaximumAmount = new Amount
                    {
                        Value = "2000.00",
                        Currency = "EUR"
                    },
                    Image = new Image
                    {
                        Size1x = new Uri("https://www.mollie.com/images/payscreen/methods/creditcard.png"),
                        Size2x = new Uri("https://www.mollie.com/images/payscreen/methods/creditcard%402x.png"),
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/methods/creditcard"),
                            Type = "application/hal+json"
                        }
                    }
                },
                new Method
                {
                    Resource = "method",
                    Id = "mistercash",
                    Description = "Bancontact",
                    MinimumAmount = new Amount
                    {
                        Value = "0.02",
                        Currency = "EUR"
                    },
                    MaximumAmount = new Amount
                    {
                        Value = "50000.00",
                        Currency = "EUR"
                    },
                    Image = new Image
                    {
                        Size1x = new Uri("https://www.mollie.com/images/payscreen/methods/mistercash.png"),
                        Size2x = new Uri("https://www.mollie.com/images/payscreen/methods/mistercash%402x.png"),
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/methods/mistercash"),
                            Type = "application/hal+json"
                        }
                    }
                },
                new Method
                {
                    Resource = "method",
                    Id = "giftcard",
                    Description = "Gift cards",
                    MinimumAmount = new Amount
                    {
                        Value = "0.01",
                        Currency = "EUR"
                    },
                    MaximumAmount = null,
                    Image = new Image
                    {
                        Size1x = new Uri("https://www.mollie.com/images/payscreen/methods/giftcard.png"),
                        Size2x = new Uri("https://www.mollie.com/images/payscreen/methods/giftcard%402x.png"),
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/methods/giftcard"),
                            Type = "application/hal+json"
                        }
                    }
                }
            };
            content.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/methods-api/list-methods"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/methods"),
                    Type = "application/hal+json"
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(content))
            };

            MockApiCall(request, response);

            var methods = await _apiClient.Methods.AllAvailable(new Dictionary<string, string> { { "include", "pricing" } });

            Assert.IsInstanceOfType(methods, typeof(MethodCollection));
            Assert.AreEqual(4, methods.Count);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/methods-api/list-methods", "text/html"), methods.Links.Documentation);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/methods", "application/hal+json"), methods.Links.Self);

            var creditcardMethod = methods[1];

            Assert.IsInstanceOfType(creditcardMethod, typeof(Method));
            Assert.AreEqual("creditcard", creditcardMethod.Id);
            Assert.AreEqual("Credit card", creditcardMethod.Description);
            Assert.AreEqual(new Amount("0.01", "EUR"), creditcardMethod.MinimumAmount);
            Assert.AreEqual(new Amount("2000.00", "EUR"), creditcardMethod.MaximumAmount);
            Assert.AreEqual(new Uri("https://www.mollie.com/images/payscreen/methods/creditcard.png"), creditcardMethod.Image.Size1x);
            Assert.AreEqual(new Uri("https://www.mollie.com/images/payscreen/methods/creditcard%402x.png"), creditcardMethod.Image.Size2x);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/methods/creditcard", "application/hal+json"), creditcardMethod.Links.Self);
        }
    }
}
