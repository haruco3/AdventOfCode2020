using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    struct PasswordData
    {
        public int lowerBound;
        public int upperBound;
        public char constraintChar;
        public string password;
    }
    static class Day2
    {
        static public void Part1()
        {
            int validPasswordCount;
            const int linesCount = 1000;
            PasswordData rollingData;
            int charCount;

            validPasswordCount = 0;

            string[] passwords = Util.Input.ReadLines(linesCount);

            for (int i = 0; i < linesCount; i++)
            {
                rollingData = Day2.parseLine(passwords[i]);
                charCount = Util.String.CharCountOf(rollingData.password, rollingData.constraintChar);

                if (charCount >= rollingData.lowerBound && charCount <= rollingData.upperBound)
                    validPasswordCount++;
            }

            Console.WriteLine("Number of valid passwords: " + validPasswordCount.ToString());
        }

        static PasswordData parseLine(string line)
        {
            PasswordData ret = new PasswordData();

            string[] splitLine = line.Split(' ');
            string[] lowerAndUpperBound = splitLine[0].Split('-');

            ret.lowerBound = int.Parse(lowerAndUpperBound[0]);
            ret.upperBound = int.Parse(lowerAndUpperBound[1]);
            ret.constraintChar = splitLine[1][0];
            ret.password = splitLine[2];

            return ret;
        }
    }
}
