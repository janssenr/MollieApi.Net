using MollieApi.Net.Types;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class GiftcardPayment : Payment
    {
        [DataMember(Name = "issuer", EmitDefaultValue = false, IsRequired = false)]
        public string Issuer { private get; set; }

        [DataMember(Name = "voucherNumber", EmitDefaultValue = false, IsRequired = false)]
        public string VoucherNumber { private get; set; }

        [DataMember(Name = "voucherPin", EmitDefaultValue = false, IsRequired = false)]
        public string VoucherPin { private get; set; }

        public GiftcardPayment()
        {
            Method = PaymentMethod.GIFTCARD;
        }
    }
}
