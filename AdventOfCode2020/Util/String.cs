using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Util
{
    static class String
    {
        public static int CharCountOf(string str, char chr)
        {
            int charCount;

            charCount = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == chr)
                    charCount++;
            }

            return charCount;
        }

        public static bool ContainsLetters(string str)
        {
            return Regex.Match(str, "[a-z]").Success;
        }
    }
}
