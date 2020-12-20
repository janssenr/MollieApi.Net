using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class CaptureCollection : BaseCollection<Capture>
    {
        public override string GetCollectionResourceName()
        {
            return "captures";
        }
    }
}
