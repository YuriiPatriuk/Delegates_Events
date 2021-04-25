using System;

namespace Events
{
    delegate void MyDelegate(string message);
    class Car
    {
        public readonly uint MaxSpeed;
        public string Brand { get; set; }
        public Car(string brand = "NoName", uint maxSpeed = 200)
        {
            this.Brand = brand;
            MaxSpeed = maxSpeed;
        }

        public event MyDelegate /*Action<string>*/ TooHighSpeed; //event
        uint speed;
        public uint Speed
        {
            get => speed;
            set
            {
                speed = value;
                if(value>=MaxSpeed - 10)
                {
                    if (speed > MaxSpeed)
                        speed = MaxSpeed;
                    TooHighSpeed?.Invoke("Please slow down");//notify
                }
            }
        }
        public override string ToString()
        {
            return $"Brand: {Brand,-10} Speed: {Speed,-7}";
        }
    }

    class Policeman
    {
        public string Name { get; set; }
        public void SpeedViolationReact(string message)
        {
            Console.WriteLine($"Policeman {Name} know about violation!");
            Console.WriteLine(message);
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Ferrari", 250);
            Policeman petro = new Policeman() { Name = "Petro" };
            Policeman ivan = new Policeman() { Name = "Ivan" };

            car.TooHighSpeed += petro.SpeedViolationReact; //subscribe
            car.TooHighSpeed += ivan.SpeedViolationReact; //subscribe

            car.Speed = 245; //event will be call
            car.TooHighSpeed -= ivan.SpeedViolationReact;
            Console.WriteLine();

            car.Speed = 249; //event will be call

        }
    }
}
