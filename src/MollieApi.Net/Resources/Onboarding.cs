using MollieApi.Net.Types;
using System;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Onboarding : BaseResource
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, IsRequired = false)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "signedUpAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime SignedUpAt { get; set; }

        /// <summary>
        /// Either "needs-data", "in-review" or "completed".
        /// Indicates this current status of the organization’s onboarding process.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "canReceivePayments", EmitDefaultValue = false, IsRequired = false)]
        public bool CanReceivePayments { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "canReceiveSettlements", EmitDefaultValue = false, IsRequired = false)]
        public bool CanReceiveSettlements { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false, IsRequired = false)]
        public Links Links { get; set; }

        public bool NeedsData()
        {
            return Status == OnboardingStatus.NEEDS_DATA;
        }

        public bool IsInReview()
        {
            return Status == OnboardingStatus.IN_REVIEW;
        }

        public bool IsCompleted()
        {
            return Status == OnboardingStatus.COMPLETED;
        }
    }
}
