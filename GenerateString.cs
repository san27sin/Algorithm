using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class GenerateString
    {
        public static void FillRandomString(string[] test)
        {
            for(int i = 0; i < test.Length; i++)
            {
                test[i] = i == test.Length/2 ? "test": CreateRandomString();
            }
        }

        public static void FillRandomString(HashSet<string> test, int count)
        {
            for (int i = 0; i < count; i++)
            {
                string word = i == count / 2 ? "test" : CheckThePreviousValue(test);               

                test.Add(word);
            }
        }

        private static string CheckThePreviousValue(HashSet<string> test)
        {
            string word = CreateRandomString();
            if (!test.Contains(word))
                return word;
            else
                return CheckThePreviousValue(test);
        }

        private static string CreateRandomString()
        {
            Random rand = new Random();
            int length = rand.Next(3, 10);
            int count = 0;
            List<char> word = new List<char>();
            while(count < length)
            {
                char letter = (char)rand.Next(65, 122);
                word.Add(letter);
                count++;
            }
            return new string(word.ToArray());
        }
    }
}
