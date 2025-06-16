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


        public bool IsExposed { get; set; } = false; 
        public string rank { get; set; }

        private Dictionary<SensorType, List<Sensor>> secretSensorProfile = new Dictionary<SensorType, List<Sensor>>();
        private Dictionary<SensorType, List<Sensor>> attachedSensors = new Dictionary<SensorType, List<Sensor>>();
        public IranianAgent(string name, int age, string rank) : base(name, age)
        {
            this.rank = rank;
        }

        public IranianAgent() { }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}, Rank: {rank}";
        }

        public void AddSecretSensorProfile(string sensorName)
        {
            SensorType sensorType = StaticFunc.ChangeStringToSensorType(sensorName);

            if (!secretSensorProfile.ContainsKey(sensorType))
            {
                secretSensorProfile[sensorType] = new List<Sensor>();


            }
            Sensor sensor = SensorFactory.CreateSensor(sensorType);
            secretSensorProfile[sensorType].Add(sensor);
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
           if (this.CountMatchingSensors() == this.getCountOfSecretSensors())
            {
                IsExposed = true;
            }
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
        public int ActivateAllAttachedSensors()
        {
            foreach (var kvp in attachedSensors)
            {
                foreach (var sensor in kvp.Value)
                {
                    sensor.Activate();
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
