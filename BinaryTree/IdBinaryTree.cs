using System.Collections;
using System.Collections.Generic;
using LabSOLID.BinaryTree.TreePrinters;
using LabSOLID.ParsingStructs;

namespace LabSOLID.BinaryTree
{
    /// <summary>
    /// Represents the binary tree with <see cref="Id"/>s
    /// </summary>
    public class IdBinaryTree : IEnumerable<IdNode>
    {
        private IdNode _root;

        public ITreePrinter Printer { get; set; }
        
        public bool Empty => _root == null;
        
        public IdBinaryTree()
        {
            _root = null;
        }
        
        public IdBinaryTree(Id data)
        {
            _root = new IdNode(data);
        }
        
        public void Add(Id nodeData)
        {
            if (Empty)
            {
                _root = new IdNode(nodeData);
                return;
            }

            var cur = _root;
            IdNode anc = null;
            
            while (!(cur is null))
            {
                anc = cur;
                if (nodeData < cur.Data)
                    cur = cur.Left;
                else if (nodeData > cur.Data)
                    cur = cur.Right;
                else
                    return;
            }
            
            cur = new IdNode(nodeData);
            
            if (cur.Data > anc.Data)
                anc.Right = cur;
            else
                anc.Left = cur;
        }

        public IEnumerator<IdNode> GetEnumerator()
        {
            return Empty ? null : _root.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Print() => Printer?.Print(this);
        
    }
}
