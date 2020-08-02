using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Core
{
    public class Temp_200
    {
        int minValue = int.MaxValue;

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




        public int GetWinner(int[] arr, int k)
        {
            var que = new Queue<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                que.Enqueue(arr[i]);
            }

            int count = k;

            int temp1 = int.MinValue;

            int max = arr.Max(x => x);

            while (count >= 1)
            {
                temp1 = (temp1 == int.MinValue ? que.Dequeue() : temp1);
                var temp2 = que.Dequeue();

                int tempMax = temp1;

                if (temp1 > temp2)
                {
                    count--;
                    que.Enqueue(temp2);
                }
                else
                {
                    que.Enqueue(temp1);
                    temp1 = temp2;
                    count = k - 1;
                }

                if (temp1 == max)
                    break;

            }

            return temp1;
        }

        public int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            int count = 0;

            for (int i = 0; i < arr.Length - 2; i++)
            {
                int j = i + 1;
                while (j < arr.Length - 1 && Math.Abs(arr[i] - arr[j]) > a)
                {
                    j++;
                }

                //if (Math.Abs(arr[i] - arr[j]) > a)
                //{
                //    continue;
                //}

                for (; j < arr.Length - 1; j++)
                {
                    int m = j + 1;
                    while (m < arr.Length && Math.Abs(arr[j] - arr[m]) > b)
                    {
                        m++;
                    }

                    if (m >= arr.Length || Math.Abs(arr[i] - arr[j]) > a || Math.Abs(arr[j] - arr[m]) > b)
                    {
                        continue;
                    }

                    for (; m < arr.Length; m++)
                    {
                        if (Math.Abs(arr[i] - arr[m]) <= c && Math.Abs(arr[i] - arr[j]) <= a && Math.Abs(arr[j] - arr[m]) <= b)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }
    }
}
