namespace MollieApi.Net.Types
{
    public class RefundStatus
    {
        /// <summary>
        /// The refund is queued until there is enough balance to process te refund. You can still cancel the refund. 
        /// </summary>
        public const string STATUS_QUEUED = "queued";

        /// <summary>
        /// The refund will be sent to the bank on the next business day. You can still cancel the refund.
        /// </summary>
        public const string STATUS_PENDING = "pending";

        /// <summary>
        /// The refund has been sent to the bank. The refund amount will be transferred to the consumer account as soon as possible.
        /// </summary>
        public const string STATUS_PROCESSING = "processing";

        /// <summary>
        /// The refund amount has been transferred to the consumer.
        /// </summary>
        public const string STATUS_REFUNDED = "refunded";
    }
}
