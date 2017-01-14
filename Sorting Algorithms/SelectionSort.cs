using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class SelectionSort
    {
        public void Run()
        {
            //int[] arr = { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48 };

            int[] arr = Utils.GenerateRandomIntegerArray(30, 100);

            Console.WriteLine("Selection sort\nInput: ");
            arr.Print();

            var watch = System.Diagnostics.Stopwatch.StartNew();

            arr = Sort(arr);

            watch.Stop();

            double elapsedTime = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds).TotalSeconds;

            Console.WriteLine("\nOutput:");
            arr.Print();
            Console.WriteLine("\nElapsed time: " + elapsedTime + " seconds\n");
        }

        /// <summary>
        /// Selection sort algotirthm
        /// </summary>
        /// <remarks>
        /// Complexity: best, average and worst case: O(n^2)
        /// Type: Unstable
        /// Method: Selection
        /// </remarks>
        static int[] Sort(int[] arr)
        {
            int curSmallestIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                curSmallestIndex = i;

                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[j] < arr[curSmallestIndex])
                    {
                        curSmallestIndex = j;
                    }
                }

                // Check if there is a smaller than the current pivot
                if (curSmallestIndex > i)
                {
                    arr.Swap(i, curSmallestIndex);
                }
            }

            return arr;
        }
    }

}
