using MollieApi.Net.Types;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class PayPalPayment : Payment
    {
        [DataMember(Name = "issuer", EmitDefaultValue = false, IsRequired = false)]
        public string Issuer { private get; set; }

        [DataMember(Name = "shippingAddress", EmitDefaultValue = false, IsRequired = false)]
        public Address ShippingAddress { private get; set; }

        [DataMember(Name = "sessionId", EmitDefaultValue = false, IsRequired = false)]
        public string SessionId { private get; set; }

        [DataMember(Name = "digitalGoods", EmitDefaultValue = false, IsRequired = false)]
        public bool DigitalGoods { private get; set; }

        public PayPalPayment()
        {
            Method = PaymentMethod.PAYPAL;
        }

    }
}
