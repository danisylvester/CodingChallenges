using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges
{
    public static class Algorithms
    {
        // Binary search
        public static int FindIndexOf(int[] nums, int target)
        {
            int min = 0;
            int max = nums.Length -1;
            int mid = max / 2;

            while(min <= max)
            {
                mid = (min + max) / 2;
                if(target == nums[mid])
                {
                    return mid;
                } 
                if(target > nums[mid])
                {
                    min = mid + 1;
                } else
                {
                    max = mid + 1;
                }
            }
            return mid;
        }
    }
}
