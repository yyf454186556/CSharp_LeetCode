// https://leetcode-cn.com/problems/n-th-tribonacci-number/
// 和斐波那契同样的思路，O(n)内即可完成，没什么好注释的。

namespace CSharpLeetCode.Core
{
    public class Tribonacci_1137
    {
        public int Tribonacci(int n)
        {
            if (n == 0)
                return 0;
            if (n == 1)
                return 1;
            if (n == 2)
                return 1;

            var array = new int[n + 1];
            array[0] = 0;
            array[1] = 1;
            array[2] = 1;

            for (int i = 3; i < array.Length; i++)
            {
                array[i] = array[i - 1] + array[i - 2] + array[i - 3];
            }

            return array[n];
        }
    }
}
