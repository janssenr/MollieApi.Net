using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class MethodCollection : BaseCollection<Method>
    {
        public override string GetCollectionResourceName()
        {
            return "methods";
        }
    }
}
