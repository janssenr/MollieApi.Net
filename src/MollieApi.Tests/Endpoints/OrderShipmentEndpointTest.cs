using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MollieApi.Tests.Endpoints
{
    [TestClass]
    public class OrderShipmentEndpointTest : BaseEndPointTest
    {
        [TestMethod]
        public async Task TestCreateShipment()
        {
            var requestContent = new Shipment
            {
                Lines = new OrderLineCollection()
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_pbjz8x/shipments"),
                Content = new StringContent(JsonHelper.Serialize(requestContent))
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonHelper.Serialize(GetShipmentResponseFixture("shp_3wmsgCJN4U", "ord_pbjz8x")))
            };

            MockApiCall(request, response);

            var order = GetOrder("ord_pbjz8x");
            var shipment = await _apiClient.OrderShipments.CreateFor(order, new Shipment
            {
                Lines = new OrderLineCollection()
            });

            AssertShipment(shipment, "shp_3wmsgCJN4U", "ord_pbjz8x");
        }

        [TestMethod]
        public async Task TestCreateShipmentUsingShorthand()
        {
            var requestContent = new Shipment
            {
                Lines = new OrderLineCollection
                {
                    new OrderLine
                    {
                        Id = "odl_dgtxyl",
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        Id = "odl_jp31jz"
                    }
                }
            };
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_pbjz8x/shipments"),
                Content = new StringContent(JsonHelper.Serialize(requestContent))
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Created,
                Content = new StringContent(JsonHelper.Serialize(GetShipmentResponseFixture("shp_3wmsgCJN4U", "ord_pbjz8x")))
            };

            MockApiCall(request, response);

            var order = GetOrder("ord_pbjz8x");
            var shipment = await _apiClient.OrderShipments.CreateFor(order, new Shipment
            {
                Lines = new OrderLineCollection
                {
                    new OrderLine
                    {
                        Id = "odl_dgtxyl",
                        Quantity = 1
                    },
                    new OrderLine
                    {
                        Id = "odl_jp31jz"
                    }
                }
            });

            AssertShipment(shipment, "shp_3wmsgCJN4U", "ord_pbjz8x");
        }

        [TestMethod]
        public async Task TestGetShipment()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_pbjz8x/shipments/shp_3wmsgCJN4U"),
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(GetShipmentResponseFixture("shp_3wmsgCJN4U", "ord_pbjz8x")))
            };

            MockApiCall(request, response);

            var order = GetOrder("ord_pbjz8x");
            var shipment = await _apiClient.OrderShipments.GetFor(order, "shp_3wmsgCJN4U");

            AssertShipment(shipment, "shp_3wmsgCJN4U", "ord_pbjz8x");
        }

        [TestMethod]
        public async Task TestListShipments()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_pbjz8x/shipments"),
            };

            var responseContent = new ShipmentCollection
            {
                GetShipmentResponseFixture("shp_3wmsgCJN4U", "ord_pbjz8x"),
                GetShipmentResponseFixture("shp_kjh234CASX", "ord_pbjz8x")
            };
            responseContent.Links = new Links
            {
                Self = new Url
                {
                    Href = new Uri("https://api.mollie.com/v2/order/ord_pbjz8x/shipments"),
                    Type = "application/hal+json"
                },
                Documentation = new Url
                {
                    Href = new Uri("https://docs.mollie.com/reference/v2/shipments-api/list-shipments"),
                    Type = "text/html"
                }
            };

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var order = GetOrder("ord_pbjz8x");
            var shipments = await _apiClient.OrderShipments.ListFor(order);

            Assert.IsInstanceOfType(shipments, typeof(ShipmentCollection));
            AssertShipment(shipments[0], "shp_3wmsgCJN4U", "ord_pbjz8x");
            AssertShipment(shipments[1], "shp_kjh234CASX", "ord_pbjz8x");
        }

        [TestMethod]
        public async Task TestUpdateShipmentTrackingInfo()
        {
            var requestContent = new Shipment
            {
                Tracking = new ShipmentTracking
                {
                    Carrier = "PostNL",
                    Code = "3SKABA000000000",
                    Url = new Uri("http://postnl.nl/tracktrace/?B=3SKABA000000000&P=1016EE&D=NL&T=C")
                }
            };
            var request = new HttpRequestMessage
            {
                Method = new HttpMethod("PATCH"),
                RequestUri = new Uri(API_ENDPOINT + "/v2/orders/ord_pbjz8x/shipments/shp_3wmsgCJN4U"),
                //Content = new StringContent(JsonHelper.Serialize(requestContent))
            };

            var responseContent = GetShipmentResponseFixture(
                "shp_3wmsgCJN4U",
                "ord_pbjz8x",
                OrderLineStatus.STATUS_SHIPPING,
                new ShipmentTracking
                {
                    Carrier = "PostNL",
                    Code = "3SKABA000000000",
                    Url = new Uri("http://postnl.nl/tracktrace/?B=3SKABA000000000&P=1016EE&D=NL&T=C")
                }
                );

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonHelper.Serialize(responseContent))
            };

            MockApiCall(request, response);

            var shipment = GetShipment("shp_3wmsgCJN4U", "ord_pbjz8x", OrderLineStatus.STATUS_SHIPPING);
            shipment.Tracking = new ShipmentTracking
            {
                Carrier = "PostNL",
                Code = "3SKABA000000000",
                Url = new Uri("http://postnl.nl/tracktrace/?B=3SKABA000000000&P=1016EE&D=NL&T=C")
            };
            var order = GetOrder("ord_pbjz8x");
            shipment = await _apiClient.OrderShipments.UpdateFor(order, shipment);

            AssertShipment(shipment, "shp_3wmsgCJN4U", "ord_pbjz8x");

            Assert.AreEqual(new ShipmentTracking
            {
                Carrier = "PostNL",
                Code = "3SKABA000000000",
                Url = new Uri("http://postnl.nl/tracktrace/?B=3SKABA000000000&P=1016EE&D=NL&T=C")
            }, shipment.Tracking);
        }

        private void AssertShipment(Shipment shipment, string shipmentId, string orderId)
        {
            Assert.IsInstanceOfType(shipment, typeof(Shipment));
            Assert.AreEqual("shipment", shipment.Resource);
            Assert.AreEqual(shipmentId, shipment.Id);
            Assert.AreEqual(orderId, shipment.OrderId);
            Assert.AreEqual(new DateTime(2018, 8, 2, 9, 29, 56), shipment.CreatedAt);

            Assert.AreEqual(new Url($"https://api.mollie.com/v2/orders/{orderId}/shipments/{shipmentId}", "application/hal+json"), shipment.Links.Self);
            Assert.AreEqual(new Url($"https://api.mollie.com/v2/orders/{orderId}", "application/hal+json"), shipment.Links.Order);
            Assert.AreEqual(new Url("https://docs.mollie.com/reference/v2/shipments-api/get-shipment", "text/html"), shipment.Links.Documentation);

            var line1 = shipment.Lines[0];
            Assert.AreEqual("orderline", line1.Resource);
            Assert.AreEqual("odl_dgtxyl", line1.Id);
            Assert.AreEqual("ord_pbjz8x", line1.OrderId);
            Assert.AreEqual("LEGO 42083 Bugatti Chiron", line1.Name);
            Assert.AreEqual(new Uri("https://shop.lego.com/nl-NL/Bugatti-Chiron-42083"), line1.ProductUrl);
            Assert.AreEqual(new Uri("https://sh-s7-live-s.legocdn.com/is/image//LEGO/42083_alt1?$main$"), line1.ImageUrl);
            Assert.AreEqual("5702016116977", line1.SKU);
            Assert.AreEqual(OrderLineType.TYPE_PHYSICAL, line1.Type);
            Assert.AreEqual(OrderLineStatus.STATUS_SHIPPING, line1.Status);
            Assert.AreEqual(2, line1.Quantity);
            Assert.AreEqual(new DateTime(2018, 8, 2, 9, 29, 56), line1.CreatedAt);
            Assert.AreEqual("21.00", line1.VatRate);
            Assert.AreEqual(new Amount("121.14", "EUR"), line1.VatAmount);
            Assert.AreEqual(new Amount("399.00", "EUR"), line1.UnitPrice);
            Assert.AreEqual(new Amount("100.00", "EUR"), line1.DiscountAmount);
            Assert.AreEqual(new Amount("698.00", "EUR"), line1.TotalAmount);

            var line2 = shipment.Lines[1];
            Assert.AreEqual("orderline", line2.Resource);
            Assert.AreEqual("odl_jp31jz", line2.Id);
            Assert.AreEqual("ord_pbjz8x", line2.OrderId);
            Assert.AreEqual("LEGO 42056 Porsche 911 GT3 RS", line2.Name);
            Assert.AreEqual(new Uri("https://shop.lego.com/nl-NL/Porsche-911-GT3-RS-42056"), line2.ProductUrl);
            Assert.AreEqual(new Uri("https://sh-s7-live-s.legocdn.com/is/image/LEGO/42056?$PDPDefault$"), line2.ImageUrl);
            Assert.AreEqual("5702015594028", line2.SKU);
            Assert.AreEqual(OrderLineType.TYPE_DIGITAL, line2.Type);
            Assert.AreEqual(OrderLineStatus.STATUS_SHIPPING, line2.Status);
            Assert.AreEqual(1, line2.Quantity);
            Assert.AreEqual(new DateTime(2018, 8, 2, 9, 29, 56), line2.CreatedAt);
            Assert.AreEqual("21.00", line2.VatRate);
            Assert.AreEqual(new Amount("57.27", "EUR"), line2.VatAmount);
            Assert.AreEqual(new Amount("329.99", "EUR"), line2.UnitPrice);
            Assert.AreEqual(new Amount("329.99", "EUR"), line2.TotalAmount);
        }
    }
}
