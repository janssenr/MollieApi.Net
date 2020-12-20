using MollieApi.Net.Types;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Refund : BaseResource
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
        /// The refund's description, if available.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false, IsRequired = false)]
        public string Description { get; set; }

        /// <summary>
        /// The payment id that was refunded.
        /// </summary>
        [DataMember(Name = "paymentId", EmitDefaultValue = false, IsRequired = false)]
        public string PaymentId { get; set; }

        /// <summary>
        /// The order id that was refunded.
        /// </summary>
        [DataMember(Name = "orderId", EmitDefaultValue = false, IsRequired = false)]
        public string OrderId { get; set; }

        /// <summary>
        /// The order lines contain the actual things the customer ordered.
        /// The lines will show the quantity, discountAmount, vatAmount and totalAmount refunded.
        /// </summary>
        [DataMember(Name = "lines", EmitDefaultValue = false, IsRequired = false)]
        public IList<OrderLine> Lines { get; set; }

        /// <summary>
        /// The settlement amount
        /// </summary>
        [DataMember(Name = "settlementAmount", EmitDefaultValue = false, IsRequired = false)]
        public Amount SettlementAmount { get; set; }

        /// <summary>
        /// The refund status
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public string Status { get; set; }

        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public Links Links { get; set; }

        /// <summary>
        /// Is this refund queued?
        /// </summary>
        /// <returns></returns>
        public bool IsQueued()
        {
            return Status == RefundStatus.STATUS_QUEUED;
        }

        /// <summary>
        /// Is this refund pending?
        /// </summary>
        /// <returns></returns>
        public bool IsPending()
        {
            return Status == RefundStatus.STATUS_PENDING;
        }

        /// <summary>
        /// Is this refund processing?
        /// </summary>
        /// <returns></returns>
        public bool IsProcessing()
        {
            return Status == RefundStatus.STATUS_PROCESSING;
        }

        /// <summary>
        /// Is this refund transferred to consumer?
        /// </summary>
        /// <returns></returns>
        public bool IsTransferred()
        {
            return Status == RefundStatus.STATUS_REFUNDED;
        }
    }
}
