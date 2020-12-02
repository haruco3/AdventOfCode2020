using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2020.Util
{
    static class Sort
    {
        public static int[] bubbleSort(int[] ar)
        {
            int[] ret = new int[ar.Length];
            int temp;
            ar.CopyTo(ret, 0);
            for (int i = 0; i < ret.Length - 1; i++)
            {
                for (int j = 0; j < ret.Length - 1; j++)
                {
                    if (ret[j] > ret[j + 1])
                    {
                        temp = ret[j];
                        ret[j] = ret[j + 1];
                        ret[j + 1] = temp;
                    }
                }
            }
            return ret;
        }
    }
}
