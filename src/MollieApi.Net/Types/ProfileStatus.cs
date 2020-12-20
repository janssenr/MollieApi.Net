namespace MollieApi.Net.Types
{
    public class ProfileStatus
    {
        /// <summary>
        /// The profile has not been verified yet and can only be used to create test payments.
        /// </summary>
        public const string STATUS_UNVERIFIED = "unverified";

        /// <summary>
        /// The profile has been verified and can be used to create live payments and test payments.
        /// </summary>
        public const string STATUS_VERIFIED = "verified";

        /// <summary>
        /// The profile is blocked and can thus no longer be used or changed.
        /// </summary>
        public const string STATUS_BLOCKED = "blocked";
    }
}
