namespace MollieApi.Net.Types
{
    public class PaymentMethodStatus
    {
        /// <summary>
        /// The payment method is activated and ready for use.
        /// </summary>
        public const string ACTIVATED = "activated";

        /// <summary>
        /// Mollie is waiting for you to finish onboarding in the Merchant Dashboard before the payment method can be activated.
        /// </summary>
        public const string PENDING_ONBOARDING = "pending-boarding";

        /// <summary>
        /// Mollie needs to review your request for this payment method before it can be activated.
        /// </summary>
        public const string PENDING_REVIEW = "pending-review";

        /// <summary>
        /// Activation of this payment method relies on you taking action with an external party, for example signing up with PayPal or a giftcard issuer.
        /// </summary>
        public const string PENDING_EXTERNAL = "pending-external";

        /// <summary>
        /// Your request for this payment method was rejected.
        /// Whenever Mollie rejects such a request, you will always be informed via email.
        /// </summary>
        public const string REJECTED = "rejected";

        /// <summary>
        /// This payment method was not requested.
        /// </summary>
        public const string NOT_REQUESTED = null;
    }
}
