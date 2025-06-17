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

        public static void show_matching_sensors(int maching, int all_secret)
        {
            Console.WriteLine($"{maching} / {all_secret} of mached");
        }

        public static void show_enum_sensors()
        {
            foreach (SensorType type in Enum.GetValues(typeof(SensorType)))
            {
                Console.WriteLine(type);
            }

        }
        public static SensorType get_random_sensor_type_from_Dict_sensor(Dictionary<SensorType, List<Sensor>> sensorsDict)
        {
            Random random = new Random();
            SensorType[] sensorTypes = sensorsDict.Keys.ToArray();
            if (sensorsDict == null || sensorsDict.Count == 0)
            {
                Console.WriteLine(("The sensors dictionary is empty or null."));
                return SensorType.Basic;
            }
            int index = random.Next(sensorTypes.Length);
            return sensorTypes[index];
        }
        public static T get_random_object_from_list<T>(List<T> list)
        {
            Random random = new Random();
            int index = random.Next(list.Count);
            return list[index];
        }

        public static List<Sensor> get_random_sensor_from_Dict_sensor_num_times(Dictionary<SensorType, List<Sensor>> sensorsDict, int num)
        {
            List<Sensor> List_resulot = new List<Sensor>();
            SensorType sensorType;
            Sensor rnd_sensor;
            for (int i = 0; i < num; i++)
            {
                sensorType = get_random_sensor_type_from_Dict_sensor(sensorsDict);
                rnd_sensor = get_random_object_from_list(sensorsDict[sensorType]);
                List_resulot.Add(rnd_sensor);
            }
            return List_resulot;
        }

        public static SensorType get_random_Type_sensor()
        {
            Random random = new Random();
            Array values = Enum.GetValues(typeof(SensorType));
            SensorType randomType = (SensorType)values.GetValue(random.Next(values.Length));
            return randomType;

        }

        public static void delete_random_sensor(Dictionary<SensorType, List<Sensor>> sensorsDict)
        {
            if (sensorsDict.Count == 0)
            {
                return;
            }

            SensorType randomSensorType = get_random_sensor_type_from_Dict_sensor(sensorsDict);
            List<Sensor> sensorsOfType = sensorsDict[randomSensorType];
            Sensor sensorToDelete = get_random_object_from_list(sensorsOfType);
            sensorsOfType.Remove(sensorToDelete);
            if (sensorsOfType.Count == 0)
            {
                sensorsDict.Remove(randomSensorType);
            }
            else
            {
                sensorsDict[randomSensorType] = sensorsOfType;
            }
            Console.WriteLine($"Deleted sensor of type {randomSensorType}");

        }
        public static void is_exposed_update(IranianAgent agent)
        {
            if (agent.CountMatchingSensors() == agent.getCountOfSecretSensors())
            {
                
               agent.IsExposed = true;
            }
            else
            {
                agent.IsExposed = false;
            }
        }
    }
}

