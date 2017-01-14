using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class QuickSort
    {
        public void Run()
        {
            //int[] arr = { 3, 44, 38, 5, 47, 15, 36, 26, 27, 6, 46, 4, 19, 50, 48 };

            int[] arr = Utils.GenerateRandomIntegerArray(30, 100);

            Console.WriteLine("Quick sort\nInput: ");
            arr.Print();

            TimeUtils.StartWatch();

            arr = Sort(arr, 0, arr.Length - 1);

            TimeUtils.StopWatch();

            Console.WriteLine("Output:");
            arr.Print();
        }

        /// <summary>
        /// Quick sort algotirthm
        /// </summary>
        /// <remarks>
        /// Complexity: best O(n^2), average and worst case: n * log(n) 
        /// Stable: Depends
        /// Method: Partioning
        /// </remarks>
        private static int[] Sort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partion(arr, left, right);

                Sort(arr, left, pivot);
                Sort(arr, pivot + 1, right);
            }

            return arr;
        }

        /// <summary>
        /// Moves all elements with less value to the left and with hiegher value to the right.
        /// Find a pivot (in best case the a number with middle value compared to the rest) and moves all elements
        /// with less or equal value to the left of it and rest - to the right.
        /// </summary>
        private static int Partion(int[] arr, int left, int right)
        {
            // 3, 44, 38, 5, 47, 15, 36, "26", 27, 6, 46, 4, 19, 50, 48
            int pivotValue = GetMedianFromArray(arr, left, right);

            int i = left - 1;
            int j = right + 1;

            while (true)
            {
                do
                {
                    j--;
                }
                while (arr[j] > pivotValue);

                do
                {
                    i++;
                }
                while (arr[i] < pivotValue);

                if (i < j)
                {
                    arr.Swap(i, j);
                }
                else
                {
                    return j;
                }
            }
        }

        private static int GetMedianFromArray(int[] arr, int rangeLeft, int rangeRight)
        {
            int middleInRange = rangeLeft + (rangeRight - rangeLeft) / 2;
            return GetMedian(arr[rangeLeft], arr[middleInRange], arr[rangeRight]);
        }

        // Returns one of three given numbers, which has value less than one of them and higher than the other (middle/median).
        private static int GetMedian(int v1, int v2, int v3)
        {
            if (v1 > v2)
            {
                if (v3 > v1)
                {
                    return v1;
                }
                else // v3 <= v1
                {
                    if (v2 > v3)
                    {
                        return v2;
                    }
                    else
                    {
                        return v3;
                    }
                }
            }
            else // v1 <= v2
            {
                if (v3 > v2)
                {
                    return v2;
                }
                else // v3 <= v2
                {
                    if (v1 > v3)
                    {
                        return v1;
                    }
                    else
                    {
                        return v3;
                    }
                }
            }
        }
    }

}
