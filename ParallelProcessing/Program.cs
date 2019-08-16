using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstInputData = Console.ReadLine().Split(' ');

            int numberOFThread = int.Parse(firstInputData[0]);
            Thread[] threads = new Thread[numberOFThread];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(i);
            }
            PiriortyQueue ThreadsPiriorty = new PiriortyQueue(threads);
            int NumberOfTasks = int.Parse(firstInputData[1]);
            int[] arrayOfTasks = Console.ReadLine().Split(' ').Select(w => int.Parse(w)).ToArray();

            foreach (int task in arrayOfTasks)
            {
                ThreadsPiriorty.AssignTask(task);
            }
        }
    }

    class PiriortyQueue
    {
        Thread[] array;
        int size;
        public PiriortyQueue(Thread[] array)
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
        ///  by get last leaf and put in the front of tree and call swiftDown
        /// </summary>
        /// <returns></returns>
        public Thread ExtractMax()
        {
            Thread max = array[0];
            array[0] = array[size - 1];
            SwiftDown(0);
            size--;
            return max;
        }

        public Thread GetMax()
        {
            return array[0];
        }

        /// <summary>
        /// remove elment by maxing it bigger piriorty and the extract this elment after bubled up
        /// </summary>
        /// <param name="i"></param>
        //public void RemoveElement(int i)
        //{
        //    array[i] = int.MaxValue;
        //    SwiftUp(i);
        //    ExtractMax();
        //}

        private void Swap(int v1, int v2)
        {
            Thread temp;
            temp = array[v1];
            array[v1] = array[v2];
            array[v2] = temp;
        }

        /// <summary>
        /// asgin task to most free thread
        /// </summary>
        /// <param name="taskTime"></param>
        public void AssignTask(long taskTime)
        {
            Console.WriteLine(array[0].index + " " + array[0].WorkingSec);
            array[0].WorkingSec += taskTime;
            SwiftDown(0);
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


    class Thread
    {
        public int index;
        private long workingSec;

        public long WorkingSec
        {
            get { return workingSec; }
            set { workingSec = value; }
        }
        public Thread(int index)
        {
            this.index = index;
            this.workingSec = 0;
        }




        public static bool operator <(Thread source, Thread other)
        {
            if (source.WorkingSec.CompareTo(other.workingSec) > 0)
            {
                return false;
            }
            if (source.WorkingSec.CompareTo(other.workingSec) < 0)
            {
                return true;
            }
            if (source.index.CompareTo(other.index) > 0)
            {
                return false;
            }
            if (source.WorkingSec.CompareTo(other.index) < 0)
            {
                return true;
            }
            // working sec and index are equals
            return true;
        }
        public static bool operator >(Thread source, Thread other)
        {
            if (source.WorkingSec.CompareTo(other.workingSec) > 0)
            {
                return true;
            }
            if (source.WorkingSec.CompareTo(other.workingSec) < 0)
            {
                return false;
            }
            if (source.index.CompareTo(other.index) > 0)
            {
                return true;
            }
            if (source.WorkingSec.CompareTo(other.index) < 0)
            {
                return false;
            }
            // working sec and index are equals
            return true;
        }
    }
}

