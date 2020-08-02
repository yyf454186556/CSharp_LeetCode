using CSharpLeetCode.Common;
using System.Collections.Generic;

namespace CSharpLeetCode.Core
{
    public class Flatten_114
    {
        public void Flatten(TreeNode root)
        {
            var list = new List<TreeNode>();

            Func(list, root);

            for (int i = 1; i < list.Count; i++)
            {
                TreeNode prev = list[i - 1];
                TreeNode current = list[i];
                prev.left = null;
                prev.right = current;
            }
        }

        private void Func(List<TreeNode> list, TreeNode root)
        {
            if (root != null)
            {
                list.Add(root);
                Func(list, root.left);
                Func(list, root.right);
            }
        }
    }
}
