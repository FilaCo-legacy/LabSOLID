namespace LabSOLID.ParsingStructs.ValueParsers
{
    public interface IValueParser
    {
        IValueParser Next { get; set; }
        
        Value Parse(string source);
    }
}