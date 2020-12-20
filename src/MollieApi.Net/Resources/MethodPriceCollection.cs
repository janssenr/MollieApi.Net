using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class MethodPriceCollection : BaseCollection<MethodPrice>
    {
        public override string GetCollectionResourceName()
        {
            return "pricing";
        }
    }
}
