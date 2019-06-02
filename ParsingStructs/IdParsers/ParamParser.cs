using System.Text.RegularExpressions;
using LabSOLID.ParsingStructs.ValueParsers;

namespace LabSOLID.ParsingStructs.IdParsers
{
    public class ParamParser
    {
        private static string Pattern =>  @"^(ref\s+|out\s+)?(?!(ref|out)\s)[^\d\s]\w*\s+(?!(ref|out|int|char|bool|string|float)$)[^\d\s]\w*$";

        private static bool CanHandle(string source)
        {
            var regex = new Regex(Pattern);

            return regex.IsMatch(source);
        }
        
        public IValueParser ValueParser { get; set; }

        public ParamParser(IValueParser parser)
        {
            ValueParser = parser;
        }

        public Param Parse(string source)
        {
            if (!CanHandle(source))
                return null;
            
            source = source.Trim(' ');
            var inp = source.Split(' ');
            var transerType = TransferType.param_val;
            switch (inp[0])
            {
                case "ref":
                    transerType = TransferType.param_ref;
                    break;
                case "out":
                    transerType = TransferType.param_out;
                    break;
                default:
                    return new Param(ValueParser.Parse(inp[0]), transerType);
            }
                
            return new Param(ValueParser.Parse(inp[1]), transerType);
        }
    }
}