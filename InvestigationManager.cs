using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors_Project
{
    internal class InvestigationManager
    {
        private List<IranianAgent> iranianAgents = new List<IranianAgent>();

        void menu_meneger()
        {
            Console.WriteLine("chooz one from this:");
            Console.WriteLine("1. Add Iranian Agent");
            Console.WriteLine("2 . start a game");
            Console.WriteLine("5. Exit");
        }

        IranianAgent get_IranianAgent_from_user()
        {
            do
            {
                Console.WriteLine("Show All Iranian Agents");
                StaticFunc.show_list_of_agents(iranianAgents);
                Console.WriteLine("chooz num");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int index) && index > 0 && index <= iranianAgents.Count)
                {
                    return iranianAgents[index - 1];
                }
                Console.WriteLine("Invalid selection. Please try again.");
            }

            while (true);



        }

        public void menu_game()
        {
            while (true)
            {
                IranianAgent agent = get_IranianAgent_from_user();
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


        }

        public void add_agent(IranianAgent agent)
        {
            iranianAgents.Add(agent);
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
                        Console.WriteLine("Enter Agent Name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Agent Age:");
                        int age = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Agent Rank:");
                        string rank = Console.ReadLine();
                        IranianAgent agent = new IranianAgent(name, age, rank);
                        add_agent(agent);
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

    }
}
