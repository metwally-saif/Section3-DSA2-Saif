using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section3_DSA2_Saif.Options
{
    public class ExitOption : IMenuOption
    {
        public string OptionName => "Exit";

        public void Execute()
        {
            Console.WriteLine("Have a nice day!");
            Environment.Exit(0);
        }
    }
}
