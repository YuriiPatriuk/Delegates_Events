using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Events
{
    delegate void HotHouseDeleg(HotHouse house);
    class HotHouse
    {
        public const double MAX_TEMP = 35;
        public const double MIN_TEMP = 20;
        double temperature = 30;

        public event HotHouseDeleg TooHot;
        public event HotHouseDeleg TooCold;
        public event HotHouseDeleg Well;

        public HotHouse(double temp = 30)
        {
            Temperature = temp;
        }

        public double Temperature
        {
            get
            {
                return temperature; 
            }
            set
            {
                if (value > MAX_TEMP)
                {
                    Console.WriteLine("Too hot!!");
                    TooHot?.Invoke(this);
                }
                else if (value < MIN_TEMP)
                {
                    Console.WriteLine("Too cold!!");
                    TooCold?.Invoke(this);
                }
                else
                {
                    temperature = value;
                    Console.WriteLine("Все добре");
                    Well?.Invoke(this);
                }
            }
        }

    }
    class Heater
    {
        public void Warm(HotHouse h)
        {
            Console.WriteLine("Warm 5 degree");
            h.Temperature += 5;
        }
    }
    class Cooler
    {
        public void Cool(HotHouse h)
        {
            Console.WriteLine("Cool 5 degree");
            h.Temperature -= 5;
        }
    }
}
