using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Resources;

namespace MollieApi.Tests.Resources
{
    [TestClass]
    public class OrderLineCollectionTest
    {
        [TestMethod]
        public void TestCanGetOrderLine()
        {
            var line1 = new OrderLine { Id = "odl_aaaaaaaaaaa1" };
            var line2 = new OrderLine { Id = "odl_aaaaaaaaaaa2" };
            var line3 = new OrderLine { Id = "odl_aaaaaaaaaaa3" };

            var lines = new OrderLineCollection
            {
                line1,
                line2,
                line3
            };

            Assert.IsNull(lines.Get("odl_not_existent"));

            var line = lines.Get("odl_aaaaaaaaaaa2");

            Assert.IsInstanceOfType(line, typeof(OrderLine));
            Assert.AreEqual(line2, line);
        }
    }
}
