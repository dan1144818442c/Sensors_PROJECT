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
            do
            {
                if (!int.TryParse(input, out _))
                {
                    if (Enum.TryParse(input, true, out SensorType type))
                    {
                        return type;
                    }
                }
                Console.WriteLine("must enter one rom this:");
                show_enum_sensors();
                input = Console.ReadLine();

            }
            while (true);
        }

        public static string show_list_of_agents(List<IranianAgent> agents)
        {
            if (agents.Count == 0)
            {
                Console.WriteLine("No agents available.");
                return ("No agents available.");
            }
            Console.WriteLine("List of Agents:");
            int index = 1;
            foreach (IranianAgent agent in agents)
            {

                Console.WriteLine(index + " :" + agent.ToString());
                index++;
            }
            return ($"{index}");
        }



        public static void check_and_show_matching_sensors(IranianAgent agent, string type)
        {
            agent.AddAttachedSensor(type);
            int num_of_meching = agent.ActivateAllAttachedSensors();
            int num_of_secret = agent.getCountOfSecretSensors();
            show_matching_sensors(num_of_meching, num_of_secret);
        }

        public static void show_matching_sensors(int maching , int all_secret)
        {
            Console.WriteLine($"{maching} / {all_secret} of mached");           
        }

        public static void show_enum_sensors()
        {
            foreach(SensorType type in Enum.GetValues(typeof(SensorType)))
            {
                Console.WriteLine(type);
            }

        }
        public static SensorType get_random_secret_sensor(Dictionary<SensorType, List<Sensor>> sensorsDict)
        {
            Random random = new Random();
            SensorType[] sensorTypes = sensorsDict.Keys.ToArray();
            int index = random.Next(sensorTypes.Length);
            return sensorTypes[index];
        }

        //public static get_goog_type()
    }
}

