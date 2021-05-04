using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Events
{
    delegate void CarDelegate(Car car);
    abstract class Car
    {
        public int Speed { get; set; }
        public string Name{ get; set; }
        public int Position { get; set; } = 0;
        abstract public void Go(int finish);
        abstract public event CarDelegate CarFinished;
    }
    class RaceCar : Car
    {
        public override event CarDelegate CarFinished;
        const int MAX_SPEED = 200;
        public RaceCar(string name)
        {
            Name = name;
            Speed = 100;
        }
        public override void Go(int finish)
        {
            Speed += new Random().Next(-20, 21);
            if (Speed > MAX_SPEED)
                Speed = MAX_SPEED;
            if (Speed < 0)
                Speed = 40;
            Position += Speed;

            if (Position >= finish)
                CarFinished?.Invoke(this);
            

        }
        public override string ToString()
        {
            return $"Race car {Name}";
        }
    }
    class SimpleCar : Car
    {
        public override event CarDelegate CarFinished;
        const int MAX_SPEED = 170;
        public SimpleCar(string name)
        {
            Name = name;
            Speed = 80;
        }
        public override void Go(int finish)
        {
            Speed += new Random().Next(-16, 17);
            if (Speed > MAX_SPEED)
                Speed = MAX_SPEED;
            if (Speed < 0)
                Speed = 40;
            Position += Speed;

            if (Position >= finish)
                CarFinished?.Invoke(this);


        }
        public override string ToString()
        {
            return $"Simple car {Name}";
        }
    }
    class Truck : Car
    {
        public override event CarDelegate CarFinished;
        const int MAX_SPEED = 150;
        public Truck(string name)
        {
            Name = name;
            Speed = 60;
        }
        public override void Go(int finish)
        {
            Speed += new Random().Next(-13, 14);
            if (Speed > MAX_SPEED)
                Speed = MAX_SPEED;
            if (Speed < 0)
                Speed = 40;
            Position += Speed;

            if (Position >= finish)
                CarFinished?.Invoke(this);


        }
        public override string ToString()
        {
            return $"Truck {Name}";
        }
    }
    class Bus : Car
    {
        public override event CarDelegate CarFinished;
        const int MAX_SPEED = 120;
        public Bus(string name)
        {
            Name = name;
            Speed = 40;
        }
        public override void Go(int finish)
        {
            Speed += new Random().Next(-11, 12);
            if (Speed > MAX_SPEED)
                Speed = MAX_SPEED;
            if (Speed < 0)
                Speed = 40;
            Position += Speed;

            if (Position >= finish)
                CarFinished?.Invoke(this);


        }
        public override string ToString()
        {
            return $"Bus {Name}";
        }
    }
    class Race
    {
        class RaceFinal : Exception
        {
            public RaceFinal(string message)
                :base(message){}
        }
        delegate void RaceDelegate(Car car);
        int length = 1000;
        public void Racing(List<Car> cars)
        {
            Console.WriteLine("----------------Start race----------------");
            try
            {
                foreach (var item in cars)
                {
                    item.CarFinished += RaceResult;
                }
                while (true)
                {
                    Console.WriteLine("------------------------------------------------------------------------------");
                    foreach (var item in cars)
                    {
                        item.Go(length);
                        Console.WriteLine(item + $" To finish: {length-item.Position}");

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n-------------------Winner is \""+ex.Message+"\" -----------------------");
            }
        }
        void RaceResult(Car car)
        {
            throw new RaceFinal(car.ToString());
        }
        public void SetLength(int val)
        {
            if (val >= 1000)
                length = val;
        }
    }
}
