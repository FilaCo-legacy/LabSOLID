namespace LabSOLID.ParsingStructs
{
    /// <summary>
    /// Represents a method-type identifier
    /// </summary>
    public class Method : Id
    {
        private readonly ListParams _listParams;

        public override Identifier TypeId => Identifier.Methods;
        
        public override Value TypeValue { get; }
        
        public Method(string name, Value typeValue, ListParams listParams) : base(name)
        {
            _listParams = listParams;
            TypeValue = typeValue;
        }

        public override string ToString()
        {
            return base.ToString() + _listParams;
        }
    }
}
