using System;
using System.Collections.Generic;

namespace HW_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------------------1.1---------------------------------
            /*HotHouse hotHouse = new HotHouse(10);
            Cooler cooler = new Cooler();
            Heater heater = new Heater();

            hotHouse.TooCold += heater.Warm;
            hotHouse.TooHot += cooler.Cool;

            char res = '1';
            while (res!='s')
            {
                hotHouse.Temperature += new Random().Next(-2, 3);
                Console.WriteLine("Current temp: " + hotHouse.Temperature);
                Console.Write("Enter 's' to stop, another to continue: ");
                res = Console.ReadKey().KeyChar;
                Console.WriteLine();
            }
            Console.WriteLine("FINITAAAA 1.1");*/
            //--------------------------------1.2---------------------------------
            Truck car = new Truck("Lamba");
            Race race = new Race();
            race.SetLength(1500);
            List<Car> p = new List<Car>() { new Bus("Gelic"),car};
            race.Racing(p);
            
        }
    }
}
