using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CSharpTutA
{
    class Program
    {
        static void Main(string[] args)
        {

            string randstring = "This is a string";
            Console.WriteLine("String Length : {0}", randstring.Length);
            Console.WriteLine("String Contains is : {0}", randstring.Contains("is"));

            Console.WriteLine("Index of is : {0}", randstring.IndexOf("is"));

            Console.WriteLine("Remove String : {0}", randstring.Remove(0,6));

            Console.WriteLine("Insert String : {0}", randstring.Insert(10, "Short"));

            Console.WriteLine("Reaplace String : {0}", randstring.Replace("String ","Sentence"));

            Console.WriteLine("Compare A to B : {0}", String.Compare("A","B",StringComparison.OrdinalIgnoreCase));

            Console.ReadLine();
        }
       
    }
}
