using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
   
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[5] { 5,4,3,2,1};
            PiriortyQueue piriorty = new PiriortyQueue(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(piriorty.ExtractMax());    
            }                                     
        }
    }

    class PiriortyQueue
    {
        int[] array;
        int size;
        public PiriortyQueue(int[] array)
        {
            this.array = array;
            size = array.Length;
            BuildArray();
        }

        private void BuildArray()
        {
            int midNode = (array.Length - 1) / 2;
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
        /// Get max piroity
        /// by get last leaf and put in the front of tree and call swiftDown
        /// </summary>
        /// <returns></returns>
        public int ExtractMax()
        {
            if (size != 0)
            {
                int max = array[0];
                array[0] = array[size-1];
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
            array[i] =  int.MaxValue;
            SwiftUp(i);
            ExtractMax();
        }

        private void Swap(int v1, int v2)
        {
            int temp;
            temp = array[v1];
            array[v1] = array[v2];
            array[v2] = temp;
        }

        /// <summary>
        /// change pirioty of an element 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="p"></param>
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
        /// <param name="i"></param>
        /// <returns></returns>
        private int Parent(int i)
        {
            return (i - 1) / 0;
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
