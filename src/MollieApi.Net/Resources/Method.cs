using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Method : BaseResource
    {
        /// <summary>
        /// More legible description of the payment method.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false, IsRequired = false)]
        public string Description { get; set; }

        /// <summary>
        /// An object containing value and currency. It represents the minimum payment amount required to use this payment method.
        /// </summary>
        [DataMember(Name = "minimumAmount", EmitDefaultValue = false, IsRequired = false)]
        public Amount MinimumAmount { get; set; }

        /// <summary>
        /// An object containing value and currency. It represents the maximum payment amount allowed when using this payment method.
        /// </summary>
        [DataMember(Name = "maximumAmount", EmitDefaultValue = false, IsRequired = false)]
        public Amount MaximumAmount { get; set; }

        /// <summary>
        /// The $image->size1x and $image->size2x to display the payment method logo.
        /// </summary>
        [DataMember(Name = "image", EmitDefaultValue = false, IsRequired = false)]
        public Image Image { get; set; }

        /// <summary>
        /// The issuers available for this payment method. Only for the methods iDEAL, KBC/CBC and gift cards.
        /// Will only be filled when explicitly requested using the query string `include` parameter.
        /// </summary>
        [DataMember(Name = "issuers", EmitDefaultValue = false, IsRequired = false)]
        public IList<Issuer> Issuers { get; set; }

        /// <summary>
        /// The pricing for this payment method. Will only be filled when explicitly requested using the query string `include` parameter.
        /// </summary>
        [DataMember(Name = "pricing", EmitDefaultValue = false, IsRequired = false)]
        public IList<MethodPrice> Pricing { get; set; }

        /// <summary>
        /// The activation status the method is in.
        /// </summary>
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public string Status { get; set; }

        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public Links Links { get; set; }
    }
}
