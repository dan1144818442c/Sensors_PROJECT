using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors_Project.Sensor_folder
{
    internal class Basic_Sensor: Sensor
    {
        public Basic_Sensor(string name, string target, bool isActive = false) : base(name, target, isActive)
        {
            this.activeSeshens = 2;
        }
        public Basic_Sensor()
        { }
    }
}
