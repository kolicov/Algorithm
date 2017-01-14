using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    // * Description of the task *:
    // Write an algorithm to display gray code numbers. In Gray code, two adjacent numbers differ only by 1 value. For example for 4 compared to binary:

    // Decimal	Binary	Gray
    // 0	    000	    000
    // 1	    001	    001
    // 2	    010	    011
    // 3	    011	    010
    // 4	    100	    110
    // 5	    101	    111
    // 6	    110	    101
    // 7	    111	    100
    class GrayCode
    {
        static int N = 20;

        static int NumberOfSolutions = 0;

        int[] _vector = new int[N];

        public void Run()
        {
            Print();
            NumberOfSolutions++; // 0, 0, 0, 0 ... the first solution = default numbers

            GenNextCode(0);

            Console.WriteLine("Number of solutions: " + NumberOfSolutions.ToString());
        }

        private void GenNextCode(int k)
        {
            for (int i = k; i < _vector.Count(); i++)
            {
                GenNextCode(i + 1);

                ChangeValue(i);

                Print();
            }
        }

        private void ChangeValue(int col)
        {
            _vector[col] = _vector[col] == 0 ? 1 : 0;
            NumberOfSolutions++;
        }

        private void Print()
        {
            foreach (int i in _vector)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine();
        }
    }

}
