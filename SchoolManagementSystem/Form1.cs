using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlTypes;

namespace SchoolManagementSystem
{

    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void txtUserName_MouseClick(object sender, MouseEventArgs e)
        {
           // hintPassword.Visible = false;
            hintUserName.Visible = false;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void hintUserName_MouseClick(object sender, MouseEventArgs e)
        {
            hintUserName.Visible = false;
            txtUserName.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void hintPassword_Click(object sender, EventArgs e)
        {
            hintPassword.Visible = false;
            txtPassword.Focus();
        }

        private void txtPassword_MouseClick(object sender, MouseEventArgs e)
        {
            hintPassword.Visible = false;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {

            try
            {
                Config config = new Config();
                using (config.sqlCon = new SqlConnection(config.conString))
                {
                    config.query = "select * from TblUser where UserName ='" + txtUserName.Text + "' and _password='" + txtPassword.Text +"'";
                    using (config.sqlCmd = new SqlCommand(config.query, config.sqlCon))
                    {
                        //if (txtPassword.Text != string.Empty || txtUserName.Text != string.Empty)
                        //{
                        //    config.sqlCon.Open();
                        //    config.sqlDr = config.sqlCmd.ExecuteReader();
                        //    if (config.sqlDr.Read())
                        //    {
                               // config.sqlDr.Close();
                                DashboardForm dashboardForm = new DashboardForm();
                                this.Hide();
                                dashboardForm.ShowDialog();
                        //    }
                        //    else
                        //    {
                        //       // config.sqlDr.Close();
                        //        MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    }

                        //}
                        //else
                        //{
                        //    MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




           // DashboardForm dashboardForm = new DashboardForm();
           // this.Hide();
           // dashboardForm.ShowDialog();
        }
    }
}
