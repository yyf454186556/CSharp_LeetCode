using CSharpLeetCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Core
{
    public class Temp_199
    {
        Dictionary<List<TreeNode>, int> dic = new Dictionary<List<TreeNode>, int>();

        public int CountPairs(TreeNode root, int distance)
        {
            if (distance <= 1)
                return 0;

            return GetResult(root, distance);
        }

        public int GetResult(TreeNode root, int height)
        {
            if (root == null)
                return 0;

            int result = 0;

            var left = new List<TreeNode>();
            var right = new List<TreeNode>();

            for (int i = 1; i <= height - 1; i++)
            {
                var tempLeft = GetLeaf(root.left, i).Except(left).ToList();
                var tempRight = GetLeaf(root.right, height - i).Except(right).ToList();

                if (tempLeft.Count != 0 && tempRight.Count != 0)
                {
                    left.AddRange(tempLeft);
                    right.AddRange(tempRight);

                    result += tempLeft.Count * tempRight.Count;
                }
            }

            if (root.left != null)
                result += GetResult(root.left, height);
            if (root.right != null)
                result += GetResult(root.right, height);

            return result;
        }

        public List<TreeNode> GetLeaf(TreeNode root, int height)
        {
            if (height == 0 || root == null)
                return new List<TreeNode>();

            var result = new List<TreeNode>();

            if (root.left == null && root.right == null)
            {
                result.Add(root);
                return result;
            }

            if (root.left != null)
            {
                result.AddRange(GetLeaf(root.left, height - 1));
            }

            if (root.right != null)
            {
                result.AddRange(GetLeaf(root.right, height - 1));
            }
            

            return result;
        }

        public int MinFlips(string target)
        {
            return func2(target.ToCharArray());
        }

        public int func2(char[] str)
        {
            int count = 0;
            if (str[0] == '1')
                count = 1;

            char flag = str[0];

            for (int i = 1; i < str.Length; i++)
            {
                if (!flag.Equals(str[i]))
                {
                    flag = str[i];
                    count++;
                }
            }

            return count;
        }


        public int func(char[] str, int count)
        {
            if (str.All(x => x.Equals('0')))
                return count;

            bool flag = false;

            var array = str;

            for (int i = 0; i < str.Length; i++)
            {
                if (flag)
                {
                    if (array[i].Equals('0'))
                        array[i] = '1';
                    else
                        array[i] = '0';
                }

                if (!flag && array[i].Equals('1'))
                {
                    array[i] = '0';
                    flag = true;
                }
            }

            return func(array, count + 1);
        }

        public string RestoreString(string s, int[] indices)
        {
            Dictionary<int, char> dict = new Dictionary<int, char>();

            for (int i = 0; i < indices.Length; i++)
            {
                dict.Add(indices[i], s[i]);
            }

            var list = dict.OrderBy(x => x.Key).Select(x => x.Value).ToArray();

            return new string(list);
        }
    }
}
