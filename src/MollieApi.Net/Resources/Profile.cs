using MollieApi.Net.Types;
using System;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Profile : BaseResource
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "mode", EmitDefaultValue = false, IsRequired = false)]
        public string Mode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, IsRequired = false)]
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "website", EmitDefaultValue = false, IsRequired = false)]
        public Uri Website { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = false, IsRequired = false)]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "phone", EmitDefaultValue = false, IsRequired = false)]
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "categoryCode", EmitDefaultValue = false, IsRequired = false)]
        public int CategoryCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "review", EmitDefaultValue = false, IsRequired = false)]
        public Review Review { get; set; }

        /// <summary>
        /// UTC datetime the profile was created in ISO-8601 format.
        /// </summary>
        [DataMember(Name = "createdAt", EmitDefaultValue = false, IsRequired = false)]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "_links", EmitDefaultValue = false, IsRequired = false)]
        public Links Links { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsUnverified()
        {
            return Status == ProfileStatus.STATUS_UNVERIFIED;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsVerified()
        {
            return Status == ProfileStatus.STATUS_VERIFIED;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsBlocked()
        {
            return Status == ProfileStatus.STATUS_BLOCKED;
        }
    }
}
