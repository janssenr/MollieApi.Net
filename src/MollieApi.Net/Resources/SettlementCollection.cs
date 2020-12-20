using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class SettlementCollection : CursorCollection<Settlement>
    {
        public override string GetCollectionResourceName()
        {
            return "settlements";
        }
    }
}
