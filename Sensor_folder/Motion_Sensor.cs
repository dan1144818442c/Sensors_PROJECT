using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors_Project.Sensor_folder
{
    internal class Motion_Sensor:Sensor
    {

        public Motion_Sensor(string name, string target, bool isActive = false) : base(name, target, isActive)
        {
            this.activeSeshens = 3;
        }

        public Motion_Sensor()
        { this.activeSeshens = 3; }
    }
}
