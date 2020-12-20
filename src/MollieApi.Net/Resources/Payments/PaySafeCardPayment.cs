using MollieApi.Net.Types;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class PaySafeCardPayment : Payment
    {
        [DataMember(Name = "customerReference", EmitDefaultValue = false, IsRequired = false)]
        public string CustomerReference { private get; set; }

        public PaySafeCardPayment()
        {
            Method = PaymentMethod.PAYSAFECARD;
        }
    }
}
