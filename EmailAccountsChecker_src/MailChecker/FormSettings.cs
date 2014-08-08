using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MailChecker
{
     public struct data {
     public string  domain;
     public string pop3;
     public int port;
     public bool isSSL;
    };


    public partial class FormSettings : Form
    {
        public List<data> list;
        public FormSettings()
        {
            InitializeComponent();
            //Load pop3 servers settings
            //域名    服务器地址  	端口号  SSL
            //126.com   pop.126.com  110  0
            list = new List<data>();
            //init listview
            // Set the view to show details.
            listPopServ.View = View.Details;
            // Allow the user to edit item text.
            listPopServ.LabelEdit = true;
            // Allow the user to rearrange columns.
            listPopServ.AllowColumnReorder = true;
            // Display check boxes.
          //  listPopServ.CheckBoxes = true;
            // Select the item and subitems when selection is made.
            listPopServ.FullRowSelect = true;
            // Display grid lines.
            listPopServ.GridLines = true;
            // Sort the items in the list in ascending order.
            listPopServ.Sorting = SortOrder.Ascending;
            // Create columns for the items and subitems. 
            // Width of -2 indicates auto-size.
            listPopServ.Columns.Add("域名", -2, HorizontalAlignment.Left);
            listPopServ.Columns.Add("pop3地址", -2, HorizontalAlignment.Left);
            listPopServ.Columns.Add("端口号", -2, HorizontalAlignment.Left);
            listPopServ.Columns.Add("是否SSL", -2, HorizontalAlignment.Center);



            //init pop3 server
            string confPath = AppDomain.CurrentDomain.BaseDirectory + "pop3.ini";
            string[] strLines = System.IO.File.ReadAllLines(confPath);
            foreach (string line in strLines)
            {
                // Use a tab to indent each line of the file.
                string[] strParts = line.Split(' ');
                bool bTmp;
                string strTmp;
                if (strParts[3] == "1")
                {
                    bTmp = true;
                    strTmp = "是";
                }
                else
                {
                    bTmp = false;
                    strTmp = "否";
                }
                list.Add(new data() { domain = strParts[0], pop3 = strParts[1], port = Convert.ToInt32(strParts[2]), isSSL = bTmp });

                // Create three items and three sets of subitems for each item.
                ListViewItem item1 = new ListViewItem(strParts[0], 0);
                // Place a check mark next to the item.
                //item1.Checked = true;
                item1.SubItems.Add(strParts[1]);
                item1.SubItems.Add(strParts[2]);
                item1.SubItems.Add(strTmp);
                listPopServ.Items.Add(item1);
                Console.WriteLine("\t" + line);
            }

            //list.Add(new data() { domain = "126.com,", pop3 = "pop.126.com", port = 110, isSSL = false });

            //test
       
           
            ListViewItem item2 = new ListViewItem("item2", 1);
            item2.SubItems.Add("4");
            item2.SubItems.Add("5");
            item2.SubItems.Add("6");
            ListViewItem item3 = new ListViewItem("item3", 0);
            // Place a check mark next to the item.
            item3.Checked = true;
            item3.SubItems.Add("7");
            item3.SubItems.Add("8");
            item3.SubItems.Add("9");

            
            //Add the items to the ListView.
           // listPopServ.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addPopServ formAdd=new addPopServ();
            formAdd.StartPosition = FormStartPosition.CenterParent;
            if (formAdd.ShowDialog(this) != DialogResult.OK)
            {
              
                return;
            }
           // formAdd.strDomain;
            //check null 
            if (String.IsNullOrEmpty(formAdd.strDomain) || String.IsNullOrEmpty(formAdd.strPop) || String.IsNullOrEmpty(formAdd.strPort))
            {
                MessageBox.Show("不能为空");
                return;
            }
            //check if exists
            foreach (data d in list)
            {
                try
                {
                    //nsole.WriteLine(d.domain);
                    if (formAdd.strDomain.ToLower() == d.domain.ToLower())
                    {
                        MessageBox.Show("该域名已经存在，请先删除然后再添加");
                        return;
                    }
                }
                catch (Exception ee)
                {
                }
            }

            //save data
            try
            {
                list.Add(new data() { domain = formAdd.strDomain, pop3 = formAdd.strPop, port = Convert.ToInt32(formAdd.strPort), isSSL = formAdd.isSSL });

                //add to liveview
                bool bTmp;
                string strTmp;
                if (formAdd.isSSL)
                {

                    strTmp = "是";
                }
                else
                {

                    strTmp = "否";
                }
                ListViewItem item1 = new ListViewItem(formAdd.strDomain, 0);
                // Place a check mark next to the item.
                //item1.Checked = true;
                item1.SubItems.Add(formAdd.strPop);
                item1.SubItems.Add(formAdd.strPort);
                item1.SubItems.Add(strTmp);
                listPopServ.Items.Add(item1);

                //Console.WriteLine(formAdd.ToString());
            }
            catch (Exception eaa)
            {
            }
           
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                var confirmation = MessageBox.Show("确定删除？", "Suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmation == DialogResult.Yes)
                {
                    foreach (ListViewItem eachItem in listPopServ.SelectedItems)
                    {
                        listPopServ.Items.Remove(eachItem);
                        bool bTmp;
                        if (Convert.ToString(eachItem.SubItems[3]) == "是")
                            bTmp = true;
                        else
                            bTmp = false;

                        string domain = eachItem.SubItems[0].Text;
                        foreach (data d in list)
                        {
                            if (d.domain == domain)
                            {
                                list.Remove(d);
                                break;
                            }
                        }
                        /* data d=new data() { domain = eachItem.SubItems[0].Text, pop3 = eachItem.SubItems[1].Text, port = Convert.ToInt32(eachItem.SubItems[2].Text), isSSL = bTmp };
                         list.Remove(d);
                         */
                        //list.RemoveAt(eachItem.);
                      //  MessageBox.Show(list.Count.ToString());
                    }

                }
            }
            catch (Exception exx)
            {

                Console.WriteLine("");
            }
            /*try
            {
                ListView.SelectedListViewItemCollection selected = this.listPopServ.SelectedItems;   
                foreach (ListViewItem item in selected)
                {
                    listPopServ.Items[item.Index].Remove();
                }
            }
            catch (Exception eee)
            {
            }
            */
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
             string confPath = AppDomain.CurrentDomain.BaseDirectory + "pop3.ini";
             StreamWriter sw = new StreamWriter(confPath);
             
                 foreach (data d in list)
                 {
                     string strTmp;
                     if (d.isSSL)
                         strTmp = "1";
                     else
                         strTmp = "0";
                     sw.WriteLine(d.domain + " " + d.pop3 + " " + d.port + " " + strTmp);
                    
                 }
                
                 sw.Close();
                 this.DialogResult = DialogResult.OK;
            
          
        }
    }
}
