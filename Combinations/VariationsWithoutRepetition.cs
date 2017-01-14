using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // In variation order of elements matters => 12 is different than 21
    class VariationsWithoutRepetition
    {
        // K is a set of elements N => K <= N
        static int K = 3;
        static int N = 4;

        static int[] Source = new int[N];
        static int NumberOfSolutions;

        public void Run()
        {
            for(int i = 0; i < N; i++)
            {
                Source[i] = i;
            }

            int[] vector = new int[K];

            // Generate all variations of (K) within set 1, 2, 3 (N)  
            GenVariations(0, vector);

            Console.WriteLine("Number of solutions: " + NumberOfSolutions.ToString());
        }

        static void GenVariations(int k, int[] vector)
        {
            int i = 0;
            while(i < N - k)
            {
                vector[k] = Source[i];
                if (k + 1 < K)
                {
                    Swap(Source, i, N - k - 1);
                    GenVariations(k + 1, vector);
                    Swap(Source, i, N - k - 1);
                }
                else
                {
                    Print(vector);
                    NumberOfSolutions++;
                }

                i++;
            }
        }

        private static void Swap(int[] arr, int e1, int e2)
        {
            int temp = arr[e1];
            arr[e1] = arr[e2];
            arr[e2] = temp;            
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
