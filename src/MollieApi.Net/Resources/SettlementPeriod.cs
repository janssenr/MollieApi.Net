using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class SettlementPeriod
    {
        [DataMember(Name = "revenue", EmitDefaultValue = false, IsRequired = false)]
        public SettlementPeriodRevenue[] Revenue { get; set; }

        [DataMember(Name = "costs", EmitDefaultValue = false, IsRequired = false)]
        public SettlementPeriodCost[] Costs { get; set; }

        [DataMember(Name = "invoiceId", EmitDefaultValue = false, IsRequired = false)]
        public string InvoiceId { get; set; }
    }
}
