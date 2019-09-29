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
            DateTime Awesome = new DateTime(1974, 12 , 21);
            Console.WriteLine("DayOfWeek : {0}", Awesome.DayOfWeek);

            Awesome = Awesome.AddDays(4);
            Awesome = Awesome.AddMonths(1);
            Awesome = Awesome.AddYears(1);

            Console.WriteLine("New Date : {0}", Awesome.Date);

            TimeSpan lunchtime = new TimeSpan(12, 30, 0);
            lunchtime = lunchtime.Subtract(new TimeSpan(0, 15, 0));
            lunchtime = lunchtime.Add(new TimeSpan(1, 0, 0));
            Console.WriteLine("New Time : {0}", lunchtime.ToString());


            Console.ReadLine();
                
        }
       
    }
}
