using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // In permutation order of elements matters => 12 is different than 21
    class PermutationsWithRepetiotion
    {
        static int NumberOfSolutions;

        public void Run()
        {
            List<int> list = new List<int>{ 2, 3, 3, 3 };

            list.Sort(new Comparison<int>((i1, i2) => i2.CompareTo(i1)));

            GenPermutations(list.ToArray(), 0);

            Console.WriteLine("Number of solutions: " + NumberOfSolutions.ToString());
        }

        private void GenPermutations(int[] vector, int k)
        {
            if (k == vector.Count() - 1)
            {
                Print(vector);
                NumberOfSolutions++;
            }
            else
            {
                for (int i = k; i < vector.Count(); i++)
                {
                    int[] vectorNext;

                    if (i > k)
                    {
                        if (vector[k] != vector[i])
                        {
                            vectorNext = Swap(vector.Clone() as int[], k, i);
                        }
                        else
                        {
                            vectorNext = null;
                        }
                    }
                    else
                    {
                        vectorNext = vector;
                    }

                    if (vectorNext != null)
                    {
                        GenPermutations(vectorNext, k + 1);
                    }
                }
            }
        }

        private static int[] Swap(int[] arr, int e1, int e2)
        {
            int temp = arr[e1];
            arr[e1] = arr[e2];
            arr[e2] = temp;

            return arr;
        }

        private void Print(int[] vector)
        {
            foreach (int i in vector)
            {
                Console.Write(i);
            }

            Console.WriteLine();
        }
    }

}
