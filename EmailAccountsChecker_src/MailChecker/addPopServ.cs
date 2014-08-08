using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MailChecker
{
    public partial class addPopServ : Form
    {

        public string strDomain;
        public string strPop;
        public string strPort;
        public bool isSSL;
        public addPopServ()
        {
            InitializeComponent();
            textBoxDomain.Select();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
          
            //close form
            strDomain = textBoxDomain.Text;
            strPop = textBoxPop3.Text;
            strPort = textBoxPort.Text;
            isSSL = checkBoxSSL.Checked;
            Close();
            this.DialogResult = DialogResult.OK;
        }
    }
}
