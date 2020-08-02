using System;

//https://leetcode-cn.com/problems/best-sightseeing-pair/

namespace CSharpLeetCode.Core
{
    public class MaxScoreSightseeingPair_1014
    {
        //这道题的关键是把得分（A[i] + A[j] + i - j） 拆分成 A[i] + i 和 A[j] - j两部分，然后单次循环时固定A[j] - j
        public int MaxScoreSightseeingPair(int[] A)
        {
            int result = 0;
            int temp = A[0] + 0;

            for (int j = 1; j < A.Length; j++)
            {
                result = Math.Max(result, temp + A[j] - j);

                temp = Math.Max(temp, A[j] + j);
            }

            return result;
        }
    }
}
