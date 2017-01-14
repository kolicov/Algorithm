using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class NestedLoopsToRequsion
    {
        static int N = 2;

        public void Run()
        {
            int[] vector = new int[N];

            GenVariations(0, vector);
        }

        // Generate variations
        static void GenVariations(int n, int[] vector)
        {
            for (int i = 0; i < N; i++)
            {
                vector[n] = i;

                if (n + 1 < N)
                {
                    GenVariations(n + 1, vector);
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
