using CSharpLeetCode.Common;

namespace CSharpLeetCode.Core
{
    public class InvertTree_226
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null || (root.left == null && root.right == null))
                return root;

            var temp = InvertTree(root.left);
            root.left = InvertTree(root.right);
            root.right = temp;

            return root;
        }
    }
}
