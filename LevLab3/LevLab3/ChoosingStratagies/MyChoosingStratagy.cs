using SpecialLabs3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialLabs3
{
    internal class MyChoosingStratagy : IBranchChoosingStratagy
    {
        public Branch GetBranch(List<Branch> branches) => branches.MinBy(branch => branch.LowBound * branch.UpBound);
    }
}
