namespace LabSOLID.ParsingStructs.IdParsers
{
    public class ParsersContainer:BaseIdParser
    {
        protected override string Pattern { get; }

        public void Add(IdParser parser)
        {
            var curParser = (IdParser)this;

            while (!(curParser is null))
                curParser = curParser.Next;

            curParser.Next = parser;
        }
    }
}