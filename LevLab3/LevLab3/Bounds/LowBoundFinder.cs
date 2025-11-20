using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpecialLabs3
{
    internal class LowBoundFinder : IBoundFinder
    {
        private readonly DataFromOrders _orders;

        public LowBoundFinder(DataFromOrders orders)
        {
            _orders = orders;
        }

        public int GetBound(List<int> indexes)
        {
            int result = Extras.CountTime(_orders, indexes, out int time);
            foreach (var num in Extras.GetMissingNodes(indexes))
            {
                if (time + _orders._times[indexes.Last(), num] > _orders._expireTimes[num - 1]) result++;

            }
            return result;
        }
    }
}
