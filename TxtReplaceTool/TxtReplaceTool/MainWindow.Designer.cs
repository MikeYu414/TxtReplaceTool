namespace TxtReplaceTool
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.button1 = new System.Windows.Forms.Button();
            this.selectFile = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.targetStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changeStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regReplace = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.floader = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_selectOutputPath = new System.Windows.Forms.Button();
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_export = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_targetExcharge = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.selectFloder = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件类型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileTypeControl = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Crimson;
            this.button1.Location = new System.Drawing.Point(313, 472);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Just Do It";
            this.toolTip1.SetToolTip(this.button1, "整");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.DoReplace);
            // 
            // selectFile
            // 
            this.selectFile.BackColor = System.Drawing.Color.Transparent;
            this.selectFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFile.ForeColor = System.Drawing.Color.Crimson;
            this.selectFile.Location = new System.Drawing.Point(629, 57);
            this.selectFile.Margin = new System.Windows.Forms.Padding(2);
            this.selectFile.Name = "selectFile";
            this.selectFile.Size = new System.Drawing.Size(80, 26);
            this.selectFile.TabIndex = 1;
            this.selectFile.Text = "选择文件";
            this.toolTip1.SetToolTip(this.selectFile, "可以选择一些文件");
            this.selectFile.UseVisualStyleBackColor = false;
            this.selectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.BackColor = System.Drawing.SystemColors.Window;
            this.listBox1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 27;
            this.listBox1.Location = new System.Drawing.Point(76, 57);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(540, 112);
            this.listBox1.TabIndex = 2;
            this.toolTip1.SetToolTip(this.listBox1, "你想替换哪些文件？");
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragTargetFileEvent);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            this.listBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ListBox1_MouseMove);
            this.listBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ListBox1_MouseUp);
            // 
            // dataGrid
            // 
            this.dataGrid.AllowDrop = true;
            this.dataGrid.AllowUserToResizeColumns = false;
            this.dataGrid.AllowUserToResizeRows = false;
            this.dataGrid.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.targetStr,
            this.changeStr,
            this.regReplace});
            this.dataGrid.Location = new System.Drawing.Point(76, 266);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.RowTemplate.Height = 27;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(540, 188);
            this.dataGrid.TabIndex = 3;
            this.toolTip1.SetToolTip(this.dataGrid, "你想咋弄");
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellContentClick);
            this.dataGrid.DragDrop += new System.Windows.Forms.DragEventHandler(this.DragConfigEvent);
            this.dataGrid.DragEnter += new System.Windows.Forms.DragEventHandler(this.DragEnter);
            this.dataGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DataGrid_MouseUp);
            // 
            // targetStr
            // 
            this.targetStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Fuchsia;
            this.targetStr.DefaultCellStyle = dataGridViewCellStyle1;
            this.targetStr.HeaderText = "要替换的文本";
            this.targetStr.Name = "targetStr";
            this.targetStr.ToolTipText = "你要改啥";
            // 
            // changeStr
            // 
            this.changeStr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Fuchsia;
            this.changeStr.DefaultCellStyle = dataGridViewCellStyle2;
            this.changeStr.HeaderText = "更改的文本";
            this.changeStr.Name = "changeStr";
            this.changeStr.ToolTipText = "你想改成啥";
            // 
            // regReplace
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Fuchsia;
            dataGridViewCellStyle3.NullValue = false;
            this.regReplace.DefaultCellStyle = dataGridViewCellStyle3;
            this.regReplace.HeaderText = "正则替换";
            this.regReplace.Name = "regReplace";
            this.regReplace.ToolTipText = "支持正则表达式";
            this.regReplace.Width = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(5, 273);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "文本替换";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(5, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "目标文件";
            // 
            // floader
            // 
            this.floader.Enabled = false;
            this.floader.Location = new System.Drawing.Point(76, 214);
            this.floader.Margin = new System.Windows.Forms.Padding(2);
            this.floader.Name = "floader";
            this.floader.Size = new System.Drawing.Size(540, 25);
            this.floader.TabIndex = 6;
            this.toolTip1.SetToolTip(this.floader, "输出文件到哪个路径？");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(5, 221);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "输出路径";
            // 
            // btn_selectOutputPath
            // 
            this.btn_selectOutputPath.BackColor = System.Drawing.Color.Transparent;
            this.btn_selectOutputPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selectOutputPath.ForeColor = System.Drawing.Color.Crimson;
            this.btn_selectOutputPath.Location = new System.Drawing.Point(629, 214);
            this.btn_selectOutputPath.Margin = new System.Windows.Forms.Padding(2);
            this.btn_selectOutputPath.Name = "btn_selectOutputPath";
            this.btn_selectOutputPath.Size = new System.Drawing.Size(80, 28);
            this.btn_selectOutputPath.TabIndex = 8;
            this.btn_selectOutputPath.Text = "选择路径";
            this.toolTip1.SetToolTip(this.btn_selectOutputPath, "选择输出路径");
            this.btn_selectOutputPath.UseVisualStyleBackColor = false;
            this.btn_selectOutputPath.Click += new System.EventHandler(this.SelectTargetPath);
            // 
            // btn_import
            // 
            this.btn_import.BackColor = System.Drawing.Color.Transparent;
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.ForeColor = System.Drawing.Color.Crimson;
            this.btn_import.Location = new System.Drawing.Point(629, 266);
            this.btn_import.Margin = new System.Windows.Forms.Padding(2);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(80, 28);
            this.btn_import.TabIndex = 9;
            this.btn_import.Text = "导入配置";
            this.toolTip1.SetToolTip(this.btn_import, "把配置导出，存起来");
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.Btn_Import_Click);
            // 
            // btn_export
            // 
            this.btn_export.BackColor = System.Drawing.Color.Transparent;
            this.btn_export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_export.ForeColor = System.Drawing.Color.Crimson;
            this.btn_export.Location = new System.Drawing.Point(629, 308);
            this.btn_export.Margin = new System.Windows.Forms.Padding(2);
            this.btn_export.Name = "btn_export";
            this.btn_export.Size = new System.Drawing.Size(80, 28);
            this.btn_export.TabIndex = 10;
            this.btn_export.Text = "导出配置";
            this.toolTip1.SetToolTip(this.btn_export, "导入配置");
            this.btn_export.UseVisualStyleBackColor = false;
            this.btn_export.Click += new System.EventHandler(this.Btn_Export_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("SimSun", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.DarkViolet;
            this.label4.Location = new System.Drawing.Point(271, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(292, 27);
            this.label4.TabIndex = 11;
            this.label4.Text = "鑫锅锅的文本替换工具";
            this.toolTip1.SetToolTip(this.label4, "版权归鑫锅锅所有，盗版也没事\r\n现在支持 .txt .cs .js .html .c .cpp .xml格式");
            // 
            // btn_targetExcharge
            // 
            this.btn_targetExcharge.BackColor = System.Drawing.Color.Transparent;
            this.btn_targetExcharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_targetExcharge.ForeColor = System.Drawing.Color.Crimson;
            this.btn_targetExcharge.Location = new System.Drawing.Point(629, 351);
            this.btn_targetExcharge.Margin = new System.Windows.Forms.Padding(2);
            this.btn_targetExcharge.Name = "btn_targetExcharge";
            this.btn_targetExcharge.Size = new System.Drawing.Size(80, 28);
            this.btn_targetExcharge.TabIndex = 12;
            this.btn_targetExcharge.Text = "目标交换";
            this.toolTip1.SetToolTip(this.btn_targetExcharge, "要替换的文本和更改的文本交换位置");
            this.btn_targetExcharge.UseVisualStyleBackColor = false;
            this.btn_targetExcharge.Click += new System.EventHandler(this.Btn_TargetExcharge_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.ForeColor = System.Drawing.Color.Crimson;
            this.checkBox1.Location = new System.Drawing.Point(179, 484);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(119, 19);
            this.checkBox1.TabIndex = 13;
            this.checkBox1.Text = "替换文件模式";
            this.toolTip1.SetToolTip(this.checkBox1, "替换后把你之前的文件覆盖掉");
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // selectFloder
            // 
            this.selectFloder.BackColor = System.Drawing.Color.Transparent;
            this.selectFloder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectFloder.ForeColor = System.Drawing.Color.Crimson;
            this.selectFloder.Location = new System.Drawing.Point(629, 97);
            this.selectFloder.Margin = new System.Windows.Forms.Padding(2);
            this.selectFloder.Name = "selectFloder";
            this.selectFloder.Size = new System.Drawing.Size(80, 26);
            this.selectFloder.TabIndex = 14;
            this.selectFloder.Text = "选择目录";
            this.toolTip1.SetToolTip(this.selectFloder, "选择文件夹下所有文件");
            this.selectFloder.UseVisualStyleBackColor = false;
            this.selectFloder.Click += new System.EventHandler(this.SelectFloder_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(739, 28);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件类型ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.设置ToolStripMenuItem.Text = "设置";
            // 
            // 文件类型ToolStripMenuItem
            // 
            this.文件类型ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileTypeControl});
            this.文件类型ToolStripMenuItem.Name = "文件类型ToolStripMenuItem";
            this.文件类型ToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.文件类型ToolStripMenuItem.Text = "文件类型限制";
            // 
            // fileTypeControl
            // 
            this.fileTypeControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileTypeControl.Items.AddRange(new object[] {
            "None",
            ".cs",
            ".js",
            ".txt",
            ".html",
            ".c",
            ".cpp",
            ".xml",
            ".bat",
            ".csproj"});
            this.fileTypeControl.Name = "fileTypeControl";
            this.fileTypeControl.Size = new System.Drawing.Size(121, 28);
            this.fileTypeControl.SelectedIndexChanged += new System.EventHandler(this.FileTypeControl_SelectedIndexChanged);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(739, 514);
            this.Controls.Add(this.selectFloder);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btn_targetExcharge);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_export);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.btn_selectOutputPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.floader);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.selectFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(757, 561);
            this.MinimumSize = new System.Drawing.Size(757, 561);
            this.Name = "MainWindow";
            this.Text = "文本替换工具";
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button selectFile;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox floader;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_selectOutputPath;
        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_export;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_targetExcharge;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button selectFloder;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn changeStr;
        private System.Windows.Forms.DataGridViewCheckBoxColumn regReplace;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件类型ToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox fileTypeControl;
    }
}

