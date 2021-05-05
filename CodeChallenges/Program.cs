using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenges
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] optionsArr = new string[] {"cat", "hat", "dog", "mat"};
            List<string> results = Unscramble("tac", optionsArr);
            
            foreach(string el in results)
            {
                Console.WriteLine(el);
            }
        }

        static List<string> Unscramble(string input, string[] options)
        {
            string sortedInput = new string(input.OrderBy(c => c).ToArray());
;
            List<string> result = new List<string>();

            for (int i = 0; i < options.Length; i++)
            {
                string sortedListItem = new string(options[i].OrderBy(c => c).ToArray());
                
                if(sortedInput == sortedListItem)
                {
                    result.Add(options[i]);
                }
            }

            return result;
        }
    }
}
