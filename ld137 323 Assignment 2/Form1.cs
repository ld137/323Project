using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace ld137_323_Assignment_2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string oradb = "Data Source=oracle.cms.waikato.ac.nz:1521/teaching;User Id=ld137;Password=QDWLfMFVjK;";
            OracleConnection conn = new OracleConnection(oradb);  // C#
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select l_name from a2_user where f_name = 'Joe';";
            //cmd.CommandText = "select * from a2_user;";
            cmd.CommandType = CommandType.Text;
            OracleDataReader dr = cmd.ExecuteReader();
            dr.Read();
            idTextbox.Text = dr.GetString(0);
            conn.Dispose();
        }

        void sqlRequest(OracleCommand cmd, String commandString)
        {

        }
    }
}
