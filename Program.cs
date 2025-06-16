using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
InvestigationManager investigationManager1 = new InvestigationManager();
            IranianAgent i1 = new IranianAgent();
            IranianAgent i4 = new IranianAgent();
            IranianAgent i2 = new IranianAgent();
            IranianAgent i3 = new IranianAgent();
            i1.AddSecretSensorProfile("Audio");
            i1.AddSecretSensorProfile("Audio");
            i1.AddSecretSensorProfile("Audio");
            i1.AddSecretSensorProfile("Pulse_Sensor");
            investigationManager1.add_agent(i3);
            investigationManager1.add_agent(i2);
            investigationManager1.add_agent(i4);
            investigationManager1.add_agent(i1);
            //investigationManager1.menu_game();
            //investigationManager1.main_menu();

        }
    }
}
