using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;
using MollieApi.Tests.Helpers;
using System;
using System.Linq;

namespace MollieApi.Tests.Resources
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void TestOrderStatuses()
        {
            var order = new Order();

            order.Status = OrderStatus.STATUS_CREATED;
            Assert.AreEqual(true, order.IsCreated());
            Assert.AreEqual(false, order.IsPaid());
            Assert.AreEqual(false, order.IsAuthorized());
            Assert.AreEqual(false, order.IsCanceled());
            Assert.AreEqual(false, order.IsShipping());
            Assert.AreEqual(false, order.IsCompleted());
            Assert.AreEqual(false, order.IsExpired());
            Assert.AreEqual(false, order.IsPending());

            order.Status = OrderStatus.STATUS_PAID;
            Assert.AreEqual(false, order.IsCreated());
            Assert.AreEqual(true, order.IsPaid());
            Assert.AreEqual(false, order.IsAuthorized());
            Assert.AreEqual(false, order.IsCanceled());
            Assert.AreEqual(false, order.IsShipping());
            Assert.AreEqual(false, order.IsCompleted());
            Assert.AreEqual(false, order.IsExpired());
            Assert.AreEqual(false, order.IsPending());

            order.Status = OrderStatus.STATUS_AUTHORIZED;
            Assert.AreEqual(false, order.IsCreated());
            Assert.AreEqual(false, order.IsPaid());
            Assert.AreEqual(true, order.IsAuthorized());
            Assert.AreEqual(false, order.IsCanceled());
            Assert.AreEqual(false, order.IsShipping());
            Assert.AreEqual(false, order.IsCompleted());
            Assert.AreEqual(false, order.IsExpired());
            Assert.AreEqual(false, order.IsPending());

            order.Status = OrderStatus.STATUS_CANCELED;
            Assert.AreEqual(false, order.IsCreated());
            Assert.AreEqual(false, order.IsPaid());
            Assert.AreEqual(false, order.IsAuthorized());
            Assert.AreEqual(true, order.IsCanceled());
            Assert.AreEqual(false, order.IsShipping());
            Assert.AreEqual(false, order.IsCompleted());
            Assert.AreEqual(false, order.IsExpired());
            Assert.AreEqual(false, order.IsPending());

            order.Status = OrderStatus.STATUS_SHIPPING;
            Assert.AreEqual(false, order.IsCreated());
            Assert.AreEqual(false, order.IsPaid());
            Assert.AreEqual(false, order.IsAuthorized());
            Assert.AreEqual(false, order.IsCanceled());
            Assert.AreEqual(true, order.IsShipping());
            Assert.AreEqual(false, order.IsCompleted());
            Assert.AreEqual(false, order.IsExpired());
            Assert.AreEqual(false, order.IsPending());

            order.Status = OrderStatus.STATUS_COMPLETED;
            Assert.AreEqual(false, order.IsCreated());
            Assert.AreEqual(false, order.IsPaid());
            Assert.AreEqual(false, order.IsAuthorized());
            Assert.AreEqual(false, order.IsCanceled());
            Assert.AreEqual(false, order.IsShipping());
            Assert.AreEqual(true, order.IsCompleted());
            Assert.AreEqual(false, order.IsExpired());
            Assert.AreEqual(false, order.IsPending());

            order.Status = OrderStatus.STATUS_EXPIRED;
            Assert.AreEqual(false, order.IsCreated());
            Assert.AreEqual(false, order.IsPaid());
            Assert.AreEqual(false, order.IsAuthorized());
            Assert.AreEqual(false, order.IsCanceled());
            Assert.AreEqual(false, order.IsShipping());
            Assert.AreEqual(false, order.IsCompleted());
            Assert.AreEqual(true, order.IsExpired());
            Assert.AreEqual(false, order.IsPending());

            order.Status = OrderStatus.STATUS_PENDING;
            Assert.AreEqual(false, order.IsCreated());
            Assert.AreEqual(false, order.IsPaid());
            Assert.AreEqual(false, order.IsAuthorized());
            Assert.AreEqual(false, order.IsCanceled());
            Assert.AreEqual(false, order.IsShipping());
            Assert.AreEqual(false, order.IsCompleted());
            Assert.AreEqual(false, order.IsExpired());
            Assert.AreEqual(true, order.IsPending());
        }

        [TestMethod]
        public void TestCanGetOrderLinesAsResourceOnOrderResource()
        {
            var orderLine = new OrderLine
            {
                Resource = "orderline",
                Id = "odl_dgtxyl",
                OrderId = "ord_pbjz8x",
                Type = "physical",
                Name = "LEGO 42083 Bugatti Chiron",
                ProductUrl = new Uri("https://shop.lego.com/nl-NL/Bugatti-Chiron-42083"),
                ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image//LEGO/42083_alt1?$main$"),
                SKU = "5702016116977",
                Status = "created",
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
                CreatedAt = new DateTime(2018, 8, 2, 9, 29, 56)
            };
            var order = new Order
            {
                Lines = new OrderLineCollection
                {
                    orderLine
                }
            };

            var lines = order.Lines;

            Assert.IsInstanceOfType(lines, typeof(OrderLineCollection));
            Assert.AreEqual(1, lines.Count);

            var line = lines.ToList()[0];

            Assert.IsInstanceOfType(line, typeof(OrderLine));

            Assert.AreEqual("orderline", line.Resource);
            Assert.AreEqual("odl_dgtxyl", line.Id);
            Assert.AreEqual("ord_pbjz8x", line.OrderId);
            Assert.AreEqual("LEGO 42083 Bugatti Chiron", line.Name);
            Assert.AreEqual(new Uri("https://shop.lego.com/nl-NL/Bugatti-Chiron-42083"), line.ProductUrl);
            Assert.AreEqual(new Uri("https://sh-s7-live-s.legocdn.com/is/image//LEGO/42083_alt1?$main$"), line.ImageUrl);
            Assert.AreEqual("5702016116977", line.SKU);
            Assert.AreEqual(OrderLineType.TYPE_PHYSICAL, line.Type);
            Assert.AreEqual(OrderLineStatus.STATUS_CREATED, line.Status);
            Assert.AreEqual(2, line.Quantity);
            Assert.AreEqual(new Amount("399.00", "EUR"), line.UnitPrice);
            Assert.AreEqual("21.00", line.VatRate);
            Assert.AreEqual(new Amount("121.14", "EUR"), line.VatAmount);
            Assert.AreEqual(new Amount("100.00", "EUR"), line.DiscountAmount);
            Assert.AreEqual(new Amount("698.00", "EUR"), line.TotalAmount);
            Assert.AreEqual(new DateTime(2018, 8, 2, 9, 29, 56), line.CreatedAt);
        }

        [TestMethod]
        public void TestCanGetPaymentAsResourcesOnOrderResource()
        {
            var orderLine = new OrderLine
            {
                Resource = "orderline",
                Id = "odl_dgtxyl",
                OrderId = "ord_pbjz8x",
                Type = "physical",
                Name = "LEGO 42083 Bugatti Chiron",
                ProductUrl = new Uri("https://shop.lego.com/nl-NL/Bugatti-Chiron-42083"),
                ImageUrl = new Uri("https://sh-s7-live-s.legocdn.com/is/image//LEGO/42083_alt1?$main$"),
                SKU = "5702016116977",
                Status = "created",
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
                CreatedAt = new DateTime(2018, 8, 2, 9, 29, 56)
            };
            var order = new Order
            {
                Lines = new OrderLineCollection
                {
                    orderLine
                }
            };

            var lines = order.Lines;

            Assert.IsInstanceOfType(lines, typeof(OrderLineCollection));
            Assert.AreEqual(1, lines.Count);

            var line = lines.ToList()[0];

            Assert.IsInstanceOfType(line, typeof(OrderLine));

            Assert.AreEqual("orderline", line.Resource);
            Assert.AreEqual("odl_dgtxyl", line.Id);
            Assert.AreEqual("ord_pbjz8x", line.OrderId);
            Assert.AreEqual("LEGO 42083 Bugatti Chiron", line.Name);
            Assert.AreEqual(new Uri("https://shop.lego.com/nl-NL/Bugatti-Chiron-42083"), line.ProductUrl);
            Assert.AreEqual(new Uri("https://sh-s7-live-s.legocdn.com/is/image//LEGO/42083_alt1?$main$"), line.ImageUrl);
            Assert.AreEqual("5702016116977", line.SKU);
            Assert.AreEqual(OrderLineType.TYPE_PHYSICAL, line.Type);
            Assert.AreEqual(OrderLineStatus.STATUS_CREATED, line.Status);
            Assert.AreEqual(2, line.Quantity);
            Assert.AreEqual(new Amount("399.00", "EUR"), line.UnitPrice);
            Assert.AreEqual("21.00", line.VatRate);
            Assert.AreEqual(new Amount("121.14", "EUR"), line.VatAmount);
            Assert.AreEqual(new Amount("100.00", "EUR"), line.DiscountAmount);
            Assert.AreEqual(new Amount("698.00", "EUR"), line.TotalAmount);
            Assert.AreEqual(new DateTime(2018, 8, 2, 9, 29, 56), line.CreatedAt);
        }

        [TestMethod]
        public void TestGetCheckoutUrlWorks()
        {
            var order = new Order();
            order.Links = new Links
            {
                Checkout = new Url
                {
                    Href = new Uri("https://www.some-mollie-checkout-url.com/123"),
                    Type = "text.html"
                }
            };

            Assert.AreEqual("https://www.some-mollie-checkout-url.com/123", order.GetCheckoutUrl());
        }

        [TestMethod]
        public void TestGetCheckoutUrlReturnsNullIfNoCheckoutUrlAvailable()
        {
            var order = new Order();
            order.Links = new Links
            {
                Checkout = null
            };

            Assert.IsNull(order.GetCheckoutUrl());
        }

        [TestMethod]
        public void TestPaymentsHelperReturnsIfNoEmbedAvailable()
        {
            //var order = new Order();
            //Assert.IsNull(order.pa)
        }

        [TestMethod]
        public void TestPaymentsHelperReturnsIfNoPaymentsEmbedded()
        {

        }
    }
}
