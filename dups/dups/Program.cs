using System;

namespace dups
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter text: ");
            string userInput = Console.ReadLine();
            int result = Util.FindDups(userInput);
            while (result == -1)
            {
                Console.Write("Non-alphanumeric characters are not permitted. Please try again: ");
                userInput = Console.ReadLine();
                result = Util.FindDups(userInput);
            }
            Console.WriteLine(string.Format("Input: {0}, Duplicates: {1}", userInput, result));
        }
    }
    public static class Util
    {
        public static int FindDups(string input)
        {
            int dupNum = 0;
            // Convert string to array of characters + sort
            char[] chars = input.ToUpper().ToCharArray();
            Array.Sort(chars);
            // Track previous char for comparison + toggle to true if a dup has already been counted for the current duplicate
            char prevChar = '!';
            bool dupAlreadyCounted = false;
            for (int i = 0; i < chars.Length; i++)
            {
                char current = chars[i];
                // If current char is non-alpha or non-numeric, return -1 to allow program to re-prompt user for input
                if (!IsAlphaNum(current))
                {
                    return -1;
                }
                // Increment the number of duplicate characters if the current and previous match && a duplicate has not already been provided
                else if (current == prevChar && !dupAlreadyCounted)
                {
                    dupNum += 1;
                    dupAlreadyCounted = true;
                }
                else if (current != prevChar)
                {
                    dupAlreadyCounted = false;
                }
                prevChar = current;
            }
            return dupNum;
        }
        private static bool IsAlphaNum(char input)
        {
            char c = char.ToUpper(input);
            if (c >= '0' && c <= '9')
            {
                return true;
            }
            else if (c >= 'A' && c <= 'Z')
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
