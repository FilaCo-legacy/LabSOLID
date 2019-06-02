using LabSOLID.ParsingStructs.IdParsers;

namespace LabSOLID.ParsingStructs.ValueParsers
{
    public class ValueParsersContainer : BaseValueParser
    {
        protected override string Pattern { get; }
        
        public void Add(IValueParser parser)
        {
            var cur = (IValueParser)this;

            while (!(cur.Next is null))
                cur = cur.Next;

            cur.Next = parser;
        }

        
    }
}