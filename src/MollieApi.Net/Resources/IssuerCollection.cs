using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class IssuerCollection : BaseCollection<Issuer>
    {
        public override string GetCollectionResourceName()
        {
            return "issuers";
        }
    }
}
