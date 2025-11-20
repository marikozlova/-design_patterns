using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialLabs3
{
    internal interface IBranchChoosingStratagy
    {
        Branch GetBranch(List<Branch> branches);
    }
}
