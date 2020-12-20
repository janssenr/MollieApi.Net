using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class SettlementPeriodCost
    {
        [DataMember(Name = "description", EmitDefaultValue = false, IsRequired = false)]
        public string Description { get; set; }

        [DataMember(Name = "method", EmitDefaultValue = false, IsRequired = false)]
        public string Method { get; set; }

        [DataMember(Name = "count", EmitDefaultValue = false, IsRequired = false)]
        public int Count { get; set; }

        [DataMember(Name = "rate", EmitDefaultValue = false, IsRequired = false)]
        public SettlementPeriodCostRate Rate { get; set; }

        [DataMember(Name = "amountNet", EmitDefaultValue = false, IsRequired = false)]
        public Amount AmountNet { get; set; }

        [DataMember(Name = "amountVat", EmitDefaultValue = false, IsRequired = false)]
        public Amount AmountVat { get; set; }

        [DataMember(Name = "amountGross", EmitDefaultValue = false, IsRequired = false)]
        public Amount AmountGross { get; set; }
    }
}
