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
using System.Xml.Linq;

namespace OMNIConnect
{
    public partial class CreateTimeslotcs : Form
    {
        public CreateTimeslotcs()
        {
            InitializeComponent();
            lblLectID.Text = LoginID.ID.ToString();
            getCourseID();
            PopulateComboBox();
        }
        int LecturerID = LoginID.ID;
        String COURSE_ID;
        string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\dkmat\\Documents\\OMNIConnectSystemDB.accdb";
        List<string> CourseIDs = new List<string>();
        public bool ValidateFormInput(bool blnValidInput)
        {
            blnValidInput = true;
            String Courseid = cmbCCode.SelectedItem as String;
            // String lectID = cmbLectID.SelectedItem as String;

            /* if (lectID == null)
             {
                 blnValidInput = false;
                 MessageBox.Show("Please select Lecture ID", "ERROR");
             }*/
            if (Courseid == null) {
                blnValidInput = false;
                MessageBox.Show("Please specify which of your courses does this Timeslot belong to!", "ERROR");
            }

            if (string.IsNullOrWhiteSpace(mtxtHH.Text)) // Check if the hour input is empty
            {
                blnValidInput = false;
                MessageBox.Show("Please enter hour", "ERROR");
            }

            if (string.IsNullOrWhiteSpace(mtxtMM.Text)) // Check if the minutes input is empty
            {
                blnValidInput = false;
                MessageBox.Show("Please enter minutes", "ERROR");
            }

            int hours;
            if (!int.TryParse(mtxtHH.Text, out hours) || hours < 1 || hours > 12)
            {
                blnValidInput = false;
                MessageBox.Show("Please enter a valid hour in 12H format", "ERROR");
            }

            return blnValidInput;
        }

        public void Clear()
        {
            //cmbLectID.SelectedIndex = -1;
            dtPicker.Value = DateTime.Now;
            mtxtHH.Text = "";
            mtxtMM.Text = "";
        }

        private bool IsTimeslotAlreadyExists(int lectID, string pSlotDate, string time)
        {
            //string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\dkmat\\Documents\\OMNIConnectSystemDB.accdb";

            string selectQuery = "SELECT * FROM Timeslots WHERE Lecturer_ID = @1 AND CalDate = @2 AND ClockTime = @3";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                using (OleDbCommand command = new OleDbCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@1", lectID);
                    command.Parameters.AddWithValue("@2", pSlotDate);
                    command.Parameters.AddWithValue("@3", time);

                    connection.Open();

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows; // If any rows are returned, the timeslot already exists.
                    }
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            bool blnValidInput = true;
            DateTime slotDate = dtPicker.Value;
            blnValidInput = ValidateFormInput(blnValidInput);
            String Courseid = cmbCCode.SelectedItem as String;  

            if (blnValidInput == true)
            {
                //int lectID = Convert.ToInt32(cmbLectID.SelectedItem);
                string pSlotDate = slotDate.ToString("yyyy/MM/dd");
                String time = mtxtHH.Text + ":" + mtxtMM.Text;

               if (IsTimeslotAlreadyExists(LecturerID, pSlotDate, time))
                {
                    MessageBox.Show("This timeslot already exists. Please choose another time.");
                    return;
                }
               
               // string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Mbongeni\\Documents\\OMNIConnectSystemDB.accdb;";

                string insertQuery = "INSERT INTO Timeslots (Lecturer_ID, CalDate, ClockTime, Slot_Status, Course_ID) VALUES (@1,@2,@3,@4,@5)";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    using (OleDbCommand command = new OleDbCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@1", LecturerID);
                        command.Parameters.AddWithValue("@2", pSlotDate);
                        command.Parameters.AddWithValue("@3", time);
                        command.Parameters.AddWithValue("@4", "A");
                        command.Parameters.AddWithValue("@4", Courseid);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Timeslot successfully created");
                        }
                        else
                        {
                            MessageBox.Show("Unsuccessful attempt");
                        }
                    }
                }
            }
            Clear();
        }


        public void getCourseID() {
            OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");

            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT Course_ID FROM Courses WHERE Lecturer_ID = @LectID", conn);
            cmd.Parameters.AddWithValue("@LectID", LoginID.ID);
            OleDbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                string courseid = reader["Course_ID"].ToString();
                COURSE_ID = courseid;

                CourseIDs.Add(courseid);

            }
            reader.Close();
            conn.Close();
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            LecturerDashboard lecturerDashboard = new LecturerDashboard();
            this.Visible = false;
            lecturerDashboard.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mtxtMM_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void mtxtHH_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dtPicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblLectID_Click(object sender, EventArgs e)
        {

        }

        private void cmbCCode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
