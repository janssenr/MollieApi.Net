using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public abstract class BaseResource
    {
        [DataMember(Name = "resource", EmitDefaultValue = false, IsRequired = false)]
        public string Resource { get; set; }

        [DataMember(Name = "id", EmitDefaultValue = false, IsRequired = false)]
        public string Id { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is BaseResource resource)) return false;
            if (!Equals(resource.Resource, Resource)) return false;
            if (!Equals(resource.Id, Id)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = -302822051;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Resource);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            return hashCode;
        }
    }
}
