using System;

namespace dups
{
    public class Program
    {
        static void Main(string[] args)
        {
            int result = Util.FindDups("#aabCe");
        }
    }
    public static class Util
    {
        public static int FindDups(string input)
        {
            int dupNum = 0;
            // Convert string to array of characters + sort
            char[] chars = input.ToCharArray();
            Array.Sort(chars);

            for (int i = 0; i < chars.Length; i++)
            {
                char current = char.ToUpper(chars[i]);
                // If current char is non-alpha or non-numeric, return -1 to allow program to re-prompt user for input
                if (!IsAlphaNum(current))
                {
                    return -1;
                }
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
