using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class PermissionCollection : BaseCollection<Permission>
    {
        public override string GetCollectionResourceName()
        {
            return "permissions";
        }
    }
}
