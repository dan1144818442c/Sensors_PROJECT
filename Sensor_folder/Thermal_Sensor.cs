using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors_Project.Sensor_folder
{
    internal class Thermal_Sensor : Sensor
    {
        public Thermal_Sensor(string name, string target, bool isActive = false) : base(name, target, isActive)
        {
            this.activeSeshens = -1;
        }
        public Thermal_Sensor()
        {
            this.activeSeshens = -1;
        }

        public override string ToString()
        {
            return $"Thermal Sensor: {this.Name}, Target: {this.target}, Active: {this.IsActive}";
        }
    }
}
