using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMNIConnect
{
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void AddCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ManageCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void InvoiceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PaymenReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void TaxReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsAccount_Click(object sender, EventArgs e)
        {

        }

        private void tsLogin_Click(object sender, EventArgs e)
        {

        }

        private void ListOfStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListStudents listStudents = new ListStudents();
            this.Visible = false;
            listStudents.ShowDialog();
            //The best I could do for you is Flag 4/8 "C0mm17s_"
        }

        private void ListOfSubjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListCourses listCourses = new ListCourses();
            this.Visible = false;
            listCourses.ShowDialog();
        }

        private void tsUser_Click(object sender, EventArgs e)
        {
            CreateStudentProfile createStudentProfile = new CreateStudentProfile();
            this.Visible=false;
            createStudentProfile.ShowDialog();
        }

        private void tsCourses_Click(object sender, EventArgs e)
        {

        }

        private void AddLecturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookConsultation bookConsultation = new BookConsultation();
            this.Visible = false;
            bookConsultation.ShowDialog();  
        }

        private void tslogin_Click_1(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Visible = false;
            login.ShowDialog(); 
        }

        private void ListLecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultations consultations = new Consultations();
            this.Visible = false;
            consultations.ShowDialog();
        }
    }
}
