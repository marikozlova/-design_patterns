using SpecialLabs3.Bounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SpecialLabs3
{
    internal class BranchAndBound : ISolver
    {
        private int _length;
        private IBranchChoosingStratagy _branchChoosingStratagy;
        private NodeCountDecorator _lowBoundFinder;
        private IBoundFinder _upBoundFinder;
        private List<Branch> _branches = new List<Branch>();

        private double _time;
        public double Time => _time;

        public BranchAndBound(int length, IBranchChoosingStratagy branchChoosingStratagy, NodeCountDecorator lowBoundFinder, IBoundFinder upBoundFinder)
        {
            _length = length;
            _branchChoosingStratagy = branchChoosingStratagy;
            _lowBoundFinder = lowBoundFinder;
            _upBoundFinder = upBoundFinder;
        }

        public int NodesAmount => _lowBoundFinder.NodeAmount;

        public int Solve()
        {
            var Timing = DateTime.Now;
            MakeRoot();
            while (true)
            {
                if (_branches.Count == 1 && _branches[0].LowBound == _branches[0].UpBound) break;
                MakeBranches();
                CutBranches();
            }
            _time = (DateTime.Now - Timing).TotalMilliseconds;
            return _branches[0].LowBound;
        }
        private void MakeRoot()
        {
            _branches.Clear();
            _branches.Add(new Branch(0, _length, _upBoundFinder, _lowBoundFinder));
        }
        private void MakeBranches()
        {
            Branch bestBranch = _branchChoosingStratagy.GetBranch(Extras.MakeCopy(_branches));
            _branches.AddRange(bestBranch.GetNextBranches());
            _branches.Remove(bestBranch);
        }
        private void CutBranches()
        {
            Branch bestBranch = FindBestBranch();
            _branches.RemoveAll(branch => branch.LowBound >= bestBranch.UpBound && branch!=bestBranch);
        }
        private Branch FindBestBranch()
        {
           return _branches.OrderBy(branch => branch.UpBound).First();
        }        
    }
}
