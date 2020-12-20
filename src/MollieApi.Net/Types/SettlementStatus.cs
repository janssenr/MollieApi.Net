namespace MollieApi.Net.Types
{
    public class SettlementStatus
    {
        /// <summary>
        /// The settlement has not been closed yet.
        /// </summary>
        public const string STATUS_OPEN = "open";

        /// <summary>
        /// The settlement has been closed and is being processed.
        /// </summary>
        public const string STATUS_PENDING = "pending";

        /// <summary>
        /// The settlement has been paid out.
        /// </summary>
        public const string STATUS_PAIDOUT = "paidout";

        /// <summary>
        /// The settlement could not be paid out.
        /// </summary>
        public const string STATUS_FAILED = "failed";
    }
}
