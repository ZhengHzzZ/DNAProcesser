using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DNAProcesser.DnaFormatParser
{
    class DnaFileParser
    {
        private static DnaFileParser _instance;

        public static DnaFileParser Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DnaFileParser();
                }
                return _instance;
            }
        }

        private DnaFileParser()
        { }

        public string ReadDnaFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    sr.ReadLine();
                    string data = sr.ReadLine();
                    string[] strs = data.Split(new char[] { '\u0002' }, StringSplitOptions.RemoveEmptyEntries);
                    return strs[1];
                }
            }
        }
    }
}
