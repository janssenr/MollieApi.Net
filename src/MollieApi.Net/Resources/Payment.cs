using MollieApi.Net.Types;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Payment : BaseResource
    {
        /// <summary>
        /// Mode of the payment, either "live" or "test" depending on the API Key that was used.
        /// </summary>
        [DataMember(Name = "mode", EmitDefaultValue = false, IsRequired = false)]
        public string Mode { get; set; }

        /// <summary>
        /// Amount object containing the value and currency
        /// </summary>
        [DataMember(Name = "amount", EmitDefaultValue = false, IsRequired = false)]
        public Amount Amount { get; set; }

        /// <summary>
        /// The amount that has been settled containing the value and currency
        /// </summary>
        [DataMember(Name = "settlementAmount", EmitDefaultValue = false, IsRequired = false)]
        public Amount SettlementAmount { get; set; }

        /// <summary>
        /// The amount of the payment that has been refunded to the consumer, in EURO with 2 decimals.This field will be null if the payment can not be refunded.
        /// </summary>
        [DataMember(Name = "amountRefunded", EmitDefaultValue = false, IsRequired = false)]
        public Amount AmountRefunded { get; set; }

        /// <summary>
        /// The amount of a refunded payment that can still be refunded, in EURO with 2 decimals.This field will be null if the payment can not be refunded.
        ///
        /// For some payment methods this amount can be higher than the payment amount.
        /// This is possible to reimburse the costs for a return shipment to your customer for example.
        /// </summary>
        [DataMember(Name = "amountRemaining", EmitDefaultValue = false, IsRequired = false)]
        public Amount AmountRemaining { get; set; }

        /// <summary>
        /// Description of the payment that is shown to the customer during the payment, and possibly on the bank or credit card statement.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false, IsRequired = false)]
        public string Description { get; set; }

        /// <summary>
        /// If method is empty/null, the customer can pick his/her preferred payment method.
        /// </summary>
        [DataMember(Name = "method", EmitDefaultValue = false, IsRequired = false)]
        public string Method { get; set; }

        /// <summary>
        /// The status of the payment.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public string Status { get; set; }

        /// <summary>
        /// UTC datetime the payment was created in ISO-8601 format.
        /// </summary>
        /// <example>2013-12-25T10:30:54+00:00</example>
        [DataMember(Name = "createdAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// UTC datetime the payment was paid in ISO-8601 format.
        /// 
        /// @example "2013-12-25T10:30:54+00:00"
        /// </summary>
        [DataMember(Name = "paidAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime? PaidAt { get; set; }

        /// <summary>
        /// UTC datetime the payment was canceled in ISO-8601 format.
        /// 
        /// @example "2013-12-25T10:30:54+00:00"
        /// </summary>
        [DataMember(Name = "canceledAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CanceledAt { get; set; }

        /// <summary>
        /// UTC datetime the payment expired in ISO-8601 format.
        /// </summary>
        [DataMember(Name = "expiresAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime ExpiresAt { get; set; }

        /// <summary>
        /// UTC datetime the payment expired in ISO-8601 format.
        /// </summary>
        [DataMember(Name = "failedAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime FailedAt { get; set; }

        /// <summary>
        /// The profile ID this payment belongs to.
        /// 
        /// @example pfl_xH2kP6Nc6X
        /// </summary>
        [DataMember(Name = "profileId", EmitDefaultValue = false, IsRequired = false)]
        public string ProfileId { get; set; }

        /// <summary>
        /// Either "first", "recurring", or "oneoff" for regular payments.
        /// </summary>
        [DataMember(Name = "sequenceType", EmitDefaultValue = false, IsRequired = false)]
        public string SequenceType { get; set; }

        /// <summary>
        /// Redirect URL set on this payment
        /// </summary>
        [DataMember(Name = "redirectUrl", EmitDefaultValue = false, IsRequired = false)]
        public Uri RedirectUrl { get; set; }

        /// <summary>
        /// Webhook URL set on this payment
        /// </summary>
        [DataMember(Name = "webhookUrl", EmitDefaultValue = false, IsRequired = false)]
        public Uri WebhookUrl { get; set; }

        /// <summary>
        /// The mandate ID this payment is performed with.
        /// 
        /// @example sub_rVKGtNd6s3
        /// </summary>
        [DataMember(Name = "subscriptionId", EmitDefaultValue = false, IsRequired = false)]
        public string SubscriptionId { get; set; }

        /// <summary>
        /// The order ID this payment belongs to.
        /// 
        /// @example ord_pbjz8x
        /// </summary>
        [DataMember(Name = "orderId", EmitDefaultValue = false, IsRequired = false)]
        public string OrderId { get; set; }

        /// <summary>
        /// The settlement ID this payment belongs to.
        /// 
        /// @example stl_jDk30akdN
        /// </summary>
        [DataMember(Name = "settlementId", EmitDefaultValue = false, IsRequired = false)]
        public string SettlementId { get; set; }

        /// <summary>
        /// The locale used for this payment.
        /// </summary>
        [DataMember(Name = "locale", EmitDefaultValue = false, IsRequired = false)]
        private string _locale;

        public CultureInfo Locale
        {
            get
            {
                return new CultureInfo(_locale);
            }
            set
            {
                _locale = value.Name.Replace("-", "_");
            }
        }

        /// <summary>
        /// During creation of the payment you can set custom metadata that is stored with the payment, and given back whenever you retrieve that payment.
        /// </summary>
        [DataMember(Name = "metadata", EmitDefaultValue = false, IsRequired = false)]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Details of a successfully paid payment are set here. For example, the iDEAL payment method will set Details["consumerName"] and Details["consumerAccount"].
        /// </summary>
        [DataMember(Name = "details", EmitDefaultValue = false, IsRequired = false)]
        public Dictionary<string, string> Details { get; set; }

        /// <summary>
        /// Used to restrict the payment methods available to your customer to those from a single country.
        /// </summary>
        [DataMember(Name = "restrictPaymentMethodsToCountry", EmitDefaultValue = false, IsRequired = false)]
        public string RestrictPaymentMethodsToCountry { get; set; }

        /// <summary>
        /// Whether or not this payment can be canceled.
        /// </summary>
        [DataMember(Name = "isCancelable", EmitDefaultValue = false, IsRequired = false)]
        public bool IsCancelable { get; set; }

        /// <summary>
        /// The total amount that is already captured for this payment. Only available when this payment supports captures.
        /// </summary>
        [DataMember(Name = "amountCaptured", EmitDefaultValue = false, IsRequired = false)]
        public Amount AmountCaptured { get; set; }

        /// <summary>
        /// The application fee, if the payment was created with one. Contains amount (the value and currency) and description.
        /// </summary>
        [DataMember(Name = "applicationFeeAmount", EmitDefaultValue = false, IsRequired = false)]
        public Amount ApplicationFeeAmount { get; set; }

        /// <summary>
        /// The date and time the payment became authorized, in ISO 8601 format. This parameter is omitted if the payment is not authorized(yet).
        /// 
        /// @example "2013-12-25T10:30:54+00:00"
        /// </summary>
        [DataMember(Name = "authorizedAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime AuthorizedAt { get; set; }

        /// <summary>
        /// The date and time the payment was expired, in ISO 8601 format. This parameter is omitted if the payment did not expire(yet).
        /// 
        /// @example "2013-12-25T10:30:54+00:00"
        /// </summary>
        [DataMember(Name = "expiredAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime ExpiredAt { get; set; }

        /// <summary>
        /// If a customer was specified upon payment creation, the customer’s token will be available here as well.
        /// 
        /// @example cst_XPn78q9CfT
        /// </summary>
        [DataMember(Name = "customerId", EmitDefaultValue = false, IsRequired = false)]
        public string CustomerId { get; set; }

        /// <summary>
        /// This optional field contains your customer’s ISO 3166-1 alpha-2 country code, detected by us during checkout. For example: BE. This field is omitted if the country code was not detected.
        /// </summary>
        [DataMember(Name = "countryCode", EmitDefaultValue = false, IsRequired = false)]
        public string CountryCode { get; set; }

        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public Links Links { get; set; }

        /// <summary>
        /// Is this payment canceled?
        /// </summary>
        /// <returns></returns>
        public bool IsCancelled()
        {
            return Status == PaymentStatus.STATUS_CANCELED;
        }

        /// <summary>
        /// Is this payment expired?
        /// </summary>
        /// <returns></returns>
        public bool IsExpired()
        {
            return Status == PaymentStatus.STATUS_EXPIRED;
        }

        /// <summary>
        /// Is this payment still open / ongoing?
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            return Status == PaymentStatus.STATUS_OPEN;
        }

        /// <summary>
        /// Is this payment pending?
        /// </summary>
        /// <returns></returns>
        public bool IsPending()
        {
            return Status == PaymentStatus.STATUS_PENDING;
        }

        /// <summary>
        /// Is this payment authorized?
        /// </summary>
        /// <returns></returns>
        public bool IsAuthorized()
        {
            return Status == PaymentStatus.STATUS_AUTHORIZED;
        }

        /// <summary>
        /// Is this payment paid for?
        /// </summary>
        /// <returns></returns>
        public bool IsPaid()
        {
            return PaidAt.HasValue;
        }

        /// <summary>
        /// Is this payment failing?
        /// </summary>
        /// <returns></returns>
        public bool IsFailed()
        {
            return Status == PaymentStatus.STATUS_FAILED;
        }

        /// <summary>
        /// Check whether 'sequenceType' is set to 'first'. If a 'first' payment has been completed successfully, the consumer's account may be charged automatically using recurring payments.
        /// </summary>
        /// <returns></returns>
        public bool HasSequenceTypeFirst()
        {
            return SequenceType == Types.SequenceType.SEQUENCETYPE_FIRST;
        }

        /// <summary>
        /// Check whether 'sequenceType' is set to 'recurring'. This type of payment is processed without involving the consumer.
        /// </summary>
        /// <returns></returns>
        public bool HasSequenceTypeRecurring()
        {
            return SequenceType == Types.SequenceType.SEQUENCETYPE_RECURRING;
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CanBeRefunded()
        {
            return AmountRemaining != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CanBePartiallyRefunded()
        {
            return CanBeRefunded();
        }

        /// <summary>
        /// Get the amount that is already refunded
        /// </summary>
        /// <returns></returns>
        public double GetAmountRefunded()
        {
            if (AmountRefunded != null)
                return Convert.ToDouble(AmountRefunded.Value, CultureInfo.InvariantCulture);

            return 0.0;
        }

        /// <summary>
        /// Get the remaining amount that can be refunded. For some payment methods this amount can be higher than the payment amount. This is possible to reimburse the costs for a return shipment to your customer for example.
        /// </summary>
        /// <returns></returns>
        public double GetAmountRemaining()
        {
            if (AmountRemaining != null)
                return Convert.ToDouble(AmountRemaining.Value, CultureInfo.InvariantCulture);

            return 0.0;
        }

        /// <summary>
        /// Does the payment have refunds
        /// </summary>
        /// <returns></returns>
        public bool HasRefunds()
        {
            return Links.Refunds != null;
        }

        /// <summary>
        /// Retrieves the refunds url associated with this payment
        /// </summary>
        public string GetRefundsUrl()
        {
            if (!HasRefunds())
                return null;

            return Links.Refunds.ToString();
        }

        /// <summary>
        /// Does the payment have refunds
        /// </summary>
        /// <returns></returns>
        public bool HasCaptures()
        {
            return Links.Captures != null;
        }

        /// <summary>
        /// Retrieves the captures url associated with this payment
        /// </summary>
        public string GetCapturesUrl()
        {
            if (!HasCaptures())
                return null;

            return Links.Captures.ToString();
        }

        /// <summary>
        /// Does this payment has chargebacks
        /// </summary>
        /// <returns></returns>
        public bool HasChargebacks()
        {
            return Links.Chargebacks != null;
        }

        /// <summary>
        /// Retrieves the chargebacks url associated with this payment
        /// </summary>
        public string GetChargebacksUrl()
        {
            if (!HasChargebacks())
                return null;

            return Links.Chargebacks.ToString();
        }

        /// <summary>
        /// The total amount that is already captured for this payment. Only available when this payment supports captures.
        /// </summary>
        /// <returns></returns>
        public double GetAmountCaptured()
        {
            if (AmountCaptured != null)
                return Convert.ToDouble(AmountCaptured.Value, CultureInfo.InvariantCulture);

            return 0.0;
        }

        /// <summary>
        /// The amount that has been settled.
        /// </summary>
        /// <returns></returns>
        public double GetSettlementAmount()
        {
            if (SettlementAmount != null)
                return Convert.ToDouble(SettlementAmount.Value, CultureInfo.InvariantCulture);

            return 0.0;
        }

        /// <summary>
        /// The total amount that is already captured for this payment. Only available when this payment supports captures.
        /// </summary>
        /// <returns></returns>
        public double GetApplicationFeeAmount()
        {
            if (ApplicationFeeAmount != null)
                return Convert.ToDouble(ApplicationFeeAmount.Value, CultureInfo.InvariantCulture);

            return 0.0;
        }
    }
}
