using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors_Project.Agent
{
    internal class Squad_Leader : IranianAgent
    {
        private int time_active;
        public Squad_Leader(string name, int age, string rank) : base(name, age, rank)
        {
            for (int i = 0; i<4; i++)
            {

                AddSecretSensorProfile(StaticFunc.get_random_Type_sensor());
            }
            time_active = 0;

        }
        public Squad_Leader() { }
        public override string ToString()
        {
            return $"Squad Leader - {base.ToString()}";
        }
   public override int ActivateAllAttachedSensors()
        {
            time_active++;
            if (this.time_active % 3 == 0)
            {
                StaticFunc.delete_random_sensor(this.GetAttachedSensors());
            }
           return base.ActivateAllAttachedSensors();
        }

    }
}
