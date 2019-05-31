using System.Collections;
using System.Collections.Generic;
using LabSOLID.ParsingStructs;

namespace LabSOLID.BinaryTree
{
    public class IdNode : IEnumerable<IdNode>
    {
        /// <summary>
        /// identifier, stored in this tree's node
        /// </summary>
        public Id Data { get; set; }

        public IdNode Left { get; set; }

        public IdNode Right { get; set; }

        public IdNode(Id data)
        {
            Data = data;
        }

        public IEnumerator<IdNode> GetEnumerator()
        {
            Left?.GetEnumerator();
            
            yield return this;
            
            Right?.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
}