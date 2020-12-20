using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class MethodPrice : BaseResource
    {
        /// <summary>
        /// The area or product-type where the pricing is applied for, translated in the optional locale passed.
        /// </summary>
        [DataMember(Name = "description", EmitDefaultValue = false, IsRequired = false)]
        public string Description { get; set; }

        /// <summary>
        /// The fixed price per transaction. This excludes the variable amount.
        /// </summary>
        [DataMember(Name = "fixed", EmitDefaultValue = false, IsRequired = false)]
        public Amount Fixed { get; set; }

        /// <summary>
        /// A string containing the percentage being charged over the payment amount besides the fixed price.
        /// </summary>
        [DataMember(Name = "variable", EmitDefaultValue = false, IsRequired = false)]
        public string Variable { get; set; }
    }
}
