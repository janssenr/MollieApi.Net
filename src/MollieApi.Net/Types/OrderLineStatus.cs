using System;

namespace MollieApi.Net.Types
{
    public class OrderLineStatus
    {
        /// <summary>
        /// The order line has just been created.
        /// </summary>
        public const string STATUS_CREATED = "created";

        /// <summary>
        /// The order line has been paid.
        /// </summary>
        public const string STATUS_PAID = "paid";

        /// <summary>
        /// The order line has been authorized.
        /// </summary>
        public const string STATUS_AUTHORIZED = "authorized";

        /// <summary>
        /// The order line has been canceled.
        /// </summary>
        public const string STATUS_CANCELED = "canceled";

        /// <summary>
        /// The order line has been refunded.
        /// </summary>
        [Obsolete]
        public const string STATUS_REFUNDED = "refunded";

        /// <summary>
        /// The order line is shipping.
        /// </summary>
        public const string STATUS_SHIPPING = "shipping";

        /// <summary>
        /// The order line is completed.
        /// </summary>
        public const string STATUS_COMPLETED = "completed";
    }
}
