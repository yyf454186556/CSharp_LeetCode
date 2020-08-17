using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpLeetCode.Core
{
    public class Temp_202
    {
        public bool ThreeConsecutiveOdds(int[] arr)
        {
            if (arr.Length < 3)
                return false;

            for (int i = 0; i < arr.Length - 2; i++)
            {
                int i1 = i + 1;
                int i2 = i + 2;

                if ((arr[i] % 2 == 1) && (arr[i1] % 2 == 1) && (arr[i2] % 2 == 1))
                    return true;
            }

            return false;
        }

        public int MinOperations(int n)
        {
            if (n == 1)
                return 0;
            if (n == 2)
                return 1;

            int count = 0;
            int i = 1;

            while (i < n)
            {
                count += (n - i);
                i += 2;
            }

            return count;
        }

        public int MaxDistance(int[] position, int m)
        {
            return 0;
        }



        /*
            这个只是大佬给出的BFS解法的C#版的实现.
            只是自做聪明的改了一下For循环的条件(注释掉的那部分是错的)
            错误的原因是如果从0开始遍历,由于遍历中同时涉及到了更改queue的长度,因此会对结果产生影响--这样每次循环的内容是不对的。以56为例，来看一下每次循环中queue的值吧。

            //正确的写法 由于队列的性质,恰好能够遍历每一层的所有数字.
            //for (int i = queue.Count - 1; i >= 0; i--)
            56
            28 55
            14 27 54
            7 13 9 26 18 53
            6 12 3 8 25 17 52
            2 5 4 11 1 24 16 51
            10 0 23 15 50

            //错误的写法
            //for (int i = 0; i < queue.Count; i++)
            56
            14 27 54 //很明显的错误, 27是应该放在下次的遍历中的,但由于我们错误的写法,27出现在了第一次的for循环中.
            18 53 6 12 3 8 25
            52 2 5 4 11 1 24 16
            1 24 16 51 10
            0 23 15 50

            作者：yang-xian-sen-3
            链接：https://leetcode-cn.com/problems/minimum-number-of-days-to-eat-n-oranges/solution/cban-bfs-by-yang-xian-sen-3/
            来源：力扣（LeetCode）
            著作权归作者所有。商业转载请联系作者获得授权，非商业转载请注明出处。
             
        */
        public int MinDays(int n)
        {
            int result = 0;
            var queue = new Queue<int>();
            var set = new HashSet<int>();

            queue.Enqueue(n);

            while (queue.Count > 0)
            {

                //for (int i = 0; i < queue.Count; i++)
                for (int i = queue.Count - 1; i >= 0; i--)
                {
                    var t = queue.Dequeue();

                    if (t == 0)
                        return result;

                    if (t % 3 == 0 && !set.Contains(t / 3))
                    {
                        queue.Enqueue(t / 3);
                        set.Add(t / 3);
                    }

                    if (t % 2 == 0 && !set.Contains(t / 2))
                    {
                        queue.Enqueue(t / 2);
                        set.Add(t / 2);
                    }

                    if (!set.Contains(t - 1))
                    {
                        queue.Enqueue(t - 1);
                        set.Add(t - 1);
                    }
                }

                result++;
            }

            return result;
        }

    }
}
