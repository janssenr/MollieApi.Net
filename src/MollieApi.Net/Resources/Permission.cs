using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Permission : BaseResource
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false, IsRequired = false)]
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "granted", EmitDefaultValue = false, IsRequired = false)]
        public bool Granted { get; set; }

        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public Links Links { get; set; }
    }
}
