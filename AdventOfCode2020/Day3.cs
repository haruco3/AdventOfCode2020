using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020
{
    static class Day3
    {
        static public void Part1()
        {
            string[] lines = Util.Input.ReadLines(323);
            int treeHitCount = TraverseSlope(3, 1, lines);

            Console.WriteLine("Number of trees hit: " + treeHitCount.ToString());
        }

        static public void Part2()
        {
            string[] lines = Util.Input.ReadLines(323);
            int slope1TreeHitCount = TraverseSlope(1, 1, lines),
                slope2TreeHitCount = TraverseSlope(3, 1, lines),
                slope3TreeHitCount = TraverseSlope(5, 1, lines),
                slope4TreeHitCount = TraverseSlope(7, 1, lines),
                slope5TreeHitCount = TraverseSlope(1, 2, lines);
            long total = slope1TreeHitCount;
            total = total * slope2TreeHitCount * slope3TreeHitCount * slope4TreeHitCount * slope5TreeHitCount;

            Console.WriteLine("Answer: " + total.ToString());
        }

        static private int TraverseSlope(int xMove, int yMove, string[] lines)
        {
            int treeHitCount = 0;
            int x = 0, y = 0;
            bool endReached = false;
            char currentSquare;

            do
            {
                currentSquare = lines[y][x];
                if (currentSquare == '#')
                    treeHitCount++;
                x += xMove; y += yMove;
                if (x >= lines[0].Length)
                    x -= lines[0].Length;
                if (y >= lines.Length)
                    endReached = true;
            }
            while (!endReached);

            return treeHitCount;
        }
    }
}
