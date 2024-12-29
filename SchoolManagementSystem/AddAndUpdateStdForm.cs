using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class AddAndUpdateStdForm : Form
    {
        public AddAndUpdateStdForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Save")
            {
                StudentForm studentForm = new StudentForm();
                this.Hide();
                studentForm.ShowDialog();

            }
            else if (button1.Text == "Update")
            {
                 viewStdForm ViewStdForm = new viewStdForm();
                this.Hide();
                ViewStdForm.ShowDialog();
            }
        }
        string TName;
        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Next")
            {

                operation1("insert into TblStudent(StdName,Gender,Status,Mobile,Address,Age,DateOfReg,DateOfBirth) values(@name,@gender,@status,@mobile,@address,@age,@dateOfReg,@dateOfBirth);SELECT SCOPE_IDENTITY();", " Added ");
               

            }
            else if(button1.Text == "Update")
            {
                operation1("UPDATE TblStudent SET StdName = @name,Gender = @gender,Address = @address,Status = @status,Age = @age,Mobile = @mobile,DateOfReg = @dateOfReg,DateOfBirth = @dateOfBirth WHERE StudentId = @studentId;", " Updated ");

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
                        TName = txtName.Text;
                        config.sqlCmd.Parameters.AddWithValue("@studentId", test.Text);
                        config.sqlCmd.Parameters.AddWithValue("@name", txtName.Text);
                        config.sqlCmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        config.sqlCmd.Parameters.AddWithValue("@mobile", txtMobile.Text);
                        config.sqlCmd.Parameters.AddWithValue("@age", txtAge.Text);
                        config.sqlCmd.Parameters.AddWithValue("@gender", comboGender.SelectedItem.ToString());
                        config.sqlCmd.Parameters.AddWithValue("@status", comboStatus.SelectedItem.ToString());
                        config.sqlCmd.Parameters.AddWithValue("@dateOfReg", dateOfReg.Value);
                        config.sqlCmd.Parameters.AddWithValue("@dateOfBirth", dateOfBirth.Value);
                        config.sqlCon.Open();
                       var lastInsertedId = config.sqlCmd.ExecuteScalar();
                       // int result = config.sqlCmd.ExecuteNonQuery();
                        if (lastInsertedId !=null)
                        {
                            // MessageBox.Show("Successfuly " + operation, operation+ " Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            EnrolmentStudentClassAndSubject studentClassAndSubject = new EnrolmentStudentClassAndSubject();
                            this.Hide();
                            studentClassAndSubject.txtId.Text = lastInsertedId.ToString();
                            studentClassAndSubject.txtName.Text = txtName.Text;
                            studentClassAndSubject.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Error", operation + " Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                //clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void clear()
        {
            txtAddress.Clear();
            txtMobile.Clear();
            txtAge.Clear();
            txtName.Clear();
            comboGender.SelectedItem = null;
            comboStatus.SelectedItem =null;
            dateOfBirth.Value = DateTime.Now;
            dateOfReg.Value = DateTime.Now;
            txtName.Focus();
        }
    }
}
