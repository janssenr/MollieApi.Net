using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class InvoiceCollection : BaseCollection<Invoice>
    {
        public override string GetCollectionResourceName()
        {
            return "invoices";
        }
    }
}
