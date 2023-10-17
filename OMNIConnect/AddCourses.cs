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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace OMNIConnect
{
    public partial class AddCourses : Form
    {
        public AddCourses()
        {
            InitializeComponent();
            GetLecturerIDs();
            getCourseID();
           // GenerateNewCourseID();
        }

        List<string> LecturerIDs = new List<string>();
        int LecturerID = LoginID.ID;
        int NewCourseID;
        String COURSE_ID;
        string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\dkmat\\Documents\\OMNIConnectSystemDB.accdb";
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");
        List<string> CourseIDs = new List<string>();
        public void GetLecturerIDs()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT lecturer_id From Lecturers", conn);
                LoginID loginID = new LoginID();

                // cmd.Parameters.AddWithValue("@1", id.ToString());
                // cmd.Parameters.AddWithValue("@2", textBox1.Text);
                OleDbDataReader reader = cmd.ExecuteReader();



                while (reader.Read())
                {

                    //string courseID = reader["Course_ID"].ToString();
                    string lecturerID = reader["lecturer_id"].ToString();

                    //LecturerIDs.Add(courseID);
                    LecturerIDs.Add(lecturerID);
                    // LecturerID = lecturerID;
                    PopulateLComboBox();


                }

                // Close the data reader and connection
                reader.Close();
                conn.Close();

                // Now you have the yearOfStudyList and degreeList with the values you need
                // You can use these lists as needed without refreshing the DataGridView
            }
            catch (Exception e)
            {
                MessageBox.Show("Error Connection: " + e);
            }
            finally
            {
                conn.Close();
            }
        }
        private void PopulateLComboBox()
        {
            cmbLectCode.Items.Clear();
            // Clear the ComboBox in case it already has items
            //tems.Clear();

            // Add each element from the CourseIDs list to the ComboBox
            foreach (string courseId in LecturerIDs)
            {
                cmbLectCode.Items.Add(courseId);
            }
        }


        public void getCourseID()
        {
            int CourseCount = 0; ;
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");

            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT Course_ID FROM Courses", conn);
            cmd.Parameters.AddWithValue("@LectID", LoginID.ID);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                string courseid = reader["Course_ID"].ToString();
                COURSE_ID = courseid;
               // MessageBox.Show(courseid);

                CourseIDs.Add(courseid);
               // CourseCount++;  
            }
           // NewCourseID = CourseCount;
            GenerateNewCourseID();
           // lblNewCourseID.Text = NewCourseID.ToString();
           // lblNewC.Text = NewCourseID.ToString();
            reader.Close();
            conn.Close();
        }

        public void GenerateNewCourseID() { 
            NewCourseID=CourseIDs.Count+1;
            lblNewC.Text = NewCourseID.ToString();  
        
        }
       

        public Boolean ValidateInput(bool blnValid) {
            blnValid = true;
            String LectID=cmbLectCode.SelectedItem as String;

            if (LectID == null) {
                blnValid =false;
                MessageBox.Show("Please Select a Lecturer ID for the Course","Error");
            }
            if (txtCourseName.Text=="") { 
                blnValid=false;
                MessageBox.Show("Please neter the Course Name", "Error");
                
            }

            return blnValid;
        
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool blnValid = true;
            blnValid = ValidateInput(blnValid);


            if (blnValid==true) {
                String lecturerid = cmbLectCode.SelectedItem as String;
                string insertQuery = "INSERT INTO Courses (Course_ID, Course_Name, Lecturer_ID) VALUES (@1,@2,@3)";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@1", NewCourseID.ToString());
                        command.Parameters.AddWithValue("@2", txtCourseName.Text);
                        command.Parameters.AddWithValue("@3", lecturerid);
                        
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Course successfully added");
                           // NewCourseID = 0;
                            //getCourseID();
                            //txtCourseName.Text = "";
                            AddCourses addCourses = new AddCourses();
                            this.Visible = false;
                            addCourses.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Unsuccessful attempt");
                        }
                        connection.Close();
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            this.Visible = false;
            adminDashboard.ShowDialog();
        }
    }
}
