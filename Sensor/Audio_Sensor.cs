using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors_Project
{
    internal class Audio_Sensor:Sensor
    {
        public Audio_Sensor(string name, string target, bool isActive = false) : base(name, target, isActive)
        {
        }
        public Audio_Sensor() { }

    }
}
