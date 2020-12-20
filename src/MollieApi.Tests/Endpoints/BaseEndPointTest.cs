using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    public abstract class BaseEndPointTest
    {
        protected const string API_ENDPOINT = "https://api.mollie.com";
        protected Mock<HttpMessageHandler> _httpMessageHandler;
        protected MollieApiClient _apiClient;

        protected void MockApiCall(HttpRequestMessage expectedRequest, HttpResponseMessage response, bool oAuthClient = false)
        {
            _httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _apiClient = new MollieApiClient(new HttpClient(_httpMessageHandler.Object));

            if (!oAuthClient)
                _apiClient.SetApiKey("test_dHar4XY7LxsDOtmnkVtjNVWXLSlXsM");
            else
                _apiClient.SetAccessToken("access_Wwvu7egPcJLLJ9Kb7J632x8wJ2zMeJ");

            _httpMessageHandler
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response)
               .Callback<HttpRequestMessage, CancellationToken>((r, c) => {
                   Assert.AreEqual(expectedRequest.Method, r.Method, "HTTP method must be identical");

                   Assert.AreEqual(expectedRequest.RequestUri, r.RequestUri, "URI path must be identical");

                   Assert.AreEqual(expectedRequest.RequestUri.Query, r.RequestUri.Query, "Query string parameters must be identical");

                   if (r.Content != null && expectedRequest.Content != null)
                   {
                       var requestContent = r.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                       var expectedContent = expectedRequest.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                       Assert.AreEqual(expectedContent, requestContent, "HTTP body must be identical");
                   }
               });
        }

        protected Customer GetCustomer()
        {
            return new Customer
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
        }

        protected Order GetOrder(string id)
        {
            return GetOrderResponseFixture(id);
        }

        protected Order GetOrderResponseFixture(string orderId, string orderStatus = OrderStatus.STATUS_CREATED, string orderNumber = "1337")
        {
            return new Order
            {
                Resource = "order",
                Id = orderId,
                ProfileId = "pfl_URR55HPMGx",
                Amount = new Amount
                {
                    Value = "1027.99",
                    Currency = "EUR"
                },
                AmountCaptured = new Amount
                {
                    Value = "0.00",
                    Currency = "EUR"
                },
                AmountRefunded = new Amount
                {
                    Value = "0.00",
                    Currency = "EUR"
                },
                Status = orderStatus,
                Metadata = new Dictionary<string, string>
                {
                    { "order_id", "1337" },
                    { "description", "Lego cars" },
                },
                ConsumerDateOfBirth = new DateTime(1958, 1, 31),
                CreatedAt = new DateTime(2018, 8, 2, 9, 29, 56),
                ExpiresAt = new DateTime(2018, 9, 2, 9, 29, 56),
                Mode = "live",
                BillingAddress = new OrderAddress
                {
                    OrganizationName = "Organization Name LTD.",
                    StreetAndNumber = "Keizersgracht 313",
                    PostalCode = "1016 EE",
                    City = "Amsterdam",
                    Country = "nl",
                    GivenName = "Luke",
                    FamilyName = "Skywalker",
                    Email = "luke@skywalker.com"
                },
                ShippingAddress = new OrderAddress
                {
                    OrganizationName = "Organization Name LTD.",
                    StreetAndNumber = "Keizersgracht 313",
                    PostalCode = "1016 EE",
                    City = "Amsterdam",
                    Country = "nl",
                    GivenName = "Luke",
                    FamilyName = "Skywalker",
                    Email = "luke@skywalker.com"
                },
                OrderNumber = orderNumber,
                Locale = new CultureInfo("nl_NL"),
                Method = "klarnapaylater",
                IsCancelable = true,
                RedirectUrl = new Uri("https://example.org/redirect"),
                WebhookUrl = new Uri("https://example.org/webhook"),
                Lines = new OrderLineCollection
                {
                    new OrderLine
                    {
                        Resource = "orderline",
                        Id = "odl_dgtxyl",
                        OrderId = orderId,
                        Name = "LEGO 42083 Bugatti Chiron",
                        ProductUrl = new Uri("https://shop.lego.com/nl-NL/Bugatti-Chiron-42083"),
                        ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image//LEGO/42083_alt1?$main$"),
                        SKU = "5702016116977",
                        Type = "physical",
                        Status = "created",
                        IsCancelable = true,
                        Quantity = 2,
                        UnitPrice = new Amount
                        {
                            Value = "399.00",
                            Currency = "EUR"
                        },
                        VatRate = "21.00",
                        VatAmount = new Amount
                        {
                            Value = "121.14",
                            Currency = "EUR"
                        },
                        DiscountAmount = new Amount
                        {
                            Value = "100.00",
                            Currency = "EUR"
                        },
                        TotalAmount = new Amount
                        {
                            Value = "698.00",
                            Currency = "EUR"
                        },
                        CreatedAt = new DateTime(2018,8,2,9,29,56)
                    },
                    new OrderLine
                    {
                        Resource = "orderline",
                        Id = "odl_jp31jz",
                        OrderId = orderId,
                        Name = "LEGO 42056 Porsche 911 GT3 RS",
                        ProductUrl = new Uri("https://shop.lego.com/nl-NL/Porsche-911-GT3-RS-42056"),
                        ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image/LEGO/42056?$PDPDefault$"),
                        SKU = "5702015594028",
                        Type = "digital",
                        Status = "created",
                        IsCancelable = true,
                        Quantity = 1,
                        UnitPrice = new Amount
                        {
                            Value = "329.99",
                            Currency = "EUR"
                        },
                        VatRate = "21.00",
                        VatAmount = new Amount
                        {
                            Value = "57.27",
                            Currency = "EUR"
                        },
                        TotalAmount = new Amount
                        {
                            Value = "329.99",
                            Currency = "EUR"
                        },
                        CreatedAt = new DateTime(2018,8,2,9,29,56)
                    }
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri($"https://api.mollie.com/v2/orders/{orderId}"),
                        Type = "application/hal+json"
                    },
                    Checkout = new Url
                    {
                        Href = new Uri("https://www.mollie.com/payscreen/select-method/7UhSN1zuXS"),
                        Type = "text/html"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/orders-api/get-order"),
                        Type = "text/html"
                    }
                }
            };
        }

        protected Shipment GetShipment(string shipmentId, string orderId, string orderlineStatus = OrderLineStatus.STATUS_SHIPPING)
        {
            return GetShipmentResponseFixture(shipmentId, orderId, orderlineStatus);
        }

        protected Shipment GetShipmentResponseFixture(string shipmentId, string orderId, string orderlineStatus = OrderLineStatus.STATUS_SHIPPING, ShipmentTracking tracking = null)
        {
            return new Shipment
            {
                Resource = "shipment",
                Id = shipmentId,
                OrderId = orderId,
                CreatedAt = new DateTime(2018, 8, 2, 9, 29, 56),
                Tracking = tracking,
                Lines = new OrderLineCollection
                {
                    new OrderLine
                    {
                        Resource = "orderline",
                        Id = "odl_dgtxyl",
                        OrderId = orderId,
                        Name = "LEGO 42083 Bugatti Chiron",
                        ProductUrl = new Uri("https://shop.lego.com/nl-NL/Bugatti-Chiron-42083"),
                        ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image//LEGO/42083_alt1?$main$"),
                        SKU = "5702016116977",
                        Type = "physical",
                        Status = orderlineStatus,
                        Quantity = 2,
                        UnitPrice = new Amount
                        {
                            Value = "399.00",
                            Currency = "EUR"
                        },
                        VatRate = "21.00",
                        VatAmount = new Amount
                        {
                            Value = "121.14",
                            Currency = "EUR"
                        },
                        DiscountAmount = new Amount
                        {
                            Value = "100.00",
                            Currency = "EUR"
                        },
                        TotalAmount = new Amount
                        {
                            Value = "698.00",
                            Currency = "EUR"
                        },
                        CreatedAt = new DateTime(2018,8,2,9,29,56)
                    },
                    new OrderLine
                    {
                        Resource = "orderline",
                        Id = "odl_jp31jz",
                        OrderId = orderId,
                        Name = "LEGO 42056 Porsche 911 GT3 RS",
                        ProductUrl = new Uri("https://shop.lego.com/nl-NL/Porsche-911-GT3-RS-42056"),
                        ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image/LEGO/42056?$PDPDefault$"),
                        SKU = "5702015594028",
                        Type = "digital",
                        Status = orderlineStatus,
                        Quantity = 1,
                        UnitPrice = new Amount
                        {
                            Value = "329.99",
                            Currency = "EUR"
                        },
                        VatRate = "21.00",
                        VatAmount = new Amount
                        {
                            Value = "57.27",
                            Currency = "EUR"
                        },
                        TotalAmount = new Amount
                        {
                            Value = "329.99",
                            Currency = "EUR"
                        },
                        CreatedAt = new DateTime(2018,8,2,9,29,56)
                    }
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri($"https://api.mollie.com/v2/orders/{orderId}/shipments/{shipmentId}"),
                        Type = "application/hal+json"
                    },
                    Order = new Url
                    {
                        Href = new Uri($"https://api.mollie.com/v2/orders/{orderId}"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri($"https://docs.mollie.com/reference/v2/shipments-api/get-shipment"),
                        Type = "text/html"
                    }
                }
            };
        }
    }
}
