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
    public partial class ViewSubjects : Form
    {
        string id;
        string subject;
        public ViewSubjects()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            SubjectsForm subjectsForm = new SubjectsForm();
            this.Hide();
            subjectsForm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            operation();
        }

        public void operation()
        {
            AddAndUpdateSubject addAndUpdateSubject = new AddAndUpdateSubject();
            addAndUpdateSubject.Text = "Update subject";
            addAndUpdateSubject.btnSave.Text = "Update";
            addAndUpdateSubject.test.Text = id;
            addAndUpdateSubject.txtSubject.Text = subject;          
            addAndUpdateSubject.lblText.Text = "Update subject";
            this.Hide();
            addAndUpdateSubject.ShowDialog();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            subject = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Config config = new Config();
                using (config.sqlCon = new SqlConnection(config.conString))
                {
                    config.query = "DELETE FROM TblSubject WHERE SubjectId = @subjectId;";
                    using (config.sqlCmd = new SqlCommand(config.query, config.sqlCon))
                    {

                        config.sqlCmd.Parameters.AddWithValue("@subjectId", id);

                        config.sqlCon.Open();
                        int result = config.sqlCmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Successfuly deleted", "deleted subject", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error", "deleted subject", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void display(string qs = "SELECT * FROM TblSubject order by SubjectId ")
        {
            try
            {
                Config config = new Config();
                using (config.sqlCon = new SqlConnection(config.conString))
                {
                    DataSet ds = new DataSet();
                    config.sqlDa = new SqlDataAdapter(qs, config.sqlCon);
                    config.sqlDa.Fill(ds, "TblSubject");
                    dataGridView1.DataSource = ds.Tables["TblSubject"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewSubjects_Load(object sender, EventArgs e)
        {
            display();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
    }
}
