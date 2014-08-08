using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MailChecker
{
    public partial class formAddAccount : Form
    {
        public string m_strEmail;
        public string m_strPwd;
        public formAddAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_strEmail = textBoxEmail.Text;
            m_strPwd = textBoxPwd.Text;
            Close();
            this.DialogResult = DialogResult.OK;
                
        }
    }
}
