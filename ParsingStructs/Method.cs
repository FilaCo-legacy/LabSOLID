namespace LabSOLID.ParsingStructs
{
    /// <summary>
    /// Represents a method-type identifier
    /// </summary>
    public class Method : Id
    {
        private readonly MonoList<Param> _monoList;

        public override Identifier TypeId => Identifier.Methods;
        
        public override Value TypeValue { get; }
        
        public Method(string name, Value typeValue, MonoList<Param> monoList) : base(name)
        {
            _monoList = monoList;
            TypeValue = typeValue;
        }

        public override string ToString()
        {
            return base.ToString() + _monoList;
        }
    }
}
