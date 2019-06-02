namespace LabSOLID.ParsingStructs
{
    /// <summary>
    /// Represents a const-type identifier
    /// </summary>
    public class Const : Id
    {
        /// <summary>
        /// Value, converted to string and stored in this <see cref="Const"/>
        /// </summary>
        public string Value { get; }

        public override Identifier TypeId => Identifier.Consts;

        public override Value TypeValue { get; }
        
        
        public Const(string name, string value, Value typeValue) : base(name)
        {
            Value = value;
            TypeValue = typeValue;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format($" | {Value}");
        }

    }
}
