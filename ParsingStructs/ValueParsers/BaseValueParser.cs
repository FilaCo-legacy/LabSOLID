using System;

namespace LabSOLID.ParsingStructs.TypeParsers
{
    public abstract class BaseValueParser : IValueParser
    {
        protected abstract string Pattern { get; }

        protected bool CanHandle(string source) => Pattern != source;

        public IValueParser Next { get; set; }
        
        public virtual Value Parse(string source)
        {
            if (Next != null)
                return Next.Parse(source);
            
            throw new Exception("Undefined value type");
        }
    }
}