using System.Linq;

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

        public static int FindSingleNumber1(int[] nums)
        {
            var numInList = nums.ToList();
            int i;
            for (i = 0; i < numInList.Count; i++)
            {
                int j;
                for (j = i + 1; j < numInList.Count; j++)
                {
                    if (numInList[i] == numInList[j])
                    {
                        break;
                    }
                }
                if (j == numInList.Count)
                {
                    break;
                }
                else
                {
                    numInList.RemoveAt(j);
                }
            }
            return numInList[i];
        }
    }
}
