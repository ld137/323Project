using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ld137_323_Assignment_2
{
    public partial class Logon_Form : Form
    {
        public Logon_Form()
        {
            InitializeComponent();
        }
        private OracleConnection conn;
        private OracleCommand cmd;
        private bool succ;

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                LoginResultLabel.Text = string.Empty;
                string username = usernameTextbox.Text;
                string password = passwordTextbox.Text;
                succ = false;
                string oradb = "Data Source=oracle.cms.waikato.ac.nz:1521/teaching;User Id=" + username + ";Password=" + password + ";";
                conn = new OracleConnection(oradb);  // C#
                conn.Open();
                cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select f_name from a2_user where userID < 3";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                dr.Read();
                //label1.Text = dr.GetString(0);
                conn.Dispose();
                succ = true;
                this.Close();
            }
            catch (Exception ex)
            {
                LoginResultLabel.Text = "Login Error: \n Invalid username or password";
            }
        }

        public String getUsername()
        {
            return usernameTextbox.Text;
        }

        public String getPassword()
        {
            return passwordTextbox.Text;
        }

        public bool getSucc()
        {
            return succ;
        }
    }
}
