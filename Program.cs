using System;
using System.IO;
using LabSOLID.BinaryTree;
using LabSOLID.ParsingStructs;
using LabSOLID.ParsingStructs.IdParsers;
using LabSOLID.ParsingStructs.ValueParsers;

namespace LabSOLID
{
   internal class Program
   {
       private static IdParsersContainer TypeParser;

       private static void InitParsers()
       {
           var valueParsers = new ValueParsersContainer();
           
           valueParsers.Add(new BoolParser());
           valueParsers.Add(new StringParser());
           valueParsers.Add(new FloatParser());
           valueParsers.Add(new CharParser());
           valueParsers.Add(new IntParser());

           TypeParser = new IdParsersContainer();
           
           TypeParser.Add(new ClassParser());
           TypeParser.Add(new ConstParser(valueParsers));
           TypeParser.Add(new MethodParser(valueParsers, new ListParamsParser(new ParamParser(valueParsers))));
           TypeParser.Add(new VarParser(valueParsers));
       }
        private static void Main(string[] args)
        {
            InitParsers();
            var idTree = new BinaryTree<Id>();
            var ind = 0;

            using (var streamReader = new StreamReader("input.txt"))
            {
                while (!streamReader.EndOfStream)
                {
                    var inputLine = streamReader.ReadLine();

                    try
                    {
                        idTree.Add(TypeParser.Parse(inputLine.Trim(' ')));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error:{e.Message}, line index {ind+1}");
                    }

                    ++ind;
                }
            }

            foreach (var curIdent in idTree)
            {
                Console.WriteLine(curIdent);
            }
        }
    }
}