using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class SettlementPeriodCostRate
    {
        [DataMember(Name = "fixed", EmitDefaultValue = false, IsRequired = false)]
        public Amount Fixed { get; set; }

        [DataMember(Name = "variable", EmitDefaultValue = false, IsRequired = false)]
        public string Variable { get; set; }
    }
}
