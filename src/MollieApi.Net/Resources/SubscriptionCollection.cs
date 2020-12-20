using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class SubscriptionCollection : CursorCollection<Subscription>
    {
        public override string GetCollectionResourceName()
        {
            return "subscriptions";
        }
    }
}
