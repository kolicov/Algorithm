using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // In permutation order of elements matters => 12 is different than 21
    class PermutationsWithoutRepetiotion
    {
        static int N = 5;

        static int NumberOfSolutions;

        List<string> _permutations = new List<string>();

        public List<string> Run()
        {
            int[] vector = new int[N];

            for (int i = 1; i <= N; i++)
            {
                vector[i - 1] = i;
            }

            GenPermutations(vector, 0);

            Console.WriteLine("Number of solutions: " + NumberOfSolutions.ToString());

            return _permutations;
        }

        private void GenPermutations(int[] vector, int k)
        {
            if (k == vector.Count() - 1)
            {
                vector.Print();
                AddPermutation(vector);
                NumberOfSolutions++;
            }
            else
            {
                for (int i = k; i < vector.Count(); i++)
                {
                    int[] vectorNext;
                    if (i > k)
                    {
                        vectorNext = vector.Clone() as int[];

                        vectorNext.Swap(k, i);
                    }
                    else
                    {
                        vectorNext = vector;
                    }

                    GenPermutations(vectorNext, k + 1);
                }
            }
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
    }

}
