using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class ProfileCollection : CursorCollection<Profile>
    {
        public override string GetCollectionResourceName()
        {
            return "profiles";
        }
    }
}
