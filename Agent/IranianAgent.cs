using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Sensors_Project.Enums;
namespace Sensors_Project
{
    internal class IranianAgent : Person
    {


        public bool IsExposed { get; set; }
        public string rank { get; set; }

        private Dictionary<SensorType, List<Sensor>> secretSensorProfile = new Dictionary<SensorType, List<Sensor>>();
        private Dictionary<SensorType, List<Sensor>> attachedSensors = new Dictionary<SensorType, List<Sensor>>();
        public IranianAgent(string name, int age, string rank) : base(name, age)
        {
            this.rank = rank;
            this.IsExposed = true;
          
            StaticFunc.is_exposed_update(this);
            
        }

        public IranianAgent()
        {
            StaticFunc.is_exposed_update(this); 
           
        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Rank: {rank}";
        }

        public void AddSecretSensorProfile(SensorType sensorType)
        {
            if (!secretSensorProfile.ContainsKey(sensorType))
            {
                secretSensorProfile[sensorType] = new List<Sensor>();


            }
            Sensor sensor = SensorFactory.CreateSensor(sensorType);
            secretSensorProfile[sensorType].Add(sensor);
            StaticFunc.is_exposed_update(this);

        }

        public void AddSecretSensorProfile(string sensorName)
        {
            SensorType sensorType = StaticFunc.ChangeStringToSensorType(sensorName);
            AddSecretSensorProfile(sensorType);
            StaticFunc.is_exposed_update(this);

        }

        public void AddAttachedSensor(string sensorName)
        {
            SensorType sensorType = StaticFunc.ChangeStringToSensorType(sensorName);
            Console.WriteLine(sensorType.ToString());

            if (!attachedSensors.ContainsKey(sensorType))
            {
                attachedSensors[sensorType] = new List<Sensor>();
            }
            Sensor sensor = SensorFactory.CreateSensor(sensorType, target: "Unknown", isActive: true);
            attachedSensors[sensorType].Add(sensor);
            StaticFunc.is_exposed_update(this);
        }

        public Dictionary<SensorType, List<Sensor>> GetSecretSensorProfile()
        {
            return secretSensorProfile;
        }
        public Dictionary<SensorType, List<Sensor>> GetAttachedSensors()
        {
            return attachedSensors;
        }

        public int CountMatchingSensors()
        {
            int count = 0;
            foreach (var sensor in attachedSensors)
            {
                var sensorType = sensor.Key;
                var attachedList = sensor.Value;

                if (secretSensorProfile.ContainsKey(sensorType))
                {
                    var secretList = secretSensorProfile[sensorType];


                    int activeAttachedCount = attachedList.Count(s => s.IsActive);

                    int secretCount = secretList.Count;

                    count += Math.Min(activeAttachedCount, secretCount);
                }
            }
            return count;

        }
        public virtual int ActivateAllAttachedSensors()
        {
            foreach (var kvp in attachedSensors)
            {
                foreach (var sensor in kvp.Value)
                {

                    sensor.Activate();
                    if ((sensor.IsActive) && (sensor is Sensor_folder.Thermal_Sensor))
                    {
                        Console.WriteLine($"one from the secert sensor for {this.Name} is {StaticFunc.get_random_sensor_type_from_Dict_sensor(this.secretSensorProfile).ToString()} ");
                    }
                }
            }
            return CountMatchingSensors();
        }

        public int getCountOfSecretSensors()
        {
            int count = 0;
            foreach (var kvp in secretSensorProfile)
            {
                count += kvp.Value.Count;
            }
            return count;
        }



    }
}
