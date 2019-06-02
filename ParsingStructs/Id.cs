namespace LabSOLID.ParsingStructs
{
    /// <summary>
    /// Defines possible types of the <see cref="Id"/>s
    /// </summary>
    public enum Identifier { Classes, Consts, Vars, Methods };
    
    /// <summary>
    /// Defines possible types of some <see cref="Id"/>'s value
    /// </summary>
    public enum Value { int_type, float_type, bool_type, char_type, string_type, class_type };
    
    /// <summary>
    /// Represents some type of the variable from the file
    /// </summary>
    public abstract class Id
    {
        public abstract Identifier TypeId { get; }
 
        public abstract Value TypeValue { get; }
        
        public string Name { get;}

        public Id(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return string.Format($"{Name} | {GetHashCode()} | {TypeId} | {TypeValue}");
        }
        
        /// <summary>
        /// Compute the hash-function (Poly-hash) from a name of this <see cref="ParsingStructs.Id"/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            const int P = 257;
            int pPow = 1, hash = 0;
            for (int i = 0; i < Name.Length; ++i)
            {
                hash += (Name[i] - '0' + 1) * pPow;
                pPow *= P;
            }
            return hash;
        }
        
        public static bool operator <(Id lhs, Id rhs) => lhs?.GetHashCode() < rhs?.GetHashCode();
        public static bool operator >(Id lhs, Id rhs) => lhs?.GetHashCode() > rhs?.GetHashCode();
        public static bool operator ==(Id lhs, Id rhs) => lhs?.GetHashCode() == rhs?.GetHashCode();
        public static bool operator !=(Id lhs, Id rhs) => lhs?.GetHashCode() != rhs?.GetHashCode();
        
    }
}
