using Microsoft.VisualStudio.TestTools.UnitTesting;
using MollieApi.Net.Types;

namespace MollieApi.Tests.Types
{
    [TestClass]
    public class MandateMethodTest
    {
        public void TestForFirstPaymentMethod(string firstPaymentMethod, string expectedMethod)
        {
            string actualMethod = MandateMethod.GetForFirstPaymentMethod(firstPaymentMethod);
            Assert.AreEqual(expectedMethod, actualMethod);
        }

        [TestMethod]
        public void TestGetForFirstPaymentMethod()
        {
            TestForFirstPaymentMethod(PaymentMethod.APPLEPAY, MandateMethod.CREDITCARD);
            TestForFirstPaymentMethod(PaymentMethod.CREDITCARD, MandateMethod.CREDITCARD);
            TestForFirstPaymentMethod(PaymentMethod.BANCONTACT, MandateMethod.DIRECTDEBIT);
            TestForFirstPaymentMethod(PaymentMethod.BELFIUS, MandateMethod.DIRECTDEBIT);
            TestForFirstPaymentMethod(PaymentMethod.EPS, MandateMethod.DIRECTDEBIT);
            TestForFirstPaymentMethod(PaymentMethod.GIROPAY, MandateMethod.DIRECTDEBIT);
            TestForFirstPaymentMethod(PaymentMethod.IDEAL, MandateMethod.DIRECTDEBIT);
            TestForFirstPaymentMethod(PaymentMethod.INGHOMEPAY, MandateMethod.DIRECTDEBIT);
            TestForFirstPaymentMethod(PaymentMethod.KBC, MandateMethod.DIRECTDEBIT);
            TestForFirstPaymentMethod(PaymentMethod.SOFORT, MandateMethod.DIRECTDEBIT);
            TestForFirstPaymentMethod(PaymentMethod.PAYPAL, MandateMethod.PAYPAL);
        }
    }
}
