namespace MollieApi.Net.Types
{
    public class SubscriptionStatus
    {
        public const string STATUS_ACTIVE = "active";
        public const string STATUS_PENDING = "pending";   // Waiting for a valid mandate.
        public const string STATUS_CANCELED = "canceled";
        public const string STATUS_SUSPENDED = "suspended"; // Active, but mandate became invalid.
        public const string STATUS_COMPLETED = "completed";
    }
}
