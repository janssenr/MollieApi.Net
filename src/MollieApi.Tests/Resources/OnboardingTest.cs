using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Resources;
using MollieApi.Net.Types;

namespace MollieApi.Tests.Resources
{
    [TestClass]
    public class OnboardingTest
    {
        [TestMethod]
        public void TestOnboardingStatuses()
        {
            var onboarding = new Onboarding();

            onboarding.Status = OnboardingStatus.NEEDS_DATA;
            Assert.AreEqual(true, onboarding.NeedsData());
            Assert.AreEqual(false, onboarding.IsInReview());
            Assert.AreEqual(false, onboarding.IsCompleted());

            onboarding.Status = OnboardingStatus.IN_REVIEW;
            Assert.AreEqual(false, onboarding.NeedsData());
            Assert.AreEqual(true, onboarding.IsInReview());
            Assert.AreEqual(false, onboarding.IsCompleted());

            onboarding.Status = OnboardingStatus.COMPLETED;
            Assert.AreEqual(false, onboarding.NeedsData());
            Assert.AreEqual(false, onboarding.IsInReview());
            Assert.AreEqual(true, onboarding.IsCompleted());
        }
    }
}
