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
            float fltPival = 3.1232F;
            float fltBignum = 3.0002F;
            Console.WriteLine("Dec : PI + BigNUm = {0} ", fltPival + fltBignum);
            Console.WriteLine("Biggest Float : {0}", float.MaxValue.ToString("#"));


            double dblPival = 3.12324564262;
            double dblBignum = 3.00000000002;
            Console.WriteLine("Dec : PI + BigNUm = {0} ", dblPival + dblBignum);
            Console.WriteLine("Biggest Double : {0}", double.MaxValue.ToString("#"));


            decimal decPival = 3.14159276767564576867553436576762222M;
            decimal decBignum = 3.000000000000000000000000000000000011M;
            Console.WriteLine("Dec : PI + BigNUm = {0} ", decPival + decBignum);

            Console.WriteLine("Biggest Decimal : {0}", decimal.MaxValue);

            Console.WriteLine("Smallest Decimal : {0}", decimal.MinValue);


            bool canIVote = true;

            Console.WriteLine("Biggest integer : {0}", int.MaxValue);

            Console.WriteLine("Smallest integer : {0}", int.MinValue);

           

            Console.WriteLine("Biggest long : {0}", long.MaxValue);

            Console.WriteLine("Smallest integer : {0}", long.MinValue);

            Console.ReadLine();
        }
       
    }
}
