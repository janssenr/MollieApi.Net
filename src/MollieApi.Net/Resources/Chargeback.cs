using System;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Chargeback : BaseResource
    {
        /// <summary>
        /// The amount that was refunded.
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false, IsRequired = false)]
        public Amount Amount { get; set; }

        /// <summary>
        /// UTC datetime the payment was created in ISO-8601 format.
        /// </summary>
        /// <example>2013-12-25T10:30:54+00:00</example>
        [DataMember(Name = "createdAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The payment id that was refunded.
        /// </summary>
        [DataMember(Name = "paymentId", EmitDefaultValue = false, IsRequired = false)]
        public string PaymentId { get; set; }

        /// <summary>
        /// The settlement amount
        /// </summary>
        [DataMember(Name = "settlementAmount", EmitDefaultValue = false, IsRequired = false)]
        public Amount SettlementAmount { get; set; }

        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public Links Links { get; set; }
    }
}
