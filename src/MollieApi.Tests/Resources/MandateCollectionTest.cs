using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;
using System.Collections.Generic;

namespace MollieApi.Tests.Resources
{
    [TestClass]
    public class MandateCollectionTest
    {
        [TestMethod]
        public void TestWhereStatus()
        {
            var collection = new MandateCollection
            {
                GetMandateWithStatus(MandateStatus.STATUS_VALID),
                GetMandateWithStatus(MandateStatus.STATUS_VALID),
                GetMandateWithStatus(MandateStatus.STATUS_VALID),
                GetMandateWithStatus(MandateStatus.STATUS_INVALID),
                GetMandateWithStatus(MandateStatus.STATUS_INVALID),
                GetMandateWithStatus(MandateStatus.STATUS_PENDING)
            };

            var valid = collection.Where(MandateStatus.STATUS_VALID);
            var invalid = collection.Where(MandateStatus.STATUS_INVALID);
            var pending = collection.Where(MandateStatus.STATUS_PENDING);

            Assert.IsInstanceOfType(collection, typeof(MandateCollection));
            Assert.IsInstanceOfType(valid, typeof(MandateCollection));
            Assert.IsInstanceOfType(invalid, typeof(MandateCollection));
            Assert.IsInstanceOfType(pending, typeof(MandateCollection));

            Assert.AreEqual(6, collection.Count);
            Assert.AreEqual(3, valid.Count);
            Assert.AreEqual(2, invalid.Count);
            Assert.AreEqual(1, pending.Count);
        }

        protected Mandate GetMandateWithStatus(string status)
        {
            var mandate = new Mandate();
            mandate.Status = status;

            return mandate;
        }
    }
}
