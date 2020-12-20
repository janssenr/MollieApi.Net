using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class ChargebackCollection : BaseCollection<Chargeback>
    {
        public override string GetCollectionResourceName()
        {
            return "chargebacks";
        }
    }
}
