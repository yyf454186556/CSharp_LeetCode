using CSharpLeetCode.Common;
using System.Collections.Generic;

namespace CSharpLeetCode.Core
{
    public class LevelOrder_Offer_32
    {
        // 从上到下打印二叉树1
        public int[] LevelOrder(TreeNode root)
        {
            if (root == null)
                return new int[0];

            var result = new List<int>();

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var t = queue.Dequeue();
                result.Add(t.val);

                if (t.left != null)
                    queue.Enqueue(t.left);
                if (t.right != null)
                    queue.Enqueue(t.right);
            }
 
            return result.ToArray();
        }

        // 从上到下打印二叉树2
        public IList<IList<int>> LevelOrder2(TreeNode root)
        {
            if (root == null)
                return new List<IList<int>>();

            var result = new List<IList<int>>();

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var chilQueue = new Queue<TreeNode>();
                var tempList = new List<int>();

                while (queue.Count > 0)
                {
                    var t = queue.Dequeue();
                    tempList.Add(t.val);

                    if (t.left != null)
                        chilQueue.Enqueue(t.left);
                    if (t.right != null)
                        chilQueue.Enqueue(t.right);
                }

                result.Add(tempList);
                queue = chilQueue;
            }

            return result;
        }
    }
}
