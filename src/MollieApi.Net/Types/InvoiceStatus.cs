namespace MollieApi.Net.Types
{
    public class InvoiceStatus
    {
        /// <summary>
        /// The invoice is not paid yet.
        /// </summary>
        public const string STATUS_OPEN = "open";

        /// <summary>
        /// The invoice is paid.
        /// </summary>
        public const string STATUS_PAID = "paid";

        /// <summary>
        /// Payment of the invoice is overdue.
        /// </summary>
        public const string STATUS_OVERDUE = "overdue";
    }
}
