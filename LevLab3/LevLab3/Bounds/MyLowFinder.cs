using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialLabs3
{
    internal class MyLowFinder : IBoundFinder
    {
        private readonly DataFromOrders _orders;

        public MyLowFinder(DataFromOrders orders)
        {
            _orders = orders;
        }

        public int GetBound(List<int> indexes)
        {
            return indexes.GetMissingNodes().Select(num => CountLowBound(AddOn(indexes,num))).Min();
        }

        private int CountLowBound(List<int> indexes)
        {
            int result = Extras.CountTime(_orders, indexes, out int time);
            foreach (var num in Extras.GetMissingNodes(indexes))
            {
                if (time + _orders._times[indexes.Last(), num] > _orders._expireTimes[num - 1]) result++;

            }
            return result;
        }
        private List<int> AddOn(List<int> indexes, int number)
        {
            var temp = Extras.MakeCopy(indexes);
            temp.Add(number);
            return temp;
        }
    }
}
