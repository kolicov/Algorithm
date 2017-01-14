using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class MergeSort
    {
        public void Run()
        {
            //int[] arr = { 3, 44, 38, 5, 47, 15, 36, 26, 27, 6, 46, 4, 19, 50, 48 };

            int[] arr = Utils.GenerateRandomIntegerArray(30, 100);

            Console.WriteLine("Merge sort\nInput: ");
            arr.Print();

            TimeUtils.StartWatch();

            arr = Sort(arr, 0, arr.Length - 1);

            TimeUtils.StopWatch();

            Console.WriteLine("Output:");
            arr.Print();
        }

        /// <summary>
        /// Merge sort algotithm
        /// </summary>
        /// <remarks>
        /// Complexity: best, average and worst case: n * log(n) 
        /// Stable: Yes
        /// Method: Merging
        /// </remarks>
        private static int[] Sort(int[] arr, int left, int right)
        {
            if (left + 2 <= right)
            {
                int pivot = GetMiddleElement(arr, left, right);

                Sort(arr, left, pivot);
                Sort(arr, pivot + 1, right);

                int i = left;
                int j = pivot + 1;

                int[] temp = new int[right - left + 1];

                for (int k = 0; k < temp.Length; k++)
                {
                    if (i >= pivot + 1)
                    {
                        temp[k] = arr[j];
                        j++;
                        continue;
                    }

                    if (j > right)
                    {
                        temp[k] = arr[i];
                        i++;
                        continue;
                    }

                    if (arr[i] > arr[j])
                    {
                        temp[k] = arr[j];
                        j++;
                    }
                    else
                    {
                        temp[k] = arr[i];
                        i++;
                    }
                }

                for (int k = 0; k < temp.Length; k++)
                {
                    arr[left + k] = temp[k];
                }
            }
            else
            {
                if (arr[left] > arr[right])
                {
                    arr.Swap(left, right);
                }
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
            int pivotValue = GetMiddleElement(arr, left, right);

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

        /// <summary>
        /// Returns the index of the middle element in a given range.
        /// </summary>
        private static int GetMiddleElement(int[] arr, int left, int right)
        {
            return left + (right - left) / 2;
        }
    }

}
