using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section3_DSA2_Saif.Options
{
    public class FindShortestWayOption : IMenuOption
    {
        public string OptionName => "Find the shortest way";

        public void Execute()
        {
            MoneyProcessor moneyProcessor = new MoneyProcessor();
            moneyProcessor.FindLeastAmount();
        }
    }
}
