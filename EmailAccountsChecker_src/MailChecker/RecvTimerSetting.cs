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
    public partial class RecvTimerSetting : Form
    {
        public int m_nTimer;
        public bool m_isEnabled;
        public RecvTimerSetting()
        {
            InitializeComponent();
            //read file
            try
            {
                string strTimer = File.ReadAllText("timer.ini");
                textBoxMins.Text = strTimer.Split(' ')[0];
                bool isChd;
                if (strTimer.Split(' ')[1] == "1")
                {
                    isChd = true;
                }
                else
                {
                    isChd = false;
                }
                checkBox1.Checked = isChd;
                m_isEnabled = isChd;
                m_nTimer = int.Parse(textBoxMins.Text);
            }
            catch (Exception ee)
            {
                MessageBox.Show("整数时间间隔");
                return;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                m_nTimer = int.Parse(textBoxMins.Text);
                m_isEnabled = checkBox1.Checked;
            }
            catch (Exception ee)
            {
                MessageBox.Show("整数时间间隔");
                return;
            }
            string str;
            if(!m_isEnabled) str="0";
            else str="1";

            File.WriteAllText("timer.ini", m_nTimer.ToString()+" " +str);
            Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
