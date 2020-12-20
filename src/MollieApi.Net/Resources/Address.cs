using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class Address
    {
        [DataMember(Name = "streetAndNumber", EmitDefaultValue = false, IsRequired = true)]
        public string StreetAndNumber { get; set; }

        [DataMember(Name = "streetAdditional", EmitDefaultValue = false, IsRequired = false)]
        public string StreetAdditional { get; set; }

        [DataMember(Name = "postalCode", EmitDefaultValue = false, IsRequired = false)]
        public string PostalCode { get; set; }

        [DataMember(Name = "city", EmitDefaultValue = false, IsRequired = true)]
        public string City { get; set; }

        [DataMember(Name = "region", EmitDefaultValue = false, IsRequired = false)]
        public string Region { get; set; }

        [DataMember(Name = "country", EmitDefaultValue = false, IsRequired = true)]
        public string Country { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Address address)) return false;
            if (!Equals(address.StreetAndNumber, StreetAndNumber)) return false;
            if (!Equals(address.StreetAdditional, StreetAdditional)) return false;
            if (!Equals(address.PostalCode, PostalCode)) return false;
            if (!Equals(address.City, City)) return false;
            if (!Equals(address.Region, Region)) return false;
            if (!Equals(address.Country, Country)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = 423860704;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StreetAndNumber);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StreetAdditional);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(PostalCode);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(City);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Region);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Country);
            return hashCode;
        }
    }
}
