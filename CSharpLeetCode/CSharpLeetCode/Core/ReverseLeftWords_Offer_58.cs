using System.Text;

namespace CSharpLeetCode.Core
{
    public class ReverseLeftWords_Offer_58
    {
        public string ReverseLeftWords(string s, int n)
        {
            var t1 = s.Substring(0, n - 1);
            var t2 = s.Substring(n - 1);

            return new StringBuilder().Append(t2).Append(t1).ToString();
        }
    }
}
