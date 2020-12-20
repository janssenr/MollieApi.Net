using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;

namespace MollieApi.Tests.Resources
{
    [TestClass]
    public class RefundTest
    {
        public void TestRefundStatuses()
        {
            var refund = new Refund();

            refund.Status = RefundStatus.STATUS_PENDING;
            Assert.AreEqual(true, refund.IsPending());
            Assert.AreEqual(false, refund.IsProcessing());
            Assert.AreEqual(false, refund.IsQueued());
            Assert.AreEqual(false, refund.IsTransferred());

            refund.Status = RefundStatus.STATUS_PROCESSING;
            Assert.AreEqual(false, refund.IsPending());
            Assert.AreEqual(true, refund.IsProcessing());
            Assert.AreEqual(false, refund.IsQueued());
            Assert.AreEqual(false, refund.IsTransferred());

            refund.Status = RefundStatus.STATUS_QUEUED;
            Assert.AreEqual(false, refund.IsPending());
            Assert.AreEqual(false, refund.IsProcessing());
            Assert.AreEqual(true, refund.IsQueued());
            Assert.AreEqual(false, refund.IsTransferred());

            refund.Status = RefundStatus.STATUS_REFUNDED;
            Assert.AreEqual(false, refund.IsPending());
            Assert.AreEqual(false, refund.IsProcessing());
            Assert.AreEqual(false, refund.IsQueued());
            Assert.AreEqual(true, refund.IsTransferred());
        }
    }
}
