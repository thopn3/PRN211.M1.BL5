using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Topic1_DesignUI_Demo
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string msg = "";
            bool flag = true;
            if (txtUsername.Text.Length == 0)
            {
                msg += "Username is required.\n";
                flag = false;
            }
                
            if (txtPassword.Text.Length == 0)
            {
                msg += "Password is required.";
                flag = false;
            }
            
            if (flag==true) 
            {
                if (txtUsername.Text.Trim().Equals("admin") && txtPassword.Text.Trim().Equals("123456"))
                    MessageBox.Show("Login success.","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Login false", "Eror", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
