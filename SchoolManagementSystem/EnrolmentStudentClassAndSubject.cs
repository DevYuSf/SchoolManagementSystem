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
using static SchoolManagementSystem.EnrolmentStudentClassAndSubject;

namespace SchoolManagementSystem
{
    public partial class EnrolmentStudentClassAndSubject : Form
    {
        
        public EnrolmentStudentClassAndSubject()
        {
           // this.name = name;
            InitializeComponent();
        }

        private void EnrolmentStudentClassAndSubject_Load(object sender, EventArgs e)
        {

            
            


        }

     

        private void displaySubjects(string qs)
        {
           
        }
       
        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal totalFee = 0;
            decimal disco = 0;
            List<int> stdId = new List<int>();
            List<decimal> stdFee = new List<decimal>();
            Config config = new Config();
            config.query = $"SELECT s.SubjectId, s.fee FROM TblSubject s, TblStudentSubject ss WHERE ss.StudentId = {txtId.Text} AND ss.SubjectId = s.SubjectId";

            using (config.sqlCon = new SqlConnection(config.conString))
            {
                using (config.sqlCmd = new SqlCommand(config.query, config.sqlCon))
                {
                    config.sqlCon.Open();
                    using (SqlDataReader dr = config.sqlCmd.ExecuteReader())
                    {
                        // Check if any rows are returned
                        if (dr.HasRows)
                        {
                            // Loop through each row
                            while (dr.Read())
                            {
                                // Access data for each row
                                stdId.Add(dr.GetInt32(0)); // First column (SubjectId)
                                stdFee.Add(dr.GetDecimal(1)); // Second column (Fee)
                                totalFee += dr.GetDecimal(1);
                                // Process the data (e.g., display or store it)
                              //  MessageBox.Show($"Subject ID: {subjectId}, Fee: {fee}");
                            }
                        }
                        else
                        {
                            MessageBox.Show("No records found for the specified Student ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            if (totalFee >= decimal.Parse(txtFee.Text))
            {
                decimal amount= totalFee-decimal.Parse(txtFee.Text);
                disco =decimal.Parse( (amount/stdId.Count).ToString("n2"));
                discount.Text = amount.ToString();
            }
            else
            {
                MessageBox.Show("Failed fee");
            }
            disp.Text = totalFee.ToString();
            for (int i = 0; stdId.Count > i; i++)
            {
                config.query = $"INSERT INTO TblStudentDiscount (StudentId, SubjectId, DiscountAmount) VALUES ({txtId.Text}, {stdId[i]}, {disco})";
                using (config.sqlCon = new SqlConnection(config.conString))
                {
                    using (config.sqlCmd = new SqlCommand(config.query, config.sqlCon))
                    {
                        config.sqlCon.Open();
                        int result = config.sqlCmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Successfuly updated" + stdId[i], "updated subject discount", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Error", "update fee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        config.sqlCon.Close();
                    }
                }
                
            }



            //Config config = new Config();



            //config.query = $"select sum(s.fee)  from TblSubject s ,TblStudentSubject ss where ss.StudentId = {txtId.Text} and ss.SubjectId = s.SubjectId";
            /*using (config.sqlCon = new SqlConnection(config.conString))
            {
                using (config.sqlCmd = new SqlCommand(config.query, config.sqlCon))
                {

                    config.sqlCon.Open();
                        SqlDataReader dr = config.sqlCmd.ExecuteReader();
                        if (dr.Read())
                        {
                            disp.Text = dr.GetValue(0).ToString();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    config.sqlCon.Close();

                }
            }*/

        }

       

        private void btnBack_Click(object sender, EventArgs e)
        {

        }
        DataGridView dataGridViewSubjects = new DataGridView();
     

       
    }
}
