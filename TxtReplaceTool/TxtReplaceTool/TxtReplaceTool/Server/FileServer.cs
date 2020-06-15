using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxtReplaceTool.Data;

namespace TxtReplaceTool.Server
{
    public static class FileServer
    {
        //默认打开路径
        private static string InitialDirectory = "D:\\";

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string ReadFile(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            string str = null;
            using (FileStream fs = new FileStream(path,FileMode.Open))
            {
                StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"),true);
                str = sr.ReadToEnd();
            }
            InitialDirectory = path;

            return str;
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="str"></param>
        /// <param name="path"></param>
        public static void WriteFile(string str, string path)
        {
            AdjustExists(path);

            if (string.IsNullOrEmpty(str))
            {
                return;
            }

            using (StreamWriter sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.Write(str);
                sw.Close();
            }
            InitialDirectory = path;

        }

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <returns></returns>
        public static List<string> SelectFiles()
        {
            List<string> retList = new List<string>();
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.InitialDirectory = InitialDirectory;//初始化路径
            fileDialog.Filter = "code files |*.txt;*.cs;*.js;*.html;*.c;*.cpp;*.xml;";//过滤选项设置，文本文件，所有文件。
            fileDialog.RestoreDirectory = true;//对话框关闭时恢复原目录
            fileDialog.Title = "选择文件";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                retList = fileDialog.FileNames.ToList();
            }

            return retList;
        }

        public static string GetExportFile()
        {
            string ret = null;
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                InitialDirectory = InitialDirectory,//初始化路径
                Filter = "config files |*.txt;",//过滤选项设置，文本文件，所有文件。
                RestoreDirectory = true,//对话框关闭时恢复原目录
                Title = "导出配置文件"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ret = fileDialog.FileName.ToString();
            }

            return ret;
        }

        public static string GetImportFile()
        {
            string ret = null;
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                InitialDirectory = InitialDirectory,//初始化路径
                Filter = "config files |*.txt;",//过滤选项设置，文本文件，所有文件。
                RestoreDirectory = true,//对话框关闭时恢复原目录
                Title = "导入配置文件"
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                ret = fileDialog.FileName.ToString();
            }

            return ret;
        }

        public static void SaveDataToFile(List<ReplaceInfo> data, string path)
        {
            AdjustExists(path);

            if (data.Count == 0)
            {
                return;
            }

            using (StreamWriter sw = new StreamWriter(path, false,Encoding.UTF8))
            {
                foreach (var item in data)
                {
                    sw.WriteLine(item.OldStr + "," + item.NewStr + "," + item.IfReg);
                }
                sw.Close();
            }
            InitialDirectory = path;

        }

        public static List<ReplaceInfo> ReadDataFromFile(string path)
        {
            List<ReplaceInfo> retList = new List<ReplaceInfo>();

            if (!File.Exists(path))
            {
                return retList;
            }
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312"), true);
                    string line = sr.ReadLine();
                    while (!string.IsNullOrEmpty(line))
                    {
                        string[] arr = line.Split(',');
                        if (arr.Length == 3)
                        {
                            ReplaceInfo info = new ReplaceInfo(arr[0], arr[1], bool.Parse(arr[2]));
                            retList.Add(info);
                        }
                        line = sr.ReadLine();
                    }
                }
            }
            catch (Exception)
            {

            }
            
            InitialDirectory = path;

            return retList;
        }

        public static string SelectFloader()
        {
            string ret = null;
            FolderBrowserDialog folder = new FolderBrowserDialog();
            folder.Description = "选择目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                //文件夹路径
                ret = folder.SelectedPath;
            }

            return ret;
        }

        /// <summary>
        /// 判断是否存在，不存在 创建
        /// </summary>
        private static void AdjustExists(string path)
        {
            if (!File.Exists(path))
            {
                FileStream f = File.Create(path);
                f.Close();
                f.Dispose();
            }
        }
    }
}
