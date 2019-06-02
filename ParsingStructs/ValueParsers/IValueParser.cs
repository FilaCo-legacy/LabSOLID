namespace LabSOLID.ParsingStructs.TypeParsers
{
    public interface IValueParser
    {
        IValueParser Next { get; set; }

        Value Parse(string source);
    }
}