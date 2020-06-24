using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class HappyNumber
    {
        public bool Is(int n)
        {
            int result = n;

            while (result != 1 && result != 4)
            {
                result = IsHappyNumber(result);
            }

            return result == 4;
        }

        private static int IsHappyNumber(int num)
        {
            int sum = 0;

            while (num > 0)
            {
                int rem = num % 10;
                sum += rem * rem;
                num /= 10;
            }

            return sum;
        }
    }
}
