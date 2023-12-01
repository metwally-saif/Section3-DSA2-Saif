using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section3_DSA2_Saif.Options
{
    public class ShowAllWaysOption : IMenuOption
    {
        public string OptionName => "Show all ways";

        public void Execute()
        {
            MoneyProcessor moneyProcessor = new MoneyProcessor();
            moneyProcessor.PrintAllWays();
        }
    }
}
