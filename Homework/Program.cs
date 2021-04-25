using System;

namespace Homework
{
    //Завдання 1
    delegate void DrawFigures(uint height, ConsoleColor color);
    class Draw
    {
        public static void DrawSquare(uint height, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < height; i++)
            {
                for (int j =0; j < height; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
        public static void DrawTriangle(uint height, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < i; j++)
                {

                    Console.Write("* ");
                }
                Console.WriteLine("* ");
                //Console.Write(" ");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
    //Завдання 2
    class Calculator
    {
       public void SetOperation(char operation) 
        {
            switch (operation)
            {
                case '+':
                    func = (a, b) => a + b; 
                    break;
                case '-':
                    func = (a, b) => a - b;
                    break;
                case '*':
                    func = (a, b) => a * b;
                    break;
                case '/':
                    func = (a, b) => b == 0 ? a/1 : a / b;
                    break;
                default:
                    throw new Exception("Error! Please, enter correct operation");
                  
            }
        }
        Func<double, double, double> func;
        public double Calculate(double a, double b)
        {
            return func(a, b);
        }
    }
    //Завдання 3
    class Product : IComparable
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int CompareTo(object obj)
        {
            Product p = obj as Product;
            if (p != null)
                return this.Price.CompareTo(p.Price);
            else
                throw new Exception("Error! Cannot CompareTo!");
        }

        public override string ToString()
        {
            return $"Name: {Name}, Price: {Price}";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Завдання 1
            //Draw.DrawSquare(5, ConsoleColor.Red);
            //Draw.DrawTriangle(10, ConsoleColor.Yellow);

            /*DrawFigures deleg = Draw.DrawSquare;
            deleg(6,ConsoleColor.Green);
            deleg = Draw.DrawTriangle;
            deleg(7,ConsoleColor.DarkMagenta);

            deleg += Draw.DrawSquare;
            deleg(8,ConsoleColor.DarkCyan);*/

            //Завдання 2
            /*Calculator c = new Calculator();
            try
            {
                c.SetOperation('k');
                Console.WriteLine(c.Calculate(6, 0));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }*/

            //Завдання 3
            static void Sort<T>(T[] arr, Comparison<T> comp)
            {
                for (int i = 0; i < arr.Length-1; i++)
                {
                    for (int j = 0; j < (arr.Length - 1)-i; j++)
                    {
                        if (comp(arr[j], arr[j + 1]) == 1)
                        {
                            T temp = arr[j];
                            arr[j] = arr[j + 1];
                            arr[j+1] = temp;
                        }
                    }
                }
            }

            string[] str= { "juice", "cat", "carrot", "helium", "rom"};
            Sort(str,(x,y) => x.Length.CompareTo(y.Length));
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(str[i]+" ");
            }
            Console.WriteLine();

            Product[] products = {  new Product { Name = "Sweets", Price = 19.94 }, new Product { Name = "Solomka", Price = 18.3 } , new Product { Name = "juice", Price = 13.23 } };
            Sort(products, (x, y) => x.CompareTo(y));
            for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine(products[i]);
            }

        }
    }
}
