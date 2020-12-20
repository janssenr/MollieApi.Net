using MollieApi.Net.Types;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class SepaDirectDebitPayment : Payment
    {
        [DataMember(Name = "consumerName", EmitDefaultValue = false, IsRequired = false)]
        public string ConsumerName { private get; set; }

        [DataMember(Name = "consumerAccount", EmitDefaultValue = false, IsRequired = false)]
        public string ConsumerAccount { private get; set; }

        public SepaDirectDebitPayment()
        {
            Method = PaymentMethod.DIRECTDEBIT;
        }
    }
}
