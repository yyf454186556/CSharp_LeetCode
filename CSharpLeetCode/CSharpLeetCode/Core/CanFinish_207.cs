using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLeetCode.Core
{
    public class CanFinish_207
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            var needPre = new HashSet<int>();

            var notNeedPre = new HashSet<int>();

            foreach (var item in prerequisites)
            {
                if(!needPre.Contains(item[0]))
                    needPre.Add(item[0]);

                if(!notNeedPre.Contains(item[1]))
                    notNeedPre.Add(item[1]);
            }

            foreach (var item in notNeedPre)
            {
                if (needPre.Contains(item))
                {
                    notNeedPre.Remove(item);
                }
            }

            if (notNeedPre.Count == 0)
            {
                return false;
            }
            else if (notNeedPre.Count > numCourses)
            {
                return true;
            }
            else
            {
                int remaind = numCourses - notNeedPre.Count();
            }

        }
    }
}
