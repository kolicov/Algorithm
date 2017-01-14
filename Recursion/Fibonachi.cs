using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Fibonachi
    {
        static int N = 9;

        // This buffer is needed for the memoization (cash) of the calculated numbers.
        int[] _fibonachiNumbers = new int[N];

        public void Run()
        {
            CalcFibonachi(N - 1);

            _fibonachiNumbers.Print();
        }

        int CalcFibonachi(int n)
        {
            if (_fibonachiNumbers[n] != 0)
            {
                return _fibonachiNumbers[n];
            }
            else
            {
                if (n == 0)
                {
                    return 0;
                }

                if (n == 1)
                {
                    return 1;
                }
            }

            _fibonachiNumbers[n] = CalcFibonachi(n - 2) + CalcFibonachi(n - 1);

            return _fibonachiNumbers[n];
        }
    }
}
