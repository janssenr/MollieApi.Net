using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class MandateCollection : CursorCollection<Mandate>
    {
        public override string GetCollectionResourceName()
        {
            return "mandates";
        }

        public MandateCollection Where(string status)
        {
            var collection = new MandateCollection();
            foreach (var item in this)
            {
                if (item.Status == status)
                    collection.Add(item);
            }
            return collection;
        }

        public bool HasValidMandate()
        {
            foreach (var item in this)
            {
                if (item.IsValid())
                    return true;
            }
            return false;
        }

        public bool HasValidMandateForMethod(string method)
        {
            foreach (var item in this)
            {
                if (item.Method == method && item.IsValid())
                    return true;
            }
            return false;
        }
    }
}
