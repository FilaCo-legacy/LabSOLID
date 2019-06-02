using System;
using System.Text.RegularExpressions;

namespace LabSOLID.ParsingStructs.IdParsers
{
    public abstract class BaseIdParser: IdParser 
    {
        protected abstract string Pattern { get; }

        protected bool CanHandle(string source)
        {
            var regex = new Regex(Pattern);

            return regex.IsMatch(source);
        }

        public IdParser Next { get; set; }

        public virtual Id Parse(string source)
        {
            if (!(Next is null))
                return Next.Parse(source);
            
            throw  new Exception("Undefined identifier type");
        }
    }
}