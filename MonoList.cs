using System.Collections;
using System.Collections.Generic;

namespace LabSOLID
{
    /// <summary>
    /// Represents a mono-direction list
    /// </summary>
    public class MonoList <T> : IEnumerable<T>
    {
        protected MonoList<T> _next;

        public T Data { get; }

        public MonoList (T data)
        {
            Data = data;
        }
        
        public MonoList () {}
        
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
                yield return cur.Data;
                
                cur = cur._next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
