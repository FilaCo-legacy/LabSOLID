using System.Text.RegularExpressions;
using LabSOLID.ParsingStructs.ValueParsers;

namespace LabSOLID.ParsingStructs.IdParsers
{
    public class MethodParser : BaseIdParser
    {
        protected override string Pattern => @"^\w+\s+(?!(ref|out|int|char|bool|string|float)\s*\()[^\d\s]\w*\s*\(.*\)\s*;$";
        
        public IValueParser ValueParser { get; set; }
        
        public ListParamsParser ListParamsParser { get; set; }

        public MethodParser(IValueParser valueParser, ListParamsParser listParamsParser)
        {
            ValueParser = valueParser;
            ListParamsParser = listParamsParser;
        }
        
        public override Id Parse(string source)
        {
            if (!CanHandle(source))
                return base.Parse(source);
            
            source = source.TrimEnd(';', ' ');
            source = Regex.Replace(source, @"\s+", " ");
            var firstOpenBracket = source.IndexOf('(');
            var argsPart = source.Substring(firstOpenBracket + 1);
            var mainPart = source.Substring(0, firstOpenBracket).Split(' ');
            
            return new Method(mainPart[1], ValueParser.Parse(mainPart[0]), ListParamsParser.Parse(argsPart));
        }
    }
}