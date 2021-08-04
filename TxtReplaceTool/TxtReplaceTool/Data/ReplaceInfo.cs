using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TxtReplaceTool.Data
{
    public class ReplaceInfo
    {
        //要替换的旧字符串
        public string OldStr { get; set; }

        //替换目标新字符串
        public string NewStr { get; set; }

        //是否使用正则
        public bool IfReg { get; set; }


        public ReplaceInfo(string oldStr, string newStr, bool ifReg)
        {
            this.OldStr = oldStr;
            this.NewStr = newStr;
            this.IfReg = ifReg;
        }
    }
}
