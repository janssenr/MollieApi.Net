using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Resources;
using System;

namespace MollieApi.Tests.Resources
{
    [TestClass]
    public class ShipmentTest
    {
        [TestMethod]
        public void TestHasTrackingReturnsTrueIfObjectNotNull()
        {
            var shipment = new Shipment();
            shipment.Tracking = GetTrackingDummy();
            Assert.IsTrue(shipment.HasTracking());
        }

        [TestMethod]
        public void TestHasTrackingReturnsFalseIfObjectIsNull()
        {
            var shipment = new Shipment();
            shipment.Tracking = null;
            Assert.IsFalse(shipment.HasTracking());
        }

        [TestMethod]
        public void TestHasTrackingUrlReturnsFalseIfTrackingIsNotSet()
        {
            var shipment = new Shipment();
            shipment.Tracking = null;
            Assert.IsFalse(shipment.HasTrackingUrl());
        }

        [TestMethod]
        public void TestHasTrackingUrlReturnsTrueIfUrlIsSet()
        {
            var shipment = new Shipment();
            shipment.Tracking = GetTrackingDummy();
            shipment.Tracking.Url = new Uri("https://www.some-tracking-url.com/123");
            Assert.IsTrue(shipment.HasTrackingUrl());
        }

        [TestMethod]
        public void TestHasTrackingUrlReturnsFalseIfUrlIsNotSet()
        {
            var shipment = new Shipment();
            shipment.Tracking = GetTrackingDummy();
            shipment.Tracking.Url = null;
            Assert.IsFalse(shipment.HasTrackingUrl());
        }

        [TestMethod]
        public void TestGetTrackingUrlReturnsNullIfNotAvailable()
        {
            var shipment = new Shipment();
            
            shipment.Tracking = null;
            Assert.IsNull(shipment.GetTrackingUrl());

            shipment.Tracking = GetTrackingDummy();
            shipment.Tracking.Url = null;
            Assert.IsNull(shipment.GetTrackingUrl());
        }

        [TestMethod]
        public void TestGetTrackingUrlReturnsUrlIfAvailable()
        {
            var shipment = new Shipment();
            shipment.Tracking = GetTrackingDummy();
            shipment.Tracking.Url = new Uri("https://www.some-tracking-url.com/123");

            Assert.AreEqual("https://www.some-tracking-url.com/123", shipment.GetTrackingUrl());
        }

        private ShipmentTracking GetTrackingDummy()
        {
            return new ShipmentTracking
            {
                Carrier = "DummyCarrier",
                Code = "123456ABCD",
                Url = new Uri("https://www.example.org/tracktrace/1234")
            };
        }
    }
}
