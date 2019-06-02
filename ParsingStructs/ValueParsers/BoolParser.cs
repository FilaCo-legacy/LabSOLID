namespace LabSOLID.ParsingStructs.TypeParsers
{
    public class BoolParser:BaseValueParser
    {
        protected override string Pattern => "bool";

        public override Value Parse(string source)
        {
            return CanHandle(source) ? Value.bool_type : base.Parse(source);
        }
    }
}