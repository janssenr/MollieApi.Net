using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class PaymentCollection : CursorCollection<Payment>
    {
        public override string GetCollectionResourceName()
        {
            return "payments";
        }
    }
}
