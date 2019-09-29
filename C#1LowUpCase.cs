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
            Console.WriteLine("A = a :{0}",
                String.Equals("A", "a", StringComparison.OrdinalIgnoreCase));

            Console.WriteLine("Pad Left : {0}", randstring.PadLeft(20, '.'));

            Console.WriteLine("Pad Right : {0}", randstring.PadRight(20, '.'));

            Console.WriteLine("Trim : {0}", randstring.Trim());

            Console.WriteLine("Uppsercase: {0}", randstring.ToUpper());

            Console.WriteLine("Lowercase: {0}", randstring.ToLower());

            string newString = String.Format("{0} Saw a {1} {2} in the {3}","Paul","Rabbit","eathing","field");

            Console.WriteLine(@"Exaclty What I Typed'\");

            Console.ReadLine();
        }
       
    }
}
