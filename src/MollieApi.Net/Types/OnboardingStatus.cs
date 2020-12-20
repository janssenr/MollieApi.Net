namespace MollieApi.Net.Types
{
    public class OnboardingStatus
    {
        /// <summary>
        /// The onboarding is not completed and the merchant needs to provide (more) information
        /// </summary>
        public const string NEEDS_DATA = "needs-data";

        /// <summary>
        /// The merchant provided all information and Mollie needs to check this
        /// </summary>
        public const string IN_REVIEW = "in-review";

        /// <summary>
        /// The onboarding is completed
        /// </summary>
        public const string COMPLETED = "completed";
    }
}
