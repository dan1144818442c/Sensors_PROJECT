using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sensors_Project.Enums;

namespace Sensors_Project
{
    static class StaticFunc
    {

        public static SensorType ChangeStringToSensorType(string input)
        {
            if (Enum.TryParse(input, true, out SensorType type))
            {
                return type;
            }
            else
            {
                Console.WriteLine("Invalid sensor type entered. Defaulting to Thermal.");
                return SensorType.Basic; // או אפשרות אחרת שתבחר
            }
        }

        public static void show_list_of_agents(List<IranianAgent> agents)
        {
            if (agents.Count == 0)
            {
                Console.WriteLine("No agents available.");
                return;
            }
            Console.WriteLine("List of Agents:");
            int index = 1;
            foreach (IranianAgent agent in agents)
            {

                Console.WriteLine( index + " :" + agent.ToString());
            }
        }

    }
}

