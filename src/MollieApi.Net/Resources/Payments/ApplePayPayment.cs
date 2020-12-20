using MollieApi.Net.Types;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class ApplePayPayment : Payment
    {
        [DataMember(Name = "applePayPaymentToken", EmitDefaultValue = false, IsRequired = false)]
        public string ApplePayPaymentToken { private get; set; }

        public ApplePayPayment()
        {
            Method = PaymentMethod.APPLEPAY;
        }

    }
}
