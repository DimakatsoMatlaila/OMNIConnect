using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OMNIConnect
{
    public partial class ListCourses : Form
    {
               OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");
      //  OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");

        public void refreshGrid()
        {
            try
            {
                conn.Open();
                DataTable dt = new DataTable();
                  OleDbDataAdapter da = new OleDbDataAdapter("SELECT Courses.Course_ID,Courses.Course_Name, Lecturers.First_Name + ' ' + Lecturers.Last_Name AS [Lecturer Name] " +
                                             "FROM Courses " +
                                             "INNER JOIN Lecturers ON Courses.Lecturer_ID = Lecturers.lecturer_id", conn);
               /* OleDbDataAdapter da = new OleDbDataAdapter("SELECT Timeslots.SlotID, Courses.Course_Name, Timeslots.CalDate, FORMAT(Timeslots.ClockTime, 'hh:mm') AS FormattedClockTime " +
                                            "FROM Timeslots " +
                                            "LEFT JOIN Courses ON Timeslots.Course_ID = Courses.Course_ID", conn);
               */




                da.Fill(dt);

                dgw.DataSource = dt;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Connection: " + e.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        public ListCourses()
        {
            InitializeComponent();
            refreshGrid();  
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            String AccType = LoginID.AccType;

            if (AccType == "Student")
            {
                StudentDashboard studentDashboard = new StudentDashboard();
                this.Visible = false;
                studentDashboard.ShowDialog();
            }
            else if (AccType == "Lecturer")
            {
                LecturerDashboard lecturerDashboard = new LecturerDashboard();
                this.Visible = false;
                lecturerDashboard.ShowDialog();
            }
            else if (AccType == "Admin") { 
                AdminDashboard adminDashboard = new AdminDashboard();
                this.Visible = false;
                adminDashboard.ShowDialog();
            }
        }
    }
}
