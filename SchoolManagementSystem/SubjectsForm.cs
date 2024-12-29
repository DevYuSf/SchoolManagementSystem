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
    public partial class SubjectsForm : Form
    {
        public SubjectsForm()
        {
            InitializeComponent();
        }

        private void btnViewSubjects_Click(object sender, EventArgs e)
        {
            ViewSubjects viewSubjects = new ViewSubjects();
            this.Hide();    
            viewSubjects.ShowDialog();
        }

        private void btnAddSubject_Click(object sender, EventArgs e)
        {
            AddAndUpdateSubject subject = new AddAndUpdateSubject();
            this.Hide();
            subject.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            this.Hide();
            dashboardForm.ShowDialog();
        }
    }
}
