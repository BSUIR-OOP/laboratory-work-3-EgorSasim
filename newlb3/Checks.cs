using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb3
{
    internal class Checks
    {
        static public bool ValidSpec(string speed, string name, string id, string power, string places)
        {
            try
            {
                Convert.ToDouble(speed);
                Convert.ToInt32(id);
                Convert.ToDouble(power);
                Convert.ToInt32(places);
            }
            catch
            {
                return false;
            }
            return true;
        }
        static public bool checkEmpty(string speed, string name, string id, string power, string places)
        {
            if (String.IsNullOrEmpty(speed) || String.IsNullOrEmpty(name) || String.IsNullOrEmpty(id) || String.IsNullOrEmpty(power) || String.IsNullOrEmpty(places))
                return false;
            return true;
        }
    }
}
