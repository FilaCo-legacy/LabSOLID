namespace LabSOLID.ParsingStructs.TypeParsers
{
    public class CharParser : BaseValueParser
    {
        protected override string Pattern => "char";

        public override Value Parse(string source)
        {
            return CanHandle(source) ? Value.char_type : base.Parse(source);
        }
    }
}