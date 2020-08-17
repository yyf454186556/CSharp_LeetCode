using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Core
{
    public class Temp_201
    {
        public int MaxNonOverlapping(int[] nums, int target)
        {
            int res = 0;

            int end = -1;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                int sum = 0;

                if (nums[i] == target)
                {
                    if(i > end)
                        res++;
                    end = i;
                    continue;
                }

                for (int j = i; j < nums.Length; j++)
                {
                    if (j == i)
                    {
                        sum = nums[i];
                    }
                    else
                    {
                        sum = sum + nums[j];
                    }

                    if (sum == target)
                    {
                        if (i > end)
                        {
                            res++;
                            end = j;
                        }

                        break;
                    }
                    else if (sum > target)
                    {
                        break;
                    }
                }
            }

            if (nums[nums.Length - 1] == target)
            {
                res++;
            }

            return res;
        }


        public char FindKthBit(int n, int k)
        {
            var s1 = "0";
            var sb = new StringBuilder(s1);

            for (int i = 1; i < n; i++)
            {
                var temp = sb.ToString();
                sb.Append("1");
                sb.Append(digui(temp));
            }

            return sb.ToString()[k - 1];
        }

        public string digui(string s)
        {
            var sb = new StringBuilder();

            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i].Equals('0'))
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }
            }

            return sb.ToString();
        }


        public string MakeGood(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            bool flag = true;

            var tempStr = s;

            while (flag)
            {
                flag = false;
                var upper = tempStr.ToUpper();

                for (int i = 0; i < tempStr.Length - 1; i++)
                {
                    if (tempStr[i] != tempStr[i + 1] && (upper[i] == upper[i + 1]))
                    {
                        tempStr = tempStr.Substring(0, i - 0) + tempStr.Substring(i + 2, tempStr.Length - i - 2);
                        flag = true;
                        break;
                    }
                }
            }

            return tempStr;
        }
    }
}
