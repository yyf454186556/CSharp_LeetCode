using System.Collections.Generic;
using System.Text;

namespace CSharpLeetCode.Core
{
    public class RestoreIpAddresses_93
    {
        public const int SEG_COUNT = 4;

        public List<string> result;
        public int[] segments = new int[SEG_COUNT];

        public IList<string> RestoreIpAddresses(string s)
        {
            result = new List<string>();
            dfs(s, 0, 0);

            return result;
        }

        public void dfs(string s, int segId, int segStart)
        {
            if (segId == SEG_COUNT)
            {
                if (segStart == s.Length)
                {
                    var ipAddress = new StringBuilder();

                    for (int i = 0; i < SEG_COUNT; i++)
                    {
                        ipAddress.Append(segments[i]);

                        if (i != SEG_COUNT - 1)
                        {
                            ipAddress.Append(".");
                        }
                    }

                    result.Add(ipAddress.ToString());
                }

                return;
            }

            //遍历到了字符串的末尾，仍旧没有找到四段IP，必然不符合条件
            if (segStart == s.Length)
            {
                return;
            }

            //遇到要判断的字符串首字符为0的情况，比较特殊，因为诸如 023，012这样的是不合法的，因此在这个IP段
            //内部，只能有0.'23*' 或 0.12*此类。0应单独占一个分隔区。
            if (s[segStart].Equals('0'))
            {
                segments[segId] = 0;
                dfs(s, segId + 1, segStart + 1);
            }

            int addr = 0;

            for (int segEnd = segStart; segEnd < s.Length; segEnd++)
            {
                addr = addr * 10 + (s[segEnd] - '0');

                if (addr > 0 && addr < 256)
                {
                    segments[segId] = addr;
                    dfs(s, segId + 1, segEnd + 1);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
