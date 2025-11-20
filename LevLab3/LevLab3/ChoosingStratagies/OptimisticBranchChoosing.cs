using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialLabs3
{
    internal class OptimisticBranchChoosing : IBranchChoosingStratagy
    {
        public Branch GetBranch(List<Branch> branches)
        {
            return branches.OrderBy(branch => branch.LowBound).First();
        }
    }
}
