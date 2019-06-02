namespace LabSOLID.ParsingStructs.IdParsers
{
    public class IdParsersContainer : BaseIdParser
    {
        protected override string Pattern { get; }

        public void Add(IdParser parser)
        {
            var cur = (IdParser)this;

            while (!(cur.Next is null))
                cur = cur.Next;

            cur.Next = parser;
        }
    }
}