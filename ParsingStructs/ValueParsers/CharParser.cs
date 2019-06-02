namespace LabSOLID.ParsingStructs.ValueParsers
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