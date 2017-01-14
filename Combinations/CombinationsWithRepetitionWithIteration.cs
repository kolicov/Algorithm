using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // In combinations order of elements does not matter => 12 is the same as 21
    class CombinationsWithRepetitionWithIteration
    {
        const int N = 6;
        const int K = 3;

        static int NumberOfSolutions = 1;

        static int[] arr = new int[N];
        static int[] currentCombination = new int[K];

        public void Run()
        {
            // N = 6:
            // 1, 2, 3, 4, 5, 6
            for (int i = 0; i < N; i++)
            {
                arr[i] = i + 1;
            }

            for (int i = 0; i < K; i++)
            {
                currentCombination[i] = i + 1;
            }

            currentCombination.Print();

            int k = K - 1;

            bool isIncremented = true;

            while (k >= 0)
            {
                while (k < K)
                {
                    if (Increment(k))
                    {
                        k++;
                        isIncremented = true;
                    }
                    else
                    {
                        isIncremented = false;
                        ResetCurrentCombinationAllAfter(k);
                        break;
                    }
                }

                k--;

                if (isIncremented)
                {
                    NumberOfSolutions++;

                    currentCombination.Print();
                }
            }

            Console.WriteLine("Number of solutions: " + NumberOfSolutions.ToString());
        }

        /// <summary>
        /// Returns true if successfully incremented, otherwise false.
        /// </summary>
        bool Increment(int col)
        {
            bool rc = false;

            if (col > 0)
            {
                if (currentCombination[col - 1] > currentCombination[col])
                {
                    currentCombination[col] = currentCombination[col - 1];
                }
            }

            if (currentCombination[col] + 1 <= N)
            {
                currentCombination[col]++;

                rc = true;
            }

            return rc;
        }

        void ResetCurrentCombinationAllAfter(int col)
        {
            for(int i = col; i < K; i++)
            {
                currentCombination[i] = 0;
            }
        }
    }

}
