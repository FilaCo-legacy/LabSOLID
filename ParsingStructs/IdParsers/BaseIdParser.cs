using System.Text.RegularExpressions;

namespace LabSOLID.ParsingStructs.IdParsers
{
    public abstract class BaseIdParser: MonoList<IdParser>,IdParser 
    {
        protected abstract string Pattern { get; }

        protected bool CanHandle(string source)
        {
            var regex = new Regex(Pattern);

            return regex.IsMatch(source);
        }

        public virtual Id Parse(string source)
        {
            return _next?.Data.Parse(source);
        }
    }
}