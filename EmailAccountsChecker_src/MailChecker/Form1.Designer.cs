namespace MailChecker
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.LoadTab = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonExpUncheckable = new System.Windows.Forms.Button();
            this.buttonExpCheckabe = new System.Windows.Forms.Button();
            this.listViewUncheckable = new System.Windows.Forms.ListView();
            this.listViewCheckable = new System.Windows.Forms.ListView();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelSepataror = new System.Windows.Forms.Label();
            this.textPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.importExcel = new System.Windows.Forms.Button();
            this.checkTab = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonAllTrans = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.textBoxThs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttoneExpUnknown = new System.Windows.Forms.Button();
            this.buttonExpCracked = new System.Windows.Forms.Button();
            this.listViewUnknown = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.listViewCreacked = new System.Windows.Forms.ListView();
            this.label5 = new System.Windows.Forms.Label();
            this.labelSepataror2 = new System.Windows.Forms.Label();
            this.receiveTab = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.labelRecvStatus = new System.Windows.Forms.Label();
            this.treeViewAttach = new System.Windows.Forms.TreeView();
            this.treeViewEmails = new System.Windows.Forms.TreeView();
            this.buttonStartRecv = new System.Windows.Forms.Button();
            this.buttonRecvSetting = new System.Windows.Forms.Button();
            this.labelSepataror3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.webBrowserMailContent = new System.Windows.Forms.WebBrowser();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.treeViewAccounts = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl.SuspendLayout();
            this.LoadTab.SuspendLayout();
            this.checkTab.SuspendLayout();
            this.receiveTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.LoadTab);
            this.tabControl.Controls.Add(this.checkTab);
            this.tabControl.Controls.Add(this.receiveTab);
            this.tabControl.Location = new System.Drawing.Point(1, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl.MaximumSize = new System.Drawing.Size(1285, 646);
            this.tabControl.MinimumSize = new System.Drawing.Size(1285, 646);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1285, 646);
            this.tabControl.TabIndex = 0;
            // 
            // LoadTab
            // 
            this.LoadTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LoadTab.Controls.Add(this.label4);
            this.LoadTab.Controls.Add(this.buttonExpUncheckable);
            this.LoadTab.Controls.Add(this.buttonExpCheckabe);
            this.LoadTab.Controls.Add(this.listViewUncheckable);
            this.LoadTab.Controls.Add(this.listViewCheckable);
            this.LoadTab.Controls.Add(this.buttonSettings);
            this.LoadTab.Controls.Add(this.label3);
            this.LoadTab.Controls.Add(this.label2);
            this.LoadTab.Controls.Add(this.labelSepataror);
            this.LoadTab.Controls.Add(this.textPath);
            this.LoadTab.Controls.Add(this.label1);
            this.LoadTab.Controls.Add(this.importExcel);
            this.LoadTab.Location = new System.Drawing.Point(4, 25);
            this.LoadTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadTab.Name = "LoadTab";
            this.LoadTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LoadTab.Size = new System.Drawing.Size(1277, 617);
            this.LoadTab.TabIndex = 0;
            this.LoadTab.Text = "导入账号";
            this.LoadTab.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(736, 168);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(397, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "注：您可以添加邮箱规则，从而减少不可检测的邮箱账号。";
            // 
            // buttonExpUncheckable
            // 
            this.buttonExpUncheckable.Location = new System.Drawing.Point(1067, 565);
            this.buttonExpUncheckable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExpUncheckable.Name = "buttonExpUncheckable";
            this.buttonExpUncheckable.Size = new System.Drawing.Size(184, 29);
            this.buttonExpUncheckable.TabIndex = 8;
            this.buttonExpUncheckable.Text = "导出不可以检测的邮箱";
            this.buttonExpUncheckable.UseVisualStyleBackColor = true;
            this.buttonExpUncheckable.Click += new System.EventHandler(this.buttonExpUncheckable_Click);
            // 
            // buttonExpCheckabe
            // 
            this.buttonExpCheckabe.Location = new System.Drawing.Point(361, 565);
            this.buttonExpCheckabe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExpCheckabe.Name = "buttonExpCheckabe";
            this.buttonExpCheckabe.Size = new System.Drawing.Size(151, 29);
            this.buttonExpCheckabe.TabIndex = 8;
            this.buttonExpCheckabe.Text = "导出可以检测邮箱";
            this.buttonExpCheckabe.UseVisualStyleBackColor = true;
            this.buttonExpCheckabe.Click += new System.EventHandler(this.buttonExpCheckabe_Click);
            // 
            // listViewUncheckable
            // 
            this.listViewUncheckable.Location = new System.Drawing.Point(631, 186);
            this.listViewUncheckable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewUncheckable.Name = "listViewUncheckable";
            this.listViewUncheckable.Size = new System.Drawing.Size(308, 423);
            this.listViewUncheckable.TabIndex = 7;
            this.listViewUncheckable.UseCompatibleStateImageBehavior = false;
            // 
            // listViewCheckable
            // 
            this.listViewCheckable.Location = new System.Drawing.Point(15, 182);
            this.listViewCheckable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewCheckable.Name = "listViewCheckable";
            this.listViewCheckable.Size = new System.Drawing.Size(281, 426);
            this.listViewCheckable.TabIndex = 7;
            this.listViewCheckable.UseCompatibleStateImageBehavior = false;
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(1101, 25);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(149, 44);
            this.buttonSettings.TabIndex = 6;
            this.buttonSettings.Text = "设置邮箱规则";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(627, 162);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "无效账号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(11, 159);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "有效账号";
            // 
            // labelSepataror
            // 
            this.labelSepataror.AutoSize = true;
            this.labelSepataror.Location = new System.Drawing.Point(11, 106);
            this.labelSepataror.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSepataror.Name = "labelSepataror";
            this.labelSepataror.Size = new System.Drawing.Size(79, 15);
            this.labelSepataror.TabIndex = 3;
            this.labelSepataror.Text = "sepatator";
            // 
            // textPath
            // 
            this.textPath.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textPath.Location = new System.Drawing.Point(175, 42);
            this.textPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textPath.Name = "textPath";
            this.textPath.ReadOnly = true;
            this.textPath.Size = new System.Drawing.Size(624, 26);
            this.textPath.TabIndex = 2;
            this.textPath.Text = "..bug 留言到http://blog.163.com/cmdbat@126 或发邮件到cmdbat@126.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 27);
            this.label1.TabIndex = 1;
            this.label1.Text = "文件路径:";
            // 
            // importExcel
            // 
            this.importExcel.Location = new System.Drawing.Point(853, 25);
            this.importExcel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.importExcel.Name = "importExcel";
            this.importExcel.Size = new System.Drawing.Size(196, 45);
            this.importExcel.TabIndex = 0;
            this.importExcel.Text = "导入excel文件";
            this.importExcel.UseVisualStyleBackColor = true;
            this.importExcel.Click += new System.EventHandler(this.importExcel_Click);
            // 
            // checkTab
            // 
            this.checkTab.Controls.Add(this.label10);
            this.checkTab.Controls.Add(this.labelStatus);
            this.checkTab.Controls.Add(this.label9);
            this.checkTab.Controls.Add(this.buttonAllTrans);
            this.checkTab.Controls.Add(this.label7);
            this.checkTab.Controls.Add(this.textBoxDelay);
            this.checkTab.Controls.Add(this.textBoxThs);
            this.checkTab.Controls.Add(this.label11);
            this.checkTab.Controls.Add(this.label8);
            this.checkTab.Controls.Add(this.buttonPause);
            this.checkTab.Controls.Add(this.buttonEnd);
            this.checkTab.Controls.Add(this.buttonStart);
            this.checkTab.Controls.Add(this.buttoneExpUnknown);
            this.checkTab.Controls.Add(this.buttonExpCracked);
            this.checkTab.Controls.Add(this.listViewUnknown);
            this.checkTab.Controls.Add(this.label6);
            this.checkTab.Controls.Add(this.listViewCreacked);
            this.checkTab.Controls.Add(this.label5);
            this.checkTab.Controls.Add(this.labelSepataror2);
            this.checkTab.Location = new System.Drawing.Point(4, 25);
            this.checkTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkTab.Name = "checkTab";
            this.checkTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkTab.Size = new System.Drawing.Size(1277, 617);
            this.checkTab.TabIndex = 1;
            this.checkTab.Text = "账号检测";
            this.checkTab.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(729, 34);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 15);
            this.label10.TabIndex = 18;
            this.label10.Text = "状态:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.labelStatus.Location = new System.Drawing.Point(776, 34);
            this.labelStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(37, 15);
            this.labelStatus.TabIndex = 18;
            this.labelStatus.Text = "空闲";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(729, 56);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(502, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = "注：这里检测的是可以检测的账号，特殊账户您需要设置邮箱服务器规则。";
            // 
            // buttonAllTrans
            // 
            this.buttonAllTrans.Enabled = false;
            this.buttonAllTrans.Location = new System.Drawing.Point(357, 521);
            this.buttonAllTrans.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAllTrans.Name = "buttonAllTrans";
            this.buttonAllTrans.Size = new System.Drawing.Size(183, 29);
            this.buttonAllTrans.TabIndex = 16;
            this.buttonAllTrans.Text = "全部转入收取邮件";
            this.buttonAllTrans.UseVisualStyleBackColor = true;
            this.buttonAllTrans.Click += new System.EventHandler(this.buttonAllTrans_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(623, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 15);
            this.label7.TabIndex = 15;
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxDelay.Location = new System.Drawing.Point(629, 32);
            this.textBoxDelay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(91, 37);
            this.textBoxDelay.TabIndex = 14;
            this.textBoxDelay.Text = "3";
            // 
            // textBoxThs
            // 
            this.textBoxThs.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxThs.Location = new System.Drawing.Point(381, 32);
            this.textBoxThs.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxThs.Name = "textBoxThs";
            this.textBoxThs.Size = new System.Drawing.Size(91, 37);
            this.textBoxThs.TabIndex = 14;
            this.textBoxThs.Text = "10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label11.Location = new System.Drawing.Point(529, 41);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 13;
            this.label11.Text = "延时(秒):";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.label8.Location = new System.Drawing.Point(288, 41);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "线程数:";
            // 
            // buttonPause
            // 
            this.buttonPause.Enabled = false;
            this.buttonPause.Location = new System.Drawing.Point(95, 14);
            this.buttonPause.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(87, 59);
            this.buttonPause.TabIndex = 12;
            this.buttonPause.Text = "暂停";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonPause_Click);
            // 
            // buttonEnd
            // 
            this.buttonEnd.Enabled = false;
            this.buttonEnd.Location = new System.Drawing.Point(175, 14);
            this.buttonEnd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(87, 59);
            this.buttonEnd.TabIndex = 12;
            this.buttonEnd.Text = "结束";
            this.buttonEnd.UseVisualStyleBackColor = true;
            this.buttonEnd.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(4, 14);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(92, 59);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "启动";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttoneExpUnknown
            // 
            this.buttoneExpUnknown.Enabled = false;
            this.buttoneExpUnknown.Location = new System.Drawing.Point(1047, 558);
            this.buttoneExpUnknown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttoneExpUnknown.Name = "buttoneExpUnknown";
            this.buttoneExpUnknown.Size = new System.Drawing.Size(151, 29);
            this.buttoneExpUnknown.TabIndex = 11;
            this.buttoneExpUnknown.Text = "导出不能登录邮箱";
            this.buttoneExpUnknown.UseVisualStyleBackColor = true;
            this.buttoneExpUnknown.Click += new System.EventHandler(this.buttoneExpUnknown_Click);
            // 
            // buttonExpCracked
            // 
            this.buttonExpCracked.Enabled = false;
            this.buttonExpCracked.Location = new System.Drawing.Point(357, 558);
            this.buttonExpCracked.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonExpCracked.Name = "buttonExpCracked";
            this.buttonExpCracked.Size = new System.Drawing.Size(183, 29);
            this.buttonExpCracked.TabIndex = 11;
            this.buttonExpCracked.Text = "导出可以登陆邮箱";
            this.buttonExpCracked.UseVisualStyleBackColor = true;
            this.buttonExpCracked.Click += new System.EventHandler(this.buttonExpCracked_Click);
            // 
            // listViewUnknown
            // 
            this.listViewUnknown.Location = new System.Drawing.Point(700, 175);
            this.listViewUnknown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewUnknown.Name = "listViewUnknown";
            this.listViewUnknown.Size = new System.Drawing.Size(281, 426);
            this.listViewUnknown.TabIndex = 10;
            this.listViewUnknown.UseCompatibleStateImageBehavior = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label6.Location = new System.Drawing.Point(696, 151);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "不能登陆账号";
            // 
            // listViewCreacked
            // 
            this.listViewCreacked.Location = new System.Drawing.Point(11, 175);
            this.listViewCreacked.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listViewCreacked.Name = "listViewCreacked";
            this.listViewCreacked.Size = new System.Drawing.Size(281, 426);
            this.listViewCreacked.TabIndex = 10;
            this.listViewCreacked.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Lime;
            this.label5.Location = new System.Drawing.Point(7, 151);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "可以登录账号";
            // 
            // labelSepataror2
            // 
            this.labelSepataror2.AutoSize = true;
            this.labelSepataror2.Location = new System.Drawing.Point(8, 72);
            this.labelSepataror2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSepataror2.Name = "labelSepataror2";
            this.labelSepataror2.Size = new System.Drawing.Size(79, 15);
            this.labelSepataror2.TabIndex = 4;
            this.labelSepataror2.Text = "sepatator";
            // 
            // receiveTab
            // 
            this.receiveTab.Controls.Add(this.panel1);
            this.receiveTab.Controls.Add(this.label16);
            this.receiveTab.Controls.Add(this.labelRecvStatus);
            this.receiveTab.Controls.Add(this.treeViewAttach);
            this.receiveTab.Controls.Add(this.treeViewEmails);
            this.receiveTab.Controls.Add(this.buttonStartRecv);
            this.receiveTab.Controls.Add(this.buttonRecvSetting);
            this.receiveTab.Controls.Add(this.labelSepataror3);
            this.receiveTab.Controls.Add(this.label15);
            this.receiveTab.Controls.Add(this.label14);
            this.receiveTab.Controls.Add(this.label13);
            this.receiveTab.Controls.Add(this.label12);
            this.receiveTab.Controls.Add(this.treeViewAccounts);
            this.receiveTab.Location = new System.Drawing.Point(4, 25);
            this.receiveTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.receiveTab.Name = "receiveTab";
            this.receiveTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.receiveTab.Size = new System.Drawing.Size(1277, 617);
            this.receiveTab.TabIndex = 2;
            this.receiveTab.Text = "邮件收取";
            this.receiveTab.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(507, 22);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 15);
            this.label16.TabIndex = 19;
            this.label16.Text = "状态:";
            // 
            // labelRecvStatus
            // 
            this.labelRecvStatus.AutoSize = true;
            this.labelRecvStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.labelRecvStatus.Location = new System.Drawing.Point(553, 22);
            this.labelRecvStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRecvStatus.Name = "labelRecvStatus";
            this.labelRecvStatus.Size = new System.Drawing.Size(37, 15);
            this.labelRecvStatus.TabIndex = 20;
            this.labelRecvStatus.Text = "空闲";
            // 
            // treeViewAttach
            // 
            this.treeViewAttach.Location = new System.Drawing.Point(776, 529);
            this.treeViewAttach.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeViewAttach.Name = "treeViewAttach";
            this.treeViewAttach.Size = new System.Drawing.Size(452, 84);
            this.treeViewAttach.TabIndex = 12;
            this.treeViewAttach.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewAttach_AfterSelect);
            // 
            // treeViewEmails
            // 
            this.treeViewEmails.Location = new System.Drawing.Point(327, 119);
            this.treeViewEmails.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeViewEmails.Name = "treeViewEmails";
            this.treeViewEmails.Size = new System.Drawing.Size(319, 494);
            this.treeViewEmails.TabIndex = 11;
            this.treeViewEmails.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewEmails_AfterSelect);
            // 
            // buttonStartRecv
            // 
            this.buttonStartRecv.Enabled = false;
            this.buttonStartRecv.Location = new System.Drawing.Point(12, 8);
            this.buttonStartRecv.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStartRecv.Name = "buttonStartRecv";
            this.buttonStartRecv.Size = new System.Drawing.Size(179, 45);
            this.buttonStartRecv.TabIndex = 10;
            this.buttonStartRecv.Text = "收取所有邮件";
            this.buttonStartRecv.UseVisualStyleBackColor = true;
            this.buttonStartRecv.Click += new System.EventHandler(this.buttonStartRecv_Click);
            // 
            // buttonRecvSetting
            // 
            this.buttonRecvSetting.Location = new System.Drawing.Point(216, 8);
            this.buttonRecvSetting.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRecvSetting.Name = "buttonRecvSetting";
            this.buttonRecvSetting.Size = new System.Drawing.Size(188, 45);
            this.buttonRecvSetting.TabIndex = 9;
            this.buttonRecvSetting.Text = "定时收取设置";
            this.buttonRecvSetting.UseVisualStyleBackColor = true;
            this.buttonRecvSetting.Click += new System.EventHandler(this.buttonRecvSetting_Click);
            // 
            // labelSepataror3
            // 
            this.labelSepataror3.AutoSize = true;
            this.labelSepataror3.Location = new System.Drawing.Point(9, 62);
            this.labelSepataror3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSepataror3.Name = "labelSepataror3";
            this.labelSepataror3.Size = new System.Drawing.Size(79, 15);
            this.labelSepataror3.TabIndex = 7;
            this.labelSepataror3.Text = "sepatator";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(693, 529);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(69, 20);
            this.label15.TabIndex = 5;
            this.label15.Text = "附件：";
            // 
            // webBrowserMailContent
            // 
            this.webBrowserMailContent.Location = new System.Drawing.Point(4, 4);
            this.webBrowserMailContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.webBrowserMailContent.MinimumSize = new System.Drawing.Size(27, 25);
            this.webBrowserMailContent.Name = "webBrowserMailContent";
            this.webBrowserMailContent.Size = new System.Drawing.Size(440, 391);
            this.webBrowserMailContent.TabIndex = 3;
            this.webBrowserMailContent.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowserMailContent.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserMailContent_DocumentCompleted);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(719, 94);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 20);
            this.label14.TabIndex = 1;
            this.label14.Text = "邮件内容";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(367, 95);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 20);
            this.label13.TabIndex = 1;
            this.label13.Text = "邮件列表";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Cursor = System.Windows.Forms.Cursors.Default;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(9, 94);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "邮箱列表";
            // 
            // treeViewAccounts
            // 
            this.treeViewAccounts.Location = new System.Drawing.Point(8, 116);
            this.treeViewAccounts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeViewAccounts.Name = "treeViewAccounts";
            this.treeViewAccounts.Size = new System.Drawing.Size(264, 496);
            this.treeViewAccounts.TabIndex = 0;
            this.treeViewAccounts.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewAccounts_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.webBrowserMailContent);
            this.panel1.Location = new System.Drawing.Point(776, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 403);
            this.panel1.TabIndex = 21;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 636);
            this.Controls.Add(this.tabControl);
            this.HelpButton = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximumSize = new System.Drawing.Size(1302, 681);
            this.MinimumSize = new System.Drawing.Size(1302, 681);
            this.Name = "MainForm";
            this.Text = "邮箱账号检测平台 ";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl.ResumeLayout(false);
            this.LoadTab.ResumeLayout(false);
            this.LoadTab.PerformLayout();
            this.checkTab.ResumeLayout(false);
            this.checkTab.PerformLayout();
            this.receiveTab.ResumeLayout(false);
            this.receiveTab.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage LoadTab;
        private System.Windows.Forms.TabPage receiveTab;
        protected System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TextBox textPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button importExcel;
        private System.Windows.Forms.Label labelSepataror;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonExpUncheckable;
        private System.Windows.Forms.Button buttonExpCheckabe;
        private System.Windows.Forms.ListView listViewUncheckable;
        private System.Windows.Forms.ListView listViewCheckable;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage checkTab;
        private System.Windows.Forms.Button buttonAllTrans;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxThs;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttoneExpUnknown;
        private System.Windows.Forms.Button buttonExpCracked;
        private System.Windows.Forms.ListView listViewUnknown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView listViewCreacked;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelSepataror2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonEnd;
        private System.Windows.Forms.TextBox textBoxDelay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label labelSepataror3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.WebBrowser webBrowserMailContent;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TreeView treeViewAccounts;
        private System.Windows.Forms.Button buttonRecvSetting;
        private System.Windows.Forms.Button buttonStartRecv;
        private System.Windows.Forms.TreeView treeViewEmails;
        private System.Windows.Forms.TreeView treeViewAttach;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label labelRecvStatus;
        private System.Windows.Forms.Panel panel1;
    }
}

