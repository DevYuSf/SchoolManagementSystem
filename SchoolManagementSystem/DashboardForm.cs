using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SchoolManagementSystem
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void brnStd_Click(object sender, EventArgs e)
        {
            StudentForm studentForm = new StudentForm();
            this.Hide();
            studentForm.ShowDialog();
        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            ClassesForm classesForm = new ClassesForm();
            this.Hide();
            classesForm.ShowDialog();
        }

        private void btnSubjects_Click(object sender, EventArgs e)
        {
            SubjectsForm subjectsForm = new SubjectsForm();
            this.Hide();
            subjectsForm.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            this.Hide();
            reportForm.ShowDialog();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            EnrolmentStudentClassAndSubject studentClassAndSubject = new EnrolmentStudentClassAndSubject();
            this.Hide();
            //studentClassAndSubject.txtId.Text = lastInsertedId.ToString();
            //studentClassAndSubject.txtName.Text = txtName.Text;
            studentClassAndSubject.ShowDialog();
        }
    }
}
