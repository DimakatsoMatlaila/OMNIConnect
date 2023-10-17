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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AddNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent addStudent = new AddStudent();
            this.Visible = false;
            addStudent.ShowDialog();
        }

        private void AddLecturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddLecturer add= new AddLecturer(); 
            this.Visible = false;
            add.ShowDialog();  

        }

        private void ListOfSubjectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListCourses listCourses = new ListCourses();
            this.Visible = false;
            listCourses.ShowDialog();
        }

        private void AddNewSubjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourses add = new AddCourses();
            this.Visible = false;   
            add.ShowDialog();
        }

        private void ListOfStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListStudentsAdmin listStudentsAdmin = new ListStudentsAdmin();
            this.Visible = false;
            listStudentsAdmin.ShowDialog(); 
        }

        private void ListLecturersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListLecturersAdmin list = new ListLecturersAdmin(); 
            this.Visible = false;   
            list.ShowDialog();
        }

        private void tslogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Visible = false;
            login.ShowDialog(); 
        }

        private void tsReport_Click(object sender, EventArgs e)
        {
            ReportsAdmin report = new ReportsAdmin();
            this.Visible=false;
            report.ShowDialog();
        }

        private void tsUser_Click(object sender, EventArgs e)
        {
            ManageUsers manageUsers = new ManageUsers();
            this.Visible=false; 
            manageUsers.ShowDialog();   
        }
    }
}
