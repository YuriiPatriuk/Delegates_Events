using System;
using System.Collections.Generic;
using System.Linq;

namespace Delegate_as_param
{
    delegate bool MyPredicate(int num);
    delegate bool FindPredicate<T>(T res);
    delegate void Change<T>(ref T res);
    class Program
    {
        //public static void ChangeList<T>(this List<T> arr,Change<T> change)
        //{
        //    for (int i = 0; i < arr.Count; i++)
        //    {
        //        change(ref arr[i]);
        //    }
        //}

        static void Main(string[] args)
        {
            int[] arr = { 10, 2, 3, 11, -2, -111 };
            Console.WriteLine($"Sum > 0 : {arr.Sum( x=> x>0)}");
            Console.WriteLine($"Sum % 2 = 0 : {arr.Sum( x=> x%2==0)}");

            Console.WriteLine("--------------------------------------------");
            List<string> str = new List<string> { "one", "two", "three", "four" };

            var res = str.MyFindAll(x => x.Length > 3);
            Console.Write("Res:");
            foreach (var item in res)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();





        }
    }
    static class ExtIntArray
    {
        public static int Sum(this int[] arr, MyPredicate p)
        {
            Console.WriteLine("My sum");
            int sum = 0;
            foreach (var e in arr)
            {
                if (p(e))
                    sum += e;
            }
            return sum;
        }

        public static List<T> MyFindAll<T>(this List<T> arr, FindPredicate<T> p)
        {
            List<T> res = new List<T>();
            foreach (var i in arr)
            {
                if (p(i))
                    res.Add(i);
            }
            return res;
        }

    }
}
