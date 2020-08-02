using CSharpLeetCode.Common;
using CSharpLeetCode.Core;
using System;

namespace CSharpLeetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var solution = new Temp_199();

            //var root = new TreeNode(1);
            //root.left = new TreeNode(2, null, new TreeNode(4));
            //root.right = new TreeNode(3, null, null);
            ////root.left = new TreeNode(2, new TreeNode(4), new TreeNode(5));
            ////root.right = new TreeNode(3, new TreeNode(6), new TreeNode(7));

            ////var root = new TreeNode(7);
            ////root.left = new TreeNode(1, new TreeNode(6), null);
            ////root.right = new TreeNode(4, new TreeNode(5), new TreeNode(3,null, new TreeNode(2)));

            //var result = solution.CountPairs(root, 3);

            var soulution = new Temp_200();

            soulution.MinSwaps(new int[][] { new int[] {1,0, 0,0}, new int[] { 1, 1, 1, 1 }, new int[] { 1, 0, 0, 0 } , new int[] { 1, 0, 0, 0 } });

            Console.ReadLine();
        }
    }
}
