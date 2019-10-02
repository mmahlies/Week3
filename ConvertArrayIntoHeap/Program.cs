using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// HeapSort is used for external sort when you need to sort huge files that don’t fit into memory of your
//  computer.
//  The first step of the HeapSort algorithm is to create a heap from the array you want to sort.By the
//  way, did you know that algorithms based on Heaps are widely used for external sort, when you need
//  to sort huge files that don’t fit into memory of a computer?
/// </summary>
namespace ConvertArrayIntoHeap
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = Console.ReadLine().Split(' ').Select(w => int.Parse(w)).ToArray();
            PiriortyQueue piriorty = new PiriortyQueue(array);
            Console.WriteLine(piriorty.swapOperations.Count);
            for (int i = 0; i < piriorty.swapOperations.Count; i++)
            {
                Console.WriteLine(piriorty.swapOperations[i].Key + " " + piriorty.swapOperations[i].Value);
            }
        }
    }

    class PiriortyQueue
    {
        int[] array;
        // datastructure t save no of swapp operation
        public List<KeyValuePair<int, int>> swapOperations;
        int size;
        public PiriortyQueue(int[] array)
        {
            this.array = array;
            size = array.Length;
            swapOperations = new List<KeyValuePair<int, int>>();
            BuildArray();
        }

        // build complete binary tree from array
        private void BuildArray()
        {
            int midNode = (array.Length - 1) / 2;
            // sart from the mid of the tree beacause if u draw this tree u will find the mid 
            // node is last parent in the tree so the last node we need to make it sticfied with it's childs
            for (int i = midNode; i >= 0; i--)
            {
                SwiftDown(i);
            }
        }
        /// <summary>
        /// used to make parent min node in it's subtree
        /// </summary>
        /// <param name="i"></param>
        private void SwiftDown(int i)
        {
            int minI = i;
            int left = LeftChild(i);
            int right = RightChild(i);
            if (left < size && array[left] < array[minI])
            {
                minI = left;
            }
            if (right < size && array[right] < array[minI])
            {
                minI = right;
            }
            if (minI != i)
            {
                Swap(i, minI);
                SwiftDown(minI);
            }

        }

        /// <summary>
        ///  by get last leaf and put in the root of tree and call swiftDown
        /// </summary>
        /// <returns></returns>
        public int ExtractMax()
        {
            if (size != 0)
            {
                int max = array[0];
                // swap root with last leaf
                array[0] = array[size - 1];
                SwiftDown(0);
                size--;
                return max;
            }
            return -1;
        }

        /// <summary>
        /// remove elment by maxing it bigger piriorty and the extract this elment after bubled up
        /// </summary>
        /// <param name="i"></param>
        public void RemoveElement(int i)
        {
            array[i] = int.MaxValue;
            SwiftUp(i);
            ExtractMax();
        }

        private void Swap(int v1, int v2)
        {
            int temp;
            temp = array[v1];
            array[v1] = array[v2];
            array[v2] = temp;
            swapOperations.Add(new KeyValuePair<int, int>(v1, v2));
        }

        public void ChangePirorty(int i, int p)
        {
            int OldP = array[i];
            array[i] = p;
            if (p > OldP)
            {
                SwiftUp(i);
            }
            if (p < OldP)
            {
                SwiftDown(i);
            }


        }
        /// <summary> 
        /// return rightChild
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int RightChild(int i)
        {
            return (2 * i) + 2;
        }

        /// <summary>
        /// return leftChild
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int LeftChild(int i)
        {
            return (2 * i) + 1;
        }

        /// <summary>
        /// return parent index for 0 based array
        /// </summary>
        /// <param name="i"></param>s
        /// <returns></returns>
        private int Parent(int i)
        {                     
            return (int)Math.Floor((decimal)(i - 1) /2);
        }

        /// <summary>
        /// used to ensure from this node is min one in thier tree by bubble up
        /// </summary>
        /// <param name="i"></param>
        private void SwiftUp(int i)
        {
            if (i < 1) return; // base case
            if (array[i] < array[Parent(i)])
            {
                Swap(i, Parent(i));
            }
            SwiftUp(Parent(i));
        }
    }
}
