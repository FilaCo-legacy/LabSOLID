namespace LabSOLID.ParsingStructs.TypeParsers
{
    public class StringParser:BaseValueParser
    {
        protected override string Pattern => "string";

        public override Value Parse(string source)
        {
            return CanHandle(source) ? Value.string_type : base.Parse(source);
        }
    }
}