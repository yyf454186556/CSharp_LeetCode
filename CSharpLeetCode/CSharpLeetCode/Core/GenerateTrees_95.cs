using CSharpLeetCode.Common;
using System.Collections.Generic;

namespace CSharpLeetCode.Core
{
    public class GenerateTrees_95
    {
        public IList<TreeNode> GenerateTrees(int n)
        {
            if (n == 0)
                return new List<TreeNode>();

            return generateTrees(1, n);
        }

        public IList<TreeNode> generateTrees(int start, int end)
        {
            var result = new List<TreeNode>();

            if (start > end)
            {
                result.Add(null);
                return result;
            }

            for (int i = start; i <= end; i++)
            {
                var leftTrees = generateTrees(start, i - 1);
                var rightTrees = generateTrees(i+1, end);

                foreach (var left in leftTrees)
                {
                    foreach (var right in rightTrees)
                    {
                        var root = new TreeNode(i, left, right);
                        result.Add(root);
                    }
                }
            }

            return result;
        }
    }
}
