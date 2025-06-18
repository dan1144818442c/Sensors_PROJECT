using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors_Project
{
    internal class Signal_Sensor : Sensor
    {
        public Signal_Sensor(string name, string target, bool isActive = false) : base(name, target, isActive)
        {
            this.activeSeshens = -1;
        }
        public Signal_Sensor()
        {
            this.activeSeshens = -1;
        }
        public override void Activate(IranianAgent iranianAgent)
        {
            base.Activate(iranianAgent);
            if (this.activeSeshens == -1)
            {
                Console.WriteLine("the name of the agent is " + iranianAgent.Name);
            }
        }
    }
}
