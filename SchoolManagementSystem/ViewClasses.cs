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
using System.Xml.Linq;

namespace SchoolManagementSystem
{
    public partial class ViewClasses : Form
    {
        string id;
        string className;
        public ViewClasses()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ClassesForm frm = new ClassesForm();
            this.Hide();
            frm.ShowDialog();
        }

        private void ViewClasses_Load(object sender, EventArgs e)
        {
            display();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }
        public void display(string qs = "SELECT * FROM TblClass")
        {
            try
            {
                Config config = new Config();
                using (config.sqlCon = new SqlConnection(config.conString))
                {
                    DataSet ds = new DataSet();
                    config.sqlDa = new SqlDataAdapter(qs, config.sqlCon);
                    config.sqlDa.Fill(ds, "TblClass");
                    dataGridView1.DataSource = ds.Tables["TblClass"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            operation();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            className = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        public void operation()
        {
            AddAndUpdateClass addAndUpdateClass = new AddAndUpdateClass();
            addAndUpdateClass.Text = "Update class";
            addAndUpdateClass.btnSave.Text = "Update";
            addAndUpdateClass.test.Text = id;
            addAndUpdateClass.txtClass.Text = className;
            addAndUpdateClass.lblText.Text = "Update class";
            this.Hide();
            addAndUpdateClass.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Config config = new Config();
                using (config.sqlCon = new SqlConnection(config.conString))
                {
                    config.query = "DELETE FROM TblClass WHERE classId = @classId;";
                    using (config.sqlCmd = new SqlCommand(config.query, config.sqlCon))
                    {

                        config.sqlCmd.Parameters.AddWithValue("@classId", id);

                        config.sqlCon.Open();
                        int result = config.sqlCmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Successfuly deleted", "deleted class", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error", "deleted class", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
