using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeChemicalConnectionsClaculator
{
    public static class LCM
    {
        public static List<int> findFactors(int num)
        {
            if (num < 2)
            {
                throw new ArgumentException("number must be greater than one");
            }
            List<int> res = new List<int>();
            for (int i = 2; i <= num; i++)
            {
                while (num % i == 0)
                {
                    num /= i;
                    res.Add(i);
                }
            }
            return res;
        }
        public static int FindLCM(int num1, int num2)
        {
            num1 = Math.Abs(num1);
            num2 = Math.Abs(num2);
            if (num1 == num2)
            {
                return num1;
            }
            if (num1 == 0 || num2 == 0)
            {
                throw new ArgumentException("cannot calculate LCM of zero");
            }
            if (num1 == 1 || num2 == 1)
            {
                return Math.Max(num1, num2);
            }

            List<int> factors1 = findFactors(num1);
            int res = 1;

            foreach (int f in factors1)
            {
                if (num2 % f == 0)
                {
                    num2 /= f;
                }
                res *= f;

            }
            res *= num2;
            return res;
        }
    }
}
