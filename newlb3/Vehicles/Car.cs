using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb3.Vehicles
{
    public class Car : Transport
    {
        public override string move()
        {
            return $"The car moves with a speed {speed}";
        }
        public Car() { }
        public Car(double speed, string name, int id, double power, int places)
        {
            this.speed = speed;
            this.name = name;
            this.id = id;
            this.power = power;
            this.places = places;
        }
    }
}
