using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class InvoiceLine
    {
        /// <summary>
        /// The administrative period in YYYY-MM on which the line should be booked.
        /// </summary>
        [DataMember(Name = "period", EmitDefaultValue = false, IsRequired = false)]
        public string Period { get; set; }

        /// <summary>
        /// Description of the product.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false, IsRequired = false)]
        public string Description { get; set; }

        /// <summary>
        /// Number of products invoiced (usually number of payments).
        /// </summary>
        [DataMember(Name = "count", EmitDefaultValue = false, IsRequired = false)]
        public int Count { get; set; }

        /// <summary>
        /// VAT percentage rate that applies to this product.
        /// </summary>
        [DataMember(Name = "vatPercentage", EmitDefaultValue = false, IsRequired = false)]
        public double VatPercentage { get; set; }

        /// <summary>
        /// Amount excluding VAT.
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false, IsRequired = false)]
        public Amount Amount { get; set; }
    }
}
