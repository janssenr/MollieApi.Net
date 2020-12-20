using System;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class ApplePayPaymentRequest
    {
        [DataMember(Name = "profileId", EmitDefaultValue = false, IsRequired = false)]
        public string ProfileId { get; set; }

        [DataMember(Name = "validationUrl", EmitDefaultValue = false, IsRequired = true)]
        public Uri ValidationUrl { get; set; }

        [DataMember(Name = "domain", EmitDefaultValue = false, IsRequired = true)]
        public string Domain { get; set; }
    }
}
