namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("PERF TEST");
            Stopwatch stopwatch = Stopwatch.StartNew();
            stopwatch.Restart();

            IEnumerable<int> list1 = Enumerable.Range(0, 100000000);
            IEnumerable<int> list2 = Enumerable.Range(0, 100000000);

            int list2Item = 0;

            Console.WriteLine("FIRST LINQ PREDICATE");

            stopwatch.Restart();
            Console.WriteLine("Item :{0} found in: {1}", list1.First(Predicate), stopwatch.Elapsed);

            Console.WriteLine("SECOND LINQ LAMBDA");

            stopwatch.Restart();
            Console.WriteLine("Item :{0} found in: {1}", list1.First(i => i == 99999999), stopwatch.Elapsed);

            Console.WriteLine("THIRD LINQ PREDICATE AGAIN");

            stopwatch.Restart();
            Console.WriteLine("Item :{0} found in: {1}", list1.First(Predicate), stopwatch.Elapsed);
            

            Console.WriteLine("FOURTH FOREACH");

            stopwatch.Restart();

            foreach (int item2 in list2)
            {
                if (item2 == 99999999)
                {
                    list2Item = item2;
                    break;
                }
            }

            Console.WriteLine("Item :{0} found in: {1}", list2Item, stopwatch.Elapsed);

            Console.ReadKey();
        }

        public static bool Predicate(int i)
        {
            return i == 99999999;
        }
    }
}
