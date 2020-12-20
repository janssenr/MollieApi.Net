using MollieApi.Net.Types;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class KbcPayment : Payment
    {
        [DataMember(Name = "issuer", EmitDefaultValue = false, IsRequired = false)]
        public string Issuer { private get; set; }

        public KbcPayment()
        {
            Method = PaymentMethod.KBC;
        }
    }
}
