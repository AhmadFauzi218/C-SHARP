using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello word");

            for (int i = 1; i < args.Length; i++)
            {
                Console.WriteLine("Arg {0} : {1}", i, args[i]);
            }

            string[] myArgs = Environment.GetCommandLineArgs();

            Console.WriteLine(string.Join(",", myArgs));

            SayHello();

                Console.ReadLine();
        }

        private static void SayHello()
        {
            string name = "";
            Console.Write("What Is Your Name :");
            name = Console.ReadLine();
            Console.WriteLine("Hello {0}", name);

        }

       

       
    }
}
