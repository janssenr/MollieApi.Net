using MollieApi.Net.Types;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Settlement : BaseResource
    {
        /// <summary>
        /// The settlement reference. This corresponds to an invoice that's in your Dashboard.
        /// </summary>
        [DataMember(Name = "reference", EmitDefaultValue = false, IsRequired = false)]
        public string Reference { get; set; }

        /// <summary>
        /// UTC datetime the payment was created in ISO-8601 format.
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The date on which the settlement was settled, in ISO 8601 format. When requesting the open settlement or next settlement the return value is null.
        /// </summary>
        [DataMember(Name = "settledAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime SettledAt { get; set; }

        /// <summary>
        /// Status of the settlement.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public string Status { get; set; }

        /// <summary>
        /// Total settlement amount in euros.
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false, IsRequired = false)]
        public Amount Amount { get; set; }

        /// <summary>
        /// Revenues and costs nested per year, per month, and per payment method.
        /// </summary>
        [DataMember(Name = "periods", EmitDefaultValue = false, IsRequired = false)]
        public Dictionary<string, Dictionary<string, SettlementPeriod>> Periods { get; set; }

        /// <summary>
        /// The ID of the invoice on which this settlement is invoiced, if it has been invoiced.
        /// </summary>
        [DataMember(Name = "invoiceId", EmitDefaultValue = false, IsRequired = false)]
        public string InvoiceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false, IsRequired = false)]
        public Links Links { get; set; }

        /// <summary>
        /// Is this settlement still open?
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            return Status == SettlementStatus.STATUS_OPEN;
        }

        /// <summary>
        /// Is this settlement pending?
        /// </summary>
        /// <returns></returns>
        public bool IsPending()
        {
            return Status == SettlementStatus.STATUS_PENDING;
        }

        /// <summary>
        /// Is this settlement paidout?
        /// </summary>
        /// <returns></returns>
        public bool IsPaidout()
        {
            return Status == SettlementStatus.STATUS_PAIDOUT;
        }

        /// <summary>
        /// Is this settlement failed?
        /// </summary>
        /// <returns></returns>
        public bool IsFailed()
        {
            return Status == SettlementStatus.STATUS_FAILED;
        }
    }
}
