using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAProcesser
{
    static class StringCompare
    {
        public static int EditDistance(string source, string target)
        {
            int i, j;
            int[,] d = new int[source.Length + 1, target.Length + 1];

            for (i = 0; i <= source.Length; i++)
                d[i, 0] = i;
            for (j = 0; j <= target.Length; j++)
                d[0, j] = j;

            for (i = 1; i <= source.Length; i++)
            {
                for (j = 1; j <= target.Length; j++)
                {
                    if ((source[i - 1] == target[j - 1]))
                    {
                        d[i, j] = d[i - 1, j - 1]; //不需要编辑操作
                    }
                    else
                    {
                        int edIns = d[i, j - 1] + 1; //source 插入字符
                        int edDel = d[i - 1, j] + 1; //source 删除字符
                        int edRep = d[i - 1, j - 1] + 1; //source 替换字符

                        d[i, j] = Math.Min(Math.Min(edIns, edDel), edRep);
                    }
                }
            }

            return d[source.Length, target.Length];
        }
    }
}
