using System;

namespace LabSOLID.ParsingStructs.ValueParsers
{
    public abstract class BaseValueParser : IValueParser
    {
        protected abstract string Pattern { get; }

        protected bool CanHandle(string source) => Pattern == source;

        public IValueParser Next { get; set; }

        public virtual Value Parse(string source)
        {
            if (!(Next is null))
                return Next.Parse(source);
            
            throw new Exception("Undefined value type");
        }
    }
}