using System;
using System.Collections;
namespace Disjontset_Naive
{
    class Program
    {                 /// <summary>
    /// find take o(1)
    /// union O(n)
    /// </summary>
    /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] x1 = new int[3] { 1, 2, 3 };
            int[] x2 = new int[3] { 4, 5, 6 };
            int[] x3 = new int[2] { 7, 8 };

            DisjointNaive disjointNaive = new DisjointNaive(8);
            disjointNaive.AddSet(x1);
            disjointNaive.AddSet(x2);
            disjointNaive.AddSet(x3);
        }
    }

    public class DisjointNaive
    {
        public int[] SmallestIds { get; set; }
        public DisjointNaive(int arrayLength)
        {
            this.SmallestIds = new int[arrayLength];
        }

        public void AddSet(int[] set)
        {
            Array.Sort(set);
            // get min element
            int min = set[0];

            for (int i = 0; i < set.Length; i++)
            {
                SmallestIds[set[i]] = min;
            }
        }

        public int Find(int id)
        {
            return SmallestIds[id];
        }


        public void Union(int x, int y)
        {
            int xId = Find(x);
            int yId = Find(y);

            if (xId == yId)
            {
                return;
            }

            int minID = Math.Min(xId, yId);
            // union all 
            for (int i = 0; i < SmallestIds.Length; i++)
            {
                if (SmallestIds[i] == xId || SmallestIds[i] == yId)
                {
                    SmallestIds[i] = minID;
                }
            }

        }


    }
}
