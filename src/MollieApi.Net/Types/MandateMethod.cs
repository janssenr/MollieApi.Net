using System.Collections;

namespace MollieApi.Net.Types
{
    public class MandateMethod
    {
        public const string DIRECTDEBIT = "directdebit";
        public const string CREDITCARD = "creditcard";
        public const string PAYPAL = "paypal";

        public static string GetForFirstPaymentMethod(string firstPaymentMethod)
        {
            if (firstPaymentMethod == PaymentMethod.PAYPAL)
            {
                return PAYPAL;
            }

            if (new ArrayList { PaymentMethod.APPLEPAY, PaymentMethod.CREDITCARD }.Contains(firstPaymentMethod))
            {
                return CREDITCARD;
            }

            return DIRECTDEBIT;
        }
    }
}
