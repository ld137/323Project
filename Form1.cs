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
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ld137_323_Assignment_2
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        private string username;
        private string password;

        private void Form1_Load(object sender, EventArgs e)
        {

            Logon_Form logonForm = new Logon_Form();
            logonForm.ShowDialog();
            this.username = logonForm.getUsername();
            this.password = logonForm.getPassword();

            if(string.IsNullOrEmpty(this.username) || string.IsNullOrEmpty(this.password))
            {
                this.Close();
            }

            selectComboBox.Items.Add("User:");
            selectComboBox.Items.Add("Spot:");
            selectComboBox.Items.Add("Tag:");
            selectComboBox.Items.Add("Comment:");

        }

        void sqlRequest(string query)
        {
            string oradb = "Data Source=oracle.cms.waikato.ac.nz:1521/teaching;User Id=" + this.username + ";Password=" + this.password + ";";
            OracleConnection conn = new OracleConnection(oradb);  // C#
            try
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();

                displayListView.Items.Clear();
                displayListView.Columns.Clear();
                if (dr.HasRows)
                {
                    ColumnHeader[] headers = new ColumnHeader[dr.FieldCount];

                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        ColumnHeader columnHeader = new ColumnHeader();
                        columnHeader.Text = dr.GetName(i);
                        headers[i] = columnHeader;
                    }
                        
                    this.displayListView.Columns.AddRange(headers);

                    while (dr.Read())
                    {

                        ListViewItem lvi = new ListViewItem(dr.GetValue(0).ToString());
                        for(int i = 1; i < dr.FieldCount; i++)
                        {
                            if (!dr.IsDBNull(i))
                                lvi.SubItems.Add(dr.GetValue(i).ToString());
                            else
                                lvi.SubItems.Add("null");
                        }
                        displayListView.Items.Add(lvi);
                        
                    }
                }
                dr.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchQuery = searchTextBox.Text;
            int res;
            if (!string.IsNullOrEmpty(searchQuery))
            {
                if(selectComboBox.SelectedIndex == 0)
                {
                    if (int.TryParse(searchQuery, out res))
                    {
                        sqlRequest("select USERID, F_NAME, L_NAME, EMAIL, PHONE from a2_user where userID =" + searchQuery);
                    }
                    else
                    {
                        sqlRequest("select USERID, F_NAME, L_NAME, EMAIL, PHONE from a2_user where REGEXP_LIKE(F_NAME, '" + searchQuery+"') or REGEXP_LIKE(L_NAME, '"+searchQuery+"')");
                    }

                }
                else if(selectComboBox.SelectedIndex == 1) 
                {
                    sqlRequest("select * from a2_spot where REGEXP_LIKE(spot_name, '" + searchQuery+"', 'i')");
                }
                else if(selectComboBox.SelectedIndex == 2)
                {
                    sqlRequest("select * from a2_tag where REGEXP_LIKE(tagName, '" + searchQuery + "', 'i')");
                }
                else if(selectComboBox.SelectedIndex == 3)
                {
                    sqlRequest("select * from a2_comment where REGEXP_LIKE(comment_text, '" + searchQuery + "', 'i')");
                }
            }
            return;
        }

        private void selectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectComboBox.SelectedIndex == 0)
            {
                 sqlRequest("select USERID, F_NAME, L_NAME, EMAIL, PHONE from a2_user");
            }
            else if (selectComboBox.SelectedIndex == 1)
            {
                sqlRequest("select * from a2_spot");
            }
            else if (selectComboBox.SelectedIndex == 2)
            {
                sqlRequest("select * from a2_tag");
            }
            else if (selectComboBox.SelectedIndex == 3)
            {
                sqlRequest("select * from a2_comment");
            }
        }

        private void displayListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string text;
                if (selectComboBox.Text == "User:")
                {
                    text = displayListView.SelectedItems[0].Text;
                    selectComboBox.SelectedIndex = 1;
                    sqlRequest("select a2_spot.SpotID, a2_spot.Spot_name, a2_spot.Spot_Description from a2_user join a2_spot on a2_user.userID = a2_spot.userID where a2_user.userID=" + text);
                }
            }
            catch(Exception ex)
            {

            }
        }
    }
}
