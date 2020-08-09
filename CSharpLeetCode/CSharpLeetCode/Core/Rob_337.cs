using CSharpLeetCode.Common;
using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharpLeetCode.Core
{
    public class Rob_337
    {
        #region 递归，容易想但是效率太慢 递推公式：f(n) = max(n.val + 左右子数不含树根的最大值， 左右子树含树根的最大值)
        //执行用时：
        //2240 ms, 在所有 C# 提交中击败了 9.43% 的用户
        //内存消耗：26.2 MB, 在所有 C# 提交中击败了100.00%的用户
        //public int Rob(TreeNode root)
        //{
        //    if (root == null)
        //        return 0;

        //    if (root.left == null && root.right == null)
        //        return root.val;

        //    var result = Math.Max(func(root, true), func(root, false));
        //    return result;
        //}

        //private int func(TreeNode root, bool isIncludeRoot)
        //{
        //    if (root == null)
        //    {
        //        return 0;
        //    }

        //    if (root.left == null && root.right == null)
        //    {
        //        if (isIncludeRoot)
        //            return root.val;
        //        else
        //            return 0;
        //    }

        //    if (isIncludeRoot)
        //    {
        //        return func(root.left, false) + func(root.right, false) + root.val;
        //    }
        //    else
        //    {
        //        return Math.Max(func(root.left, true), func(root.left, false)) + Math.Max(func(root.right, true), func(root.right, false));
        //    }
        //}
        #endregion

        //大佬的解法，数组还是快呀
        public int Rob(TreeNode root)
        {
            //长度为二的数组，分别用于存储 选当前节点时能拿到的最多的钱， 索引0为不选当前结点，1为选当前结点
            //和不选当前节点能拿到的最多的钱
            int[] money = f(root);
            return Math.Max(money[0], money[1]);
        }

        private int[] f(TreeNode root)
        {
            if (root == null) return new int[2];
            int[] money = new int[2];
            int[] left = f(root.left);
            int[] right = f(root.right);

            money[0] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
            money[1] = left[0] + right[0] + root.val;

            return money;
        }
    }
}
