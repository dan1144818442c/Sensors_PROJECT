using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sensors_Project.Agent;

namespace Sensors_Project
{
    internal class InvestigationManager
    {
        private Dictionary<string, List<IranianAgent>> iranianAgents;
        private Random random = new Random();
        public InvestigationManager()
        {
            iranianAgents = new Dictionary<string, List<IranianAgent>>
                {
                    { "simple", new List<IranianAgent>() } ,
                {"Upgraded" , new List<IranianAgent>() }
                };
            //add_random_agent_with_random_sensor(5); 
        }

        void menu_meneger()
        {
            Console.WriteLine("chooz one from this:");
            Console.WriteLine("1. Add  simple Iranian Agent");
            Console.WriteLine("2 . start a game");
            Console.WriteLine("5. Exit");
        }

        IranianAgent get_IranianAgent_from_user(string type_level)
        {
            do
            {
                Console.WriteLine("Show All Iranian Agents");
                StaticFunc.PrintAgentsBeautifully(iranianAgents[type_level]);
                Console.WriteLine("chooz num");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int index) && index > 0 && index <= iranianAgents[type_level].Count)
                {
                    return iranianAgents[type_level][index - 1];
                }
                Console.WriteLine("Invalid selection. Please try again.");
            }
            while (true);
        }

        public void menu_game()
        {
            while (true)
            {
                if (check_if_can__level2())
                {
                    break;
                }

                main_level_1();
            }
            while (true)
            {

                main_level_2();

            }
        }

        public void add_Simple_agent(IranianAgent agent)
        {
            iranianAgents["simple"].Add(agent);
        }
        public void add_Upgraded_agent(IranianAgent agent)
        {
            iranianAgents["Upgraded"].Add(agent);
        }

        public void main_menu()
        {
            while (true)
            {
                menu_meneger();
                string chois = Console.ReadLine();
                switch (chois)
                {
                    case "1":
                        this.inputFor_add_agent();
                        break;

                    case "2":
                        menu_game();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }


        public bool check_if_can__level2()
        {
            foreach (IranianAgent agent in iranianAgents["simple"])
            {
                Console.WriteLine(agent.ToString());
                Console.WriteLine(agent.IsExposed.ToString());
                StaticFunc.is_exposed_update(agent);
                if (!agent.IsExposed)
                {
                    return false;
                }
            }
            return true;
        }
        public void main_level_1()
        {
            IranianAgent agent = get_IranianAgent_from_user("simple");
            StaticFunc.show_enum_sensors();
            string input = Console.ReadLine();
            StaticFunc.check_and_show_matching_sensors(agent, input);
            if (agent.IsExposed)
            {
                Console.WriteLine("Agent is exposed!");
            }
            else
            {
                Console.WriteLine("Agent is not exposed.");
            }
        }
        public void main_level_2()
        {
            Console.WriteLine("All agents are exposed. You can proceed to level 2.");

            IranianAgent agent = get_IranianAgent_from_user("Upgraded");
            StaticFunc.show_enum_sensors();
            string input = Console.ReadLine();
            StaticFunc.check_and_show_matching_sensors(agent, input);
            if (agent.IsExposed)
            {
                Console.WriteLine("Agent is exposed!");
            }
            else
            {
                Console.WriteLine("Agent is not exposed.");
            }
            Console.WriteLine("count");
            StaticFunc.show_dict_list( agent.GetAttachedSensors());
            

        }


        public void inputFor_add_agent()
        {
            Console.WriteLine("Enter Agent Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Agent Age:");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Agent Rank:");
            string rank = Console.ReadLine();
            IranianAgent agent = new IranianAgent(name, age, rank);
            add_Simple_agent(agent);
        }

        public void add_random_agent_with_random_sensor()
        {
            string name = "Agent" + random.Next(1, 1000);
            int age = random.Next(20, 50);
            string rank = "Rank" + random.Next(1, 5);
            IranianAgent agent = new IranianAgent(name, age, rank);
            for (int i = 0; i < random.Next(1, 4); i++)
            {
                Enums.SensorType sensorType = StaticFunc.get_random_Type_sensor();
                agent.AddSecretSensorProfile(sensorType);
            }
            add_Simple_agent(agent);


        }
        public void add_random_agent_with_random_sensor(int count)
        {
            for (int i = 0; i < count; i++)
            {
                add_random_agent_with_random_sensor();
            }
        }
    }
}
