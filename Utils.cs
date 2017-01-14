using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Utils
    {
        public static bool AreEqual(List<string> vec1, List<string> vec2)
        {
            if (vec1.Count == vec2.Count)
            {
                foreach (string str in vec1)
                {
                    if (!vec2.Contains(str))
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public static int[] GenerateRandomIntegerArray(int length, int maxValue)
        {
            Random random = new Random();

            int[] arr = new int[length];

            for (int i = 0; i < length; i++)
            {
                arr[i] = random.Next(maxValue);
            }

            return arr;
        }
    }

    static class ArrayEx
    {
        public static void Print(this int[] arr)
        {
            foreach (int i in arr)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine();
        }

        public static void Print(this int[,] arr)
        {
            int rowsCount = arr.GetLength(0);
            int columnsCount = arr.GetLength(1);

            for (int row = 0; row < rowsCount; row++)
            {
                for (int col = 0; col < columnsCount; col++)
                {
                    string cellValue = arr[row, col].ToString();

                    if (col > 0)
                    {
                        cellValue = ", " + cellValue;
                    }

                    Console.Write(cellValue);
                }

                Console.WriteLine();
            }
        }

        public static void Swap(this int[] arr, int e1, int e2)
        {
            int temp = arr[e1];
            arr[e1] = arr[e2];
            arr[e2] = temp;
        }
    }

    static class TimeUtils
    {
        static System.Diagnostics.Stopwatch _watch;

        public static void StartWatch()
        {
            _watch = System.Diagnostics.Stopwatch.StartNew();
        }

        public static void StopWatch()
        {
            _watch.Stop();

            double elapsedTime = TimeSpan.FromMilliseconds(_watch.ElapsedMilliseconds).TotalSeconds;

            Console.WriteLine("Elapsed time: " + elapsedTime + " seconds");
        }
    }
}
