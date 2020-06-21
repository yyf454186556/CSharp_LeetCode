namespace CSharpLeetCode.Core
{
    //没有特别好的思路，使用的是官方的解法，先转置再翻转每一行
    //另外也可以从变换前后的规律下手，但要注意替换后是否会影响后续的操作
    //具体来说规则应该是 i,j ==> j, lenght - i - 1
    /*
            00 01 02 03      30 20 10 00
            10 11 12 13      31 21 11 01
            20 21 22 23      32 22 12 02
            30 31 32 33      33 23 13 03
    */
    public class Rotate_48
    {
        public void Rotate(int[][] matrix)
        {
            int length = matrix.Length;

            for (int i = 0; i < length; i++)
            {
                for (int j = i; j < length; j++)
                {
                    int tmp = matrix[j][i];
                    matrix[j][i] = matrix[i][j];
                    matrix[i][j] = tmp;
                }
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length / 2; j++)
                {
                    int tmp = matrix[i][j];
                    matrix[i][j] = matrix[i][length - j - 1];
                    matrix[i][length - j - 1] = tmp;
                }
            }
        }
    }
}
