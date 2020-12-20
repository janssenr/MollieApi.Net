using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class OrderRefundEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestCreatePartialOrderRefund()
        {
            var requestContent = new Refund
            {
                Lines = new OrderLineCollection
                {
                    new OrderLine
                    {
                        Id = "odl_dgtxyl",
                        Quantity = 1
                    }
                }
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_stTC2WHAuS/refunds"),
                Content = new StringContent(JsonHelper.Serialize(requestContent))
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonHelper.Serialize(GetOrderRefundResponseFixture("re_4qqhO89gsT", "ord_stTC2WHAuS")))
            };

            MockApiCall(request, response);

            var order = GetOrder("ord_stTC2WHAuS");

            var refund = await _apiClient.OrderRefunds.CreateFor(order, new Refund
            {
                Lines = new OrderLineCollection
                {
                    new OrderLine
                    {
                        Id = "odl_dgtxyl",
                        Quantity = 1
                    }
                }
            });

            AssertOrderRefund(refund, "re_4qqhO89gsT");
        }

        [TestMethod]
        public async Task TestCreateCompleteOrderRefund()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_stTC2WHAuS/refunds")
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonHelper.Serialize(GetOrderRefundResponseFixture("re_4qqhO89gsT", "ord_stTC2WHAuS")))
            };

            MockApiCall(request, response);

            var order = GetOrder("ord_stTC2WHAuS");

            var refund = await _apiClient.OrderRefunds.CreateFor(order, new Refund());

            AssertOrderRefund(refund, "re_4qqhO89gsT");
        }

        [TestMethod]
        public async Task TestListOrderRefunds()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_stTC2WHAuS/refunds")
            };

            var responseContent = new RefundCollection {
                new Refund
                {
                    Resource = "refund",
                    Id = "re_4qqhO89gsT",
                    Amount = new Amount
                    {
                        Currency = "EUR",
                        Value = "698.00"
                    },
                    Status = "pending",
                    CreatedAt = new DateTime(2018, 3, 19, 12, 33, 37),
                    Description = "Item not in stock, refunding",
                    PaymentId = "tr_WDqYK6vllg",
                    OrderId = "ord_pbjz8x",
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
                            Status = "refunded",
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
                        }
                    },
                    Links = new Links
                    {
                        Self = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/payments/tr_WDqYK6vllg/refunds/re_4qqhO89gsT"),
                            Type = "application/hal+json"
                        },
                        Payment = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/payments/tr_WDqYK6vllg"),
                            Type = "application/hal+json"
                        },
                        Order = new Url
                        {
                            Href = new Uri("https://api.mollie.com/v2/orders/ord_pbjz8x"),
                            Type = "application/hal+json"
                        },
                        Documentation = new Url
                        {
                            Href = new Uri("https://docs.mollie.com/reference/v2/refunds-api/get-refund"),
                            Type = "text/html"
                        }
                    }
                }
            };
            responseContent.Links = new Links
            {
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/payments/tr_7UhSN1zuXS/refunds?limit=5"),
                    Type = "application/hal+json"
                },
                Previous = null,
                Next = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/payments/tr_7UhSN1zuXS/refunds?from=re_APBiGPH2vV&limit=5"),
                    Type = "application/hal+json"
                },
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/orders-api/list-order-refunds"),
                    Type = "text/html"
                }
            };
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var order = GetOrder("ord_stTC2WHAuS");

            var refunds = await _apiClient.OrderRefunds.ListFor(order);

            Assert.IsInstanceOfType(refunds, typeof(RefundCollection));
            Assert.AreEqual(1, refunds.Count);

            AssertOrderRefund(refunds[0], "re_4qqhO89gsT");
        }

        private void AssertOrderRefund(Refund refund, string refundId, string refundStatus = RefundStatus.STATUS_PENDING)
        {
            Assert.IsInstanceOfType(refund, typeof(Refund));
            Assert.AreEqual(refundId, refund.Id);
            Assert.AreEqual(new Amount("698.00", "EUR"), refund.Amount);
            Assert.AreEqual(refundStatus, refund.Status);
            Assert.AreEqual(new DateTime(2018, 3, 19, 12, 33, 37), refund.CreatedAt);
            Assert.AreEqual("Item not in stock, refunding", refund.Description);
            Assert.AreEqual("tr_WDqYK6vllg", refund.PaymentId);
            Assert.AreEqual(new Url($"https://api.mollie.com/v2/payments/tr_WDqYK6vllg/refunds/{refundId}", "application/hal+json"), refund.Links.Self);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/refunds-api/get-refund", "text/html"), refund.Links.Documentation);
        }

        private Refund GetOrderRefundResponseFixture(string refundId, string orderId)
        {
            return new Refund
            {
                Resource = "refund",
                Id = refundId,
                Amount = new Amount
                {
                    Currency = "EUR",
                    Value = "698.00"
                },
                Status = "pending",
                CreatedAt = new DateTime(2018, 3, 19, 12, 33, 37),
                Description = "Item not in stock, refunding",
                PaymentId = "tr_WDqYK6vllg",
                OrderId = orderId,
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
                        Status = "refunded",
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
                    }
                },
                Links = new Links
                {
                    Self = new Url
                    {
                        Href = new Uri($"https://api.mollie.com/v2/payments/tr_WDqYK6vllg/refunds/{refundId}"),
                        Type = "application/hal+json"
                    },
                    Payment = new Url
                    {
                        Href = new Uri("https://api.mollie.com/v2/payments/tr_WDqYK6vllg"),
                        Type = "application/hal+json"
                    },
                    Order = new Url
                    {
                        Href = new Uri($"https://api.mollie.com/v2/orders/{orderId}"),
                        Type = "application/hal+json"
                    },
                    Documentation = new Url
                    {
                        Href = new Uri("https://docs.mollie.com/reference/v2/refunds-api/get-refund"),
                        Type = "text/html"
                    }
                }
            };
        }
    }
}
