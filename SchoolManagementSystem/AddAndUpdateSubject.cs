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

namespace SchoolManagementSystem
{
    public partial class AddAndUpdateSubject : Form
    {
        public AddAndUpdateSubject()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                SubjectsForm subjectsForm = new SubjectsForm();
                this.Hide();
                subjectsForm.ShowDialog();

            }
            else if (btnSave.Text == "Update")
            {
                ViewSubjects viewSubjects = new ViewSubjects();
                this.Hide(); viewSubjects.ShowDialog();
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {

                operation1("insert into TblSubject(SubjectName) values(@subject)", " Added ");

            }
            else if (btnSave.Text == "Update")
            {
                operation1("UPDATE TblSubject SET SubjectName = @subject WHERE SubjectId = @id", " Updated ");

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

                        config.sqlCmd.Parameters.AddWithValue("@id", test.Text);
                        config.sqlCmd.Parameters.AddWithValue("@subject", txtSubject.Text);
                        config.sqlCon.Open();
                        int result = config.sqlCmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Successfuly " + operation, operation + " subject", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error", operation + " subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtSubject.Clear();
            txtSubject.Focus();
        }
    }
}
