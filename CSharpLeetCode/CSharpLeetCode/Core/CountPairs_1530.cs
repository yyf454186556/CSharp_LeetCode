using CSharpLeetCode.Common;

namespace CSharpLeetCode.Core
{
    /*
         这道题是199次周赛的第三题,笔者当时没有做出来
         记录一下
         当时印象深刻的错误是如何去重。
         考虑到需要递归的计算左右子树的好节点对，但当时禁锢于细节，陷入了去重影响当前逻辑，不去重结果必然错误的窘境.

         官方题解在这方面处理的方法值得思考。每次计算到可以作为子数根的结点P时，判断结点对是否满足条件的时候，人为增加了一个条件：
         两个结点必须分别在P的左右子数中，这样其实就会避免我上面遇到的问题.
         并且在这种情况下,好节点对之间的举例就等于A到Left的距离 + B到Right的距离 + 2.
    */
    public class CountPairs_1530
    {
        public int CountPairs(TreeNode root, int distance)
        {
            var pair = DFS(root, distance);
            return pair.count;
        }

        private Pair DFS(TreeNode root, int distance)
        {
            int[] depth = new int[distance + 1];
            bool isLeaf = root.left == null && root.right == null;

            //这个结点是叶子结点，因此depth[0] = 1, 且它没有子树，因此count = 0
            if (isLeaf)
            {
                depth[0] = 1;
                return new Pair(depth, 0);
            }

            int[] leftDepth = new int[distance + 1];
            int[] rightDepth = new int[distance + 1];
            int leftCount = 0;
            int rightCount = 0;

            //分别计算左右子树
            if (root.left != null)
            {
                var pair = DFS(root.left, distance);
                leftDepth = pair.depth;
                leftCount = pair.count;
            }

            if (root.right != null)
            {
                var pair = DFS(root.right, distance);
                rightDepth = pair.depth;
                rightCount = pair.count;
            }

            //注意这里结合depth的定义，这里计算的时当前结点为根的子树的 到当前结点长度为n的 叶子结点的个数
            //如果这个结点有子树，它一定不是叶子结点，也就没有必要计算 i = 0的情况，此外，还要额外加上1 为P的子树到p的距离.
            for (int i = 0; i < distance; i++)
            {
                depth[i + 1] += leftDepth[i];
                depth[i + 1] += rightDepth[i];
            }

            int count = 0;
            //排列组合，注意这里计算的都是当前结点为根的子树中的好结点对数，且一定是一个是在左子树，一个在右子树.
            for (int i = 0; i <= distance; i++)
            {
                for (int j = 0; j + i + 2 <= distance; j++)
                {
                    count += leftDepth[i] * rightDepth[j];
                }
            }

            //注意这里的count + leftCount + rightCount
            //其中count是P的好结点对个数，leftCount是P的左子树的对个数，rightCount类似.
            return new Pair(depth, count + leftCount + rightCount);
        }

        #region 没完成的Code
        //下面注释掉的是参赛时的代码：
        /*
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
        */
        #endregion
    }

    /// <summary>
    /// 注意这个类 用于描述某个子数的根结点的相关信息
    /// depth[i] 代表叶子结点到当前子树结点P的距离为i的叶子节点个数。例如 depth[2] = 1 代表到P的距离为2的叶子结点的个数为1
    /// count 代表以当前结点P为根的树中，好结点的对数
    /// </summary>
    public class Pair {
        public int[] depth;
        public int count;

        public Pair(int[] depth, int count)
        {
            this.depth = depth;
            this.count = count;
        }
    }
}
