using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialLabs3.Bounds
{
    internal class NodeCountDecorator : IBoundFinder
    {
        private int _nodeAmount;
        private IBoundFinder _boundFinder;

        public int NodeAmount => _nodeAmount;

        public NodeCountDecorator(IBoundFinder boundFinder)
        {
            _boundFinder = boundFinder;
        }
        public int GetBound(List<int> indexes)
        {
            _nodeAmount++;
            return _boundFinder.GetBound(indexes);
        }
    }
}
