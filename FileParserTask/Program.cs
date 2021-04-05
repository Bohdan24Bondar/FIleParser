using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using FileParserLibrary;

namespace FileParserTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    ConsoleController application = new ConsoleController(args);
            //    application.Run();
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Instruction");// todo
            //}

            using (TextReplacer rep = new TextReplacer(".\\Instruction.txt", "a"))
            {
                rep.ReplaceString("77");
            }

            Console.ReadKey();
        
        }
    }
}
