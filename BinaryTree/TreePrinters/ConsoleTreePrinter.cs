using System;

namespace LabSOLID.BinaryTree.TreePrinters
{
    public class ConsoleTreePrinter:ITreePrinter
    {
        public void Print(IdBinaryTree tree)
        {
            foreach (var curNode in tree)
            {
                Console.WriteLine(curNode);
            }
        }
    }
}