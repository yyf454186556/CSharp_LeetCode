using CSharpLeetCode.Core;
using System;

namespace CSharpLeetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //使用对应的文件来跑，举个例子：
            //Tribonacci_1137 solution = new Tribonacci_1137();
            //solution.Tribonacci(25);

            //IsPalindrome_125 solution = new IsPalindrome_125();
            //solution.IsPalindrome("race a car");

            IsInterleave_97 solution = new IsInterleave_97();
            //            var result = solution.IsInterleave("bbbbbabbbbabaababaaaabbababbaaabbabbaaabaaaaababbbababbbbbabbbbababbabaabababbbaabababababbbaaababaa",
            //"babaaaabbababbbabbbbaabaabbaabbbbaabaaabaababaaaabaaabbaaabaaaabaabaabbbbbbbbbbbabaaabbababbabbabaab",
            //"babbbabbbaaabbababbbbababaabbabaabaaabbbbabbbaaabbbaaaaabbbbaabbaaabababbaaaaaabababbababaababbababbbababbbbaaaabaabbabbaaaaabbabbaaaabbbaabaaabaababaababbaaabbbbbabbbbaabbabaabbbbabaaabbababbabbabbab");

            //var result = solution.IsInterleave("aabcc","dbbca","aadbcbbcac");

            //var test = solution.CountSubTrees(7, new int[][] { new int[]{ 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 4 }, new int[] { 1, 5 }, new int[] { 2, 3 }, new int[] { 2, 6 } }, "abaedcd");

            //var test = solution.CountSubTrees(5, new int[][] { new int[] { 0, 1 }, new int[] { 0, 2 }, new int[] { 1, 3 }, new int[] { 0, 4 } }, "aabab");

            var test = solution.CountSubTrees(4, new int[][] { new int[] { 0, 2 }, new int[] { 0, 3 }, new int[] { 1, 2 } }, "aeed");

            Console.ReadLine();
        }
    }
}
