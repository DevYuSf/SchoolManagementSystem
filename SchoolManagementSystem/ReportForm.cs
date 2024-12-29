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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            PaymentReportForm paymentReportForm = new PaymentReportForm();
            this.Hide();
            paymentReportForm.ShowDialog();
        }

        private void btnViewSubjects_Click(object sender, EventArgs e)
        {
            StudentsReportForm student = new StudentsReportForm();
            this.Hide();
            student.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            this.Hide();
            dashboardForm.ShowDialog();
        }
    }
}
