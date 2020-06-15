using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TxtReplaceTool.Data;

namespace TxtReplaceTool.Server
{
    public static class TxtReplaceServer
    {
        public static string ReplaceTxtByDictionary(List<ReplaceInfo> replaceDic, string targetStr)
        {
            if (replaceDic == null)
            {
                return null;
            }
            foreach (var item in replaceDic)
            {
                if (item.IfReg)
                {
                    Regex reg = new Regex(item.OldStr);
                    targetStr = reg.Replace(targetStr, item.NewStr);
                }
                else
                {

                    targetStr = targetStr.Replace(item.OldStr, item.NewStr);
                }
            }
            return targetStr;
        }

    }
}
