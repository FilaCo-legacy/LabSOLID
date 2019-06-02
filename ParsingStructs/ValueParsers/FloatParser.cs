namespace LabSOLID.ParsingStructs.ValueParsers
{
    public class FloatParser:BaseValueParser
    {
        protected override string Pattern => "float";

        public override Value Parse(string source)
        {
            return CanHandle(source) ? Value.float_type : base.Parse(source);
        }
    }
}