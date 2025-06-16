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
        public int activeSeshens { get; set; } = -1; // -1 means no limit on active sessions
        public Sensor(string name,string target, bool isActive = false , int activeSeshens = -1)
        {
            Name = name;
            IsActive = isActive;
            this.target = target;
            this.activeSeshens = activeSeshens;
        }
        public Sensor() { }
        public override string ToString()
        {
            return $"Sensor Name: {Name}, Target: {target}, Is Active: {IsActive}";
        }
        public void Activate()
        {
            if ((activeSeshens > 0) || (activeSeshens < 0))
            {
                activeSeshens--;
                IsActive = true;
            }
            else if (activeSeshens == 0)
            {
                IsActive = false;
                Console.WriteLine("\"Cannot activate sensor, no active sessions left.\"");
                //throw new InvalidOperationException("Cannot activate sensor, no active sessions left.");
            }
           

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
