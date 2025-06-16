using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sensors_Project.Enums;

namespace Sensors_Project
{
    internal class SensorFactory
    {
        

        public static Sensor CreateSensor(SensorType type, string target = "Unknown", bool isActive = false)
        {
            switch (type)
            {
                //case SensorType.Thermal:
                //    return new Thermal_Sensor("Thermal", target, isActive);
                case SensorType.Audio:
                    return new Audio_Sensor("Audio", target, isActive);
                
                default:
                    throw new ArgumentException("Unknown sensor type");
            }
        }



    }
}
