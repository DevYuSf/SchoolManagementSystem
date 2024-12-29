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
using static System.Net.Mime.MediaTypeNames;

namespace SchoolManagementSystem
{
    public partial class viewStdForm : Form
    {
        string id;
        string name;
        string gender;
        string status;
        string mobile;
        string address;
        string age;
        string dOR;
        string dOB;
        public viewStdForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            this.Hide();
            studentForm.ShowDialog();
        }

        private void viewStdForm_Load(object sender, EventArgs e)
        {
            display();
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void display(string qs = "SELECT * FROM TblStudent")
        {
            try
            {
                Config config = new Config();
                using (config.sqlCon = new SqlConnection(config.conString))
                {
                    DataSet ds = new DataSet();
                    config.sqlDa = new SqlDataAdapter(qs, config.sqlCon);
                    config.sqlDa.Fill(ds, "TblStudent");
                    dataGridView1.DataSource = ds.Tables["TblStudent"];
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();            
            gender = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString().Replace(" ", "");
            address = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            status = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString().Replace(" ", "");
            age = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            mobile = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();          
            dOR = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            dOB = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
     
        }

        public void operation()
        {
            AddAndUpdateStdForm addAndUpdateStdForm = new AddAndUpdateStdForm();
            this.Hide();
            addAndUpdateStdForm.Text = "Update student";
            addAndUpdateStdForm.button1.Text = "Update";
            addAndUpdateStdForm.txtName.Text = name;
            addAndUpdateStdForm.txtMobile.Text = mobile;
            addAndUpdateStdForm.txtAge.Text = age;
            addAndUpdateStdForm.txtAddress.Text = address;
            addAndUpdateStdForm.lblText.Text = "Update Student";
            addAndUpdateStdForm.dateOfBirth.Value = DateTime.Parse(dOB);
            addAndUpdateStdForm.dateOfReg.Value = DateTime.Parse(dOR);
            addAndUpdateStdForm.test.Text = id;
            if (gender == "Male")
            {
                addAndUpdateStdForm.comboGender.SelectedItem="Male";
            }
            else if(gender == "Female")
            {
                addAndUpdateStdForm.comboGender.SelectedItem ="Female";
            }

            if (status == "Active")
            {
                addAndUpdateStdForm.comboStatus.SelectedItem = "Active";
            }
            else if (status =="InActive")
            {
                addAndUpdateStdForm.comboStatus.SelectedItem = "InActive";
            }
            


            if (DateTime.TryParse(dOR.ToString(), out DateTime selectedDate2))
            {

                addAndUpdateStdForm.dateOfReg.Value = selectedDate2; // Assuming dataRegistration is your DateTimePicker
            }
            addAndUpdateStdForm.ShowDialog();


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Config config = new Config();
                using (config.sqlCon = new SqlConnection(config.conString))
                {
                    config.query = "DELETE FROM TblStudent WHERE StudentId = @StudentId;";
                    using (config.sqlCmd = new SqlCommand(config.query, config.sqlCon))
                    {
                        //string gender = rBtnFemale.Checked ? "Female" : "Male";

                        config.sqlCmd.Parameters.AddWithValue("@studentId", id);
                       
                        config.sqlCon.Open();
                        int result = config.sqlCmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Successfuly deleted" ,"deleted Student", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error",  "deleted Student", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
