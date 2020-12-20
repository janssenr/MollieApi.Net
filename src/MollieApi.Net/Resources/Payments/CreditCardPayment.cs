using MollieApi.Net.Types;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class CreditCardPayment : Payment
    {
        [DataMember(Name = "billingAddress", EmitDefaultValue = false, IsRequired = false)]
        public Address BillingAddress { private get; set; }

        [DataMember(Name = "cardToken", EmitDefaultValue = false, IsRequired = false)]
        public string CardToken { private get; set; }

        [DataMember(Name = "shippingAddress", EmitDefaultValue = false, IsRequired = false)]
        public Address ShippingAddress { private get; set; }

        public CreditCardPayment()
        {
            Method = PaymentMethod.CREDITCARD;
        }
    }
}
