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
            Console.WriteLine("1. Add Iranian Agent");
            Console.WriteLine("5. Exit");
        }

        IranianAgent get_IranianAgent_from_user()
        {
            Console.WriteLine("2. Show All Iranian Agents");
            StaticFunc.show_list_of_agents(iranianAgents);
            Console.WriteLine("chooz num");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int index) && index > 0 && index <= iranianAgents.Count)
            {
                return iranianAgents[index - 1];
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
                return null;
            }


        }

        void menu_game()
        {
            while (true)
            {
                get_IranianAgent_from_user();
            }


        }
        
    }
}
