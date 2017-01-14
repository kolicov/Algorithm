using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // Cube of pascal

    // The cube of pascal 

    // Example at N = 6

    // 1
    // 1  1
    // 1  2  1
    // 1  3  3  1
    // 1  4  6  4  1
    // 1  5 10  10 5  1
    // 1  6 15  20 15 6 1
    class TriangleOfPascal
    {
        static int N = 10;

        public void Run()
        {
            int[] vector = new int[1];

            for (int i = 0; i < N; i++)
            {
                vector = GenLine(vector);

                Print(vector);
            }
        }

        private int[] GenLine(int[] arr)
        {
            int[] arrGenerated = new int[arr.Count() + 1];

            arrGenerated[0] = 1;
            arrGenerated[arr.Count()] = 1;

            if (arr.Count() > 1)
            {
                for (int i = 0; i < arr.Count() - 1; i++)
                {
                    arrGenerated[i + 1] = arr[i] + arr[i + 1];
                }
            }

            return arrGenerated;
        }

        private static void Print(int[] vector)
        {
            foreach (int i in vector)
            {
                Console.Write(i + "  ");
            }

            Console.WriteLine();
        }
    }
}
