using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Util
{
    static class Input
    {
        static public string[] ReadLines(int arrayLength)
        {
            string currentInput;
            int currentArrayIndex;
            string[] inputLines;

            currentInput = "";
            currentArrayIndex = 0;
            inputLines = new string[arrayLength];

            while (currentInput != "end")
            {
                currentInput = Console.ReadLine();
                if (currentInput == "end")
                    break;
                inputLines[currentArrayIndex] = currentInput;
                currentArrayIndex++;
            }

            return inputLines;
        }
    }
}
