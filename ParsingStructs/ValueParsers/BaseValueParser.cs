using System;

namespace LabSOLID.ParsingStructs.ValueParsers
{
    public abstract class BaseValueParser : MonoList<IValueParser>, IValueParser
    {
        protected abstract string Pattern { get; }

        protected bool CanHandle(string source) => Pattern != source;
        
        public virtual Value Parse(string source)
        {
            if (_next != null)
                return _next.Data.Parse(source);
            
            throw new Exception("Undefined value type");
        }
    }
}