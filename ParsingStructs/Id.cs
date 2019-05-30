using System;
using System.Xml.Serialization;

namespace ParsingStructs
{
    /// <summary>
    /// Defines possible types of the <see cref="Id"/>s
    /// </summary>
    public enum TypeIdent { Classes, Consts, Vars, Methods };
    
    /// <summary>
    /// Defines possible types of some <see cref="Id"/>'s value
    /// </summary>
    public enum TypeValue { int_type, float_type, bool_type, char_type, string_type, class_type };
    
    /// <summary>
    /// Represents some type of the variable from the file
    /// </summary>
    public abstract class Id
    {
        public TypeIdent TypeId { get; set; }
 
        public TypeValue TypeVal { get; set; }
        
        public string Name { get; set; }

        public override string ToString()
        {
            return string.Format($"{Name} | {GetHashCode()} | {TypeId} | {TypeVal}");
        }
        
        /// <summary>
        /// Compute the hash-function (Poly-hash) from a name of this <see cref="Id"/>
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
        
        public static bool operator <(Id ident1, Id ident2) => ident1.GetHashCode() < ident2.GetHashCode();
        public static bool operator >(Id ident1, Id ident2) => ident1.GetHashCode() > ident2.GetHashCode();
        public static bool operator ==(Id ident1, Id ident2) => ident1.GetHashCode() == ident2.GetHashCode();
        public static bool operator !=(Id ident1, Id ident2) => ident1.GetHashCode() != ident2.GetHashCode();
        
    }
}
