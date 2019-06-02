namespace LabSOLID.ParsingStructs
{
    /// <summary>
    /// Represents a class-type identifier
    /// </summary>
    public class Class : Id
    {
        public override Identifier TypeId => Identifier.Classes;

        public override Value TypeValue => Value.class_type;

        public Class(string name):base(name) {}
    }
}
