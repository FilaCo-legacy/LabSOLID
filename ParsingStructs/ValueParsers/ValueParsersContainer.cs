using System.Text.RegularExpressions;
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

        public override Value Parse(string source)
        {
            source = Regex.Replace(source, @"\s+", " ");
            
            return base.Parse(source);
        }
    }
}