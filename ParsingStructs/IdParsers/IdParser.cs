namespace LabSOLID.ParsingStructs.IdParsers
{
    public interface IdParser
    {
        IdParser Next { get; set; }
        
        Id Parse(string source);
    }
}