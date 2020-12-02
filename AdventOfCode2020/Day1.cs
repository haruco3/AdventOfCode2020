using System;

namespace AdventOfCode2020
{
    static class Day1
    {
        public static void Part1()
        {
            string input = "";
            int[] ar = new int[200];
            int index = 0;
            while (input != "end")
            {
                input = Console.ReadLine();
                if (input == "end")
                    break;
                ar[index] = int.Parse(input);
                index++;
            }
            ar = Util.Sort.bubbleSort(ar);
            int ans1 = 0;
            int seek = 0;
            bool ansFound = false;
            int ans2 = 0;
            for (int i = 0; i < (ar.Length / 2); i++)
            {
                ans1 = ar[i];
                seek = 2020 - ar[i];
                for (int j = ar.Length - 1; j >= i; j--)
                {
                    if (ar[j] < seek)
                        break;
                    else if (ar[j] == seek)
                    {
                        ansFound = true;
                        ans2 = ar[j];
                        break;
                    }
                }
                if (ansFound)
                    break;
            }
            if (ansFound)
                Console.WriteLine("Answer is: " + ans1.ToString() + " * " + ans2.ToString() + " = " + (ans1 * ans2).ToString());
        }

        public static void Part2()
        {
            string input = "";
            int[] ar = new int[200];
            int index = 0;
            while (input != "end")
            {
                input = Console.ReadLine();
                if (input == "end")
                    break;
                ar[index] = int.Parse(input);
                index++;
            }
            ar = Util.Sort.bubbleSort(ar);
            int ans = 0;
            int seek = 0;
            int seek2 = 0;
            bool ansFound = false;
            for (int i = 0; i < ar.Length; i++)
            {
                seek = 2020 - ar[i];
                for (int j = i + 1; j < ar.Length; j++)
                {
                    if (ar[j] >= seek)
                        break;
                    seek2 = seek - ar[j];
                    for (int k = j + 1; k < ar.Length; k++)
                    {
                        if (ar[k] > seek2)
                            break;
                        else if (ar[k] == seek2)
                        {
                            ansFound = true;
                            ans = ar[i] * ar[j] * ar[k];
                        }
                    }
                    if (ansFound)
                        break;
                }
                if (ansFound)
                    break;
            }
            if (ansFound)
                Console.WriteLine("Answer is: " + ans.ToString());
        }
    }
}