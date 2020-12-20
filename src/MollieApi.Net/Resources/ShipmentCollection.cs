using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class ShipmentCollection : BaseCollection<Shipment>
    {
        public override string GetCollectionResourceName()
        {
            return "shipments";
        }
    }
}
