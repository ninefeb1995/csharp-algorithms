using System;
using System.Linq;

namespace ClassLibrary
{
    public class MaximumSubarray
    {
        public static int MaxSubArray(int[] nums)
        {
            int max = int.MinValue;
            int tempSum;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    tempSum = nums.Skip(i).Take(j - i + 1).Sum();
                    if (max < tempSum)
                    {
                        max = tempSum;
                    }
                }
            }
            return max;
        }

        public static int MaxSubArray1(int[] nums)
        {
            int size = nums.Length,
                max_so_far = int.MinValue,
                max_ending_here = 0;

            for (int i = 0; i < size; i++)
            {
                max_ending_here += nums[i];

                if (max_so_far < max_ending_here)
                    max_so_far = max_ending_here;

                if (max_ending_here < 0)
                    max_ending_here = 0;
            }

            return max_so_far;
        }

        public static int MaxSubArray2(int[] nums)
        {
            int n = nums.Length;
            int currentSum = nums[0];
            int maxSum = nums[0];

            for (int i = 1; i < n; i++)
            {
                currentSum = Math.Max(nums[i], currentSum + nums[i]);
                maxSum = Math.Max(maxSum, currentSum);
            }

            return maxSum;
        }

        public static int MaxSubArray3(int[] nums)
        {
            int tSum = int.MinValue,
                cSum = 0;
            
            for (int i = 0; i < nums.Length; i++)
            {
                if (cSum < 0)
                {
                    cSum = nums[i];
                }
                else
                {
                    cSum += nums[i];
                }

                if (cSum > tSum)
                {
                    tSum = cSum;
                }
            }
            
            return tSum;
        }

        public static int MaxSubArray4(int[] nums)
        {
            int n = nums.Length;
            return maxSubArraySum(nums, 0, n - 1);
        }

        // Find the maximum possible sum in arr[]  
        // such that arr[m] is part of it 
        private static int maxCrossingSum(int[] arr, int l, int m, int h)
        {
            // Include elements on left of mid. 
            int sum = 0;
            int left_sum = int.MinValue;
            for (int i = m; i >= l; i--)
            {
                sum += arr[i];
                if (sum > left_sum)
                {
                    left_sum = sum;
                }
            }

            // Include elements on right of mid 
            sum = 0;
            int right_sum = int.MinValue; ;
            for (int i = m + 1; i <= h; i++)
            {
                sum += arr[i];
                if (sum > right_sum)
                {
                    right_sum = sum;
                }
            }

            // Return sum of elements on left 
            // and right of mid 
            // returning only left_sum + right_sum will fail for [-2, 1] 
            return Math.Max(left_sum + right_sum, Math.Max(left_sum, right_sum));
        }

        // Returns sum of maxium sum subarray  
        // in aa[l..h] 
        private static int maxSubArraySum(int[] arr, int l, int h)
        {

            // Base Case: Only one element 
            if (l == h)
            {
                return arr[l];
            }

            // Find middle point 
            int m = (l + h) / 2;

            /* Return maximum of following three  
            possible cases: 
            a) Maximum subarray sum in left half 
            b) Maximum subarray sum in right half 
            c) Maximum subarray sum such that the  
            subarray crosses the midpoint */
            return Math.Max(Math.Max(maxSubArraySum(arr, l, m), maxSubArraySum(arr, m + 1, h)), maxCrossingSum(arr, l, m, h));
        }
    }
}
