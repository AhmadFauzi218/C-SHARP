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
            BigInteger bigNum = BigInteger.Parse("1234512345123451234512345123451234512345");
            Console.WriteLine("Big Number * 2  = {0}", bigNum * 2);

            Console.WriteLine("Currency : {0:c}", 23.455);
            Console.WriteLine("Pad With 0s :{0:d4}", 23);
            Console.WriteLine("3 Decimals :{0:f3}", 23,455555);
            Console.WriteLine("Commas : {0:n4}", 2300);

            Console.ReadLine();
        }
       
    }
}
