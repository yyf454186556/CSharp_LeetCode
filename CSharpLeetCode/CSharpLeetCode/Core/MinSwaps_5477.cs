namespace CSharpLeetCode.Core
{
    /*
     这是第200次周赛的第三题
         */
    public class MinSwaps_5477
    {
        public int MinSwaps(int[][] grid)
        {
            // 规模
            int n = grid.Length;
            var array = new int[n]; //记录每行 从后向前连续的0的个数

            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = n - 1; j >= 0; j--)
                {
                    if (grid[i][j] == 0)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                array[i] = count;
            }

            //记录一下交换顺序
            int result = 0;

            for (int i = 0; i < n - 1; i++)
            {
                //不需要交换的情况,这里很容易发现，每行需要的从后向前连续的0的个数是依次递减的.所以即使超过了 n - i - 1 也没关系的
                if (array[i] >= n - i - 1)
                {
                    continue;
                }
                else //需要交换的情况
                {
                    int j = i;

                    for (j = i; j < n; j++)
                    {
                        //找到了！
                        if (array[j] >= n - i - 1)
                            break;
                    }

                    //找不到满足条件的结果了，直接判断不能完成，返回-1
                    if (j == n)
                        return -1;

                    for (; j > i; j--)
                    {
                        //经典冒泡向上浮动，哈哈
                        var temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;

                        //别忘了计算操作的次数
                        result++;
                    }
                }
            }

            return result;
        }
    }

    #region 比赛版本
    /*
     先贴一个没有完成的版本吧。感觉还是没有适应比赛的状态，和某位大佬的思路开头几乎一毛一样。
     可惜后来为啥想不开要去套个冒泡排序，哈哈哈

    public class Solution {
        public int MinSwaps(int[][] grid)
        {
            int n = grid.Length;
            var dict = new Dictionary<int, List<List<int>>>();
            var dict2 = new int[n];

            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = n - 1; j >= 0; j--)
                {
                    if (grid[i][j] == 0)
                    {
                        count++;
                    }
                    else
                    {
                        dict2[i] = count;
                        if (dict.ContainsKey(count))
                        {
                            dict[count].Add(grid[i].ToList());
                        }
                        else
                        {
                            var temp = new List<List<int>>();
                            temp.Add(grid[i].ToList());
                            dict.Add(count, temp);
                        }
                    }
                }
            }

            int remind = 0;

            for (int i = n - 1; i >= 1; i--)
            {
                if (!dict.ContainsKey(i) && remind <= 0)
                {
                    return -1;
                }
                else if (dict.ContainsKey(i))
                {
                    remind += dict[i].Count() - 1;
                }
                else if (!dict.ContainsKey(i) && remind > 0)
                {
                    remind--;
                }
            }

            int result = 0;

            for (int i = 0; i < n - 1; i ++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (dict2[i] < dict2[j])
                    {
                        var zzz = dict2[i];
                        dict2[i] = dict2[j];
                        dict2[j] = zzz;
                        result++;
                    }
                }
            }

            return result;
        }
    }

     */
    #endregion
}
