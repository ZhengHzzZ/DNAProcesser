using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAProcesser.StringProcessor
{
    static class StringCompare
    {
        public static int EditDistance(string source, string target, out Queue<EditStruct> queue)
        {
            queue = new Queue<EditStruct>();
            Dictionary<string, EditStruct> dic = new Dictionary<string, EditStruct>();
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
                        EditType type = d[i, j] == edIns ? EditType.Insert : d[i, j] == edDel ? EditType.Delete : EditType.Replace;
                        dic.Add(i.ToString() + "@" + j.ToString(), GetChangeStruct(source, target, i, j, type));
                    }
                }
            }
            for (i = 0; i < d.GetLength(0); i++)
            {
                string str = "";
                for (j = 0; j < d.GetLength(1); j++)
                {
                    str += d[i, j].ToString() + " ";
                }
                Console.WriteLine(str);
                Console.WriteLine("");
            }



            return d[source.Length, target.Length];
        }

        private static EditStruct GetChangeStruct(string source, string target, int i, int j, EditType type)
        {
            EditStruct es = new EditStruct();
            es.editType = type;
            es.editPos = i - 1;
            es.editChar = target[j - 1];
            return es;
        }
    }
}
