using MollieApi.Net.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Order : BaseResource
    {
        /// <summary>
        /// The profile ID this order belongs to.
        /// </summary>
        [DataMember(Name = "profileId", EmitDefaultValue = false, IsRequired = false)]
        public string ProfileId { get; set; }

        /// <summary>
        /// Either "live" or "test". Indicates this being a test or a live (verified) order.
        /// </summary>
        [DataMember(Name = "mode", EmitDefaultValue = false, IsRequired = false)]
        public string Mode { get; set; }

        /// <summary>
        /// Amount object containing the value and currency
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false, IsRequired = false)]
        public Amount Amount { get; set; }

        /// <summary>
        /// The total amount captured, thus far.
        /// </summary>
        [DataMember(Name = "amountCaptured", EmitDefaultValue = false, IsRequired = false)]
        public Amount AmountCaptured { get; set; }

        /// <summary>
        /// The total amount refunded, thus far.
        /// </summary>
        [DataMember(Name = "amountRefunded", EmitDefaultValue = false, IsRequired = false)]
        public Amount AmountRefunded { get; set; }

        /// <summary>
        /// The status of the order.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public string Status { get; set; }

        /// <summary>
        /// The person and the address the order is billed to.
        /// </summary>
        [DataMember(Name = "billingAddress", EmitDefaultValue = false, IsRequired = false)]
        public OrderAddress BillingAddress { get; set; }

        /// <summary>
        /// The date of birth of your customer, if available.
        /// </summary>
        [DataMember(Name = "consumerDateOfBirth", EmitDefaultValue = false, IsRequired = false)]
        public DateTime ConsumerDateOfBirth { get; set; }

        /// <summary>
        /// The date of birth of your customer, if available.
        /// </summary>
        [DataMember(Name = "orderNumber", EmitDefaultValue = false, IsRequired = false)]
        public string OrderNumber { get; set; }

        /// <summary>
        /// The person and the address the order is billed to.
        /// </summary>
        [DataMember(Name = "shippingAddress", EmitDefaultValue = false, IsRequired = false)]
        public OrderAddress ShippingAddress { get; set; }

        /// <summary>
        /// The payment method last used when paying for the order.
        /// </summary>
        [DataMember(Name = "method", EmitDefaultValue = false, IsRequired = false)]
        public string Method { get; set; }

        /// <summary>
        /// The locale used for this order.
        /// </summary>
        [DataMember(Name = "locale", EmitDefaultValue = false, IsRequired = false)]
        private string _locale;

        public CultureInfo Locale
        {
            get
            {
                return !string.IsNullOrEmpty(_locale) ? new CultureInfo(_locale.Replace("_", "-")) : null;
            }
            set
            {
                _locale = value != null ? value.Name.Replace("-", "_") : null;
            }
        }

        /// <summary>
        /// During creation of the order you can set custom metadata that is stored with the order, and given back whenever you retrieve that order.
        /// </summary>
        [DataMember(Name = "metadata", EmitDefaultValue = false, IsRequired = false)]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Can this order be canceled?
        /// </summary>
        [DataMember(Name = "isCancelable", EmitDefaultValue = false, IsRequired = false)]
        public bool IsCancelable { get; set; }

        /// <summary>
        /// Webhook URL set on this payment
        /// </summary>
        [DataMember(Name = "webhookUrl", EmitDefaultValue = false, IsRequired = false)]
        public Uri WebhookUrl { get; set; }

        /// <summary>
        /// Redirect URL set on this payment
        /// </summary>
        [DataMember(Name = "redirectUrl", EmitDefaultValue = false, IsRequired = false)]
        public Uri RedirectUrl { get; set; }

        /// <summary>
        /// UTC datetime the order was created in ISO-8601 format.
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// UTC datetime the order the order will expire in ISO-8601 format.
        /// </summary>
        [DataMember(Name = "expiresAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// UTC datetime if the order is expired, the time of expiration will be present in ISO-8601 format.
        /// </summary>
        [DataMember(Name = "expiredAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime ExpiredAt { get; set; }

        /// <summary>
        /// UTC datetime if the order has been paid, the time of payment will be present in ISO-8601 format.
        /// </summary>
        [DataMember(Name = "paidAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime PaidAt { get; set; }

        /// <summary>
        /// UTC datetime if the order has been authorized, the time of authorization will be present in ISO-8601 format.
        /// </summary>
        [DataMember(Name = "authorizedAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime AuthorizedAt { get; set; }

        /// <summary>
        /// UTC datetime if the order has been canceled, the time of cancellation will be present in ISO 8601 format.
        /// </summary>
        [DataMember(Name = "canceledAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CanceledAt { get; set; }

        /// <summary>
        /// UTC datetime if the order is completed, the time of completion will be present in ISO 8601 format.
        /// </summary>
        [DataMember(Name = "completedAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CompletedAt { get; set; }

        /// <summary>
        /// The order lines contain the actual things the customer bought.
        /// </summary>
        [DataMember(Name = "lines", EmitDefaultValue = false, IsRequired = false)]
        public IList<OrderLine> Lines { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "_embedded", EmitDefaultValue = false, IsRequired = false)]
        public PaymentCollection Payments { get; set; }

        /// <summary>
        /// An object with several URL objects relevant to the customer. Every URL object will contain an href and a type field.
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false, IsRequired = false)]
        public Links Links { get; set; }

        /// <summary>
        /// Is this order created?
        /// </summary>
        /// <returns></returns>
        public bool IsCreated()
        {
            return Status == OrderStatus.STATUS_CREATED;
        }

        /// <summary>
        /// Is this order paid for?
        /// </summary>
        /// <returns></returns>
        public bool IsPaid()
        {
            return Status == OrderStatus.STATUS_PAID;
        }

        /// <summary>
        /// Is this order authorized?
        /// </summary>
        /// <returns></returns>
        public bool IsAuthorized()
        {
            return Status == OrderStatus.STATUS_AUTHORIZED;
        }

        /// <summary>
        /// Is this order canceled?
        /// </summary>
        /// <returns></returns>
        public bool IsCanceled()
        {
            return Status == OrderStatus.STATUS_CANCELED;
        }

        /// <summary>
        /// Is this order refunded?
        /// </summary>
        /// <returns></returns>
        [Obsolete]
        public bool IsRefunded()
        {
            return Status == OrderStatus.STATUS_REFUNDED;
        }

        /// <summary>
        /// Is this order shipping?
        /// </summary>
        /// <returns></returns>
        public bool IsShipping()
        {
            return Status == OrderStatus.STATUS_SHIPPING;
        }

        /// <summary>
        /// Is this order completed?
        /// </summary>
        /// <returns></returns>
        public bool IsCompleted()
        {
            return Status == OrderStatus.STATUS_COMPLETED;
        }

        /// <summary>
        /// Is this order expired?
        /// </summary>
        /// <returns></returns>
        public bool IsExpired()
        {
            return Status == OrderStatus.STATUS_EXPIRED;
        }

        /// <summary>
        /// Is this order pending?
        /// </summary>
        /// <returns></returns>
        public bool IsPending()
        {
            return Status == OrderStatus.STATUS_PENDING;
        }

        /// <summary>
        /// Get the checkout URL where the customer can complete the payment.
        /// </summary>
        /// <returns></returns>
        public string GetCheckoutUrl()
        {
            if (Links.Checkout == null)
                return null;

            return Links.Checkout.Href.ToString();
        }
    }
}
