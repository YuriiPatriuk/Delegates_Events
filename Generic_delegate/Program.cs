using System;
using System.Collections.Generic;

namespace Generic_delegate
{
    delegate T AddDelegate<T>(T one, T two);
    class Program
    {
        static void Main(string[] args)
        {
            AddDelegate<double> d1 = AddCalculator.AddNumbers;
            AddDelegate<string> d2 = AddCalculator.ConcatStrings;
            Console.WriteLine("Res (double): " + d1(4.23,6.234));

            Console.WriteLine("Res (string): " + d2("qwe","qwe"));

        }
    }

    class AddCalculator
    {
        public static double AddNumbers(double a, double b) => a + b;
        public static string ConcatStrings(string a, string b) => a +" "+ b;
        public static TimeSpan AddTimeSpan(TimeSpan a, TimeSpan b) => a + b;
    }
}
