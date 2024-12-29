using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    internal class Config
    {
        public string conString = @"Data Source=DESKTOP-KCQ5JHF\SQLEXPRESS;Initial Catalog=studentFeeManagementDB;Integrated Security=SSPI";
        public string query;
        public SqlConnection sqlCon;
        public SqlCommand sqlCmd;
        public SqlDataAdapter sqlDa;
        public SqlDataReader sqlDr;
        public string insertAlert = "Data has been saved.";
        public string updateAlert = "Data has been updated.";
        public string deleteAlert = "Data has been deleted.";

        //connect method
        public void Connect()
        {
            if (sqlCon.State != ConnectionState.Open)
                sqlCon.Open();
        }
        //disconnect method
        public void Disconnect()
        {
            if (sqlCon.State != ConnectionState.Closed)
                sqlCon.Close();
        }
        //ProcessData method
        public void ProcessData(string query, string _alert)
        {
            try
            {
                using (sqlCmd = new SqlCommand(query, sqlCon))
                {
                    Connect();//open connection
                    if (sqlCmd.ExecuteNonQuery() > 0)
                        MessageBox.Show(_alert, "Student Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Failed!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Disconnect();//close connection
                }
            }
            catch (Exception ex)
            {
                Disconnect();
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //display method
        public void Display(string query, DataGridView dataGridView)
        {
            try
            {
                using (sqlDa = new SqlDataAdapter(query, sqlCon))
                {
                    DataSet ds = new DataSet();
                    sqlDa.Fill(ds, "tbl");
                    dataGridView.DataSource = ds.Tables["tbl"];
                }
            }
            catch (Exception ex)
            {
                Disconnect();
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //clear method
        public void Clear(params Control[] ctrl)
        {
            try
            {

                for (int i = 0; i < ctrl.Length; i++)
                {
                    ctrl[i].Text = string.Empty;
                }
                ctrl[0].Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //GetDataFromDGV method
        public void GetDataFromDGV(DataGridView dataGridView, DataGridViewCellEventArgs e, params Control[] ctrl)
        {
            try
            {
                for (int i = 0; i < ctrl.Length; i++)
                {
                    ctrl[i].Text = dataGridView.Rows[e.RowIndex].Cells[i].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
