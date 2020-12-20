using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class RefundCollection : CursorCollection<Refund>
    {
        public override string GetCollectionResourceName()
        {
            return "refunds";
        }
    }
}
