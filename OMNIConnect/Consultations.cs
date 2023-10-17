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
    public partial class Consultations : Form
    {
        OleDbConnection conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\dkmat\Documents\OMNIConnectSystemDB.accdb");
        int id = LoginID.ID;
        List<string> CourseIDs = new List<string>();
        List<string> LecturerIDs = new List<string>();
        String CourseID = "";
        String LecturerID = "";
        String CourseNAME = "";
        String DellStatus = "";
        public Consultations()
        {
            InitializeComponent();
            GetUpcomingConsultations(dataGridView1);
           //refreshGrid();
        }



        public void GetPastConsultations() {

            try
            {

                conn.Open();
                DataTable dt = new DataTable();
                // Assuming you have a parameter named courseIDParam with the desired value.
                // Assuming you have parameters for both Course_ID and Slot_Status.
                OleDbCommand cmd = new OleDbCommand("SELECT Consultations.Consultation_ID,Consultations.Slot_ID, Courses.Course_Name, FORMAT(Timeslots.CalDate,'dd-mmmm-yyyy') AS [Calendar Date], FORMAT(Timeslots.ClockTime, 'hh:mm') AS [Time of Day] " +
                                      "FROM (Consultations " +
                                      "INNER JOIN Timeslots ON Consultations.Slot_ID = Timeslots.SlotID) " +
                                      "LEFT JOIN Courses ON Courses.Course_ID = Timeslots.Course_ID " +
                                      "WHERE Consultations.Student_ID = @courseIDParam AND Timeslots.Slot_Status = @slotStatusParam AND Timeslots.CalDate<DATE()", conn);

                cmd.Parameters.AddWithValue("@courseIDParam", LoginID.ID.ToString()); // Replace courseID with the actual value
                cmd.Parameters.AddWithValue("@slotStatusParam", "B"); // Replace slotStatus with the actual value


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

        public void GetUpcomingConsultations(DataGridView view)
        {

            try
            {

                conn.Open();
                DataTable dt = new DataTable();
                // Assuming you have a parameter named courseIDParam with the desired value.
                // Assuming you have parameters for both Course_ID and Slot_Status.
                OleDbCommand cmd = new OleDbCommand("SELECT Consultations.Consultation_ID,Consultations.Slot_ID, Courses.Course_Name, FORMAT(Timeslots.CalDate,'dd-mmmm-yyyy') AS [Calendar Date], FORMAT(Timeslots.ClockTime, 'hh:mm') AS [Time of Day] " +
                                      "FROM (Consultations " +
                                      "INNER JOIN Timeslots ON Consultations.Slot_ID = Timeslots.SlotID) " +
                                      "LEFT JOIN Courses ON Courses.Course_ID = Timeslots.Course_ID " +
                                      "WHERE Consultations.Student_ID = @courseIDParam AND Timeslots.Slot_Status = @slotStatusParam AND Timeslots.CalDate>DATE()", conn);

                cmd.Parameters.AddWithValue("@courseIDParam", LoginID.ID.ToString()); // Replace courseID with the actual value
                cmd.Parameters.AddWithValue("@slotStatusParam", "B"); // Replace slotStatus with the actual value


                OleDbDataAdapter da = new OleDbDataAdapter(cmd);




                da.Fill(dt);

                view.DataSource = dt;
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

            public void refreshGrid()
        {
            try
            {

                conn.Open();
                DataTable dt = new DataTable();
                // Assuming you have a parameter named courseIDParam with the desired value.
                // Assuming you have parameters for both Course_ID and Slot_Status.
                OleDbCommand cmd = new OleDbCommand("SELECT Consultations.Consultation_ID,Consultations.Slot_ID, Courses.Course_Name, FORMAT(Timeslots.CalDate,'dd-mmmm-yyyy') AS [Calendar Date], FORMAT(Timeslots.ClockTime, 'hh:mm') AS [Time of Day] " +
                                      "FROM (Consultations " +
                                      "INNER JOIN Timeslots ON Consultations.Slot_ID = Timeslots.SlotID) " +
                                      "LEFT JOIN Courses ON Courses.Course_ID = Timeslots.Course_ID " +
                                      "WHERE Consultations.Student_ID = @courseIDParam AND Timeslots.Slot_Status = @slotStatusParam ", conn);

                cmd.Parameters.AddWithValue("@courseIDParam", LoginID.ID.ToString()); // Replace courseID with the actual value
                cmd.Parameters.AddWithValue("@slotStatusParam", "B"); // Replace slotStatus with the actual value
                
              
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
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnALLCons_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            GetUpcomingConsultations(dgw);
        }

        private void btnPast_Click(object sender, EventArgs e)
        {
            GetPastConsultations();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lblDate.Text !="_ _ _") {
                DeleteConsultation();
                if (DellStatus=="success") {
                    UpdateSlot();
                    GetUpcomingConsultations(dataGridView1);
                    ClearLabels();
                }
            }
        }

        private void btnCloseW_Click(object sender, EventArgs e)
        {
            StudentDashboard studentDashboard = new StudentDashboard();
            this.Visible = false;
            studentDashboard.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            StudentDashboard studentDashboard = new StudentDashboard();
            this.Visible = false;
            studentDashboard.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DellStatus = "not";
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            string ConsID = row.Cells["Consultation_ID"].Value.ToString();
            string slotid = row.Cells["Slot_ID"].Value.ToString();
            string courseName = row.Cells["Course_Name"].Value.ToString();
            string date = row.Cells["Calendar Date"].Value.ToString();
            string time = row.Cells["Time of Day"].Value.ToString();

            lblConID.Text = ConsID;
            lblSlotID.Text = slotid;
            lblCourse.Text = courseName;
            getLecturerName(lblCourse.Text);
            lblDate.Text = date;
            lblTime.Text = time;


           // String SelectedCode = cmbCCode.SelectedItem as String;
            //String AttType = cmbAttendanceType.SelectedItem as String;
          //  /String SessionS = cmbSess.SelectedItem as String;


        }
        public void getLecturerName(String CourseName) {

           


        }
        public void UpdateSlot()
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("update Timeslots set Slot_Status = @1 where SlotID = @2", conn);
                cmd.Parameters.AddWithValue("@1", "A");

                cmd.Parameters.AddWithValue("@2", lblSlotID.Text);

                cmd.ExecuteNonQuery();
               // DellStatus = "success";
                conn.Close();
            }
            catch
            {
             //   DellStatus = "fail";
                MessageBox.Show("Error occured while updating timeslots!,Please contact Admin ASAP", "System ERROR :");
            }

        }


        public void DeleteConsultation() {
            try
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand("DELETE FROM Consultations where Consultation_ID = @1", conn);
              //  cmd.Parameters.AddWithValue("@1", "A");

                cmd.Parameters.AddWithValue("@1", lblSlotID.Text);

                cmd.ExecuteNonQuery();
                DellStatus = "success";
                conn.Close();
            }
            catch
            {
                DellStatus = "fail";
                MessageBox.Show("Error occured while updating timeslots!,Please contact Admin ASAP", "System ERROR :");
            }

        }

        public void ClearLabels() {
            lblDate.Text = "_ _ _";
            lblTime.Text = "_ _ _";
            lblConID.Text = "_ _ _";
            lblSlotID.Text = "_ _ _";
            lblCourse.Text = "_ _ _";

        }
    }
}
