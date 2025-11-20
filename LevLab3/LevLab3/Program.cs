using SpecialLabs3;
using SpecialLabs3.Bounds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialLabs3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var orders = new FileOrdersReader("task_3_02_n3.txt").GetData();
            var solver = new BranchAndBound(orders.OrdersAmount, new MyChoosingStratagy(), new NodeCountDecorator(new LowBoundFinder(orders)),(new MyUpBoundFinder(orders)));
            Console.Write("---Task---\n");
            solver.Solve();
            Console.Write("Nodes are :");
            Console.WriteLine(solver.NodesAmount);
            Console.Write("Time is :");
            Console.WriteLine(solver.Time);
        }
    }
}
