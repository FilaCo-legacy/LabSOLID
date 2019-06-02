using System.Text.RegularExpressions;
using LabSOLID.ParsingStructs.ValueParsers;

namespace LabSOLID.ParsingStructs.IdParsers
{
    public class ConstParser : BaseIdParser
    {
        protected override string Pattern =>
            @"^const\s+\w+\s+(?!(ref|out|int|char|bool|string|float)\s*=)[^\d\s]\w*\s*=\s*[\w\d,""'-]+\s*;$";

        public IValueParser ValueParser { get; set; }

        public ConstParser(IValueParser parser)
        {
            ValueParser = parser;
        }
        
        public override Id Parse(string source)
        {
            if (!CanHandle(source))
                return base.Parse(source);
            
            source = source.TrimEnd(';', ' ');
            source = source.Replace('=', ' ');
            var splittedSource = Regex.Replace(source, @"\s+", " ").Split(' ');

            return new Const(splittedSource[2], splittedSource[3], ValueParser.Parse(splittedSource[1]));
        }
    }
}