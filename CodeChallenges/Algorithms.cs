using System;
using System.Collections.Generic;
using System.Text;

namespace CodeChallenges
{
    public static class Algorithms
    {
        // Binary search
        // Runtime: O(log n)
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

        // Selection Sort
        // runtime: O(n^2)
        public static int[] SortNums(int[] input)
        {
            List<int> inputList = new List<int>(input);
            int smallest = inputList[0];
            int[] result = new int[input.Length];

            for(int i = 0; i < input.Length; i++)
            {
                for(int j = 1; j < inputList.Count; j++)
                {
                    if(inputList[j] < smallest)
                    {
                        smallest = inputList[j];
                    }
                }
                result[i] = smallest;
                inputList.Remove(smallest);
                if(inputList.Count > 0)
                {
                    smallest = inputList[0];
                }
            }
            return result;
        }
    }
}
