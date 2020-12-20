using MollieApi.Net.Types;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Mandate : BaseResource
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "mode", EmitDefaultValue = false, IsRequired = false)]
        public string Mode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "method", EmitDefaultValue = false, IsRequired = false)]
        public string Method { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "details", EmitDefaultValue = false, IsRequired = false)]
        public Dictionary<string, string> Details { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "customerId", EmitDefaultValue = false, IsRequired = false)]
        public string CustomerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "mandateReference", EmitDefaultValue = false, IsRequired = false)]
        public string MandateReference { get; set; }

        /// <summary>
        /// Date of signature, for example: 2018-05-07
        /// </summary>
        [DataMember(Name = "signatureDate", EmitDefaultValue = false, IsRequired = false)]
        public DateTime SignatureDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false, IsRequired = false)]
        public Links Links { get; set; }

        public bool IsValid()
        {
            return Status == MandateStatus.STATUS_VALID;
        }

        public bool IsPending()
        {
            return Status == MandateStatus.STATUS_PENDING;
        }

        public bool IsInvalid()
        {
            return Status == MandateStatus.STATUS_INVALID;
        }
    }
}
