using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class OrderAddress : Address
    {
        [DataMember(Name = "organizationName", EmitDefaultValue = false, IsRequired = false)]
        public string OrganizationName { get; set; }

        [DataMember(Name = "title", EmitDefaultValue = false, IsRequired = false)]
        public string Title { get; set; }

        [DataMember(Name = "givenName", EmitDefaultValue = false, IsRequired = true)]
        public string GivenName { get; set; }

        [DataMember(Name = "familyName", EmitDefaultValue = false, IsRequired = true)]
        public string FamilyName { get; set; }

        [DataMember(Name = "email", EmitDefaultValue = false, IsRequired = true)]
        public string Email { get; set; }

        [DataMember(Name = "phone", EmitDefaultValue = false, IsRequired = false)]
        public string Phone { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is OrderAddress orderAddress)) return false;
            if (!base.Equals(obj)) return false;
            if (!Equals(orderAddress.OrganizationName, OrganizationName)) return false;
            if (!Equals(orderAddress.Title, Title)) return false;
            if (!Equals(orderAddress.GivenName, GivenName)) return false;
            if (!Equals(orderAddress.FamilyName, FamilyName)) return false;
            if (!Equals(orderAddress.Email, Email)) return false;
            if (!Equals(orderAddress.Phone, Phone)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = 513945765;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(OrganizationName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GivenName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FamilyName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Phone);
            return hashCode;
        }
    }
}
