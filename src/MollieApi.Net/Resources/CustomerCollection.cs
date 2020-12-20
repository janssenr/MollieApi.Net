using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class CustomerCollection : BaseCollection<Customer>
    {
        public override string GetCollectionResourceName()
        {
            return "customers";
        }
    }
}
