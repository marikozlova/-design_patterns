using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialLabs3
{
    internal class Branch
    {
        private readonly List<int> _nodesIndexes;
        private int _upBound;
        private int _lowBound;
        private readonly IBoundFinder _upBoundFinder;

        private readonly IBoundFinder _lowBoundFinder;
        public int LowBound => _lowBound;

        public int UpBound => _upBound;

        public int CountNodes => _nodesIndexes.Count;

        public Branch(int startNum, int Length, IBoundFinder upBoundFinder, IBoundFinder lowBoundFinder)
        {
            _nodesIndexes = new(Length + 1) { startNum };
            _upBoundFinder = upBoundFinder;
            _lowBoundFinder = lowBoundFinder;
            CountLowBound();
            CountUpBound();
            
        }
        public Branch(Branch branch)
        {
            _nodesIndexes = Extras.MakeCopy(branch._nodesIndexes);
            _lowBound = branch._lowBound;
            _upBound = branch._upBound;
            _upBoundFinder = branch._upBoundFinder;
            _lowBoundFinder = branch._lowBoundFinder;

        }



        public void AddNode(int index)
        {
            _nodesIndexes.Add(index);
            CountLowBound();
            CountUpBound();

        }
        public List<Branch> GetNextBranches()
        {
            List<Branch> result = [];
            foreach (var num in Extras.GetMissingNodes(_nodesIndexes))
            {
                Branch branch = new(this);
                branch.AddNode(num);
                result.Add(branch);

            }
            return result;

        }

        private void CountLowBound() => _lowBound = _lowBoundFinder.GetBound(Extras.MakeCopy(_nodesIndexes));


        private void CountUpBound() => _upBound = _upBoundFinder.GetBound(Extras.MakeCopy(_nodesIndexes));

        


    }
}
