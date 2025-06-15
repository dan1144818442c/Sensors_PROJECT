using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors_Project
{
    abstract class Sensor
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string target { get; set; }
        public Sensor(string name,string target, bool isActive = false)
        {
            Name = name;
            IsActive = isActive;
            this.target = target;
        }
        public Sensor() { }
        public override string ToString()
        {
            return $"Sensor Name: {Name}, Target: {target}, Is Active: {IsActive}";
        }
        public void Activate()
        {
            IsActive = true;
        }
        public void Deactivate()
        {
            IsActive = false;
        }
        public bool IsSensorActive()
        {
            return IsActive;
        }


    }
}
