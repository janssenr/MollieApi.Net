using MollieApi.Net.Types;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Subscription : BaseResource
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "customerId", EmitDefaultValue = false, IsRequired = false)]
        public string CustomerId { get; set; }

        /// <summary>
        /// Either "live" or "test" depending on the customer's mode.
        /// </summary>
        [DataMember(Name = "mode", EmitDefaultValue = false, IsRequired = false)]
        public string Mode { get; set; }

        /// <summary>
        /// UTC datetime the shipment was created in ISO-8601 format.
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false, IsRequired = false)]
        public Amount Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "times", EmitDefaultValue = false, IsRequired = false)]
        public int? Times { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "interval", EmitDefaultValue = false, IsRequired = false)]
        public string Interval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false, IsRequired = false)]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "method", EmitDefaultValue = false, IsRequired = false)]
        public string Method { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "mandateId", EmitDefaultValue = false, IsRequired = false)]
        public string MandateId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "metadata", EmitDefaultValue = false, IsRequired = false)]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// UTC datetime the subscription canceled in ISO-8601 format.
        /// </summary>
        [DataMember(Name = "canceledAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CanceledAt { get; set; }

        /// <summary>
        /// Date the subscription started. For example: 2018-04-24
        /// </summary>
        [DataMember(Name = "startDate", EmitDefaultValue = false, IsRequired = false)]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Contains an optional 'webhookUrl'.
        /// </summary>
        [DataMember(Name = "webhookUrl", EmitDefaultValue = false, IsRequired = false)]
        public Uri WebhookUrl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false, IsRequired = false)]
        public Links Links { get; set; }

        /// <summary>
        /// Returns whether the Subscription is active or not.
        /// </summary>
        /// <returns></returns>
        public bool IsActive()
        {
            return Status == SubscriptionStatus.STATUS_ACTIVE;
        }

        /// <summary>
        /// Returns whether the Subscription is pending or not.
        /// </summary>
        /// <returns></returns>
        public bool IsPending()
        {
            return Status == SubscriptionStatus.STATUS_PENDING;
        }

        /// <summary>
        /// Returns whether the Subscription is canceled or not.
        /// </summary>
        /// <returns></returns>
        public bool IsCanceled()
        {
            return Status == SubscriptionStatus.STATUS_CANCELED;
        }

        /// <summary>
        /// Returns whether the Subscription is suspended or not.
        /// </summary>
        /// <returns></returns>
        public bool IsSuspended()
        {
            return Status == SubscriptionStatus.STATUS_SUSPENDED;
        }

        /// <summary>
        /// Returns whether the Subscription is completed or not.
        /// </summary>
        /// <returns></returns>
        public bool IsCompleted()
        {
            return Status == SubscriptionStatus.STATUS_COMPLETED;
        }
    }
}
