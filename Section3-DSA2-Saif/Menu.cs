using Section3_DSA2_Saif.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section3_DSA2_Saif
{
    internal class Menu
    {
        private readonly Dictionary<string, IMenuOption> menuOptions;

        public Menu()
        {
            menuOptions = new Dictionary<string, IMenuOption>
            {
                { "1", new ShowAllWaysOption() },
                { "2", new FindShortestWayOption() },
                { "0", new ExitOption() }
            };
        }

        public void ShowMenu()
        {
            Console.WriteLine("Welcome to the Cash Dispensing Machine");
            Console.WriteLine("1. Show all possible coin combinations for an amount");
            Console.WriteLine("2. Find the combination with the fewest coins");
            Console.WriteLine("0. Exit");
            Console.Write("Please enter your choice: ");
        }

        public bool HandleInput(string userInput)
        {
            if (menuOptions.TryGetValue(userInput, out IMenuOption selectedOption))
            {
                selectedOption.Execute();
                return true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                return false;
            }
        }
    }
}
