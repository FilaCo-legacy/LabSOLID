using System.Text.RegularExpressions;

namespace LabSOLID.ParsingStructs.IdParsers
{
    public class IdParsersContainer : BaseIdParser
    {
        protected override string Pattern { get; }

        public override Id Parse(string source)
        {
            source = Regex.Replace(source, @"\s+", " ");
            
            return base.Parse(source);
        }

        public void Add(IdParser parser)
        {
            var cur = (IdParser)this;

            while (!(cur.Next is null))
                cur = cur.Next;

            cur.Next = parser;
        }
    }
}