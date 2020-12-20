using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class OrganizationCollection : CursorCollection<Organization>
    {
        public override string GetCollectionResourceName()
        {
            return "organizations";
        }
    }
}
