using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetLongestSubstring("abacdaacdesf"));
        }

        static List<string> Unscramble(string input, string[] options)
        {
            string sortedInput = new string(input.OrderBy(c => c).ToArray());
            List<string> result = new List<string>();

            for(int i = 0; i < options.Length; i++)
            {
                string sortedEl = new string(options[i].OrderBy(c => c).ToArray());
                
                if(sortedEl == sortedInput)
                {
                    result.Add(options[i]);
                }
            }
            return result;
        }

        static char? GetDuplicate(List<char> arr)
        {
            var duplicates = arr.GroupBy(c => c)
                                .Where(g => g.Count() > 1)
                                .Select(g => g.Key)
                                .ToList();
            char? result = null;
            return duplicates.Count() == 0 ? result : duplicates[0];
        }

        static int GetLongestSubstring(string input)
        {
            char[] inputArr = input.ToCharArray();
            int maxLength = 0;
            List<char> temp = new List<char>();
            int deleteNum;

            for(int i = 0; i < inputArr.Length; i++)
            {
                temp.Add(inputArr[i]);
                char? duplicate = GetDuplicate(temp);

                if(duplicate.GetValueOrDefault() == 0)
                {
                    if(maxLength < temp.Count())
                    {
                        maxLength = temp.Count();
                    }
                } else
                {
                    // abcdb
                    deleteNum = temp.IndexOf(duplicate.GetValueOrDefault()) + 1;
                    temp.RemoveRange(0, deleteNum);
                }
            }
            return maxLength;
        }
    }
}
