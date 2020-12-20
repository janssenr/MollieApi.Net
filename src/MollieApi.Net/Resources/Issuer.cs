using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Issuer : BaseResource
    {
        /// <summary>
        /// Name of the issuer.
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false, IsRequired = false)]
        public string Name { get; set; }

        /// <summary>
        /// The payment method this issuer belongs to.
        /// </summary>
        [DataMember(Name = "method", EmitDefaultValue = false, IsRequired = false)]
        public string Method { get; set; }

        /// <summary>
        /// Object containing a size1x or size2x image
        /// </summary>
        [DataMember(Name = "image", EmitDefaultValue = false, IsRequired = false)]
        public Image Image { get; set; }
    }
}
