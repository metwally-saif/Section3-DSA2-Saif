using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section3_DSA2_Saif.Options
{
    internal interface IMenuOption
    {
        string OptionName { get; }
        void Execute();
    }
}
