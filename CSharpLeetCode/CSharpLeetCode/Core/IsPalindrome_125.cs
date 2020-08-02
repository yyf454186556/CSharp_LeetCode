using System.Linq;
using System.Text;

namespace CSharpLeetCode.Core
{
    public class IsPalindrome_125
    {
        public bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            var array = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'}.ToList();

            var builder = new StringBuilder();

            s = s.ToUpper();

            for (int i = 0; i < s.Length; i++)
            {
                if (array.Contains(s[i]))
                    builder.Append(s[i]);
            }

            string temp = builder.ToString();

            int start = 0;
            int end = temp.Length-1;

            while (start <= end)
            {
                if (temp[start++] == temp[end--])
                    continue;
                else
                    return false;
            }

            return true;
        }
    }
}
