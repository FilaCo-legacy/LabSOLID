using System.Text.RegularExpressions;

namespace LabSOLID.ParsingStructs.IdParsers
{
    public class ClassParser : BaseIdParser
    {
        protected override string Pattern => @"^class\s+(?!(ref|out|int|char|bool|string|float)\s*;)[^\d\s]\w*\s*;$";

        public override Id Parse(string source)
        {
            if (!CanHandle(source))
                return base.Parse(source);
            
            source = source.TrimEnd(';');
            var splittedSource = Regex.Replace(source, @"\s+", " ").Split(' ');
            return new Class(splittedSource[1]);
        }
    }
}