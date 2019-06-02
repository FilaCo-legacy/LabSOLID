using System;
using System.Collections;
using System.Collections.Generic;
using LabSOLID.ParsingStructs;

namespace LabSOLID.BinaryTree
{
    /// <summary>
    /// Represents the binary tree with <see cref="Id"/>s
    /// </summary>
    public class BinaryTree <T> : IEnumerable<T> where T : IComparable<T>
    {
        private class Node
        {
            /// <summary>
            /// identifier, stored in this tree's node
            /// </summary>
            public T Data { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }
            
            public int Count { get; set; }

            public Node(T data)
            {
                Data = data;
                Count = 1;
            }
        }
        
        private Node _root;

        public int Count => _root.Count;

        public bool Empty => _root == null;

        public T this[int index]
        {
            get
            {
                var curNode = _root;

                while (!(curNode is null))
                {
                    var beforeCount = curNode.Left?.Count ?? 0;

                    if (beforeCount == index) return curNode.Data;

                    if (beforeCount < index)
                    {
                        index -= beforeCount + 1;
                        curNode = curNode.Right;
                    }
                    else
                    {
                        curNode = curNode.Left;
                    }
                }

                throw  new Exception("Value with such index does not exist in this tree");
            }
        }
        
        public BinaryTree()
        {
            _root = null;
        }
        
        public BinaryTree(T data)
        {
            _root = new Node(data);
        }

        public bool Contains(T data)
        {
            var cur = _root;

            while (!(cur is null))
            {
                if (data.CompareTo(cur.Data) == 1)
                    cur = cur.Right;
                else if (data.CompareTo(cur.Data) == -1)
                    cur = cur.Left;
                else
                    return true;
            }

            return false;
        }

        public void Add(T data)
        {
            if (Empty)
            {
                _root = new Node(data);
                return;
            }

            if (Contains(data)) return;

            var cur = _root;
            Node anc = null;
            
            while (!(cur is null))
            {
                ++cur.Count;
                anc = cur;

                if (data.CompareTo(cur.Data) == 1)
                    cur = cur.Right;
                else if (data.CompareTo(cur.Data) == -1) 
                    cur = cur.Left;
            }
            
            cur = new Node(data);
            
            if (cur.Data.CompareTo(anc.Data) == 1)
                anc.Right = cur;
            else
                anc.Left = cur;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var index = 0; index < _root.Count; ++index)
                yield return this[index];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
