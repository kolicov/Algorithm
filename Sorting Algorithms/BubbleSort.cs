using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class BubbleSort
    {
        public void Run()
        {
            //int[] arr = { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48 };

            int[] arr = Utils.GenerateRandomIntegerArray(30, 100);

            Console.WriteLine("Bubble sort\nInput: ");
            arr.Print();

            TimeUtils.StartWatch();

            arr = Sort(arr);

            TimeUtils.StopWatch();

            Console.WriteLine("Output:");
            arr.Print();
        }

        /// <summary>
        /// Bubble sort algotirthm
        /// </summary>
        /// <remarks>
        /// Complexity: best O(n), average and worst case: O(n^2)
        /// Type: Stable
        /// Method: Exchanging
        /// </remarks>
        static int[] Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                bool swapped = false;

                int left = 0;
                for (int j = 0; j < arr.Length - 1; j++)
                {
                    if (arr[left + 1] < arr[left])
                    {
                        arr.Swap(left, left + 1);
                        swapped = true;
                    }

                    left++;
                }

                if (!swapped)
                {
                    break;
                }
            }

            return arr;
        }
    }

}
