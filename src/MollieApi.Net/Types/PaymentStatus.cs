namespace MollieApi.Net.Types
{
    public class PaymentStatus
    {
        /// <summary>
        /// The payment has just been created, no action has happened on it yet.
        /// </summary>
        public const string STATUS_OPEN = "open";

        /// <summary>
        /// The payment has just been started, no final confirmation yet.
        /// </summary>
        public const string STATUS_PENDING = "pending";

        /// <summary>
        /// The payment is authorized, but captures still need to be created in order to receive the money.
        ///
        /// This is currently only possible for Klarna Pay later and Klarna Slice it.Payments with these payment methods can
        /// only be created with the Orders API.You should create a Shipment to trigger the capture to receive the money.
        ///
        /// @see https://docs.mollie.com/reference/v2/shipments-api/create-shipment
        /// </summary>
        public const string STATUS_AUTHORIZED = "authorized";

        /// <summary>
        /// The customer has canceled the payment.
        /// </summary>
        public const string STATUS_CANCELED = "canceled";

        /// <summary>
        /// The payment has expired due to inaction of the customer.
        /// </summary>
        public const string STATUS_EXPIRED = "expired";

        /// <summary>
        /// The payment has been paid.
        /// </summary>
        public const string STATUS_PAID = "paid";

        /// <summary>
        /// The payment has failed.
        /// </summary>
        public const string STATUS_FAILED = "failed";
    }
}
