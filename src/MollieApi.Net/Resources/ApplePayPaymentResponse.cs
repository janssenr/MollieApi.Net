using System;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class ApplePayPaymentResponse
    {
        [DataMember(Name = "epochTimestamp", EmitDefaultValue = false, IsRequired = true)]
        public TimeSpan EpochTimestamp { get; set; }

        [DataMember(Name = "expiresAt", EmitDefaultValue = false, IsRequired = true)]
        public TimeSpan ExpiresAt { get; set; }

        [DataMember(Name = "merchantSessionIdentifier", EmitDefaultValue = false, IsRequired = true)]
        public string MerchantSessionIdentifier { get; set; }

        [DataMember(Name = "nonce", EmitDefaultValue = false, IsRequired = true)]
        public string Nonce { get; set; }

        [DataMember(Name = "merchantIdentifier", EmitDefaultValue = false, IsRequired = true)]
        public string MerchantIdentifier { get; set; }

        [DataMember(Name = "domainName", EmitDefaultValue = false, IsRequired = true)]
        public string DomainName { get; set; }

        [DataMember(Name = "displayName", EmitDefaultValue = false, IsRequired = true)]
        public string DisplayName { get; set; }

        [DataMember(Name = "signature", EmitDefaultValue = false, IsRequired = true)]
        public string Signature { get; set; }
    }
}
