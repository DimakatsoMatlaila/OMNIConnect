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
    public partial class LecturerDashboard : Form
    {
        public LecturerDashboard()
        {
            InitializeComponent();
        }

        private void AddNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ListOfStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddLecturerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ListLecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddNewSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ListOfSubjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsUser_Click(object sender, EventArgs e)
        {
            CreateLecturerProfile createLecturerProfile = new CreateLecturerProfile();
            this.Visible = false;
            createLecturerProfile.ShowDialog();
        }

        private void ListOfStudentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ListStudentsAdmin studentsAdmin = new ListStudentsAdmin();
            this.Visible = false;
            studentsAdmin.ShowDialog();
        }

        private void ListOfSubjectsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ListCourses admins = new ListCourses();
            this.Visible = false;
            admins.ShowDialog();
        }

        private void ListLecturersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CreateTimeslotcs admins = new CreateTimeslotcs();
            this.Visible = false;   
            admins.ShowDialog();    
        }

        private void tslogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Visible = false;
            login.ShowDialog();
        }
    }
}
