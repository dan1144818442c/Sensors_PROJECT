using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors_Project.Agent
{
    static class AgentFactory
    {
        public static IranianAgent CreateAgent(string type, string name, int age, string rank)
        {
            switch (type.ToLower())
            {
                case "simple":
                    return new Simple_IranianAgent(name, age, rank);
                case "squad_leader":
                    return new Squad_Leader(name, age, rank);
                default:
                    throw new ArgumentException("Unknown agent type");
            }
        }
    }
}
