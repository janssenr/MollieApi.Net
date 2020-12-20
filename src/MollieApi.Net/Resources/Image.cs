using System;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Image
    {
        [DataMember(Name = "size1x", EmitDefaultValue = false, IsRequired = false)]
        public Uri Size1x { get; set; }

        [DataMember(Name = "size2x", EmitDefaultValue = false, IsRequired = false)]
        public Uri Size2x { get; set; }

        [DataMember(Name = "svg", EmitDefaultValue = false, IsRequired = false)]
        public Uri Svg { get; set; }
    }
}
