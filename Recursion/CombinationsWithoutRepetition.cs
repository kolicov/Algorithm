using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // In combinations order of elements does not matter => 12 is the same as 21
    class CombinationsWithoutRepetition
    {
        // K is a set of elements N => K <= N
        static int K = 3;
        static int N = 4;

        public void Run()
        {
            int[] vector = new int[K];

            // Generate all combinations of (K) within set 1, 2, 3 (N)  
            GenCombinations(0, 0, vector);
        }

        static void GenCombinations(int k, int start, int[] vector)
        {
            for (int i = start; i < N; i++)
            {
                vector[k] = i;

                if (k + 1 < K)
                {
                    GenCombinations(k + 1, i + 1, vector);
                }
                else
                {
                    Print(vector);
                }
            }


        }

        static void Print(int[] vector)
        {
            foreach (int i in vector)
            {
                Console.Write("{0} ", i + 1);
            }
            Console.WriteLine();
        }
    }

}
