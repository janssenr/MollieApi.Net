using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;
using MollieApi.Tests.Extensions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class CustomerMandateEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestCreateWorks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/mandates")
            };

            var content = new Mandate
            {
                Resource = "mandate",
                Id = "mdt_AcQl5fdL4h",
                Status = "valid",
                Method = "directdebit",
                Details = new Dictionary<string, string>
                {
                    { "consumerName", "John Doe" },
                    { "consumerAccount", "NL55INGB0000000000" },
                    { "consumerBic", "INGBNL2A" },
                },
                MandateReference = null,
                SignatureDate = new DateTime(2018, 5, 7),
                CreatedAt = new DateTime(2018, 5, 7, 10, 49, 8),
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/mandates/mdt_AcQl5fdL4h"),
                        Type = "application/hal+json"
                    },
                    Customer = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://mollie.com/en/docs/reference/customers/create-mandate"),
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

            var customer = GetCustomer();

            var mandate = await _apiClient.CustomerMandates.CreateFor(customer, new Mandate
            {
                Method = "directdebit",
                Details = new Dictionary<string, string>
                {
                    { "consumerName", "John Doe" },
                    { "consumerAccount", "NL55INGB0000000000" },
                    { "consumerBic", "INGBNL2A" },
                }
            });

            Assert.IsInstanceOfType(mandate, typeof(Mandate));
            Assert.AreEqual("mandate", mandate.Resource);
            Assert.AreEqual(MandateStatus.STATUS_VALID, mandate.Status);
            Assert.AreEqual(MandateMethod.DIRECTDEBIT, mandate.Method);
            //Assert.AreEqual(new Dictionary<string, string> { { "consumerName", "John Doe" }, { "consumerAccount", "NL55INGB0000000000" }, { "consumerBic", "INGBNL2A" } }, mandate.Details);
            Assert.IsTrue(mandate.Details.ContentEquals(new Dictionary<string, string> { { "consumerName", "John Doe" }, { "consumerAccount", "NL55INGB0000000000" }, { "consumerBic", "INGBNL2A" } }));
            Assert.IsNull(mandate.MandateReference);
            Assert.AreEqual(new DateTime(2018, 5, 7), mandate.SignatureDate);
            Assert.AreEqual(new DateTime(2018, 5, 7, 10, 49, 8), mandate.CreatedAt);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/mandates/mdt_AcQl5fdL4h", "application/hal+json"), mandate.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n", "application/hal+json"), mandate.Links.Customer);
            Assert.AreEqual(new Url("https://mollie.com/en/docs/reference/customers/create-mandate", "text/html"), mandate.Links.Documentation);
        }

        [TestMethod]
        public async Task TestGetWorks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/mandates/mdt_AcQl5fdL4h")
            };

            var content = new Mandate
            {
                Resource = "mandate",
                Id = "mdt_AcQl5fdL4h",
                Status = "valid",
                Method = "directdebit",
                Details = new Dictionary<string, string>
                {
                    { "consumerName", "John Doe" },
                    { "consumerAccount", "NL55INGB0000000000" },
                    { "consumerBic", "INGBNL2A" },
                },
                MandateReference = null,
                SignatureDate = new DateTime(2018, 5, 7),
                CreatedAt = new DateTime(2018, 5, 7, 10, 49, 8),
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/mandates/mdt_AcQl5fdL4h"),
                        Type = "application/hal+json"
                    },
                    Customer = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://mollie.com/en/docs/reference/customers/get-mandate"),
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

            var customer = GetCustomer();

            var mandate = await _apiClient.CustomerMandates.GetFor(customer, "mdt_AcQl5fdL4h");

            Assert.IsInstanceOfType(mandate, typeof(Mandate));
            Assert.AreEqual("mandate", mandate.Resource);
            Assert.AreEqual(MandateStatus.STATUS_VALID, mandate.Status);
            Assert.AreEqual(MandateMethod.DIRECTDEBIT, mandate.Method);
            //Assert.AreEqual(new Dictionary<string, string> { { "consumerName", "John Doe" }, { "consumerAccount", "NL55INGB0000000000" }, { "consumerBic", "INGBNL2A" } }, mandate.Details);
            Assert.IsTrue(mandate.Details.ContentEquals(new Dictionary<string, string> { { "consumerName", "John Doe" }, { "consumerAccount", "NL55INGB0000000000" }, { "consumerBic", "INGBNL2A" } }));
            Assert.IsNull(mandate.MandateReference);
            Assert.AreEqual(new DateTime(2018, 5, 7), mandate.SignatureDate);
            Assert.AreEqual(new DateTime(2018, 5, 7, 10, 49, 8), mandate.CreatedAt);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/mandates/mdt_AcQl5fdL4h", "application/hal+json"), mandate.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n", "application/hal+json"), mandate.Links.Customer);
            Assert.AreEqual(new Url("https://mollie.com/en/docs/reference/customers/get-mandate", "text/html"), mandate.Links.Documentation);
        }

        [TestMethod]
        public async Task TestListWorks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/mandates")
            };

            var content = new MandateCollection
            {
                new Mandate
                {
                    Resource = "mandate",
                    Id = "mdt_AcQl5fdL4h",
                    Status = "valid",
                    Method = "directdebit",
                    Details = new Dictionary<string, string>
                    {
                        { "consumerName", "John Doe" },
                        { "consumerAccount", "NL55INGB0000000000" },
                        { "consumerBic", "INGBNL2A" },
                    },
                    MandateReference = null,
                    SignatureDate = new DateTime(2018, 5, 7),
                    CreatedAt = new DateTime(2018, 5, 7, 10, 49, 8),
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/mandates/mdt_AcQl5fdL4h"),
                            Type = "application/hal+json"
                        },
                        Customer = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n"),
                            Type = "application/hal+json"
                        },
                    }
                }
            };
            content.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://mollie.com/en/docs/reference/customers/list-mandates"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/customers/cst_vzEExMcxj7/mandates?limit=50"),
                    Type = "application/hal+json"
                },
                Previous = null,
                Next = null
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(content))
            };

            MockApiCall(request, response);

            var customer = GetCustomer();

            var mandates = await _apiClient.CustomerMandates.ListFor(customer);

            Assert.IsInstanceOfType(mandates, typeof(MandateCollection));

            foreach (var mandate in mandates)
            {
                Assert.IsInstanceOfType(mandate, typeof(Mandate));
                Assert.AreEqual("mandate", mandate.Resource);
                Assert.AreEqual(MandateStatus.STATUS_VALID, mandate.Status);
                Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n", "application/hal+json"), mandate.Links.Customer);
            }
            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers/cst_vzEExMcxj7/mandates?limit=50", "application/hal+json"), mandates.Links.Self);
            Assert.AreEqual(new Url("https://mollie.com/en/docs/reference/customers/list-mandates", "text/html"), mandates.Links.Documentation);
        }

        [TestMethod]
        public async Task TestCustomerHasValidMandateWhenTrue()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/mandates")
            };

            var content = new MandateCollection
            {
                new Mandate
                {
                    Resource = "mandate",
                    Id = "mdt_AcQl5fdL4h",
                    Status = "valid",
                    Method = "directdebit",
                    Details = new Dictionary<string, string>
                    {
                        { "consumerName", "John Doe" },
                        { "consumerAccount", "NL55INGB0000000000" },
                        { "consumerBic", "INGBNL2A" },
                    },
                    MandateReference = null,
                    SignatureDate = new DateTime(2018, 5, 7),
                    CreatedAt = new DateTime(2018, 5, 7, 10, 49, 8),
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/mandates/mdt_AcQl5fdL4h"),
                            Type = "application/hal+json"
                        },
                        Customer = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n"),
                            Type = "application/hal+json"
                        },
                    }
                }
            };
            content.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://mollie.com/en/docs/reference/customers/list-mandates"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/customers/cst_vzEExMcxj7/mandates?limit=50"),
                    Type = "application/hal+json"
                },
                Previous = null,
                Next = null
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(content))
            };

            MockApiCall(request, response);

            var customer = GetCustomer();

            var mandates = await _apiClient.CustomerMandates.ListFor(customer);

            Assert.IsTrue(mandates.HasValidMandate());
        }

        [TestMethod]
        public async Task TestCustomerHasValidMandateWhenFalse()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/mandates")
            };

            var content = new MandateCollection
            {
                Links = new Links
                {
                    Documentation = new Url
                    {
                        Href = new Uri("https://mollie.com/en/docs/reference/customers/list-mandates"),
                        Type = "text/html"
                    },
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/customers/cst_vzEExMcxj7/mandates?limit=50"),
                        Type = "application/hal+json"
                    },
                    Previous = null,
                    Next = null
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(content))
            };

            MockApiCall(request, response);

            var customer = GetCustomer();

            var mandates = await _apiClient.CustomerMandates.ListFor(customer);

            Assert.IsFalse(mandates.HasValidMandate());
        }

        [TestMethod]
        public async Task TestCustomerHasValidMandateForMethodWhenFalse()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/mandates")
            };

            var content = new MandateCollection
            {
                Links = new Links
                {
                    Documentation = new Url
                    {
                        Href = new Uri("https://mollie.com/en/docs/reference/customers/list-mandates"),
                        Type = "text/html"
                    },
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/customers/cst_vzEExMcxj7/mandates?limit=50"),
                        Type = "application/hal+json"
                    },
                    Previous = null,
                    Next = null
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(content))
            };

            MockApiCall(request, response);

            var customer = GetCustomer();

            var mandates = await _apiClient.CustomerMandates.ListFor(customer);

            Assert.IsFalse(mandates.HasValidMandateForMethod("directdebit"));
        }

        [TestMethod]
        public async Task TestCustomerHasValidMandateForMethodWhenTrue()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n/mandates")
            };

            var content = new MandateCollection
            {
                new Mandate
                {
                    Resource = "mandate",
                    Id = "mdt_AcQl5fdL4h",
                    Status = "valid",
                    Method = "directdebit",
                    Details = new Dictionary<string, string>
                    {
                        { "consumerName", "John Doe" },
                        { "consumerAccount", "NL55INGB0000000000" },
                        { "consumerBic", "INGBNL2A" },
                    },
                    MandateReference = null,
                    SignatureDate = new DateTime(2018, 5, 7),
                    CreatedAt = new DateTime(2018, 5, 7, 10, 49, 8),
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n/mandates/mdt_AcQl5fdL4h"),
                            Type = "application/hal+json"
                        },
                        Customer = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/customers/cst_FhQJRw4s2n"),
                            Type = "application/hal+json"
                        },
                    }
                }
            };
            content.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://mollie.com/en/docs/reference/customers/list-mandates"),
                    Type = "text/html"
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/customers/cst_vzEExMcxj7/mandates?limit=50"),
                    Type = "application/hal+json"
                },
                Previous = null,
                Next = null
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(content))
            };

            MockApiCall(request, response);

            var customer = GetCustomer();

            var mandates = await _apiClient.CustomerMandates.ListFor(customer);

            Assert.IsTrue(mandates.HasValidMandateForMethod("directdebit"));
        }
    }
}
