using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace MollieApi.Net.Resources
{
    [DataContract]
    public abstract class BaseCollection<T> : IList<T>
    {
        private List<T> _collection;

        public abstract string GetCollectionResourceName();

        [DataMember(Name = "count", EmitDefaultValue = false)]
        public int Count
        {
            get
            {
                return _collection.Count;
            }
            set { }
        }

        [DataMember(Name = "_embedded", EmitDefaultValue = false)]
        private Dictionary<string, T[]> Embedded
        {
            get
            {
                return new Dictionary<string, T[]>
                {
                    { GetCollectionResourceName(), _collection.ToArray() }
                };
            }
            set
            {
                _collection = value[GetCollectionResourceName()].ToList();
            }
        }

        [DataMember(Name = "_links", EmitDefaultValue = false)]
        public Links Links { get; set; }

        public BaseCollection()
        {
            _collection = new List<T>();
        }

        public int IndexOf(T item)
        {
            return _collection.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _collection.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _collection.RemoveAt(index);
        }

        public void Add(T item)
        {
            _collection.Add(item);
        }

        public void Clear()
        {
            _collection.Clear();
        }

        public bool Contains(T item)
        {
            return _collection.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _collection.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return _collection.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        public bool IsReadOnly => false;

        public T this[int index] { get => _collection[index]; set => _collection[index] = value; }
    }
}
