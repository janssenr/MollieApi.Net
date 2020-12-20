using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;

namespace MollieApi.Tests.Resources
{
    [TestClass]
    public class SettlementTest
    {
        [TestMethod]
        public void TestSettlementStatuses()
        {
            var settlement = new Settlement();

            settlement.Status = SettlementStatus.STATUS_PENDING;
            Assert.AreEqual(true, settlement.IsPending());
            Assert.AreEqual(false, settlement.IsOpen());
            Assert.AreEqual(false, settlement.IsPaidout());
            Assert.AreEqual(false, settlement.IsFailed());

            settlement.Status = SettlementStatus.STATUS_OPEN;
            Assert.AreEqual(false, settlement.IsPending());
            Assert.AreEqual(true, settlement.IsOpen());
            Assert.AreEqual(false, settlement.IsPaidout());
            Assert.AreEqual(false, settlement.IsFailed());

            settlement.Status = SettlementStatus.STATUS_PAIDOUT;
            Assert.AreEqual(false, settlement.IsPending());
            Assert.AreEqual(false, settlement.IsOpen());
            Assert.AreEqual(true, settlement.IsPaidout());
            Assert.AreEqual(false, settlement.IsFailed());

            settlement.Status = SettlementStatus.STATUS_FAILED;
            Assert.AreEqual(false, settlement.IsPending());
            Assert.AreEqual(false, settlement.IsOpen());
            Assert.AreEqual(false, settlement.IsPaidout());
            Assert.AreEqual(true, settlement.IsFailed());
        }
    }
}
