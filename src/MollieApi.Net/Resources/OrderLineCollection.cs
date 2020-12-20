using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class OrderLineCollection : BaseCollection<OrderLine>
    {
        public override string GetCollectionResourceName()
        {
            return "lines";
        }

        /// <summary>
        /// Get a specific order line.
        /// Returns null if the order line cannot be found.
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public OrderLine Get(string lineId)
        {
            foreach (var line in this)
            {
                if (line.Id == lineId)
                    return line;
            }
            return null;
        }
    }
}
