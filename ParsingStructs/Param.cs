using System;
using System.Text.RegularExpressions;

namespace LabSOLID.ParsingStructs
{
    /// <summary>
    /// Defines possible types of parameter's transfer
    /// </summary>
    public enum TransferType { param_val, param_ref, param_out};
    
    /// <summary>
    /// Represents a single parameter in some <see cref="Method"/>'s arguments list
    /// </summary>
    public class Param 
    {
        /// <summary>
        /// Type of this param value
        /// </summary>
        public Value TypeValue { get;  }
        
        public TransferType Transfer { get; }

        public Param(Value typeValue, TransferType transferType)
        {
            TypeValue = typeValue;
            Transfer = transferType;
        }
        
        public override string ToString()
        {
            return string.Format($"->|| {TypeValue} | {Transfer} ||");
        }
    }
}
