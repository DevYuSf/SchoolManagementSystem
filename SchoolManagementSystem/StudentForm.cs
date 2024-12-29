using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementSystem
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            DashboardForm dashboardForm = new DashboardForm();
            dashboardForm.ShowDialog();
           
            
        }

        private void btnViewStd_Click(object sender, EventArgs e)
        {
            viewStdForm ViewStdForm = new viewStdForm();
            this.Hide();
            ViewStdForm.ShowDialog();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddAndUpdateStdForm addAndUpdateStdForm = new AddAndUpdateStdForm();
            this.Hide();
            addAndUpdateStdForm.ShowDialog();
        }
    }
}
