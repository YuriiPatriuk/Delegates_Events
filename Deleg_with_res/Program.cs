using System;

namespace Deleg_with_res
{
    delegate double Calc(double a, double b);

    class Calculator
    {
        public static double Add(double a, double b) => a + b;
        public static double Mult(double a, double b) => a * b;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Calc calc = Calculator.Add;
            Console.WriteLine($"{calc.Method.Name} : { calc.Invoke(2,3)}");

            calc += Calculator.Mult;
            Console.WriteLine($"{calc.Method.Name} : { calc?.Invoke(2,3)}");
            Console.WriteLine("\n\n---------All results(GetInvocationList)----------");
            foreach (Delegate m in calc.GetInvocationList())
            {
                Console.WriteLine($"{m.Method.Name} : {m.DynamicInvoke(2,10)}");
            }



        }
    }
}
