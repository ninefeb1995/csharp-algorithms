using System;

namespace ClassLibrary
{
    public class SingleNumber
    {
        public static int FindSingleNumber(int[] nums)
        {
            int result = 0;
            foreach (var num in nums)
            {
                result ^= num;
            }
            return result;
        }
    }
}
