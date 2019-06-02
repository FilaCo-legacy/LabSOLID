using System.Collections;
using System.Collections.Generic;

namespace LabSOLID
{
    /// <summary>
    /// Represents a mono-direction list
    /// </summary>
    public class MonoList <T> : IEnumerable<T>
    {
        private MonoListEntry<T> _root;

        public bool Empty => _root is null;

        public MonoList()
        {
            _root = null;
        }
        
        public void AddEnd(T data)
        {
            if (Empty)
            {
                _root = new MonoListEntry<T>(data);
                return;
            }

            var cur = _root;
            
            while (!(cur.Next is null))
                cur = cur.Next;
            
            cur.Next = new MonoListEntry<T>(data);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var cur = _root;

            while (!(cur is null))
            {
                yield return cur.Data;
                
                cur = cur.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
