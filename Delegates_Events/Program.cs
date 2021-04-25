using System;
using System.Collections.Generic;

namespace Delegate_Void
{
    //delegate = reference тип(клас), який інкапсулює у собі посилання на метод з певною сигнатурою
    delegate void MyDelegate(string str); //створено делегат(ТИП, за кадром клас)
    class Program
    {
        static void Hello(string name)
        {
            Console.WriteLine("Hello, "+name);
        }
        static void Bye(string name)
        {
            Console.WriteLine("Bye, " + name);
        }

        static void Main(string[] args)
        {
            //створюємо екземпляр делегату, що посилається на статичний метод Hello
            MyDelegate deleg = new MyDelegate(Program.Hello);
            Console.WriteLine("Deleg ----> " + deleg.Method);
            Hello("pofig"); //явний виклик методу
            deleg("pofig"); //неявний виклик

            deleg = Bye;
            Console.WriteLine("Deleg ----> " + deleg.Method);
            deleg("pofig");

            deleg = (string s) => Console.WriteLine("Good luck, " + s); ;
            Console.WriteLine("Deleg ----> " + deleg.Method);
            deleg("pofig");//спрощений виклик методу, на який посилається делегат

            deleg.Invoke("pofig"); //виклик методу, на який посилається делегат

            deleg = null;
            //if(deleg!= null)
            //    deleg("pofig"); //exception
            //else
            //    Console.WriteLine("Deleg is null!");
            deleg?.Invoke("pofig"); // викликємо метод делегату, якщо він є

            Person ann = new Person { Name = "Ann", Age = 22 };
            Person oleg = new Person { Name = "Oleg", Age = 32 };
            deleg = ann.Busy; //deleg ----> Busy(), метод буде спрацьовувати на об'єкт ann
            deleg?.Invoke("hw");
            deleg = oleg.Busy;
            deleg?.Invoke("repair car");

            deleg = Hello;
            deleg += Bye;
            deleg("Sasha");
            Console.WriteLine("--------------------For Dima-------------------");
            foreach (var item in deleg.GetInvocationList())
            {
                Console.WriteLine("Current method ---> "+item.Method);
                item.DynamicInvoke("Dima");
            }

        }

        class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Things {get; set;} = new List<string>();

            public void Busy(string t)
            {
                Console.WriteLine($"Person {Name} with age {Age} is doing {t}");
                Things.Add(t);
            }

           
        }

    }
}
