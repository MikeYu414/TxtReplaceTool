using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TxtReplaceTool.Controls;
using TxtReplaceTool.Data;
using TxtReplaceTool.Server;

namespace TxtReplaceTool
{
    public partial class MainWindow : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(IntPtr classname, string title); // extern method: FindWindow

        [DllImport("user32.dll")]
        static extern void MoveWindow(IntPtr hwnd, int X, int Y,
            int nWidth, int nHeight, bool rePaint); // extern method: MoveWindow

        [DllImport("user32.dll")]
        static extern bool GetWindowRect
            (IntPtr hwnd, out Rectangle rect);

        //可执行的文件后缀名
        List<string> defaultExtNames = new List<string> { ".txt", ".cs", ".js", ".html", ".c", ".cpp", ".xml", ".bat", ".csproj" };
        List<string> extNames = new List<string> { ".txt", ".cs", ".js", ".html", ".c", ".cpp", ".xml", ".bat", ".csproj" };

        //存储文件路径
        List<string> files = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            this.fileTypeControl.SelectedIndex = 0;
        }

        public void UpdateFileTypeLimit()
        {
            string fileType = this.fileTypeControl.SelectedItem.ToString();
            if (fileType != "None")
            {
                extNames.Clear();
                extNames.Add(fileType);
            }
            else
            {
                extNames = defaultExtNames;
            }
        }

        /// <summary>
        /// do it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoReplace(object sender, EventArgs e)
        {
            List<ReplaceInfo> replaceDic = GetReplaceInfo();
            Dictionary<string, string> filePathDic = GetFilePathInfo();

            try
            {
                if (replaceDic.Count == 0 || filePathDic.Count == 0)
                {
                    FindAndMoveMsgBox("提示");
                    MessageBox.Show("什么都没有发生，你选文件了吗？ 设置文本替换了吗？", "提示");
                    return;
                }
                if (string.IsNullOrEmpty(this.floader.Text))
                {
                    FindAndMoveMsgBox("提示");
                    DialogResult dr = MessageBox.Show("没有设置输出路径的话会在原路径生成并且替换源文件，注意自行备份哦！\n是否继续？", "提示", MessageBoxButtons.OKCancel);
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                //替换
                DealReplace(filePathDic, replaceDic);

                FindAndMoveMsgBox("提示");
                string targetPath = this.floader.Text;
                if (string.IsNullOrEmpty(targetPath))
                {
                    MessageBox.Show("整完了，全替换完了" + this.floader.Text, "提示");
                }
                else
                {
                    MessageBox.Show("整完了，你看看这个路径\n" + this.floader.Text, "提示");
                }
            }
            catch (Exception ex)
            {
                FindAndMoveMsgBox("提示");
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 替换核心
        /// </summary>
        /// <param name="filePathDic"></param>
        /// <param name="replaceDic"></param>
        private void DealReplace(Dictionary<string, string> filePathDic, List<ReplaceInfo> replaceInfo)
        {
            foreach (var item in filePathDic)
            {
                string fileStr = FileServer.ReadFile(item.Key, GetEncodingType(item.Key));
                if (fileStr == null)
                    continue;

                fileStr = TxtReplaceServer.ReplaceTxtByDictionary(replaceInfo, fileStr);
                //替换模式
                if (this.checkBox1.Checked)
                {
                    FileServer.WriteFile(fileStr, item.Key, GetEncodingType(item.Key));
                }
                else
                {
                    //说明之前没有设置输出路径 给默认路径
                    /*if (filePathDic.FirstOrDefault().Key == filePathDic.FirstOrDefault().Value)
                    {
                        if (string.IsNullOrEmpty(this.floader.Text))
                        {
                            string fileName = filePathDic.FirstOrDefault().Key;
                            string path = fileName.Substring(0, fileName.LastIndexOf('\\'));
                            this.floader.Text = path;
                        }
                    }*/
                    FileServer.WriteFile(fileStr, item.Value, GetEncodingType(item.Key));
                }
            }
        }

        /// <summary>
        /// 文件路径右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ContextMenuStrip contextMenu = GetContextMenu(new EventHandler(SelectAllPath),new EventHandler(DeleteFilePath), new EventHandler(DeleteAllPath));
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show(this.listBox1, e.Location);//鼠标右键按下弹出菜单
            }
        }

        /// <summary>
        /// 交换字符串grid右键菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGrid_MouseUp(object sender, MouseEventArgs e)
        {
            ContextMenuStrip contextMenu = GetContextMenu(new EventHandler(SelectAllRow), new EventHandler(DeleteReplaceRow), new EventHandler(DeleteAllReplaceRow));
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show(this.dataGrid, e.Location);//鼠标右键按下弹出菜单
            }
        }

        /// <summary>
        /// 右键菜单
        /// </summary>
        /// <param name="selectAllEvent"></param>
        /// <param name="deleteEvent"></param>
        /// <param name="deleteAllEvent"></param>
        /// <returns></returns>
        private ContextMenuStrip GetContextMenu(EventHandler selectAllEvent, EventHandler deleteEvent, EventHandler deleteAllEvent)
        {
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripItem item = new ToolStripMenuItem();
            item.Name = "selectAll";
            item.Text = "全选";
            item.Click += selectAllEvent;
            contextMenu.Items.Add(item);
            ToolStripItem item1 = new ToolStripMenuItem();
            item1.Name = "delete";
            item1.Text = "删除";
            item1.Click += deleteEvent;
            contextMenu.Items.Add(item1);
            ToolStripItem item2 = new ToolStripMenuItem();
            item2.Name = "deleteAll";
            item2.Text = "清空所有";
            item2.Click += deleteAllEvent;
            contextMenu.Items.Add(item2);

            return contextMenu;
        }

        #region event handler
        public void DeleteFilePath(object sender, EventArgs e)
        {
            foreach (var item in listBox1.SelectedIndices)
            {
                listBox1.Items.RemoveAt(int.Parse(item.ToString()));
            }
        }

        public void DeleteAllPath(object sender, EventArgs e)
        {
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                listBox1.Items.RemoveAt(i);
            }
        }
        public void SelectAllPath(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                listBox1.SelectedItem = listBox1.Items[i];
            }
        }

        public void SelectAllRow(object sender, EventArgs e)
        {
            dataGrid.SelectAll();
        }

        public void DeleteReplaceRow(object sender, EventArgs e)
        {
            try
            {
                for (int i = this.dataGrid.SelectedRows.Count; i > 0; i--)
                {
                    int index = Convert.ToInt32(dataGrid.SelectedRows[i - 1].Index);
                    dataGrid.Rows.RemoveAt(index);
                }
            }
            catch (Exception)
            {

            }
        }

        public void DeleteAllReplaceRow(object sender, EventArgs e)
        {
            this.dataGrid.Rows.Clear();
        }
        #endregion

        /// <summary>
        /// 选择文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFile_Click(object sender, EventArgs e)
        {
            List<string> filePaths = FileServer.SelectFiles();
            foreach (var item in filePaths)
            {
                this.listBox1.Items.Add(item);
            }
        }

        /// <summary>
        /// 选择输出路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectTargetPath(object sender, EventArgs e)
        {
            string floderStr = FileServer.SelectFloader();
            this.floader.Text = floderStr;
        }

        /// <summary>
        /// 配置导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Export_Click(object sender, EventArgs e)
        {
            try
            {
                string floderStr = FileServer.GetExportFile();
                if (string.IsNullOrEmpty(floderStr))
                {
                    return;
                }
                List<ReplaceInfo> data = GetReplaceInfo();
                FileServer.SaveDataToFile(data, floderStr, Encoding.Default);

                FindAndMoveMsgBox("提示");
                MessageBox.Show("导出成功，看这噶哒------>" + floderStr, "提示");
            }
            catch (Exception ex)
            {
                FindAndMoveMsgBox("提示");
                MessageBox.Show("导出失败------>" + ex.Message, "提示");
            }
        }

        /// <summary>
        /// 配置导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Import_Click(object sender, EventArgs e)
        {
            string floderStr = FileServer.GetImportFile();
            try
            {
                List<ReplaceInfo> data = FileServer.ReadDataFromFile(floderStr, Encoding.Default);
                this.LoadDataToDatagrid(data);
            }
            catch (Exception ex)
            {
                FindAndMoveMsgBox("提示");
                MessageBox.Show("读取配置失败，请检查格式（旧字符串,新字符串,true or false代表是否正则替换）------>" + floderStr, "提示");
            }
        }

        private  Encoding GetEncodingType(string filename)
        {
            using (System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
                byte[] buffer = br.ReadBytes(2);

                if (buffer[0] >= 0xEF)
                {
                    if (buffer[0] == 0xEF && buffer[1] == 0xBB)
                    {
                        return System.Text.Encoding.UTF8;
                    }
                    else if (buffer[0] == 0xFE && buffer[1] == 0xFF)
                    {
                        return System.Text.Encoding.BigEndianUnicode;
                    }
                    else if (buffer[0] == 0xFF && buffer[1] == 0xFE)
                    {
                        return System.Text.Encoding.Unicode;
                    }
                    else
                    {
                        return System.Text.Encoding.Default;
                    }
                }
                else
                {
                    return System.Text.Encoding.Default;
                }
            }
        }

        private List<ReplaceInfo> GetReplaceInfo()
        {
            List< ReplaceInfo > replaceInfos = new List<ReplaceInfo>();
            for (int i = 0; i < this.dataGrid.RowCount; i++)
            {
                string oldStr = this.dataGrid.Rows[i].Cells[0].FormattedValue.ToString();
                string newStr = this.dataGrid.Rows[i].Cells[1].FormattedValue.ToString();
                bool ifReg = (bool)this.dataGrid.Rows[i].Cells[2].FormattedValue;

                if (oldStr != newStr)
                {
                    ReplaceInfo info = new ReplaceInfo(oldStr, newStr, ifReg);
                    replaceInfos.Add(info);
                }
            }

            return replaceInfos;
        }

        private Dictionary<string, string> GetFilePathInfo()
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            foreach (var item in this.listBox1.Items)
            {
                string oldPath = item.ToString();
                string targetPath = this.floader.Text;
                string newPath = oldPath;
                if (!string.IsNullOrEmpty(targetPath))
                {
                    int spliteNum = oldPath.LastIndexOf('\\');
                    string fileName = oldPath.Substring(spliteNum);
                    newPath = targetPath + fileName;
                }

                ret.Add(oldPath, newPath);
            }

            return ret;
        }

        private void LoadDataToDatagrid(List<ReplaceInfo> data)
        {
            foreach (var item in data)
            {
                this.dataGrid.Rows.Add(item.OldStr, item.NewStr, item.IfReg);
            }
        }

        private void FindAndMoveMsgBox(string title)
        {
            Point location = this.Location;
            int x = location.X + this.Width / 2 - 200;
            int y = location.Y + this.Height / 2 - 100;

            Thread thr = new Thread(() => // create a new thread
            {
                IntPtr msgBox = IntPtr.Zero;
                // while there's no MessageBox, FindWindow returns IntPtr.Zero
                while ((msgBox = FindWindow(IntPtr.Zero, title)) == IntPtr.Zero) ;
                // after the while loop, msgBox is the handle of your MessageBox
                Rectangle r = new Rectangle();
                GetWindowRect(msgBox, out r); // Gets the rectangle of the message box
                MoveWindow(msgBox /* handle of the message box */, x, y,
                   r.Width - r.X /* width of originally message box */,
                   r.Height - r.Y /* height of originally message box */,
                   true /* if true, the message box repaints */);
            });
            thr.Start(); // starts the thread

        }

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            dataGrid.CurrentCell = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex];
            dataGrid.BeginEdit(true);
        }

        private void Btn_TargetExcharge_Click(object sender, EventArgs e)
        {
            for (int i = this.dataGrid.SelectedRows.Count; i > 0; i--)
            {
                int index = Convert.ToInt32(dataGrid.SelectedRows[i - 1].Index);
                DataGridViewCell cell1 = dataGrid.Rows[index].Cells[0];
                DataGridViewCell cell2 = dataGrid.Rows[index].Cells[1];
                if (cell1.Value == null || cell2.Value == null)
                {
                    continue;
                }
                string oldStr = dataGrid.Rows[index].Cells[0].Value.ToString();
                string targetStr = dataGrid.Rows[index].Cells[1].Value.ToString();
                dataGrid.Rows[index].Cells[0].Value = targetStr;
                dataGrid.Rows[index].Cells[1].Value = oldStr;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                this.btn_selectOutputPath.Enabled = false;
                this.floader.Text = "";
            }
            else
            {
                this.btn_selectOutputPath.Enabled = true;
            }
        }

        /// <summary>
        /// 选择文件夹下所有文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFloder_Click(object sender, EventArgs e)
        {
            string floderPath = FileServer.SelectFloader();
            if (string.IsNullOrEmpty(floderPath))
            {
                return;
            }
            //清空
            this.files.Clear();
            //获取
            this.GetFloderFiles(floderPath);
            foreach (var item in this.files)
            {
                this.listBox1.Items.Add(item);
            }
        }

        /// <summary>
        /// 递归获取路径下所有文件
        /// </summary>
        /// <param name="path"></param>
        public  void GetFloderFiles(string path)
        {
            DirectoryInfo fatherInfo = new DirectoryInfo(path);
            FileSystemInfo[] filesInfo = fatherInfo.GetFileSystemInfos();
            foreach (var fileInfo in filesInfo)
            {
                if (fileInfo is DirectoryInfo)
                {
                    GetFloderFiles(fileInfo.FullName);
                }
                else
                {
                    foreach (var extN in extNames)
                    {
                        if (fileInfo.Extension == extN)
                        {
                            files.Add(fileInfo.FullName);
                            break;
                        }
                    }
                }
            }
        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))      //判断该文件是否可以转换到文件放置格式
            {
                e.Effect = DragDropEffects.Link;       //放置效果为链接放置
            }
            else
            {
                e.Effect = DragDropEffects.None;      //不接受该数据,无法放置，后续事件也无法触发
            }
        }

        private void DragTargetFileEvent(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();     //获取文件路径
            bool isPathRight = false;
            if (Path.IsPathRooted(path))
            {
                //folder
                if (string.IsNullOrEmpty(Path.GetExtension(path)))
                {
                    this.GetFloderFiles(path);
                    foreach (var item in this.files)
                    {
                        this.listBox1.Items.Add(item);
                    }
                    isPathRight = true;
                }
                else // file
                {
                    foreach (var item in extNames)
                    {
                        if (path.EndsWith(item))
                        {
                            this.listBox1.Items.Add(path);
                            isPathRight = true;
                        }
                    }
                }
            }
            if (!isPathRight)
            {
                MessageBox.Show("目前不支持您拖拽的文件类型。");
            }
        }

        private void DragConfigEvent(object sender, DragEventArgs e)
        {
            string path = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();     //获取文件路径
            if (Path.GetExtension(path) == ".txt")
            {
                try
                {
                    List<ReplaceInfo> data = FileServer.ReadDataFromFile(path, Encoding.Default);
                    this.LoadDataToDatagrid(data);
                }
                catch (Exception ex)
                {
                    FindAndMoveMsgBox("提示");
                    MessageBox.Show("读取配置失败，请检查格式（旧字符串,新字符串,true or false代表是否正则替换）------>" + path, "提示");
                }
            }
            else
            {
                MessageBox.Show("配置文件类型为*.txt");
            }
        }

        private void ListBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.Location);
            // Check if the index is valid.
            if (index != -1 && index < listBox1.Items.Count)
            {
                // Check if the ToolTip's text isn't already the one
                // we are now processing.
                if (toolTip1.GetToolTip(listBox1) != listBox1.Items[index].ToString())
                {
                    // If it isn't, then a new item needs to be
                    // displayed on the toolTip. Update it.
                    toolTip1.SetToolTip(listBox1, listBox1.Items[index].ToString());
                }
            }
        }

        private void FileTypeControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateFileTypeLimit();
        }
    }
}
