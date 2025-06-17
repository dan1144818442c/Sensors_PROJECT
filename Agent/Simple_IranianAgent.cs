using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors_Project.Agent
{
    internal class Simple_IranianAgent:IranianAgent
    {
        public Simple_IranianAgent() { }
        public Simple_IranianAgent(string name, int age, string rank) : base(name, age, rank)
        {
        }
        public override string ToString()
        {
            return $"Simple Iranian Agent - {base.ToString()}";
        }
    }
}
