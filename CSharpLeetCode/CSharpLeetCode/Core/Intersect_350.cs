using System.Collections.Generic;
using System.Linq;

namespace CSharpLeetCode.Core
{
    public class Intersect_350
    {
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            var result = new List<int>();
            var dict = new Dictionary<int, int>();

            int[] temp;
            int[] tempL;

            if (nums1.Length < nums2.Length)
            {
                temp = nums1;
                tempL = nums2;
            }
            else
            {
                temp = nums2;
                tempL = nums1;
            }

            for (int i = 0; i < temp.Length; i++)
            {
                if (dict.Keys.Contains(temp[i]))
                {
                    dict[temp[i]] = dict[temp[i]] + 1;
                }
                else
                {
                    dict.Add(temp[i], 1);
                }
            }

            for (int i = 0; i < tempL.Length; i++)
            {
                if (dict.Keys.Contains(tempL[i]) && dict[tempL[i]] > 0)
                {
                    dict[tempL[i]] = dict[tempL[i]] - 1;
                    result.Add(tempL[i]);
                }
            }

            return result.ToArray();
        }
    }
}
