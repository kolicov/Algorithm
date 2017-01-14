using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class InsertionSort
    {
        public void Run()
        {
            //int[] arr = { 3, 44, 38, 5, 47, 15, 36, 26, 27, 6, 46, 4, 19, 50, 48 };

            int[] arr = Utils.GenerateRandomIntegerArray(30, 100);

            Console.WriteLine("Insertion sort\nInput: ");
            arr.Print();

            TimeUtils.StartWatch();

            arr = Sort(arr);

            TimeUtils.StopWatch();

            Console.WriteLine("Output:");
            arr.Print();
        }

        /// <summary>
        /// Insertion sort algotirthm
        /// </summary>
        /// <remarks>
        /// Complexity: best O(n), average and worst case: O(n^2) 
        /// Type: Stable
        /// Method: Insertion
        /// </remarks>
        static int[] Sort(int[] arr)
        {
            // All elements to the left (less than its index) are sorted
            int lastSorted = 0;

            while (lastSorted + 1 < arr.Length)
            {
                for (int j = lastSorted; j >= 0; j--)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        arr.Swap(j, j + 1);
                    }
                    else
                    {
                        break;
                    }
                }

                lastSorted++;
            }

            return arr;
        }
    }

}
