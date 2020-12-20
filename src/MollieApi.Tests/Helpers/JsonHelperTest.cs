using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Helpers;
using MollieApi.Net.Resources;
using System;

namespace MollieApi.Tests.Helpers
{
    [TestClass]
    public class JsonHelperTest
    {
        [TestMethod]
        public void TestCreateFromApiResponseWorks()
        {
            var apiResult = "{\"resource\":\"payment\",\"id\":\"tr_44aKxzEbr8\",\"mode\":\"test\",\"createdAt\":\"2018-03-13T14:02:29+00:00\",\"amount\":{\"value\":\"20.00\",\"currency\":\"EUR\"}}";

            var payment = JsonHelper.Deserialize<Payment>(apiResult);

            Assert.IsInstanceOfType(payment, typeof(Payment));
            Assert.AreEqual("payment", payment.Resource);
            Assert.AreEqual("tr_44aKxzEbr8", payment.Id);
            Assert.AreEqual("test", payment.Mode);
            Assert.AreEqual(new DateTime(2018,3,13,14,2,29, DateTimeKind.Utc).ToLocalTime(), payment.CreatedAt);
            Assert.AreEqual(new Amount("20.00", "EUR"), payment.Amount);
        }
    }
}
