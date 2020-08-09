using System.Text;

namespace CSharpLeetCode.Core
{
    public class AddStrings_415
    {
        public string AddStrings(string num1, string num2)
        {
            int i = num1.Length - 1;
            int j = num2.Length - 1;
            int add = 0;

            var strBuilder = new StringBuilder();

            while (i >= 0 || j >= 0 || add != 0)
            {
                int t1 = i >= 0 ? int.Parse(num1[i].ToString()) : 0;
                int t2 = j >= 0 ? int.Parse(num2[j].ToString()) : 0;

                int result = t1 + t2 + add;
                strBuilder.Append(result % 10);
                add = result / 10;

                i--;
                j--;
            }

            var reversStr = strBuilder.ToString();
            strBuilder.Clear();

            for (int m = reversStr.Length - 1; m >= 0; m--)
            {
                strBuilder.Append(reversStr[m]);
            }

            return strBuilder.ToString();
        }
    }
}
