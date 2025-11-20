using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialLabs3
{
    internal interface ISolver
    {
        int Solve();
        int NodesAmount { get; }
    }
}
