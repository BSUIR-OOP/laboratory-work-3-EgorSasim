using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb3
{
    public abstract class Transport
    {
        public double speed;
        public string name;
        public int id;
        public double power;
        public int places;

        public abstract string move();

    }
}
