using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialLabs3
{
    internal class MyUpBoundFinder : IBoundFinder
    {
        private DataFromOrders _orders;
        public MyUpBoundFinder(DataFromOrders orders)
        {
            _orders = orders;
        }
        public int GetBound(List<int> indexes)
        {
            while (indexes.Count != _orders.OrdersAmount + 1)
            {
                Extras.CountTime(_orders, indexes, out int time);
                indexes.Add(GetNextNode(indexes.Last(), time, Extras.GetMissingNodes(indexes)));

            }
            return Extras.CountTime(_orders, indexes, out _);
        }
        private int GetNextNode(int lastNode, int currentTime, List<int> possibleNodes)
        {   
            var nodesWithoutFine = GetNonExpiredNodes(lastNode, currentTime, possibleNodes);
            if (nodesWithoutFine.Count == 0)
            {
                return possibleNodes[new Random().Next(possibleNodes.Count)];
            }
            else
            {
                return nodesWithoutFine.OrderBy(index => _orders._expireTimes[index-1]-currentTime).First();
            }


        }
        private List<int> GetNonExpiredNodes(int lastNode, int currentTime, List<int> possibleNodes)
        {
            return possibleNodes.Where(num => currentTime + _orders._times[lastNode, num] <= _orders._expireTimes[num - 1]).ToList();
        }
    }
}
