using System.Text.RegularExpressions;

namespace LabSOLID.ParsingStructs.IdParsers
{
    public class ListParamsParser
    {
        private static string Pattern => @"^\(\s*((\s*(\w+\s+){1,2}\w+\s*,)*\s*(\w+\s+){1,2}\w+)?\s*\)$";

        private static bool CanHandle(string source)
        {
            var regex = new Regex(Pattern);

            return regex.IsMatch(source);
        }
        
        public ParamParser ParamParser { get; set; }

        public ListParamsParser(ParamParser parser)
        {
            ParamParser = parser;
        }

        public MonoList<Param> Parse(string source)
        {
            if (!CanHandle(source))
                return null;
            
            source = source.Trim('(', ')');
            var inp = source.Split(',');
            var listParams = new MonoList<Param>();

            for (var i = 0; i < inp.Length; ++i)
            {
                var elem = ParamParser.Parse(inp[i]);
                listParams.AddEnd(elem);
            }

            return listParams;
        }
    }
}