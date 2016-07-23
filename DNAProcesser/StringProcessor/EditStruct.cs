using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNAProcesser.StringProcessor
{
    class EditStruct
    {
        public int editPos;
        public EditType editType;
        public char editChar;

        public EditStruct()
        {
            editPos = -1;
            editType = EditType.None;
            editChar = '@';
        }

        public override string ToString()
        {
            return string.Format("EditPos:{0},EditType:{1},EditChar:{2}", editPos.ToString(), editType.ToString(), editChar.ToString());
        }
    }

    enum EditType
    {
        None,
        Insert,
        Delete,
        Replace,
    }
}
