using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;

namespace MollieApi.Tests.Resources
{
    [TestClass]
    public class ProfileTest
    {
        [TestMethod]
        public void TestProfileStatusses()
        {
            var profile = new Profile();

            profile.Status = ProfileStatus.STATUS_BLOCKED;
            Assert.AreEqual(true, profile.IsBlocked());
            Assert.AreEqual(false, profile.IsVerified());
            Assert.AreEqual(false, profile.IsUnverified());

            profile.Status = ProfileStatus.STATUS_VERIFIED;
            Assert.AreEqual(false, profile.IsBlocked());
            Assert.AreEqual(true, profile.IsVerified());
            Assert.AreEqual(false, profile.IsUnverified());

            profile.Status = ProfileStatus.STATUS_UNVERIFIED;
            Assert.AreEqual(false, profile.IsBlocked());
            Assert.AreEqual(false, profile.IsVerified());
            Assert.AreEqual(true, profile.IsUnverified());
        }
    }
}
