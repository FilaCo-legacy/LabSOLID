using System;
using System.IO;
using LabSOLID.BinaryTree;

namespace LabSOLID
{
   internal class Program
    {
        private static void CombineParsers()
        {
            
        }
        
        private static void Main(string[] args)
        {
            var idTree = new IdBinaryTree();
            using (var streamReader = new StreamReader("input.txt"))
            {
                while (!streamReader.EndOfStream)
                {
                    var inputLine = streamReader.ReadLine();
                    
                }
            }
        }
    }
}