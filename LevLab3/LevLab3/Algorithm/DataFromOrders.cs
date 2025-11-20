using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialLabs3
{
    internal class DataFromOrders
    {
        public int[] _expireTimes;
        public int[,] _times;
        public int OrdersAmount => _expireTimes.Length;

        public DataFromOrders(int[] expireTimes, int[,] times)
        {
            _expireTimes = expireTimes;
            _times = times;
        }

        public DataFromOrders(int length)
        {
            _expireTimes = new int[length];
            _times = new int[length+1,length+1];
        }
    }
}
