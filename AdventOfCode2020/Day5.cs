using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    static class Day5
    {
        public const int ROW_COUNT = 128;
        public const int COLUMN_COUNT = 8;
        
        public static void Part1()
        {
            string[] lines = Util.Input.ReadLines(771);
            int highestID = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                BoardingPass b = new BoardingPass(lines[i]);
                if (b.seatID > highestID)
                    highestID = b.seatID;
            }
            Console.WriteLine("Highest seat ID: " + highestID);
        }

        public static void Part2()
        {
            const int MAX_ID = 816;
            bool[] seatsFilled = new bool[MAX_ID + 1];
            string[] lines = Util.Input.ReadLines(771);
            for (int i = 0; i < lines.Length; i++)
            {
                BoardingPass b = new BoardingPass(lines[i]);
                seatsFilled[b.seatID] = true;
            }
            for (int i = 1; i < seatsFilled.Length - 1; i++)
            {
                if (!seatsFilled[i])
                {
                    if (seatsFilled[i-1] && seatsFilled[i + 1])
                    {
                        Console.WriteLine("Your seat ID is: " + i);
                        return;
                    }
                }
            }
        }
    }

    class BoardingPass
    {
        public int row;
        public int column;
        public int seatID;

        public BoardingPass(string inputCode)
        {
            row = getRowNumber(inputCode, Day5.ROW_COUNT);
            seatID = (row * 8) + column;
        }

        private int getRowNumber(string inputCode, int numRows)
        {
            int ret;
            switch (inputCode[0])
            {
                case 'F':
                    ret = getRowNumber(inputCode.Substring(1), numRows/2);
                    break;
                case 'B':
                    ret = getRowNumber(inputCode.Substring(1), numRows / 2) + (numRows / 2);
                    break;
                default:
                    ret = 0;
                    column = getColumnNumber(inputCode, Day5.COLUMN_COUNT);
                    break;
            }
            return ret;
        }

        private int getColumnNumber(string inputCode, int numColumns)
        {
            int ret;
            if (inputCode == "")
                return 0;
            switch (inputCode[0])
            {
                case 'L':
                    ret = getColumnNumber(inputCode.Substring(1), numColumns / 2);
                    break;
                case 'R':
                    ret = getColumnNumber(inputCode.Substring(1), numColumns / 2) + (numColumns / 2);
                    break;
                default:
                    ret = 0;
                    break;
            }
            return ret;
        }
    }
}
