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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OMNIConnect
{
    public partial class BookConsultation : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");
        int id = LoginID.ID;
        List<string> CourseIDs = new List<string>();
        List<string> LecturerIDs = new List<string>();
        String CourseID = "";
        String LecturerID = "";
        String CourseNAME = "";
        // OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");
        //  OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");

        public void refreshGrid()
        {
            try
            {

                conn.Open();
                DataTable dt = new DataTable();
                // Assuming you have a parameter named courseIDParam with the desired value.
                // Assuming you have parameters for both Course_ID and Slot_Status.
                OleDbCommand cmd = new OleDbCommand("SELECT Timeslots.SlotID, Courses.Course_Name, FORMAT(Timeslots.CalDate,'dd-mmmm-yyyy') AS [Calender Date], FORMAT(Timeslots.ClockTime, 'hh:mm') AS [Time of Day] " +
                                                     "FROM Timeslots " +
                                                     "LEFT JOIN Courses ON Timeslots.Course_ID = Courses.Course_ID " +
                                                     "WHERE Courses.Course_ID = @courseIDParam AND Timeslots.Slot_Status = 'A'", conn);
                cmd.Parameters.AddWithValue("@courseIDParam", CourseID);

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);



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

        private void PopulateComboBox()
        {
            // Clear the ComboBox in case it already has items
            cmbCCode.Items.Clear();

            // Add each element from the CourseIDs list to the ComboBox
            foreach (string courseId in CourseIDs)
            {
                cmbCCode.Items.Add(courseId);
            }
        }

        public void GetData()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT Course_ID, Lecturer_ID From Courses", conn);
                LoginID loginID = new LoginID();

                cmd.Parameters.AddWithValue("@1", id.ToString());
                // cmd.Parameters.AddWithValue("@2", textBox1.Text);
                OleDbDataReader reader = cmd.ExecuteReader();

               

                while (reader.Read())
                {
                  
                    string courseID = reader["Course_ID"].ToString();
                    string lecturerID = reader["Lecturer_ID"].ToString();
                   
                    CourseIDs.Add(courseID);
                    LecturerIDs.Add(lecturerID);
                    LecturerID = lecturerID;

                
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



        public BookConsultation()
        {
            InitializeComponent();
            GetData();
            PopulateComboBox();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            StudentDashboard studentDashboard = new StudentDashboard();
            this.Visible = false;
            studentDashboard.ShowDialog();
        }

        private void dgw_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgw.Rows[e.RowIndex];

                string slotid = row.Cells["SlotID"].Value.ToString();
                string courseName = row.Cells["Course_Name"].Value.ToString();
                string date = row.Cells["Calender Date"].Value.ToString();
                string time = row.Cells["Time of Day"].Value.ToString();

                lblDate.Text = date;
                lblTime.Text = time;

                String SelectedCode = cmbCCode.SelectedItem as String;
                String AttType = cmbAttendanceType.SelectedItem as String;
                String SessionS = cmbSess.SelectedItem as String;


                lblSlotID.Text = SelectedCode;
                lblLocation.Text = AttType;
                lblSession.Text = SessionS;
                lblSlotID.Text = slotid;
               // MessageBox.Show("SlotID = "+lblSlotID.Text);
                lblStatus.Text = "Available";

            }
           
        }

        public Boolean ValidateInput(bool blnValid) {
            blnValid = true;

            String Ccode = cmbCCode.SelectedItem as String;
            String AttType = cmbAttendanceType.SelectedItem as String;
            String SessionS = cmbSess.SelectedItem as String;

            if (Ccode==null) {
                blnValid=false;
                MessageBox.Show("Please Select the Course Code!","Input Error: ");
            }
            if (AttType==null) {
                blnValid = false;
                MessageBox.Show("Please Select the Attendance Type!", "Input Error: ");
            }
            if (SessionS == null)
            {
                blnValid = false;
                MessageBox.Show("Please Select the Session Type!", "Input Error: ");
            }

            return blnValid;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String SelectedCode = cmbCCode.SelectedItem as String;
            String AttType = cmbAttendanceType.SelectedItem as String;
            String SessionS = cmbSess.SelectedItem as String;



            bool blnValid = true;
            blnValid = ValidateInput(blnValid);

            if (blnValid==true)
            {

                if (SelectedCode != null)
                {
                    getCourseName();
                    CourseID = SelectedCode;
                    refreshGrid();
                    int rowCount = dgw.RowCount;
                    // MessageBox.Show("Number of rows in the dgw :"+rowCount);
                    if (rowCount==0) {
                        MessageBox.Show("There are No Available Slots for " + CourseNAME + " At the moment,check again later!", "System Message : ");
                       // BookConsultation bookConsultation = new BookConsultation();
                       // this.Visible = false;
                       // bookConsultation.ShowDialog();
                        
                    }
                }
                for (int i = 0; i < CourseIDs.Count; i++)
                {
                    if (SelectedCode == CourseIDs[i])
                    {
                        LecturerID = LecturerIDs[i];
                    }
                }

               

            }
        }

        public void getCourseName() {
            String SelectedCourseCode = cmbCCode.SelectedItem as String;
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT Course_Name FROM Courses WHERE Course_ID = @CourseID", conn);
            cmd.Parameters.AddWithValue("@CourseID", SelectedCourseCode);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                string coursename = reader["Course_Name"].ToString();
                CourseNAME = coursename;

            }
            reader.Close();
            conn.Close();
        }

        public void UpdateSlot() {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("update Timeslots set Slot_Status = @1 where SlotID = @2", conn);
                cmd.Parameters.AddWithValue("@1", "B");

                cmd.Parameters.AddWithValue("@2", lblSlotID.Text);

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch {
                MessageBox.Show("Error occured while updating timeslots!,Please contact Admin ASAP","System ERROR :");
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {



            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("insert into Consultations (Lecturer_ID,Student_ID,Slot_ID) values (@1,@2,@3)", conn);
                cmd.Parameters.AddWithValue("@1", LecturerID);
                cmd.Parameters.AddWithValue("@2", LoginID.ID.ToString());
                cmd.Parameters.AddWithValue("@3", Convert.ToInt32(lblSlotID.Text));

                cmd.ExecuteNonQuery();
                conn.Close();
                UpdateSlot();
                refreshGrid();
                MessageBox.Show("Consultation Successfully created!");
                int rowCount = dgw.RowCount;
                // MessageBox.Show("Number of rows in the dgw :"+rowCount);
                if (rowCount == 0)
                {
                    MessageBox.Show("There are No More Available Slots for " + CourseNAME + " At the moment,check again later!", "System Message : ");

                }
               
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("Oops...! An error occured,Please Retry.","Database Error :");
            }

        }
    }
}
