using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class QRCode
    {
        [DataMember(Name = "height", EmitDefaultValue = false, IsRequired = false)]
        public string Height { get; set; }

        [DataMember(Name = "width", EmitDefaultValue = false, IsRequired = false)]
        public string Width { get; set; }

        [DataMember(Name = "src", EmitDefaultValue = false, IsRequired = false)]
        public string Src { get; set; }
    }
}
