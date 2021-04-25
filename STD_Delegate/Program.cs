using System;

namespace STD_Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            // Action --- void

            Action<int, double> a1 = (int a, double d) => Console.WriteLine($"{a}+{d}={a+d}");
        
            Action<string, int> a2 = (str, num) => Console.WriteLine($"{str} has more {num} symbols={str.Length > num}");
            a2("demolinr", 5);

            // Func --- return result
            Func<double, double, double> f = (a, b) => (a / b);
            Console.WriteLine($"Func({13},{3}) = {f(13,3):F3} ");

            Predicate<int> pred = (x) => x % 2 == 0;
            int nr = new Random().Next(2000);
            Console.WriteLine($"\nNumber: {nr} Even: {pred(nr)}");

            Comparison<double> cmp = (a, b) => Math.Abs(a).CompareTo(Math.Abs(b));
            double a = 10, b = 22.3;
            Console.WriteLine($"Comparison by absolute values |{a}| and |{b}| = {cmp(a,b)}");


            //practise
        }
    }
}
