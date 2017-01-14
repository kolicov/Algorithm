using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // In variation order of elements matters => 12 is different than 21
    class VariationsWithRepetition
    {
        // K is a set of elements N => K <= N
        static int K = 15;
        static int N = 4;

        public void Run()
        {
            int[] vector = new int[K];

            // Generate all variations of (K) within set 1, 2, 3 (N)  
            GenVariations(0, vector);

            Console.WriteLine("End");
        }

        static void GenVariations(int k, int[] vector)
        {
            for (int i = 0; i < N; i++)
            {
                vector[k] = i;

                if (k + 1 < K)
                {
                    GenVariations(k + 1, vector);
                }
                else
                {
                    //Print(vector);
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
