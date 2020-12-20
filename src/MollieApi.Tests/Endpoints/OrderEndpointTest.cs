using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;
using MollieApi.Tests.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class OrderEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestCreateOrder()
        {
            var requestContent = new Order
            {
                Amount = new Amount
                {
                    Value = "1027.99",
                    Currency = "EUR"
                },
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
                Metadata = new Dictionary<string, string>
                {
                    { "order_id", "1337" },
                    { "description", "Lego cars" },
                },
                ConsumerDateOfBirth = new DateTime(1958, 1, 31),
                OrderNumber = "1337",
                Locale = new CultureInfo("nl-NL"),
                Method = "klarnapaylater",
                RedirectUrl = new Uri("https://example.org/redirect"),
                WebhookUrl = new Uri("https://example.org/webhook"),
                Lines = new OrderLineCollection
                {
                    new OrderLine
                    {
                        SKU = "5702016116977",
                        Name = "LEGO 42083 Bugatti Chiron",
                        ProductUrl = new Uri("https://shop.lego.com/nl-NL/Bugatti-Chiron-42083"),
                        ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image//LEGO/42083_alt1?$main$"),
                        Quantity = 2,
                        UnitPrice = new Amount
                        {
                            Currency = "EUR",
                            Value = "399.00"
                        },
                        VatRate = "21.00",
                        VatAmount = new Amount
                        {
                            Currency = "EUR",
                            Value = "121.14"
                        },
                        DiscountAmount = new Amount
                        {
                            Currency = "EUR",
                            Value = "100.00"
                        },
                        TotalAmount = new Amount
                        {
                            Currency = "EUR",
                            Value = "698.00"
                        }
                    },
                    new OrderLine
                    {
                        Type = "digital",
                        SKU = "5702015594028",
                        Name = "LEGO 42056 Porsche 911 GT3 RS",
                        ProductUrl = new Uri("https://shop.lego.com/nl-NL/Porsche-911-GT3-RS-42056"),
                        ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image/LEGO/42056?$PDPDefault$"),
                        Quantity = 1,
                        UnitPrice = new Amount
                        {
                            Currency = "EUR",
                            Value = "329.99"
                        },
                        VatRate = "21.00",
                        VatAmount = new Amount
                        {
                            Currency = "EUR",
                            Value = "57.27"
                        },
                        TotalAmount = new Amount
                        {
                            Currency = "EUR",
                            Value = "329.99"
                        }
                    }
                }
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders"),
                Content = new StringContent(JsonHelper.Serialize(requestContent))
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonHelper.Serialize(GetOrderResponseFixture("ord_pbjz8x")))
            };

            MockApiCall(request, response);

            var order = await _apiClient.Orders.Create(new Order
            {
                Amount = new Amount
                {
                    Value = "1027.99",
                    Currency = "EUR"
                },
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
                Metadata = new Dictionary<string, string>
                {
                    { "order_id", "1337" },
                    { "description", "Lego cars" },
                },
                ConsumerDateOfBirth = new DateTime(1958, 1, 31),
                Locale = new CultureInfo("nl-NL"),
                OrderNumber = "1337",
                RedirectUrl = new Uri("https://example.org/redirect"),
                WebhookUrl = new Uri("https://example.org/webhook"),
                Method = "klarnapaylater",
                Lines = new OrderLineCollection
                {
                    new OrderLine
                    {
                        SKU = "5702016116977",
                        Name = "LEGO 42083 Bugatti Chiron",
                        ProductUrl = new Uri("https://shop.lego.com/nl-NL/Bugatti-Chiron-42083"),
                        ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image//LEGO/42083_alt1?$main$"),
                        Quantity = 2,
                        VatRate = "21.00",
                        UnitPrice = new Amount
                        {
                            Currency = "EUR",
                            Value = "399.00"
                        },
                        TotalAmount = new Amount
                        {
                            Currency = "EUR",
                            Value = "698.00"
                        },
                        DiscountAmount = new Amount
                        {
                            Currency = "EUR",
                            Value = "100.00"
                        },
                        VatAmount = new Amount
                        {
                            Currency = "EUR",
                            Value = "121.14"
                        }
                    },
                    new OrderLine
                    {
                        Type = "digital",
                        SKU = "5702015594028",
                        Name = "LEGO 42056 Porsche 911 GT3 RS",
                        ProductUrl = new Uri("https://shop.lego.com/nl-NL/Porsche-911-GT3-RS-42056"),
                        ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image/LEGO/42056?$PDPDefault$"),
                        Quantity = 1,
                        VatRate = "21.00",
                        UnitPrice = new Amount
                        {
                            Currency = "EUR",
                            Value = "329.99"
                        },
                        TotalAmount = new Amount
                        {
                            Currency = "EUR",
                            Value = "329.99"
                        },
                        VatAmount = new Amount
                        {
                            Currency = "EUR",
                            Value = "57.27"
                        }
                    }
                }
            });

            AssertOrder(order, "ord_pbjz8x");
        }

        [TestMethod]
        public async Task TestGetOrderDirectly()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_pbjz8x"),
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonHelper.Serialize(GetOrderResponseFixture("ord_pbjz8x")))
            };

            MockApiCall(request, response);

            var order = await _apiClient.Orders.Get("ord_pbjz8x");

            AssertOrder(order, "ord_pbjz8x");
        }

        [TestMethod]
        public async Task TestGetOrderDirectlyIncludingPayments()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_kEn1PlbGa?embed=payments"),
            };

            var responseContent = new Order
            {
                Resource = "order",
                Id = "ord_kEn1PlbGa",
                ProfileId = "pfl_URR55HPMGx",
                Method = "klarnapaylater",
                Amount = new Amount
                {
                    Value = "1027.99",
                    Currency = "EUR"
                },
                Status = "created",
                IsCancelable = true,
                Metadata = null,
                CreatedAt = new DateTime(2018, 8, 2, 9, 29, 56),
                ExpiresAt = new DateTime(2018, 8, 30, 9, 29, 56),
                Mode = "live",
                Locale = new CultureInfo("nl-NL"),
                BillingAddress = new OrderAddress
                {
                    OrganizationName = "Mollie B.V.",
                    StreetAndNumber = "Keizersgracht 313",
                    PostalCode = "1016 EE",
                    City = "Amsterdam",
                    Country = "nl",
                    GivenName = "Luke",
                    FamilyName = "Skywalker",
                    Email = "luke@skywalker.com"
                },
                OrderNumber = "18475",
                ShippingAddress = new OrderAddress
                {
                    OrganizationName = "Mollie B.V.",
                    StreetAndNumber = "Keizersgracht 313",
                    PostalCode = "1016 EE",
                    City = "Amsterdam",
                    Country = "nl",
                    GivenName = "Luke",
                    FamilyName = "Skywalker",
                    Email = "luke@skywalker.com"
                },
                RedirectUrl = new Uri("https://example.org/redirect"),
                Lines = new OrderLineCollection
                {
                    new OrderLine
                    {
                        Resource = "orderline",
                        Id = "odl_dgtxyl",
                        OrderId = "ord_pbjz8x",
                        Name = "LEGO 42083 Bugatti Chiron",
                        ProductUrl = new Uri("https://shop.lego.com/nl-NL/Bugatti-Chiron-42083"),
                        ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image//LEGO/42083_alt1?$main$"),
                        SKU = "5702016116977",
                        Type = "physical",
                        Status = "created",
                        Metadata = null,
                        IsCancelable = false,
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
                        CreatedAt = new DateTime(2018,8,2,9,29,56),
                    },
                    new OrderLine
                    {
                        Resource = "orderline",
                        Id = "odl_jp31jz",
                        OrderId = "ord_pbjz8x",
                        Name = "LEGO 42056 Porsche 911 GT3 RS",
                        ProductUrl = new Uri("https://shop.lego.com/nl-NL/Porsche-911-GT3-RS-42056"),
                        ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image/LEGO/42056?$PDPDefault$"),
                        SKU = "5702015594028",
                        Type = "physical",
                        Status = "created",
                        Metadata = null,
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
                Payments = new PaymentCollection
                {
                    new Payment
                    {
                        Resource = "payment",
                        Id = "tr_ncaPcAhuUV",
                        Mode = "live",
                        CreatedAt = new DateTime(2018,9,7,12,0,5),
                        Amount = new Amount
                        {
                            Value = "1027.99",
                            Currency = "EUR"
                        },
                        Description = "Order #1337 (Lego cars)",
                        Method = null,
                        Metadata = null,
                        Status = "open",
                        IsCancelable = false,
                        Locale = new CultureInfo("nl-NL"),
                        ProfileId = "pfl_URR55HPMGx",
                        OrderId = "ord_kEn1PlbGa",
                        SequenceType = "oneoff",
                        RedirectUrl = new Uri("https://example.org/redirect"),
                        Links = new Links
                        {
                            Self = new Url
                            {
                                Href = new Uri("https://api.mollie.com/v2/payments/tr_ncaPcAhuUV"),
                                Type = "application/hal+json"
                            },
                            Checkout = new Url
                            {
                                Href = new Uri("https://www.mollie.com/payscreen/select-method/ncaPcAhuUV"),
                                Type = "text/html"
                            },
                            Order = new Url
                            {
                                Href = new Uri("https://api.mollie.com/v2/orders/ord_kEn1PlbGa"),
                                Type = "application/hal+json"
                            }
                        }
                    }
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/orders/ord_pbjz8x"),
                        Type = "application/hal+json"
                    },
                    Checkout = new Url
                    {
                        Href = new Uri("https://www.mollie.com/payscreen/order/checkout/pbjz8x"),
                        Type = "text/html"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/orders-api/get-order"),
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

            var order = await _apiClient.Orders.Get("ord_kEn1PlbGa", new Dictionary<string, string> { { "embed", "payments" } });

            Assert.IsInstanceOfType(order, typeof(Order));
            Assert.AreEqual("ord_kEn1PlbGa", order.Id);

            var payments = order.Payments;
            Assert.IsInstanceOfType(payments, typeof(PaymentCollection));

            var payment = payments[0];
            Assert.IsInstanceOfType(payment, typeof(Payment));
            Assert.AreEqual("tr_ncaPcAhuUV", payment.Id);
            Assert.AreEqual(new DateTime(2018, 9, 7, 12, 0, 5), payment.CreatedAt);
            Assert.AreEqual(new Amount("1027.99", "EUR"), payment.Amount);
            Assert.AreEqual("Order #1337 (Lego cars)", payment.Description);
            Assert.IsNull(payment.Method);
            Assert.IsNull(payment.Metadata);
            Assert.AreEqual("open", payment.Status);
            Assert.IsFalse(payment.IsCancelable);
            Assert.AreEqual(new CultureInfo("nl-NL"), payment.Locale);
            Assert.AreEqual("pfl_URR55HPMGx", payment.ProfileId);
            Assert.AreEqual("ord_kEn1PlbGa", payment.OrderId);
            Assert.AreEqual(new Uri("https://example.org/redirect"), payment.RedirectUrl);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/payments/tr_ncaPcAhuUV", "application/hal+json"), payment.Links.Self);
            Assert.AreEqual(new Url("https://www.mollie.com/payscreen/select-method/ncaPcAhuUV", "text/html"), payment.Links.Checkout);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/orders/ord_kEn1PlbGa", "application/hal+json"), payment.Links.Order);
        }

        [TestMethod]
        public async Task TestListOrders()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders"),
            };

            var responseContent = new OrderCollection
            {
                GetOrderResponseFixture("ord_pbjz1x"),
                GetOrderResponseFixture("ord_pbjz2y"),
                GetOrderResponseFixture("ord_pbjz3z")
            };
            responseContent.Links = new Links
            {
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/orders"),
                    Type = "application/hal+json"
                },
                Previous = null,
                Next = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/orders?from=ord_stTC2WHAuS"),
                    Type = "application/hal+json"
                },
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/orders-api/list-orders"),
                    Type = "text/html"
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var orders = await _apiClient.Orders.Page();

            Assert.IsInstanceOfType(orders, typeof(OrderCollection));
            Assert.AreEqual(3, orders.Count);
            Assert.IsNull(orders.Links.Previous);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/orders", "application/hal+json"), orders.Links.Self);
            Assert.AreEqual(new Url("https://api.mollie.com/v2/orders?from=ord_stTC2WHAuS", "application/hal+json"), orders.Links.Next);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/orders-api/list-orders", "text/html"), orders.Links.Documentation);
            Assert.AreEqual("ord_pbjz1x", orders[0].Id);
            Assert.AreEqual("ord_pbjz2y", orders[1].Id);
            Assert.AreEqual("ord_pbjz3z", orders[2].Id);
        }

        [TestMethod]
        public async Task TestCancelOrderDirectly()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_pbjz1x"),
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(GetOrderResponseFixture("ord_pbjz1x", OrderStatus.STATUS_CANCELED)))
            };

            MockApiCall(request, response);

            var order = await _apiClient.Orders.Cancel("ord_pbjz1x");
            AssertOrder(order, "ord_pbjz1x", OrderStatus.STATUS_CANCELED);
        }

        [TestMethod]
        public async Task TestCancelOrderLines()
        {
            var requestContent = new OrderLineCollection
            {
                new OrderLine
                {
                    Id = "odl_dgtxyl",
                    Quantity = 1
                }
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_8wmqcHMN4U/lines"),
                Content = new StringContent(JsonHelper.Serialize(requestContent))
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent,
                Content = new StringContent("")
            };

            MockApiCall(request, response);

            var order = GetOrder("ord_8wmqcHMN4U");
            var result = await _apiClient.OrderLines.CancelFor(order, new OrderLineCollection
            {
                new OrderLine
                {
                    Id = "odl_dgtxyl",
                    Quantity = 1
                }
            });

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task TestCancelAllOrderLines()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_8wmqcHMN4U/lines"),
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.NoContent,
                Content = new StringContent("")
            };

            MockApiCall(request, response);

            var order = GetOrder("ord_8wmqcHMN4U");
            var result = await _apiClient.OrderLines.CancelFor(order, null);

            Assert.IsNull(result);
        }

        [TestMethod]
        public async Task TestUpdateOrder()
        {
            var requestContent = new Order
            {
                BillingAddress = new OrderAddress
                {
                    OrganizationName = "Organization Name LTD.",
                    StreetAndNumber = "Keizersgracht 313",
                    PostalCode = "1234AB",
                    City = "Amsterdam",
                    Country = "NL",
                    GivenName = "Piet",
                    FamilyName = "Mondriaan",
                    Email = "piet@mondriaan.com",
                    Region = "Noord-Holland",
                    Title = "Dhr",
                    Phone = "+31208202070"
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
                OrderNumber = "16738",
                RedirectUrl = new Uri("https://example.org/updated-redirect"),
                WebhookUrl = new Uri("https://example.org/updated-webhook")
            };
            var request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_pbjz8x"),
                //Content = new StringContent(JsonHelper.Serialize(requestContent))
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonHelper.Serialize(GetOrderResponseFixture("ord_pbjz8x", OrderStatus.STATUS_CREATED, "16738")))
            };

            MockApiCall(request, response);

            var order = GetOrder("ord_pbjz8x");

            order.BillingAddress.OrganizationName = "Organization Name LTD.";
            order.BillingAddress.StreetAndNumber = "Keizersgracht 313";
            order.BillingAddress.City = "Amsterdam";
            order.BillingAddress.Region = "Noord-Holland";
            order.BillingAddress.PostalCode = "1234AB";
            order.BillingAddress.Country = "NL";
            order.BillingAddress.Title = "Dhr";
            order.BillingAddress.GivenName = "Piet";
            order.BillingAddress.FamilyName = "Mondriaan";
            order.BillingAddress.Email = "piet@mondriaan.com";
            order.BillingAddress.Phone = "+31208202070";
            order.OrderNumber = "16738";
            order.RedirectUrl = new Uri("https://example.org/updated-redirect");
            order.WebhookUrl = new Uri("https://example.org/updated-webhook");

            order = await _apiClient.Orders.Update(order);

            AssertOrder(order, "ord_pbjz8x", OrderStatus.STATUS_CREATED, "16738");
        }

        [TestMethod]
        public async Task TestUpdateOrderLine()
        {
            var requestContent = new OrderLine
            {
                Name = "LEGO 71043 Hogwarts™ Castle",
                ProductUrl = new Uri("https://shop.lego.com/en-GB/product/Hogwarts-Castle-71043"),
                ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image//LEGO/71043_alt1?$main$"),
                Quantity = 2,
                VatRate = "21.00",
                UnitPrice = new Amount
                {
                    Currency = "EUR",
                    Value = "349.00"
                },
                TotalAmount = new Amount
                {
                    Currency = "EUR",
                    Value = "598.00"
                },
                DiscountAmount = new Amount
                {
                    Currency = "EUR",
                    Value = "100.00"
                },
                VatAmount = new Amount
                {
                    Currency = "EUR",
                    Value = "103.79"
                },
                Metadata = new Dictionary<string, string>
                {
                    { "foo", "bar" }
                }
            };
            var request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_pbjz8x/lines/odl_dgtxyl"),
                //Content = new StringContent(JsonHelper.Serialize(requestContent))
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonHelper.Serialize(GetOrderResponseFixture("ord_pbjz8x")))
            };

            MockApiCall(request, response);

            var orderLine = new OrderLine
            {
                Id = "odl_dgtxyl",
                OrderId = "ord_pbjz8x",
                Name = "LEGO 71043 Hogwarts™ Castle",
                ProductUrl = new Uri("https://shop.lego.com/en-GB/product/Hogwarts-Castle-71043"),
                ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image//LEGO/71043_alt1?$main$"),
                Quantity = 2,
                VatRate = "21.00",
                UnitPrice = new Amount("349.00", "EUR"),
                TotalAmount = new Amount("598.00", "EUR"),
                DiscountAmount = new Amount("100.00", "EUR"),
                VatAmount = new Amount("103.79", "EUR"),
                Metadata = new Dictionary<string, string> { { "foo", "bar" } }
            };

            var result = await _apiClient.OrderLines.Update(orderLine);

            //AssertOrder(result, "ord_pbjz8x");
        }

        private void AssertOrder(Order order, string orderId, string orderStatus = OrderStatus.STATUS_CREATED, string orderNumber = "1337")
        {
            Assert.IsInstanceOfType(order, typeof(Order));
            Assert.AreEqual("order", order.Resource);
            Assert.AreEqual(orderId, order.Id);
            Assert.AreEqual("pfl_URR55HPMGx", order.ProfileId);
            Assert.AreEqual("live", order.Mode);
            Assert.AreEqual("klarnapaylater", order.Method);
            Assert.AreEqual(new DateTime(2018, 8, 2, 9, 29, 56), order.CreatedAt);
            Assert.AreEqual(new DateTime(2018, 9, 2, 9, 29, 56), order.ExpiresAt);

            Assert.AreEqual(new Amount("1027.99", "EUR"), order.Amount);
            Assert.AreEqual(new Amount("0.00", "EUR"), order.AmountCaptured);
            Assert.AreEqual(new Amount("0.00", "EUR"), order.AmountRefunded);

            Assert.IsTrue(order.Metadata.ContentEquals(new Dictionary<string, string> { { "order_id", "1337" }, { "description", "Lego cars" } }));

            Assert.AreEqual(orderStatus, order.Status);

            var billingAddress = new OrderAddress
            {
                OrganizationName = "Organization Name LTD.",
                StreetAndNumber = "Keizersgracht 313",
                PostalCode = "1016 EE",
                City = "Amsterdam",
                Country = "nl",
                GivenName = "Luke",
                FamilyName = "Skywalker",
                Email = "luke@skywalker.com"
            };
            Assert.AreEqual(billingAddress, order.BillingAddress);

            var shippingAddress = new OrderAddress
            {
                OrganizationName = "Organization Name LTD.",
                StreetAndNumber = "Keizersgracht 313",
                PostalCode = "1016 EE",
                City = "Amsterdam",
                Country = "nl",
                GivenName = "Luke",
                FamilyName = "Skywalker",
                Email = "luke@skywalker.com"
            };
            Assert.AreEqual(shippingAddress, order.ShippingAddress);

            Assert.AreEqual(orderNumber, order.OrderNumber);
            Assert.AreEqual(new CultureInfo("nl-NL"), order.Locale);

            Assert.AreEqual(new Uri("https://example.org/redirect"), order.RedirectUrl);
            Assert.AreEqual(new Uri("https://example.org/webhook"), order.WebhookUrl);

            var links = new Links
            {
                Self = new Url
                {
                    Href = new Uri($"https://api.mollie.com/v2/orders/{orderId}"),
                    Type = "application/hal+json"
                },
                Checkout = new Url
                {
                    Href = new Uri($"https://www.mollie.com/payscreen/select-method/7UhSN1zuXS"),
                    Type = "text/html"
                },
                Documentation = new Url
                {
                    Href = new Uri($"https://docs.mollie.com/reference/v2/orders-api/get-order"),
                    Type = "text/html"
                }
            };
            Assert.AreEqual(links, order.Links);

            var line1 = new OrderLine
            {
                Resource = "orderline",
                Id = "odl_dgtxyl",
                OrderId = orderId,
                Name = "LEGO 42083 Bugatti Chiron",
                ProductUrl = new Uri("https://shop.lego.com/nl-NL/Bugatti-Chiron-42083"),
                ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image//LEGO/42083_alt1?$main$"),
                SKU = "5702016116977",
                Type = OrderLineType.TYPE_PHYSICAL,
                Status = OrderLineStatus.STATUS_CREATED,
                IsCancelable = true,
                Quantity = 2,
                UnitPrice = new Amount { Value = "399.00", Currency = "EUR" },
                VatRate = "21.00",
                VatAmount = new Amount { Value = "121.14", Currency = "EUR" },
                DiscountAmount = new Amount { Value = "100.00", Currency = "EUR" },
                TotalAmount = new Amount { Value = "698.00", Currency = "EUR" },
                CreatedAt = new DateTime(2018, 8, 2, 9, 29, 56)
            };
            Assert.AreEqual(line1, order.Lines[0]);

            var line2 = new OrderLine
            {
                Resource = "orderline",
                Id = "odl_jp31jz",
                OrderId = orderId,
                Name = "LEGO 42056 Porsche 911 GT3 RS",
                ProductUrl = new Uri("https://shop.lego.com/nl-NL/Porsche-911-GT3-RS-42056"),
                ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image/LEGO/42056?$PDPDefault$"),
                SKU = "5702015594028",
                Type = OrderLineType.TYPE_DIGITAL,
                Status = OrderLineStatus.STATUS_CREATED,
                IsCancelable = true,
                Quantity = 1,
                UnitPrice = new Amount { Value = "329.99", Currency = "EUR" },
                VatRate = "21.00",
                VatAmount = new Amount { Value = "57.27", Currency = "EUR" },
                TotalAmount = new Amount { Value = "329.99", Currency = "EUR" },
                CreatedAt = new DateTime(2018, 8, 2, 9, 29, 56)
            };
            Assert.AreEqual(line2, order.Lines[1]);
        }
    }
}
