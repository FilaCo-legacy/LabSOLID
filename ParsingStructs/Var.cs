
namespace LabSOLID.ParsingStructs
{
    /// <summary>
    /// Represents a variable-type identifier
    /// </summary>
    public class Var : Id
    {
        public override Identifier TypeId => Identifier.Vars;
        
        public override Value TypeValue { get; }
       
        public Var(string name, Value typeValue):base(name)
        {
            TypeValue = typeValue;
        }
    }
}
