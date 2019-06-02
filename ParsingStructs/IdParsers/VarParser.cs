using System.Text.RegularExpressions;
using LabSOLID.ParsingStructs.ValueParsers;

namespace LabSOLID.ParsingStructs.IdParsers
{
    public class VarParser : BaseIdParser
    {
        protected override string Pattern => @"^\w+\s+(?!(ref|out|int|char|bool|string|float)\s*;)[^\d\s]\w*\s*;$";

        public IValueParser ValueParser { get; set; }

        public VarParser(IValueParser parser)
        {
            ValueParser = parser;
        }
        
        public override Id Parse(string source)
        {
            if (!CanHandle(source))
                return base.Parse(source);
            
            source = source.TrimEnd(';');
            var splittedSource = source.Split(' ');
            
            return  new Var( splittedSource[1], ValueParser.Parse(splittedSource[0]));
        }
    }
}