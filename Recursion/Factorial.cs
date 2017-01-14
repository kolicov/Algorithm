using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Factorial
    {
        static int F = 5;

        public void Run()
        {
            int factorielSum = GenFactoriel(F);

            Console.WriteLine(factorielSum);
        }

        static int GenFactoriel(int f)
        {
            int sum = f;

            if (f > 1)
            {
                sum *= GenFactoriel(f - 1);
            }

            return sum;
        }
    }

}
