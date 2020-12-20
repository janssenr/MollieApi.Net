using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public class EntityCollectionWorkaround<EntityType> : ICollection<EntityType>
    {
        #region Constructor
        public EntityCollectionWorkaround()
        {
            Entities = new List<EntityType>();
        }
        #endregion

        [DataMember]
        public int AdditionalProperty { get; set; }

        [DataMember]
        public List<EntityType> Entities { get; set; }

        #region ICollection<T> Members

        public void Add(EntityType item)
        {
            Entities.Add(item);
        }

        public void Clear()
        {
            this.Entities.Clear();
        }

        public bool Contains(EntityType item)
        {
            return Entities.Contains(item);
        }

        public void CopyTo(EntityType[] array, int arrayIndex)
        {
            this.Entities.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                return this.Entities.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public bool Remove(EntityType item)
        {
            return this.Entities.Remove(item);
        }

        public EntityType this[int index]
        {
            get
            {
                return this.Entities[index];
            }
            set
            {
                this.Entities[index] = value;
            }
        }
        #endregion

        #region IEnumerable<T> Members

        public IEnumerator<EntityType> GetEnumerator()
        {
            return this.Entities.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.Entities.GetEnumerator();
        }

        #endregion
    }
}
