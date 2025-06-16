using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors_Project
{
    internal class Pulse_Sensor : Sensor
    {
        
        public Pulse_Sensor(string name, string target, bool isActive = false ) : base(name, target, isActive)
        {
            this.activeSeshens = 3;
        }

        public Pulse_Sensor()
        { }



    }
}
