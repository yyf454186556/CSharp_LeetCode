using System;
using System.Collections.Generic;

namespace CSharpLeetCode.Core
{
    public class MinimumTotal_120
    {
        private object math;

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            if (triangle.Count == 1)
            {
                return triangle[0][0];
            }

            int length = triangle.Count;

            return back(0, 0, triangle);
        }

        public int back(int i, int j, IList<IList<int>> triangle)
        {
            if (i >= triangle.Count)
            {
                return 0;
            }

           return triangle[i][j] + Math.Min(back(i + 1, j, triangle), back(i + 1, j + 1, triangle));
        }
    }
}
