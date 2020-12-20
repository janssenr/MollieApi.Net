using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public abstract class CursorCollection<T> : BaseCollection<T>
    {
        public bool HasNext()
        {
            return Links.Next != null;
        }

        public string GetNextUrl()
        {
            if (!HasNext())
                return null;

            return Links.Next.ToString();
        }

        public bool HasPrevious()
        {
            return Links.Previous != null;
        }

        public string GetPreviousUrl()
        {
            if (!HasPrevious())
                return null;

            return Links.Previous.ToString();
        }
    }
}
