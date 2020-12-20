using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;

namespace MollieApi.Tests.Resources
{
    [TestClass]
    public class SubscriptionTest
    {
        [TestMethod]
        public void TestSubscriptionStatuses()
        {
            var subscription = new Subscription();

            subscription.Status = SubscriptionStatus.STATUS_PENDING;
            Assert.AreEqual(true, subscription.IsPending());
            Assert.AreEqual(false, subscription.IsCanceled());
            Assert.AreEqual(false, subscription.IsCompleted());
            Assert.AreEqual(false, subscription.IsSuspended());
            Assert.AreEqual(false, subscription.IsActive());

            subscription.Status = SubscriptionStatus.STATUS_CANCELED;
            Assert.AreEqual(false, subscription.IsPending());
            Assert.AreEqual(true, subscription.IsCanceled());
            Assert.AreEqual(false, subscription.IsCompleted());
            Assert.AreEqual(false, subscription.IsSuspended());
            Assert.AreEqual(false, subscription.IsActive());

            subscription.Status = SubscriptionStatus.STATUS_COMPLETED;
            Assert.AreEqual(false, subscription.IsPending());
            Assert.AreEqual(false, subscription.IsCanceled());
            Assert.AreEqual(true, subscription.IsCompleted());
            Assert.AreEqual(false, subscription.IsSuspended());
            Assert.AreEqual(false, subscription.IsActive());

            subscription.Status = SubscriptionStatus.STATUS_SUSPENDED;
            Assert.AreEqual(false, subscription.IsPending());
            Assert.AreEqual(false, subscription.IsCanceled());
            Assert.AreEqual(false, subscription.IsCompleted());
            Assert.AreEqual(true, subscription.IsSuspended());
            Assert.AreEqual(false, subscription.IsActive());

            subscription.Status = SubscriptionStatus.STATUS_ACTIVE;
            Assert.AreEqual(false, subscription.IsPending());
            Assert.AreEqual(false, subscription.IsCanceled());
            Assert.AreEqual(false, subscription.IsCompleted());
            Assert.AreEqual(false, subscription.IsSuspended());
            Assert.AreEqual(true, subscription.IsActive());
        }
    }
}
