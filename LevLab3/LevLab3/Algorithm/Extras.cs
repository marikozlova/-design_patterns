using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialLabs3
{
    internal static class Extras
    {


        public static List<int> GetMissingNodes(this List<int> nums) => Enumerable.Range(0, nums.Capacity).Except(nums).ToList();

        public static int CountTime(DataFromOrders data, List<int> nodesIndexes, out int time)
        {
            int result = 0;
            time = 0;
            for (var i = 1; i < nodesIndexes.Count; i++)
            {
                time += data._times[nodesIndexes[i - 1], nodesIndexes[i]];
                if (time > data._expireTimes[nodesIndexes[i] - 1]) result++;

            }
            return result;

        }

        public static List<int> MakeCopy(List<int> nums)
        {
            List<int> result = [.. nums];
            result.Capacity = nums.Capacity;
            return result;
        }
        public static List<Branch> MakeCopy(List<Branch> nums)
        {
            List<Branch> result = [.. nums];
            result.Capacity = nums.Capacity;
            return result;
        }
    }
}
