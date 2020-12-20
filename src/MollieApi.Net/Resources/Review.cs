using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Review
    {
        [DataMember(Name = "status", EmitDefaultValue = false, IsRequired = false)]
        public string Status { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Review review)) return false;
            if (!Equals(review.Status, Status)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            return -1618034841 + EqualityComparer<string>.Default.GetHashCode(Status);
        }
    }
}
