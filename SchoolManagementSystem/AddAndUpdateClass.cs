using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace SchoolManagementSystem
{
    public partial class AddAndUpdateClass : Form
    {
        public AddAndUpdateClass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                ClassesForm classesForm = new ClassesForm();
                this.Hide();
                classesForm.ShowDialog();

            }
            else if (btnSave.Text == "Update")
            {
                ViewClasses viewClasses = new ViewClasses();
                this.Hide();
                viewClasses.ShowDialog();
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {

                operation1("insert into TblClass(className) values(@class)", " Added ");

            }
            else if (btnSave.Text == "Update")
            {
                operation1("UPDATE TblClass SET className = @class WHERE classId = @id", " Updated ");

            }
        }
        public void operation1(String que, String operation)
        {
            try
            {
                Config config = new Config();
                using (config.sqlCon = new SqlConnection(config.conString))
                {
                    config.query = que;
                    using (config.sqlCmd = new SqlCommand(config.query, config.sqlCon))
                    {
                        //string gender = rBtnFemale.Checked ? "Female" : "Male";

                        config.sqlCmd.Parameters.AddWithValue("@id", test.Text);
                        config.sqlCmd.Parameters.AddWithValue("@class", txtClass.Text);
                        config.sqlCon.Open();
                        int result = config.sqlCmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Successfuly " + operation, operation + " class", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error", operation + " class", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void clear()
        {
            txtClass.Clear();
            txtClass.Focus();
        }
    }
}
