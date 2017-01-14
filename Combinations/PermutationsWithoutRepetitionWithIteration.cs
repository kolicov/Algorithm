using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // In permutation order of elements matters => 12 is different than 21
    class PermutationsWithoutRepetitionWithIteration
    {
        const int N = 5;

        static int NumberOfSolutions = 1;

        static int[] arr = new int[] { 1, 2, 3, 4, 5 };

        List<string> _permutations = new List<string>();

        public List<string> Run()
        {
            // Create vector with needed number of steps to iterate for each column.
            int[] steps = new int[N];

            ResetStepsStartingFrom(0, steps);

            arr.Print();
           
            AddPermutation(arr);

            int k = N - 2; // Start from the end

            while (true)
            {
                while (steps[k] > 0)
                {
                    steps[k]--;

                    // Check if column position is even or odd
                    bool isOdd = (N - k) % 2 != 0;

                    if (!isOdd && k < N - 3 && steps[k] == 0)
                    {
                        arr.Swap(k, N - 1);
                    }
                    else
                    {
                        arr.Swap(k, k + 1);
                    }

                    ResetStepsStartingFrom(k + 1, steps);

                    k = N - 2;

                    NumberOfSolutions++;

                    AddPermutation(arr);

                    arr.Print();
                }

                k--;

                if (k < 0)
                {
                    break;
                }
            }

            return _permutations;

            //Console.WriteLine("Number of solutions: " + NumberOfSolutions.ToString());
        }

        private void AddPermutation(int[] permutation)
        {
            string str = "";

            foreach (int i in permutation)
            {
                str += i + ",";
            }

            _permutations.Add(str);
        }

        void ResetStepsStartingFrom(int startCol, int[] steps)
        {
            for (int i = 1; i < N - startCol; i++)
            {
                steps[N - i - 1] = i;
            }
        }
    }

}
