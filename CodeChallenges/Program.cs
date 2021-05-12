using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Atoi("   -42"));
        }

        // Unscramble a string by comparing it to a list of strings
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

        // helper function for GetLongestSubstring
        static char? GetDuplicate(List<char> arr)
        {
            var duplicates = arr.GroupBy(c => c)
                                .Where(g => g.Count() > 1)
                                .Select(g => g.Key)
                                .ToList();
            char? result = null;
            return duplicates.Count() == 0 ? result : duplicates[0];
        }
        // Returns the length of the longest substring without repeating values from a string input
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

        // Returns the median value of two int arrays
        static double GetMedian(int[] arrOne, int[] arrTwo)
        {
            List<int> numsArr = new List<int>();
            numsArr.AddRange(arrOne);
            numsArr.AddRange(arrTwo);

            var sortedNums = numsArr.OrderBy(n => n).ToList();

            if(sortedNums.Count() % 2 != 0)
            {
                double half = sortedNums.Count() / 2;
                int mid = (int)Math.Floor(half);
                return sortedNums[mid];
            } else
            {
                int secondIndex = sortedNums.Count() / 2;
                double num1 = sortedNums[secondIndex - 1];
                double num2 = sortedNums[secondIndex];

                double result = (num1 + num2) / 2;
                return result; 
            }
        }

        // Reverses the order of an int and returns 0 if there's an overflow exception
        static int ReverseNumber(int num)
        {
            try
            {
                string newString = "";
             
                if(num < 0)
                {
                    newString = "-";
                    num = Math.Abs(num);
                }
                string input = num.ToString();
                for(int i = input.Length - 1; i >= 0; i--)
                {
                    newString += input[i];
                }
                int result = Int32.Parse(newString);
                return result;
            }
            catch(Exception)
            {
                return 0;
            }
        }

        // Return the greatest numnber
        static int GetGreatestNum(int[] input)
        {
            List<int> inputArr = input.OrderBy(n => n).ToList();
            return inputArr[inputArr.Count() - 1];
        }

        // Determines if a number is a palindrome
        static bool isPalindrome(int n)
        {
            string input = n.ToString();
            char[] inputArr = input.ToCharArray();
            Array.Reverse(inputArr);
            string reversed = new string(inputArr);
            return input == reversed;
        }

        // Parse string to int. 
        static int Atoi(string input)
        {
            char[] inputArr = input.ToCharArray();   
            byte[] asciiValues = Encoding.ASCII.GetBytes(input);
            StringBuilder temp = new StringBuilder();
            bool numDetected = false;
            bool isNegative = false;
            for(int i = 0; i < inputArr.Length; i++)
            {
                if(!numDetected && asciiValues[i] == 43)
                {
                    temp.Append(inputArr[i]);
                    continue;
                }
                if (!numDetected && asciiValues[i] == 45)
                {
                    temp.Append(inputArr[i]);
                    isNegative = true;
                    continue;
                }
                if (asciiValues[i] >= 48 && asciiValues[i] <= 57)
                {
                    temp.Append(inputArr[i]);
                    numDetected = true;
                } else
                {
                    if(!numDetected && asciiValues[i] != 32)
                    {
                        break;
                    }
                    if (numDetected)
                    {
                        break;
                    }

                }
            }
            int result;
            try
            {
                result = Int32.Parse(temp.ToString());
            }
            catch (OverflowException)
            {
                if (isNegative)
                {
                    result = Int32.MinValue;
                } else
                {
                    result = Int32.MaxValue;
                }

            }
            catch(Exception)
            {
                result = 0;
            }
            return result;
        }

    }
}
