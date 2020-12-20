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
    public class CustomerEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestCreateWorks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers")
            };

            var content = new Customer
            {
                Resource = "customer",
                Id = "cst_FhQJRw4s2n",
                Mode = "test",
                Name = "John Doe",
                Email = "johndoe@example.org",
                Locale = null,
                Metadata = null,
                //RecentlyUsedMethods 
                CreatedAt = new DateTime(2018,4,19,8,49,1),
                Links = new Links
                {
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/customers-api/create-customer"),
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

            var customer = await _apiClient.Customers.Create(new Customer
            {
                Name = "John Doe",
                Email = "johndoe@example.org"
            });

            Assert.IsInstanceOfType(customer, typeof(Customer));
            Assert.AreEqual("customer", customer.Resource);
            Assert.AreEqual("cst_FhQJRw4s2n", customer.Id);
            Assert.AreEqual("John Doe", customer.Name);
            Assert.AreEqual("johndoe@example.org", customer.Email);
            Assert.IsNull(customer.Locale);
            Assert.IsNull(customer.Metadata);
            Assert.AreEqual(new DateTime(2018, 4, 19, 8, 49, 1), customer.CreatedAt);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/customers-api/create-customer", "text/html"), customer.Links.Documentation);
        }

        [TestMethod]
        public async Task TestGetWorks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n")
            };

            var content = new Customer
            {
                Resource = "customer",
                Id = "cst_FhQJRw4s2n",
                Mode = "test",
                Name = "John Doe",
                Email = "johndoe@example.org",
                Locale = null,
                Metadata = null,
                //RecentlyUsedMethods 
                CreatedAt = new DateTime(2018, 4, 19, 8, 49, 1),
                Links = new Links
                {
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/customers-api/get-customer"),
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

            var customer = await _apiClient.Customers.Get("cst_FhQJRw4s2n");

            Assert.IsInstanceOfType(customer, typeof(Customer));
            Assert.AreEqual("customer", customer.Resource);
            Assert.AreEqual("cst_FhQJRw4s2n", customer.Id);
            Assert.AreEqual("John Doe", customer.Name);
            Assert.AreEqual("johndoe@example.org", customer.Email);
            Assert.IsNull(customer.Locale);
            Assert.IsNull(customer.Metadata);
            Assert.AreEqual(new DateTime(2018, 4, 19, 8, 49, 1), customer.CreatedAt);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/customers-api/get-customer", "text/html"), customer.Links.Documentation);
        }

        [TestMethod]
        public async Task TestListWorks()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers")
            };

            var content = new CustomerCollection {
                new Customer
                {
                    Resource = "customer",
                    Id = "cst_FhQJRw4s2n",
                    Mode = "test",
                    Name = "John Doe",
                    Email = "johndoe@example.org",
                    Locale = null,
                    Metadata = null,
                    //RecentlyUsedMethods 
                    CreatedAt = new DateTime(2018, 4, 19, 8, 49, 1),
                    Links = new Links
                    {
                        Documentation = new Url
                        {
                            Href = new Uri("https://docs.mollie.com/reference/v2/customers-api/create-customer"),
                            Type = "text/html"
                        }
                    }
                }
            };
            content.Links = new Links
            {
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/customers-api/list-customers"),
                    Type = "text/html",
                },
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/customers?limit=50"),
                    Type = "application/hal+json",
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

            var customers = await _apiClient.Customers.Page();

            Assert.IsInstanceOfType(customers, typeof(CustomerCollection));
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/customers-api/list-customers", "text/html"), customers.Links.Documentation);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/customers?limit=50", "application/hal+json"), customers.Links.Self);

            foreach (var customer in customers)
            {
                Assert.IsInstanceOfType(customer, typeof(Customer));
                Assert.AreEqual("customer", customer.Resource);
                Assert.IsNotNull(customer.CreatedAt);
            }
        }

        [TestMethod]
        public async Task TestUpdateWorks()
        {
            var expectedName = "Kaas Broodje";
            var expectedEmail = "kaas.broodje@gmail.com";

            var request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(API_ENDPOINT + "/v2/customers/cst_FhQJRw4s2n")
            };

            var content = new Customer
            {
                Resource = "customer",
                Id = "cst_FhQJRw4s2n",
                Mode = "test",
                Name = expectedName,
                Email = expectedEmail,
                Locale = null,
                Metadata = null,
                //RecentlyUsedMethods 
                CreatedAt = new DateTime(2018, 4, 19, 8, 49, 1),
                Links = new Links
                {
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/customers-api/get-customer"),
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
            customer.Name = expectedName;
            customer.Email = expectedEmail;

            var updatedCustomer = await _apiClient.Customers.Update(customer);

            Assert.AreEqual(expectedName, updatedCustomer.Name);
            Assert.AreEqual(expectedEmail, updatedCustomer.Email);
        }
    }
}
