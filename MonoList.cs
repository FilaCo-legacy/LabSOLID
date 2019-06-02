using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LabSOLID
{
    /// <summary>
    /// Represents a mono-direction list
    /// </summary>
    public class MonoList <T> : IEnumerable<T>
    {
        private MonoList<T> _next;

        private readonly T _data;

        public MonoList (T data)
        {
            _data = data;
        }
        
        public void AddEnd(T data)
        {
            var cur = this;
            
            while (cur._next != null)
                cur = cur._next;
            
            cur._next = new MonoList<T>(data);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var cur = this;

            while (!(cur is null))
            {
                yield return cur._data;
                
                cur = cur._next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
