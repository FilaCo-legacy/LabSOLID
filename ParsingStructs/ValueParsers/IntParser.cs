namespace LabSOLID.ParsingStructs.ValueParsers
{
    public class IntParser:BaseValueParser
    {
        protected override string Pattern => "int";

        public override Value Parse(string source)
        {
            return CanHandle(source) ? Value.int_type : base.Parse(source);
        }
    }
}