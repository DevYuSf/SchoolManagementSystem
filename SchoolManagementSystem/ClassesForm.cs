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
    public partial class ClassesForm : Form
    {
        public ClassesForm()
        {
            InitializeComponent();
        }

        private void btnViewClasses_Click(object sender, EventArgs e)
        {
            ViewClasses viewClasses = new ViewClasses();
            this.Hide();
            viewClasses.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            DashboardForm dashboardForm = new DashboardForm();
            this.Hide();
            dashboardForm.ShowDialog();
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            AddAndUpdateClass addAndUpdateClass = new AddAndUpdateClass();
            this.Hide();
            addAndUpdateClass.ShowDialog();
        }
    }
}
