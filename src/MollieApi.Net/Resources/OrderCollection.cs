using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class OrderCollection : CursorCollection<Order>
    {
        public override string GetCollectionResourceName()
        {
            return "orders";
        }
    }
}
