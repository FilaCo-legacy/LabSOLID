using System.Text.RegularExpressions;

namespace LabSOLID.ParsingStructs
{
    /// <summary>
    /// Represents a one-direction list of params for some <see cref="Method"/> 
    /// </summary>
    public class ListParams
    {
        private ListParams _next;

        private readonly Param _data;

        public ListParams (Param data)
        {
            _data = data;
        }
        
        public void AddEnd(Param data)
        {
            var cur = this;
            
            while (cur._next != null)
                cur = cur._next;
            
            cur._next = new ListParams(data);
        }
        
        public override string ToString()
        {
            var cur = "";
            var pntr = this;
            
            while (pntr != null)
            {
                cur += pntr._data;
                pntr = pntr._next;
            }
            
            return cur;
        }
    }
}
