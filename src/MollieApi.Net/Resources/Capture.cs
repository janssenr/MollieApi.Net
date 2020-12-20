using System;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Capture : BaseResource
    {
        /// <summary>
        /// Mode of the capture, either "live" or "test" depending on the API Key that was used.
        /// </summary>
        [DataMember(Name = "mode", EmitDefaultValue = false, IsRequired = false)]
        public string Mode { get; set; }

        /// <summary>
        /// Amount object containing the value and currency
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false, IsRequired = false)]
        public Amount Amount { get; set; }

        /// <summary>
        /// Amount object containing the settlement value and currency
        /// </summary>
        [DataMember(Name = "settlementAmount", EmitDefaultValue = false, IsRequired = false)]
        public Amount SettlementAmount { get; set; }

        /// <summary>
        /// Id of the capture's payment (on the Mollie platform).
        /// </summary>
        [DataMember(Name = "paymentId", EmitDefaultValue = false, IsRequired = false)]
        public string PaymentId { get; set; }

        /// <summary>
        /// Id of the capture's shipment (on the Mollie platform).
        /// </summary>
        [DataMember(Name = "shipmentId", EmitDefaultValue = false, IsRequired = false)]
        public string ShipmentId { get; set; }

        /// <summary>
        /// Id of the capture's settlement (on the Mollie platform).
        /// </summary>
        [DataMember(Name = "settlementId", EmitDefaultValue = false, IsRequired = false)]
        public string SettlementId { get; set; }

        [DataMember(Name = "createdAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CreatedAt { get; set; }

        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public Links Links { get; set; }
    }
}
