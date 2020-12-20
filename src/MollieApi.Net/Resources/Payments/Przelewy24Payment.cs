using MollieApi.Net.Types;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Przelewy24Payment : Payment
    {
        [DataMember(Name = "billingEmail", EmitDefaultValue = false, IsRequired = false)]
        public string BillingEmail { private get; set; }

        public Przelewy24Payment()
        {
            Method = PaymentMethod.PRZELEWY24;
        }
    }
}
