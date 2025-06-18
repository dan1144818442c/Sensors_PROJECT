using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sensors_Project.Agent;

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
            Squad_Leader squad_Leader = new Squad_Leader("Ali", 30, "Captain");
            i1.AddSecretSensorProfile("Audio");
            //StaticFunc.is_exposed_update(i1);
            //i1.AddSecretSensorProfile("Audio");
            //i1.AddSecretSensorProfile("Audio");
            //i1.AddSecretSensorProfile("Pulse_Sensor");
            //i1.AddSecretSensorProfile("Thermal");
            investigationManager1.add_Simple_agent(i3);
            investigationManager1.add_Simple_agent(i2);
            investigationManager1.add_Simple_agent(i4);
            investigationManager1.add_Simple_agent(i1);
            investigationManager1.add_Upgraded_agent(squad_Leader);

            //investigationManager1.menu_game();
            investigationManager1.main_menu();

        }
    }
}
