using System;

namespace CSharpLeetCode.Core
{
    public class LongestIncreasingPath_329
    {
        int returnResult;

        public int LongestIncreasingPath(int[][] matrix)
        {
            returnResult = 1;
            if (matrix == null || matrix.Length == 0 || matrix[0].Length == 0)
            {
                return 0;
            }

            bool[][] flag = new bool[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                flag[i] = new bool[matrix[i].Length];
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    flag[i][j] = true;
                    if (i > 0 && matrix[i - 1][j] > matrix[i][j])
                        returnResult = Math.Max(returnResult, dfs(matrix, flag, i - 1, j, 2));
                    if (j > 0 && matrix[i][j - 1] > matrix[i][j])
                        returnResult = Math.Max(returnResult, dfs(matrix, flag, i, j - 1, 2));
                    if (i < matrix.Length - 1 && matrix[i + 1][j] > matrix[i][j])
                        returnResult = Math.Max(returnResult, dfs(matrix, flag, i + 1, j, 2));
                    if (j < matrix[i].Length - 1 && matrix[i][j + 1] > matrix[i][j])
                        returnResult = Math.Max(returnResult, dfs(matrix, flag, i, j + 1, 2));

                    flag[i][j] = false;
                }
            }

            return returnResult;
        }

        private int dfs(int[][] matrix, bool[][] flag, int i, int j, int result)
        {
            if (i < 0 || i >= matrix.Length || j < 0 || j >= matrix[i].Length)
                return result;

            flag[i][j] = true;

            if (i > 0 && matrix[i - 1][j] > matrix[i][j] && !flag[i - 1][j])
            {
                result = Math.Max(result, dfs(matrix, flag, i - 1, j, result + 1));
            }

            if (j > 0 && matrix[i][j - 1] > matrix[i][j] && !flag[i][j - 1])
            {
                result = Math.Max(result, dfs(matrix, flag, i, j - 1, result + 1));
            }

            if (i < matrix.Length - 1 && matrix[i + 1][j] > matrix[i][j] && !flag[i + 1][j])
            {
                result = Math.Max(result, dfs(matrix, flag, i + 1, j, result + 1));
            }

            if (j < matrix[i].Length - 1 && matrix[i][j + 1] > matrix[i][j] && !flag[i][j + 1])
            {
                result = Math.Max(result, dfs(matrix, flag, i, j + 1, result + 1));
            }

            flag[i][j] = false;

            return result;
        }
    }
}
