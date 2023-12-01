using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section3_DSA2_Saif.Classes
{
    internal class CombinationInfo
    {
        public int StartIdx { get; set; }
        public List<int> CurrentCombination { get; set; }
        public int RemainingAmount { get; set; }

        public CombinationInfo(int startIdx, List<int> currentCombination, int remainingAmount)
        {
            StartIdx = startIdx;
            CurrentCombination = currentCombination;
            RemainingAmount = remainingAmount;
        }
    }
}
