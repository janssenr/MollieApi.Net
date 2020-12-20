using System;

namespace MollieApi.Net.Types
{
    public class OrderStatus
    {
        /// <summary>
        /// The order has just been created.
        /// </summary>
        public const string STATUS_CREATED = "created";

        /// <summary>
        /// The order has been paid.
        /// </summary>
        public const string STATUS_PAID = "paid";

        /// <summary>
        /// The order has been authorized.
        /// </summary>
        public const string STATUS_AUTHORIZED = "authorized";

        /// <summary>
        /// The order has been canceled.
        /// </summary>
        public const string STATUS_CANCELED = "canceled";

        /// <summary>
        /// The order is shipping.
        /// </summary>
        public const string STATUS_SHIPPING = "shipping";

        /// <summary>
        /// The order is completed.
        /// </summary>
        public const string STATUS_COMPLETED = "completed";

        /// <summary>
        /// The order is expired.
        /// </summary>
        public const string STATUS_EXPIRED = "expired";

        /// <summary>
        /// The order is pending.
        /// </summary>
        public const string STATUS_PENDING = "pending";

        /// <summary>
        /// The order has been refunded.
        /// </summary>
        [Obsolete]
        public const string STATUS_REFUNDED = "refunded";
    }
}
